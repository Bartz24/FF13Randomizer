using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreString : DataStore
    {
        private string value;
        public string Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public override ByteArray Data
        {
            get
            {
                if (GetSize() == 1)
                    return new ByteArray(new byte[] { 0 });
                return new ByteArray(Encoding.UTF8.GetBytes(value).Concat(new byte[] { 0 }));
            }
            set
            {
                if (value.Data.Length == 1 && value.Data[0] == 0)
                    this.value = "";
                else
                    this.value = Encoding.UTF8.GetString(value.Data.SubArray(0, value.Data.Length - 1));
            }
        }

        public override DataStore LoadData(ByteArray data, int offset = 0)
        {
            int size = data.FindIndexNextByte(offset, 0) - offset;
            Data = new ByteArrayRef(data, offset, size +1);
            return this;
        }

        public override int GetSize()
        {
            return value.Length + 1;
        }

        public override bool Equals(object obj)
        {
            if (obj is DataStoreString)
                return this.value == ((DataStoreString)obj).value;
            return base.Equals(obj);
        }

        public static bool operator ==(DataStoreString a, DataStoreString b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(DataStoreString a, DataStoreString b)
        {
            return !a.Equals(b);
        }
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}
