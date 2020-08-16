using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreID : DataStore
    {
        public string ID
        {
            get => Encoding.UTF8.GetString(Data.SubArray(0, 0x10)).Replace("\0","");
            set
            {
                byte[] bytes = Encoding.UTF8.GetBytes(value.ToCharArray(), 0, 0x10);
                byte[] empty = new byte[0x10 - bytes.Length];
                for (int i = 0; i < empty.Length; i++)
                    empty[i] = 0;
                Data.SetSubArray(0, bytes.Concat(empty));
            }
        }

        public int Offset
        {
            get => (int)Data.ReadUInt(0x10);
            set => Data.SetUInt(0x10, (uint)value);
        }

        public int DataSize
        {
            get => (int)Data.ReadUInt(0x14);
            set => Data.SetUInt(0x14, (uint)value);
        }

        public override int GetDefaultLength()
        {
            return 0x20;
        }
    }
}
