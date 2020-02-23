using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStorePointerList<T> : DataStoreList<T> where T : DataStore, new()
    {
        public readonly T NULL;
        private Dictionary<int, int> pointerToIndexDictionary = new Dictionary<int, int>();

        public DataStorePointerList(int minSizeFactor, T nullVal) : base(minSizeFactor)
        {
            NULL = nullVal;
        }

        public override DataStore LoadData(ByteArray data, int offset = 0)
        {
            list.Clear();
            while (offset < data.Data.Length)
            {
                T val = new T();
                val.LoadData(data, offset);
                Add(val,offset);
                offset += val.GetSize();
            }
            return this;
        }

        public Dictionary<int, int> GetNewPointers()
        {
            Dictionary<int, int> newDict = new Dictionary<int, int>();
            int offset = 0;
            pointerToIndexDictionary.Keys.ToList().ForEach(key =>
            {
                newDict.Add(key, offset);
                offset += this[key].GetSize();
            });
            return newDict;
        }

        public void UpdatePointers()
        {
            Dictionary<int, int> newPointers = GetNewPointers();
            Dictionary<int, int> newDict = new Dictionary<int, int>();
            pointerToIndexDictionary.Keys.ToList().ForEach(key =>
            {
                newDict.Add(newPointers[key], pointerToIndexDictionary[key]);
            });
            pointerToIndexDictionary = newDict;
        }

        public new T this[int i]
        {
            get
            {
                if (pointerToIndexDictionary.ContainsKey(i + 1))
                    return NULL;
                return list[pointerToIndexDictionary[i]];
            }
            set { list[pointerToIndexDictionary[i]] = value; UpdatePointers(); }
        }

        public override void Clear()
        {
            base.Clear();
            pointerToIndexDictionary.Clear();
        }

        public override void Add(T obj, int i)
        {
            pointerToIndexDictionary.Add(i, list.Count);
            base.Add(obj,list.Count);
        }

        public override int IndexOf(T obj)
        {
            IEnumerable<int> values = pointerToIndexDictionary.Keys.Where(key => this[key].Equals(obj));
            if (Contains(obj) && values.Count() == 0)
                throw new Exception("Invalid check!");
            return values.Count() > 0 ? values.First() : -1;
        }
    }
}
