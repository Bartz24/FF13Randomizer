using Bartz24.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreAbility : DataStore
    {
        public ushort ATBCost
        {
            get { return Data.ReadUShort(0xF4); }
            set { Data.SetUShort(0xF4, value); }
        }

        public override int GetDefaultLength()
        {
            return 0x120;
        }
    }
}
