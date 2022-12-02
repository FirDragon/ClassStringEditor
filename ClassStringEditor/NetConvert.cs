using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStringEditor
{
    internal static class NetConvert
    {
        public static byte[] FromBytes(byte[] bytes)
        {
            return bytes;
        }
        public static UInt16 FromUInt16(UInt16 data)
        {
            return BitConverter.ToUInt16(BitConverter.GetBytes(data).Reverse().ToArray(), 0);
        }
        public static UInt32 FromUInt32(UInt32 data)
        {
            return BitConverter.ToUInt32(BitConverter.GetBytes(data).Reverse().ToArray(), 0);
        }
        public static UInt64 FromUInt64(UInt64 data)
        {
            return BitConverter.ToUInt64(BitConverter.GetBytes(data).Reverse().ToArray(), 0);
        }
    }
}
