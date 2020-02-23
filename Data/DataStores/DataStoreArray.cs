using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreArray<T> : DataStore, IEnumerable<T> where T : DataStore, new()
    {
        public int count, size, offset;
        private List<Func<int, int>> accessModifiers = new List<Func<int, int>>();

        public DataStoreArray(int count, int size, int offset)
        {
            this.count = count;
            this.size = size;
            this.offset = offset;
        }

        public T this[int i]
        {
            get
            {
                int index = i;
                accessModifiers.ForEach(mod => index = mod.Invoke(index));
                T val = new T();
                val.LoadData(Data, offset + index * size);
                return val;
            }
            set
            {
                int index = i;
                accessModifiers.ForEach(mod => index = mod.Invoke(index));
                value.SetData(Data, offset + index * size);
            }
        }

        public override int GetSize()
        {
            return offset + count * size;
        }

        public void AddAccessModifier(Func<int,int> modifier)
        {
            accessModifiers.Add(modifier);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
