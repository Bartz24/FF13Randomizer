using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreTreasure : DataStore
    {
        public uint StartingPointer
        {
            get { return Data.ReadUInt(0x0); }
            set { Data.SetUInt(0x0, value); }
        }

        public uint Count
        {
            get { return Data.ReadUInt(0x4); }
            set { Data.SetUInt(0x4, value); }
        }

        public uint EndingPointer
        {
            get { return Data.ReadUInt(0x8); }
            set { Data.SetUInt(0x8, value); }
        }

        public override int GetSize()
        {
            return 0xC;
        }
    }
}
