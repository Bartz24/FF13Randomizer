using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreEquip : DataStore
    {
        public ushort NameID
        {
            get { return Data.ReadUShort(0x02); }
            set { Data.SetUShort(0x02, value); }
        }

        public ushort Cost
        {
            get { return Data.ReadUShort(0x12); }
            set { Data.SetUShort(0x12, value); }
        }

        public byte Defense
        {
            get { return Data.ReadByte(0x18); }
            set { Data.SetByte(0x18, value); }
        }

        public byte MagicResistence
        {
            get { return Data.ReadByte(0x19); }
            set { Data.SetByte(0x19, value); }
        }

        public byte Power
        {
            get { return Data.ReadByte(0x1A); }
            set { Data.SetByte(0x1A, value); }
        }

        public byte Knockback
        {
            get { return Data.ReadByte(0x1B); }
            set { Data.SetByte(0x1B, value); }
        }

        public byte ComboChance
        {
            get { return Data.ReadByte(0x1C); }
            set { Data.SetByte(0x1C, value); }
        }

        public byte Evasion
        {
            get { return Data.ReadByte(0x1D); }
            set { Data.SetByte(0x1D, value); }
        }

        public byte HitChance
        {
            get { return Data.ReadByte(0x1F); }
            set { Data.SetByte(0x1F, value); }
        }

        public Status StatusEffect
        {
            get { return (Status)Data.ReadUInt(0x20); }
            set { Data.SetUInt(0x20, (uint)value); }
        }

        public byte ChargeTime
        {
            get { return Data.ReadByte(0x27); }
            set { Data.SetByte(0x27, value); }
        }

        public override int GetSize()
        {
            return 52;
        }
    }
}
