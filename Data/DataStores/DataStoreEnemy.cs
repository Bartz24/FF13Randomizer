using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreEnemy : DataStore
    {
        public uint HP
        {
            get { return Data.ReadUInt(0x10); }
            set { Data.SetUInt(0x10, value); }
        }
        public uint CP
        {
            get { return Data.ReadUInt(0xEC); }
            set { Data.SetUInt(0xEC, value); }
        }
        public byte Level
        {
            get { return Data.ReadByte(0xFE); }
            set { Data.SetByte(0xFE, value); }
        }
        public uint CommonDropPointer
        {
            get { return Data.ReadUInt(0xF0); }
            set { Data.SetUInt(0xF0, value); }
        }
        public uint RareDropPointer
        {
            get { return Data.ReadUInt(0xF4); }
            set { Data.SetUInt(0xF4, value); }
        }

        public ushort CommonDropChance
        {
            get { return Data.ReadUShort(0x160); }
            set { Data.SetUShort(0x160, value); }
        }

        public ushort RareDropChance
        {
            get { return Data.ReadUShort(0x162); }
            set { Data.SetUShort(0x162, value); }
        }

        public override int GetSize()
        {
            return 0x168;
        }
    }
}
