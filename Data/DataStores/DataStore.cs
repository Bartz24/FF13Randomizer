using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStore
    {
        public virtual ByteArray Data { get; set; }

        public virtual int GetSize()
        {
            return Data.Data.Length;
        }

        public virtual DataStore LoadData(ByteArray data, int offset = 0)
        {
            Data = new ByteArrayRef(data, offset, GetSize());
            return this;
        }

        public virtual void SetData(ByteArray data, int offset = 0)
        {
            data.SetSubArray(offset, Data.Data);
        }
    }
}
