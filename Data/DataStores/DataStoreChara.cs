using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreChara : DataStore
    {
        public byte RunSpeed
        {
            get { return Data.ReadByte(0x17); }
            set { Data.SetByte(0x17, value); }
        }

        public override int GetDefaultLength()
        {
            return 0x58;
        }
    }
}
