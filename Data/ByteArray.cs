using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class ByteArray
    {
        public virtual ByteArray Bytes
        {
            get { return this; }
        }

        private byte[] data;

        public virtual byte[] Data { get { return data; } }

        public ByteArray() { }

        public ByteArray(byte[] data)
        {
            this.data = data;
        }

        public virtual ByteArray SubArray(int index, int length)
        {
            return new ByteArrayRef(this, index, length);
        }

        public virtual void SetSubArray(int index, byte[] bytes)
        {
            Data.SetSubArray(index, bytes);
        }

        public int FindIndexNextByte(int offset, byte value)
        {
            while (Data[offset] != value && offset < Data.Length - 1)
            {                
                offset++;
            }
            return offset;
        }
    }
}
