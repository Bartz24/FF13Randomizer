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

        public byte PhysicalRes
        {
            get { return Data.ReadByte(0x100); }
            set { Data.SetByte(0x100, value); }
        }

        public byte ElemRes1
        {
            //get { return (byte)(Data.ReadByte(0x128) / 0x10); }
            //set { Data.SetByte(0x128, (byte)(Data.ReadByte(0x128) % 0x10 + value * 0x10)); }
            get { return Data.ReadByte(0x128); }
            set { Data.SetByte(0x128, value); }
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
            get { return Data.SubArray(0x130, 16).Data; }
            set { Data.SetSubArray(0x130, value); }
        }

        public override int GetSize()
        {
            return 0x168;
        }
    }
}
