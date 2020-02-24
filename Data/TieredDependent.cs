using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class TieredDependent<T> : Tiered<T>
    {

        protected Dictionary<T, List<T>> dependentDict = new Dictionary<T, List<T>>();
        protected bool anyNeeded = false;

        public TieredDependent(int rank, T item, int weight = 1, int max = 1, float scale = 1f, T dependent = default(T))
            : base(0, default(T), weight, max, scale)
        {
            list.Clear();
            Add(rank, item, dependent);
        }

        public TieredDependent(int rank, T item, T dependent, bool any=false)
            : base(0, default(T), 1, 1, 1)
        {
            anyNeeded = any;
            list.Clear();
            Add(rank, item, dependent);
        }

        public override Tiered<T> Add(int rank, T item)
        {
            Add(rank, item, default(T));
            return this;
        }

        public Tiered<T> Add(int rank, T item, T dependent)
        {
            list.Add(new Tuple<int, T>(rank, item));
            list.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            AddDep(item, dependent);
            return this;
        }

        public TieredDependent<T> AddDep(T item, T dependent)
        {
            if(dependent != null)
            {
                if (dependentDict.ContainsKey(item))
                    dependentDict[item].Add(dependent);
                else
                    dependentDict.Add(item, new T[] { dependent }.ToList());
            }
                
            return this;
        }

        public new TieredDependent<T> Register(TieredManager<T> manager)
        {
            return (TieredDependent<T>) base.Register(manager);
        }

        public bool MeetsRequirement(T item, List<T> possibleDepedents)
        {
            if (!dependentDict.ContainsKey(item) || dependentDict[item] == null)
                return true;
            foreach (T t in dependentDict[item])
            {
                if (anyNeeded && possibleDepedents.Contains(t))
                    return true;
                else if (!anyNeeded && !possibleDepedents.Contains(t))
                    return false;
            }
            return !anyNeeded;
        }
    }
}
