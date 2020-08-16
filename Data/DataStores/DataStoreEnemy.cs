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

        public uint ChainRes
        {
            get { return Data.ReadUInt(0x24); }
            set { Data.SetUInt(0x24, value); }
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
        public string CommonDropID { get; set; }
        public string RareDropID { get; set; }

        protected uint CommonDropPointer
        {
            get { return Data.ReadUInt(0xF0); }
            set { Data.SetUInt(0xF0, value); }
        }
        protected uint RareDropPointer
        {
            get { return Data.ReadUInt(0xF4); }
            set { Data.SetUInt(0xF4, value); }
        }

        public ushort Magic
        {
            get { return Data.ReadUShort(0x10C); }
            set { Data.SetUShort(0x10C, value); }
        }

        public ushort Strength
        {
            get { return Data.ReadUShort(0x10E); }
            set { Data.SetUShort(0x10E, value); }
        }

        public ushort StaggerPoint
        {
            get { return Data.ReadUShort(0x126); }
            set { Data.SetUShort(0x126, value); }
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

        public byte PhysicalRes
        {
            get { return Data.ReadByte(0x100); }
            set { Data.SetByte(0x100, value); }
        }

        public ElementalRes ElemRes1
        {
            get { return (ElementalRes)(Data.ReadByte(0x128) / 0x10); }
            set { Data.SetByte(0x128, (byte)(Data.ReadByte(0x128) % 0x10 + (byte)value * 0x10)); }
            //get { return Data.ReadByte(0x128); }
            //set { Data.SetByte(0x128, value); }
        }
        public ElementalRes MagicRes
        {
            get { return (ElementalRes)(Data.ReadByte(0x128) % 0x10); }
            set { Data.SetByte(0x128, (byte)((Data.ReadByte(0x128) / 0x10) * 0x10 + (byte)value)); }
        }

        public byte ElemRes2
        {
            get { return (byte)(Data.ReadByte(0x12D) % 0x10); }
            set { Data.SetByte(0x12D, (byte)((Data.ReadByte(0x12D) / 0x10) * 0x10 + value)); }
        }
        public byte ElemRes3
        {
            get { return Data.ReadByte(0x12E); }
            set { Data.SetByte(0x12E, value); }
        }
        public byte ElemRes4
        {
            get { return Data.ReadByte(0x12F); }
            set { Data.SetByte(0x12F, value); }
        }
        public byte[] DebuffRes
        {
            get { return Data.SubArray(0x130, 16); }
            set { Data.SetSubArray(0x130, value); }
        }

        public override int GetDefaultLength()
        {
            return 0x168;
        }

        public override void UpdateStringPointers(DataStorePointerList<DataStoreString> list)
        {
            if (CommonDropID != null)
            {
                DataStoreString value = new DataStoreString() { Value = CommonDropID };
                if (!list.Contains(value))
                    list.Add(value, list.Length);
                CommonDropPointer = (uint)list.IndexOf(value);
            }
            CommonDropID = list[(int)CommonDropPointer].Value;

            if (RareDropID != null)
            {
                DataStoreString value = new DataStoreString() { Value = RareDropID };
                if (!list.Contains(value))
                    list.Add(value, list.Length);
                RareDropPointer = (uint)list.IndexOf(value);
            }
            RareDropID = list[(int)RareDropPointer].Value;
        }
    }
}
