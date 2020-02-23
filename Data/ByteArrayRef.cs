using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class ByteArrayRef : ByteArray
    {
        private ByteArray byteArray;

        private int offset, size;

        public override ByteArray Bytes
        {
            get { return byteArray.SubArray(offset, size); }
        }

        public override byte[] Data
        {
            get { return byteArray.Data.SubArray(offset, size); }
        }

        public ByteArrayRef(ByteArray byteArray, int offset, int size)
        {
            this.byteArray = byteArray;
            this.offset = offset;
            this.size = size;
        }

        public override void SetSubArray(int index, byte[] bytes)
        {
            byteArray.SetSubArray(this.offset+index, bytes);
        }
    }
}
