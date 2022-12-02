using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStringEditor
{

    internal class ClsFileHeader
    {
        public enum ConstTag
        {
            None = 0,
            Class = 7,
            Fieldref = 9,
            Methodref = 10,
            InterfaceMethodref = 11,
            String = 8,
            Integer = 3,
            Float = 4,
            Long = 5,
            Double = 6,
            NameAndType = 12,
            Utf8 = 1,
            MethodHandle = 15,
            MethodType = 16,
            InvokeDynamic = 18,
        }
        internal class ClsConstInfo
        {
            public ConstTag tag;
            public UInt32 offset;
            public UInt16 size;
        }
        internal class ClsConstClass : ClsConstInfo
        {
            public const ushort StructSize = 2;
            public UInt16 name_index;
        }

        internal class ClsConstRef : ClsConstInfo
        {
            public const ushort StructSize = 4;
            public UInt16 class_index;
            public UInt16 name_and_type_index;
        }
        internal class ClsConstString : ClsConstInfo
        {
            public const ushort StructSize = 2;
            public UInt16 string_index;
        }
        internal class ClsConstByte4 : ClsConstInfo
        {
            public const ushort StructSize = 4;
            public UInt32 value;
        }
        internal class ClsConstByte8 : ClsConstInfo
        {
            public const ushort StructSize = 8;
            public UInt32 valueHigh;
            public UInt32 valueLow;
        }
        internal class ClsConstNameAndType : ClsConstInfo
        {
            public const ushort StructSize = 4;
            public UInt16 name_index;
            public UInt16 descriptor_index;
        }
        internal class ClsConstUtf8 : ClsConstInfo
        {
            public const ushort StructSize = 2;
            public UInt16 length;
            public byte[] bytes;
        }
        internal class ClsConstMethodHandle : ClsConstInfo
        {
            public const ushort StructSize = 1 + 2;
            public byte reference_kind;
            public UInt16 reference_index;
        }
        internal class ClsConstMethodType : ClsConstInfo
        {
            public const ushort StructSize = 2;
            public UInt16 descriptor_index;
        }
        internal class ClsConstInvokeDynamic : ClsConstInfo
        {
            public const ushort StructSize = 2 + 2;
            public UInt16 bootstrap_method_attr_index;
            public UInt16 name_and_type_index;
        }
        public UInt32 magic;
        public UInt16 minor_version;
        public UInt16 major_version;
        public UInt16 constant_pool_count;
        public ClsConstInfo[]? constant_pool;
        public UInt16 access_flags;
        public UInt16 this_class;
        public UInt16 super_class;
        public UInt16 interfaces_count;
        public UInt16[]? interfaces;
        public UInt16 fields_count;
        // Not impl
        // public ClsFieldInfo[] fields;
        // public UInt16 methods_count;
        // public ClsMethodInfo[] methods;
        // public UInt16 attributes_count;
        // public ClsAttributeInfo[] attributes;
    }
}
