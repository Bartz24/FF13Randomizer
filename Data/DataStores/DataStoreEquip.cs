using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreEquip : DataStore
    {
        public string UpgradeInto { get; set; }

        protected uint UpgradeIntoPointer
        {
            get { return Data.ReadUInt(0x14); }
            set { Data.SetUInt(0x14, value); }
        }

        public override int GetDefaultLength()
        {
            return 0x68;
        }
        public override void UpdateStringPointers(DataStorePointerList<DataStoreString> list)
        {
            if (UpgradeInto != null)
            {
                DataStoreString value = new DataStoreString() { Value = UpgradeInto };
                if (!list.Contains(value))
                    list.Add(value, list.Length);
                UpgradeIntoPointer = (uint)list.IndexOf(value);
            }
            UpgradeInto = list[(int)UpgradeIntoPointer].Value;
        }
    }
}
