using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreEquip : DataStore
    {
        public string Model { get; set; }

        protected uint ModelName
        {
            get { return Data.ReadUInt(0x0); }
            set { Data.SetUInt(0x0, value); }
        }
        public string Model2 { get; set; }

        protected uint Model2Pointer
        {
            get { return Data.ReadUInt(0x4); }
            set { Data.SetUInt(0x4, value); }
        }
        public string Passive { get; set; }

        protected uint PassivePointer
        {
            get { return Data.ReadUInt(0x8); }
            set { Data.SetUInt(0x8, value); }
        }
        public string PassiveDisplayName { get; set; }

        protected uint PassiveDisplayNamePointer
        {
            get { return Data.ReadUInt(0xC); }
            set { Data.SetUInt(0xC, value); }
        }
        public string String5 { get; set; }

        protected uint String5Pointer
        {
            get { return Data.ReadUInt(0x10); }
            set { Data.SetUInt(0x10, value); }
        }

        public string UpgradeInto { get; set; }

        protected uint UpgradeIntoPointer
        {
            get { return Data.ReadUInt(0x14); }
            set { Data.SetUInt(0x14, value); }
        }
        public string HelpDisplay { get; set; }

        protected uint HelpDisplayPointer
        {
            get { return Data.ReadUInt(0x18); }
            set { Data.SetUInt(0x18, value); }
        }

        public uint BuyPriceIncrease
        {
            get { return Data.ReadUInt(0x1C); }
            set { Data.SetUInt(0x1C, value); }
        }

        public uint SellPriceIncrease
        {
            get { return Data.ReadUInt(0x20); }
            set { Data.SetUInt(0x20, value); }
        }

        public string Dismantle1 { get; set; }

        protected uint Dismantle1Pointer
        {
            get { return Data.ReadUInt(0x24); }
            set { Data.SetUInt(0x24, value); }
        }
        public string Dismantle2 { get; set; }

        protected uint Dismantle2Pointer
        {
            get { return Data.ReadUInt(0x28); }
            set { Data.SetUInt(0x28, value); }
        }

        public string Dismantle3 { get; set; }

        protected uint Dismantle3Pointer
        {
            get { return Data.ReadUInt(0x2C); }
            set { Data.SetUInt(0x2C, value); }
        }

        public string Dismantle4 { get; set; }

        protected uint Dismantle4Pointer
        {
            get { return Data.ReadUInt(0x30); }
            set { Data.SetUInt(0x30, value); }
        }

        public string Dismantle5 { get; set; }

        protected uint Dismantle5Pointer
        {
            get { return Data.ReadUInt(0x34); }
            set { Data.SetUInt(0x34, value); }
        }

        public byte MaxLevel
        {
            get { return (byte)((Data.ReadByte(0x38) % 0x10 - 2) * 64 + Data.ReadByte(0x39) / 4); }
            set
            {
                Data.SetByte(0x38, (byte)(Data.ReadByte(0x38) / 0x10 * 0x10 + (byte)value / 64 + 2));
                Data.SetByte(0x39, (byte)(value % 64 * 4));
            }
        }
        public ushort ExpValue1
        {
            get { return Data.ReadUShort(0x3E); }
            set { Data.SetUShort(0x3E, value); }
        }
        public byte StatType1
        {
            get { return Data.ReadNibbleRight(0x41); }
            set { Data.SetNibbleRight(0x41, value); }
        }
        public ushort StatType2
        {
            get { return Data.ReadUShort(0x42); }
            set { Data.SetUShort(0x42, value); }
        }
        public ushort StatIncrease
        {
            get { return Data.ReadUShort(0x44); }
            set { Data.SetUShort(0x44, value); }
        }
        public short StatInitial
        {
            get { return Data.ReadShort(0x46); }
            set { Data.SetShort(0x46, value); }
        }
        public ushort StrengthIncrease
        {
            get { return Data.ReadUShort(0x48); }
            set { Data.SetUShort(0x48, value); }
        }
        public short StrengthInitial
        {
            get { return Data.ReadShort(0x4A); }
            set { Data.SetShort(0x4A, value); }
        }
        public ushort MagicIncrease
        {
            get { return Data.ReadUShort(0x4C); }
            set { Data.SetUShort(0x4C, value); }
        }
        public short MagicInitial
        {
            get { return Data.ReadShort(0x4E); }
            set { Data.SetShort(0x4E, value); }
        }

        public override int GetDefaultLength()
        {
            return 0x68;
        }
        public override void UpdateStringPointers(DataStorePointerList<DataStoreString> list)
        {
            UpdateStringPointer(list, Model, ModelName, v => Model = v, v => ModelName = v);
            UpdateStringPointer(list, Model2, Model2Pointer, v => Model2 = v, v => Model2Pointer = v);
            UpdateStringPointer(list, Passive, PassivePointer, v => Passive = v, v => PassivePointer = v);
            UpdateStringPointer(list, PassiveDisplayName, PassiveDisplayNamePointer, v => PassiveDisplayName = v, v => PassiveDisplayNamePointer = v);
            UpdateStringPointer(list, String5, String5Pointer, v => String5 = v, v => String5Pointer = v);
            UpdateStringPointer(list, UpgradeInto, UpgradeIntoPointer, v => UpgradeInto = v, v => UpgradeIntoPointer = v);
            UpdateStringPointer(list, HelpDisplay, HelpDisplayPointer, v => HelpDisplay = v, v => HelpDisplayPointer = v);
            UpdateStringPointer(list, Dismantle1, Dismantle1Pointer, v => Dismantle1 = v, v => Dismantle1Pointer = v);
            UpdateStringPointer(list, Dismantle2, Dismantle2Pointer, v => Dismantle2 = v, v => Dismantle2Pointer = v);
            UpdateStringPointer(list, Dismantle3, Dismantle3Pointer, v => Dismantle3 = v, v => Dismantle3Pointer = v);
            UpdateStringPointer(list, Dismantle4, Dismantle4Pointer, v => Dismantle4 = v, v => Dismantle4Pointer = v);
            UpdateStringPointer(list, Dismantle5, Dismantle5Pointer, v => Dismantle5 = v, v => Dismantle5Pointer = v);
        }
    }
}
