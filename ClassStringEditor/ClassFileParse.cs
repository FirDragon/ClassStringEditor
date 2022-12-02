using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static ClassStringEditor.ClsFileHeader;

namespace ClassStringEditor
{

    [Serializable]
    public class ParseException : Exception
    {
        public ParseException() { }
        public ParseException(string message) : base(message) { }
        public ParseException(string message, Exception inner) : base(message, inner) { }
        protected ParseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    internal class ClassFileParser
    {
        private string filePath = "";
        private BinaryReader? fileReader;
        private ClsFileHeader header = new ClsFileHeader();
        public ClassFileParser(string fileName)
        {
            Load(fileName);
        }

        public void Load(string fileName)
        {
            Close();
            fileReader = new BinaryReader(File.OpenRead(fileName));
            filePath = fileName;
            if (!ReadHeader())
                throw new ParseException("Cannot paser file!");
            LoadConst();
        }
        public void Close()
        {
            if (fileReader != null)
                fileReader.Close();
            header = new ClsFileHeader();
        }
        private bool ReadHeader()
        {
            fileReader.BaseStream.Seek(0, SeekOrigin.Begin);
            header.magic = NetConvert.FromUInt32(fileReader.ReadUInt32());
            header.minor_version = NetConvert.FromUInt16(fileReader.ReadUInt16());
            header.major_version = NetConvert.FromUInt16(fileReader.ReadUInt16());
            return header.magic == 0xCAFEBABE;
        }
        private bool LoadConst()
        {
            ushort count = NetConvert.FromUInt16(fileReader.ReadUInt16());
            header.constant_pool_count = count;
            if (count == 0)
                return false;

            header.constant_pool = new ClsConstInfo[count - 1];
            for (int i = 1; i < count - 1; i++)
            {
                ConstTag tag = (ConstTag)fileReader.ReadByte();
                if (tag == ConstTag.None)
                {
                    fileReader.BaseStream.Seek(-1, SeekOrigin.Current);
                    break;
                }
                ClsConstInfo? constInfo = null;
                UInt16 size;
                switch (tag)
                {
                    case ConstTag.Class:
                        size = ClsConstClass.StructSize;
                        break;
                    case ConstTag.Fieldref:
                        size = ClsConstRef.StructSize;
                        break;
                    case ConstTag.Methodref:
                        size = ClsConstRef.StructSize;
                        break;
                    case ConstTag.InterfaceMethodref:
                        size = ClsConstRef.StructSize;
                        break;
                    case ConstTag.String:
                        size = ClsFileHeader.ClsConstString.StructSize;
                        ClsFileHeader.ClsConstString constString = new ClsFileHeader.ClsConstString();
                        constString.string_index = NetConvert.FromUInt16(fileReader.ReadUInt16());
                        constInfo = constString;
                        break;
                    case ConstTag.Integer:
                        size = ClsConstByte4.StructSize;
                        break;
                    case ConstTag.Float:
                        size = ClsConstByte4.StructSize;
                        break;
                    case ConstTag.Long:
                        size = ClsConstByte8.StructSize;
                        break;
                    case ConstTag.Double:
                        size = ClsConstByte8.StructSize;
                        break;
                    case ConstTag.NameAndType:
                        size = ClsConstNameAndType.StructSize;
                        break;
                    case ConstTag.Utf8:
                        constInfo = LoadConstUtf8();
                        size = constInfo.size;
                        break;
                    case ConstTag.MethodHandle:
                        size = ClsConstMethodHandle.StructSize;
                        break;
                    case ConstTag.MethodType:
                        size = ClsConstMethodType.StructSize;
                        break;
                    case ConstTag.InvokeDynamic:
                        size = ClsConstInvokeDynamic.StructSize;
                        break;
                    default:
                        return false;
                }
                if (constInfo != null)
                {
                    constInfo.offset = (uint)fileReader.BaseStream.Position - size - 1;
                    constInfo.size = size;
                    constInfo.tag = tag;
                    header.constant_pool[i] = constInfo;
                }
                else
                {
                    fileReader.BaseStream.Seek(size, SeekOrigin.Current);
                }
                if (tag == ConstTag.Long || tag == ConstTag.Double)
                    ++i;
            }
            return true;
        }
        private ClsConstUtf8 LoadConstUtf8()
        {
            ClsConstUtf8 constUtf8 = new ClsConstUtf8();
            constUtf8.length = NetConvert.FromUInt16(fileReader.ReadUInt16());
            constUtf8.bytes = fileReader.ReadBytes(constUtf8.length);
            constUtf8.size = (ushort)(constUtf8.length + 2);
            return constUtf8;
        }
        public ClsFileHeader GetFileHeader()
        {
            return header;
        }
        public string GetFilePath()
        {
            return filePath;
        }
    }
}
