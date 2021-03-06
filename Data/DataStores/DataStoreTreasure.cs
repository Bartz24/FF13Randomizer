﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreTreasure : DataStore
    {
        public string ItemID { get; set; }

        protected uint StartingPointer
        {
            get { return Data.ReadUInt(0x0); }
            set { Data.SetUInt(0x0, value); }
        }

        public uint Count
        {
            get { return Data.ReadUInt(0x4); }
            set { Data.SetUInt(0x4, value); }
        }

        protected uint EndingPointer
        {
            get { return Data.ReadUInt(0x8); }
            set { Data.SetUInt(0x8, value); }
        }

        public override int GetDefaultLength()
        {
            return 0xC;
        }

        public override void UpdateStringPointers(DataStorePointerList<DataStoreString> list)
        {
            if (ItemID != null)
            {
                DataStoreString value = new DataStoreString() { Value = ItemID };
                if (!list.Contains(value))
                    list.Add(value, list.Length);
                StartingPointer = (uint)list.IndexOf(value);
                EndingPointer = (uint)(StartingPointer + value.Value.Length);
            }
            ItemID = list[(int)StartingPointer].Value;
        }
    }
}
