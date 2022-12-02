using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClassStringEditor.ClsFileHeader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClassStringEditor
{
    internal struct ClsStringItem
    {
        public int index;
        public string data;
    }
    internal class ClassStringEditor
    {
        private ClassFileParser parser;
        private Dictionary<int, string> modifyCache = new Dictionary<int, string>();
        public ClassStringEditor(ClassFileParser parser)
        {
            this.parser = parser;
        }
        public ClassStringEditor(string filePath)
        {
            this.parser = new ClassFileParser(filePath);
        }
        public ClassFileParser GetParser()
        {
            return parser;
        }
        public ClsStringItem[] GetStrings()
        {
            List<ClsStringItem> stringItems = new List<ClsStringItem>();
            var header = this.parser.GetFileHeader();
            if (header.constant_pool == null)
                return stringItems.ToArray();
            foreach (var constant in header.constant_pool)
            {
                if (constant == null)
                    continue;
                if (constant.tag == ConstTag.String)
                {
                    ClsConstString constStringInfo = (ClsConstString)constant;
                    ClsConstUtf8 utf8String = (ClsConstUtf8)header.constant_pool[constStringInfo.string_index];
                    ClsStringItem stringItem;
                    stringItem.data = Encoding.UTF8.GetString(utf8String.bytes);
                    stringItem.index = constStringInfo.string_index;
                    stringItems.Add(stringItem);
                }
            }
            return stringItems.ToArray();
        }
        public void Edit(int index, string newString)
        {
            var header = parser.GetFileHeader();
            if (header.constant_pool == null ||
                header.constant_pool.Length <= index ||
                index == 0)
                return;
            if (header.constant_pool[index] is not ClsConstUtf8)
                return;

            if (!modifyCache.TryAdd(index, newString))
                modifyCache[index] = newString;
        }
        public void Recover(int index)
        {
            if (modifyCache.TryGetValue(index, out _))
                modifyCache.Remove(index);
        }
        public string LookupEdit(int index)
        {
            return modifyCache.TryGetValue(index, out var item) ? item : "";
        }
        public void Save(bool close = false)
        {
            if (modifyCache.Count == 0)
                return;
            string path = parser.GetFilePath();
            string tmpPath = path + ".tmp";
            BinaryReader binaryReader = new BinaryReader(File.OpenRead(path));
            BinaryWriter binaryWriter = new BinaryWriter(File.OpenWrite(tmpPath));

            var constantPool = parser.GetFileHeader().constant_pool;
            if (constantPool == null)
                return;
            
            var orderDict = from item in modifyCache orderby modifyCache.Keys select item;
            foreach (var modifedItem in orderDict)
            {
                ClsConstInfo stringInfo = constantPool[modifedItem.Key];
                byte[] prevBytes = binaryReader.ReadBytes((int)(stringInfo.offset - binaryReader.BaseStream.Position));
                byte[] newStringBytes = Encoding.UTF8.GetBytes(modifedItem.Value);
                binaryWriter.Write(prevBytes);
                binaryWriter.Write((byte)ConstTag.Utf8);
                binaryWriter.Write(NetConvert.FromUInt16((ushort)newStringBytes.Length));
                binaryWriter.Write(newStringBytes);
                binaryReader.BaseStream.Seek(stringInfo.size + 1, SeekOrigin.Current);
            }
            binaryWriter.Write(binaryReader.ReadBytes((int)(binaryReader.BaseStream.Length - binaryReader.BaseStream.Position)));
            binaryReader.Close();
            binaryWriter.Close();
            parser.Close();
            File.Move(tmpPath, path, true);
            if (!close)
                parser.Load(path);
        }
        public void Close()
        {
            parser.Close();
        }
    }
}
