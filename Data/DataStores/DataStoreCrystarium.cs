using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreCrystarium : DataStore
    {

        public uint CPCost
        {
            get { return Data.ReadUInt(0x0); }
            set { Data.SetUInt(0x0, value); }
        }

        public string AbilityName { get; set; }

        protected uint AbilityPointer
        {
            get { return Data.ReadUInt(0x4); }
            set { Data.SetUInt(0x4, value); }
        }

        public ushort Value
        {
            get { return Data.ReadUShort(0x8); }
            set { Data.SetUShort(0x8, value); }
        }

        public CrystariumType Type
        {
            get { return (CrystariumType)Data.ReadByte(0xA); }
            set { Data.SetByte(0xA, (byte)value); }
        }

        public byte Stage
        {
            get { return (byte)(Data.ReadByte(0xB) / 0x10); }
            set { Data.SetByte(0xB, (byte)(value * 0x10 + (byte)Role)); }
        }

        public Role Role
        {
            get { return (Role)(Data.ReadByte(0xB) % 0x10); }
            set { Data.SetByte(0xB, (byte)(Stage * 0x10 + (byte)value)); }
        }

        public override int GetDefaultLength()
        {
            return 0xC;
        }

        public void SwapStats(DataStoreCrystarium other)
        {
            CrystariumType type = other.Type;
            ushort value = other.Value;
            other.Type = this.Type;
            other.Value = this.Value;
            this.Type = type;
            this.Value = value;
        }

        public void SwapStatsAbilities(DataStoreCrystarium other)
        {
            SwapStats(other);
            uint pointer = other.AbilityPointer;
            other.AbilityPointer = this.AbilityPointer;
            this.AbilityPointer = pointer;

            string abilityName = other.AbilityName;
            other.AbilityName = this.AbilityName;
            this.AbilityName = abilityName;
        }

        public override void UpdateStringPointers(DataStorePointerList<DataStoreString> list)
        {
            if (Type == CrystariumType.Ability)
            {
                if (AbilityName != null)
                {
                    DataStoreString value = new DataStoreString() { Value = AbilityName };
                    if (!list.Contains(value))
                        list.Add(value, list.Length);
                    AbilityPointer = (uint)list.IndexOf(value);
                }
                AbilityName = list[(int)AbilityPointer].Value;
            }
        }
    }
}
