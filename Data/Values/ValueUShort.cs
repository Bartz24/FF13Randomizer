using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public static class ValueUShort
    {
        public static ushort ReadUShort(this byte[] data, int index)
        {
            return BitConverter.ToUInt16(data.SubArray(index,2).ReverseArray(), 0);
        }

        public static void SetUShort(this byte[] data, int index, ushort value)
        {
            data.SetSubArray(index, BitConverter.GetBytes(value).ReverseArray());
        }
    }
}
