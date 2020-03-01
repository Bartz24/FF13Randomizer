using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class Tiered<T>
    {
        protected List<Tuple<int, T>> list = new List<Tuple<int, T>>();
        protected int maxCount, weight;
        protected float countScale;

        public Tiered(int rank, T item,int weight=1, int max=1, float scale = 1.1f)
        {
            this.maxCount = max;
            this.weight = weight;
            this.countScale = scale;
            if (rank >= 0)
                Add(rank, item);
        }

        public virtual Tiered<T> Add(int rank, T item)
        {
            list.Add(new Tuple<int, T>(rank, item));
            list.Sort((a, b) => a.Item1.CompareTo(b.Item1));
            return this;
        }

        public virtual Tiered<T> Register(TieredManager<T> manager)
        {
            manager.list.Add(this);
            return this;
        }

        public IReadOnlyCollection<T> Items
        {
            get => list.Select(o => o.Item2).ToList().AsReadOnly();
        }

        public int LowBound
        {
            get => list[0].Item1;
        }

        public int Weight
        {
            get => weight;
        }

        public int HighBound
        {
            get => list[list.Count - 1].Item1 + GetCountBoost(maxCount);
        }

        public int GetCountBoost(int count)
        {
            return (int)Math.Ceiling(Math.Pow(Math.Min(count, maxCount), 1f / countScale));
        }

        public int GetRank(T obj, int count)
        {
            foreach(Tuple<int,T> t in list)
            {
                if (!t.Item2.Equals(obj))
                    continue;
                int minRank = 0, maxRank = 0;
                for (int rank = 0; rank <= HighBound; rank++)
                {
                    List<Tuple<T, int>> tuples = Get(rank);
                    if (tuples.Where(tuple => tuple.Item1.Equals(obj) && tuple.Item2 <= count).Count() > 0)
                        minRank = rank;
                }
                for (int rank = HighBound; rank >= minRank; rank--)
                {
                    List<Tuple<T, int>> tuples = Get(rank);
                    if (tuples.Where(tuple => tuple.Item1.Equals(obj) && tuple.Item2 >= count).Count() > 0)
                        maxRank = rank;
                }
                return (minRank + maxRank) / 2;
            }
            return -1;
        }

        public int GetCount(int rankBoost)
        {
            return Math.Min(maxCount, Math.Max(1, (int)Math.Pow(rankBoost, countScale)));
        }

        public List<Tuple<T, int>> Get(int rank, Func<T, bool> meetsReq = null)
        {
            if (meetsReq == null)
                meetsReq = t => true;
            if (rank < LowBound || rank > HighBound)
                return new List<Tuple<T, int>>();
            List<int> validIndexes = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                int upperBound = (i == list.Count - 1 ? HighBound : list[i + 1].Item1);
                upperBound = Math.Max(upperBound, list[i].Item1 + GetCountBoost(maxCount));
                if (rank >= list[i].Item1 && rank <= upperBound && meetsReq.Invoke(list[i].Item2))
                    validIndexes.Add(i);
            }
            return validIndexes.Select(i => new Tuple<T, int>(list[i].Item2, GetCount(rank - list[i].Item1))).ToList();
        }

    }
}
