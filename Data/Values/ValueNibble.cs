using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public static class ValueNibble
    {
        public static byte ReadNibbleLeft(this byte[] data, int index)
        {
            return (byte)(data.ReadByte(index) / 0x10);
        }
        public static byte ReadNibbleRight(this byte[] data, int index)
        {
            return (byte)(data.ReadByte(index) % 0x10);
        }

        public static void SetNibbleLeft(this byte[] data, int index, byte value)
        {
            data.SetByte(index, (byte)(data.ReadNibbleRight(index) + 0x10 * value));
        }

        public static void SetNibbleRight(this byte[] data, int index, byte value)
        {
            data.SetByte(index, (byte)(data.ReadNibbleLeft(index) * 0x10 + value));
        }
    }
}
