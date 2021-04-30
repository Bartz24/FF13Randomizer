using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreItem : DataStore
    {
        public uint BuyPrice
        {
            get { return Data.ReadUInt(0xC); }
            set { Data.SetUInt(0xC, value); }
        }
        public uint SellPrice
        {
            get { return Data.ReadUInt(0x10); }
            set { Data.SetUInt(0x10, value); }
        }
        public byte SynthesisGroup
        {
            get { return Data.ReadByte(0x18); }
            set { Data.SetByte(0x18, value); }
        }

        public byte Rank
        {
            get { return Data.ReadNibbleLeft(0x19); }
            set { Data.SetNibbleLeft(0x19, value); }
        }

        public override int GetDefaultLength()
        {
            return 0x24;
        }
    }
}
