using Bartz24.Data;
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

        public ElementalRes PhysicalRes
        {
            get { return Enemy.PhysMapping[Data.ReadByte(0x100)]; }
            set { Data.SetByte(0x100, Enemy.PhysMapping.Where(p => p.Value == value).First().Key); }
        }

        public ElementalRes FireRes
        {
            get { return fromByte(Data.ReadByte(0x128) / 0x10); }
            set { Data.SetByte(0x128, (byte)(Data.ReadByte(0x128) % 0x10 + fromElemRes(value) * 0x10)); }
        }
        public ElementalRes MagicRes
        {
            get { return fromByte(Data.ReadByte(0x128) % 0x10); }
            set { Data.SetByte(0x128, (byte)(Data.ReadByte(0x128) / 0x10 * 0x10 + fromElemRes(value))); }
        }
        public ElementalRes EarthRes
        {
            get { return fromByte(Data.ReadByte(0x12D) % 0x10); }
            set { Data.SetByte(0x12D, (byte)(Data.ReadByte(0x12D) / 0x10 * 0x10 + fromElemRes(value))); }
        }
        public ElementalRes WindRes
        {
            get { return fromByte(Data.ReadByte(0x12E) / 0x10); }
            set { Data.SetByte(0x12E, (byte)(Data.ReadByte(0x12E) % 0x10 + fromElemRes(value) * 0x10)); }
        }
        public ElementalRes WaterRes
        {
            get { return fromByte(Data.ReadByte(0x12E) % 0x10); }
            set { Data.SetByte(0x12E, (byte)(Data.ReadByte(0x12E) / 0x10 * 0x10 + fromElemRes(value))); }
        }
        public ElementalRes ThunderRes
        {
            get { return fromByte(Data.ReadByte(0x12F) / 0x10); }
            set { Data.SetByte(0x12F, (byte)(Data.ReadByte(0x12F) % 0x10 + fromElemRes(value) * 0x10)); }
        }
        public ElementalRes IceRes
        {
            get { return fromByte(Data.ReadByte(0x12F) % 0x10); }
            set { Data.SetByte(0x12F, (byte)(Data.ReadByte(0x12F) / 0x10 * 0x10 + fromElemRes(value))); }
        }

        private ElementalRes fromByte(int val)
        {
            if (val == 0)
                return ElementalRes.Normal;
            if (val == 1)
                return ElementalRes.Weakness;
            return (ElementalRes)val;
        }

        private byte fromElemRes(ElementalRes res)
        {
            if (res == ElementalRes.Weakness)
                return 1;
            if (res == ElementalRes.Normal)
                return 0;
            return (byte)res;
        }

        public byte FogRes
        {
            get { return (byte)(Data.ReadByte(0x12D) / 0x10 + Data.ReadByte(0x12C) % 0x10 * 0x10); }
            set
            {
                Data.SetByte(0x12C, (byte)(Data.ReadByte(0x12C) / 0x10 * 0x10 + (byte)value / 0x10));
                Data.SetByte(0x12D, (byte)(Data.ReadByte(0x12D) % 0x10 + (byte)value % 0x10 * 0x10));
            }
        }
        public byte CurseRes
        {
            get { return Data.ReadByte(0x130); }
            set { Data.SetByte(0x130, value); }
        }
        public byte PainRes
        {
            get { return Data.ReadByte(0x131); }
            set { Data.SetByte(0x131, value); }
        }
        public byte ImperilRes
        {
            get { return Data.ReadByte(0x132); }
            set { Data.SetByte(0x132, value); }
        }
        public byte SlowRes
        {
            get { return Data.ReadByte(0x133); }
            set { Data.SetByte(0x133, value); }
        }
        public byte DeprotectRes
        {
            get { return Data.ReadByte(0x134); }
            set { Data.SetByte(0x134, value); }
        }
        public byte PoisonRes
        {
            get { return Data.ReadByte(0x136); }
            set { Data.SetByte(0x136, value); }
        }
        public byte DazeRes
        {
            get { return Data.ReadByte(0x137); }
            set { Data.SetByte(0x137, value); }
        }
        public byte ProvokeRes
        {
            get { return Data.ReadByte(0x138); }
            set { Data.SetByte(0x138, value); }
        }
        public byte DeshellRes
        {
            get { return Data.ReadByte(0x13B); }
            set { Data.SetByte(0x13B, value); }
        }
        public byte DeathRes
        {
            get { return Data.ReadByte(0x13C); }
            set { Data.SetByte(0x13C, value); }
        }
        public byte DefaithRes
        {
            get { return Data.ReadByte(0x13E); }
            set { Data.SetByte(0x13E, value); }
        }
        public byte DebraveRes
        {
            get { return Data.ReadByte(0x13F); }
            set { Data.SetByte(0x13F, value); }
        }
        public byte DispelRes
        {
            get { return Data.ReadByte(0x140); }
            set { Data.SetByte(0x140, value); }
        }
        #region Unknown/Unused?
        /*
        public byte DebuffRes6
        {
            get { return Data.ReadByte(0x135); }
            set { Data.SetByte(0x135, value); }
        }
        public byte DebuffRes10
        {
            get { return Data.ReadByte(0x139); }
            set { Data.SetByte(0x139, value); }
        }
        public byte DebuffRes11
        {
            get { return Data.ReadByte(0x13A); }
            set { Data.SetByte(0x13A, value); }
        }
        public byte DebuffRes14
        {
            get { return Data.ReadByte(0x13D); }
            set { Data.SetByte(0x13D, value); }
        }
        public byte DebuffRes18
        {
            get { return Data.ReadByte(0x141); }
            set { Data.SetByte(0x141, value); }
        }
        public byte DebuffRes19
        {
            get { return Data.ReadByte(0x142); }
            set { Data.SetByte(0x142, value); }
        }
        public byte DebuffRes20
        {
            get { return Data.ReadByte(0x143); }
            set { Data.SetByte(0x143, value); }
        }
        */
        #endregion
        public ElementalRes this[Element e]
        {
            get
            {
                switch (e)
                {
                    case Element.Fire:
                        return FireRes;
                    case Element.Ice:
                        return IceRes;
                    case Element.Thunder:
                        return ThunderRes;
                    case Element.Water:
                        return WaterRes;
                    case Element.Wind:
                        return WindRes;
                    case Element.Earth:
                        return EarthRes;
                    case Element.Physical:
                        return PhysicalRes;
                    case Element.Magical:
                        return MagicRes;
                    default:
                        return ElementalRes.Normal;
                }
            }
            set
            {
                switch (e)
                {
                    case Element.Fire:
                        FireRes = value;
                        break;
                    case Element.Ice:
                        IceRes = value;
                        break;
                    case Element.Thunder:
                        ThunderRes = value;
                        break;
                    case Element.Water:
                        WaterRes = value;
                        break;
                    case Element.Wind:
                        WindRes = value;
                        break;
                    case Element.Earth:
                        EarthRes = value;
                        break;
                    case Element.Physical:
                        PhysicalRes = value;
                        break;
                    case Element.Magical:
                        MagicRes = value;
                        break;
                }
            }
        }

        public byte this[Debuff d]
        {
            get
            {
                switch (d)
                {
                    case Debuff.Deprotect:
                        return DeprotectRes;
                    case Debuff.Deshell:
                        return DeshellRes;
                    case Debuff.Poison:
                        return PoisonRes;
                    case Debuff.Imperil:
                        return ImperilRes;
                    case Debuff.Slow:
                        return SlowRes;
                    case Debuff.Fog:
                        return FogRes;
                    case Debuff.Pain:
                        return PainRes;
                    case Debuff.Curse:
                        return CurseRes;
                    case Debuff.Daze:
                        return DazeRes;
                    //case Debuff.Provoke:
                    //    return ProvokeRes;
                    case Debuff.Death:
                        return DeathRes;
                    case Debuff.Dispel:
                        return DispelRes;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (d)
                {
                    case Debuff.Deprotect:
                        DeprotectRes = value;
                        break;
                    case Debuff.Deshell:
                        DeshellRes = value;
                        break;
                    case Debuff.Poison:
                        PoisonRes = value;
                        break;
                    case Debuff.Imperil:
                        ImperilRes = value;
                        break;
                    case Debuff.Slow:
                        SlowRes = value;
                        break;
                    case Debuff.Fog:
                        FogRes = value;
                        break;
                    case Debuff.Pain:
                        PainRes = value;
                        break;
                    case Debuff.Curse:
                        CurseRes = value;
                        break;
                    case Debuff.Daze:
                        DazeRes = value;
                        break;
                    //case Debuff.Provoke:
                    //    ProvokeRes = value;
                    //    break;
                    case Debuff.Death:
                        DeathRes = value;
                        break;
                    case Debuff.Dispel:
                        DispelRes = value;
                        break;
                }
            }
        }

        public override int GetDefaultLength()
        {
            return 0x168;
        }

        public override void UpdateStringPointers(DataStorePointerList<DataStoreString> list)
        {
            UpdateStringPointer(list, CommonDropID, CommonDropPointer, v => CommonDropID = v, v => CommonDropPointer = v);
            UpdateStringPointer(list, RareDropID, RareDropPointer, v => RareDropID = v, v => RareDropPointer = v);
        }
    }
}
