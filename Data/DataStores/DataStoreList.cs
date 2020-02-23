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
        protected int minSizeFactor = 1;

        public DataStoreList(int minSizeFactor)
        {
            this.minSizeFactor = minSizeFactor;
        }

        public override void SetData(ByteArray data, int offset = 0)
        {
            int i = 0;
            list.ForEach(obj =>
            {
                obj.SetData(data, offset + i);
                i += obj.GetSize();
            });
        }

        public override DataStore LoadData(ByteArray data, int offset = 0)
        {
            list.Clear();
            while (offset < data.Data.Length)
            {
                T val = new T();
                val.LoadData(data, offset);
                offset += val.GetSize();
                Add(val,list.Count);
            }
            return this;
        }

        public T this[int i]
        {
            get { return list[i]; }
            set { list[i] = value; }
        }

        public virtual int GetTrueSize()
        {
            int count = 0;
            list.ForEach(obj => count += obj.GetSize());
            return count;
        }

        public override int GetSize()
        {
            int count = GetTrueSize();
            if (count % minSizeFactor == 0)
                return count;
            return count + (minSizeFactor - count % minSizeFactor);
        }

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
    }
}
