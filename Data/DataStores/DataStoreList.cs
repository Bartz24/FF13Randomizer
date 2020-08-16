using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreList<T> : DataStore, IEnumerable<T> where T : DataStore, new()
    {
        protected List<T> list = new List<T>();

        public override byte[] Data
        {
            get
            {
                List<byte[]> data = list.Select(t => t.Data).ToList();
                byte[] allData = new byte[data.Sum(a => a.Length)];
                int offset = 0;
                foreach(byte[] array in data)
                {
                    allData.SetSubArray(offset, array);
                    offset += array.Length;
                }
                return allData;
            }
        }

        public override void LoadData(byte[] data, int offset = 0)
        {
            list.Clear();
            while (offset < data.Length)
            {
                T val = new T();
                val.LoadData(data, offset);
                offset += val.Length;
                Add(val,list.Count);
            }
        }

        public T this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }

        public int Count => list.Count;

        public virtual void Clear()
        {
            list.Clear();            
        }

        public virtual void Add(T obj, int i)
        {
            list.Insert(i, obj);
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public virtual int IndexOf(T obj)
        {
            return list.IndexOf(obj);
        }

        public virtual bool Contains(T obj)
        {
            return list.Contains(obj);
        }

        public override int GetDefaultLength()
        {
            return -1;
        }
    }
}
