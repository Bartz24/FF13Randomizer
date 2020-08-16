using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public abstract class DataStore
    {
        public virtual byte[] Data { get; set; }

        public virtual void LoadData(byte[] data, int offset = 0)
        {
            if (GetDefaultLength() > 0)
                Data = data.SubArray(offset, GetDefaultLength());
        }

        public virtual int Length
        {
            get => Data.Length;
        }

        public abstract int GetDefaultLength();

        public virtual void UpdateStringPointers(DataStorePointerList<DataStoreString> list) { }
    }
}
