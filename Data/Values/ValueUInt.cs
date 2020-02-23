using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public static class ValueUInt
    {
        public static uint ReadUInt(this ByteArray data, int index)
        {
            return BitConverter.ToUInt32(data.Data.SubArray(index,4).ReverseArray(), 0);
        }

        public static void SetUInt(this ByteArray data, int index, uint value)
        {
            data.SetSubArray(index, BitConverter.GetBytes(value).ReverseArray());
        }
    }
}
