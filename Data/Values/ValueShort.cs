using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public static class ValueShort
    {
        public static short ReadShort(this byte[] data, int index)
        {
            return BitConverter.ToInt16(data.SubArray(index, 2).ReverseArray(), 0);
        }

        public static void SetShort(this byte[] data, int index, short value)
        {
            data.SetSubArray(index, BitConverter.GetBytes(value).ReverseArray());
        }
    }
}
