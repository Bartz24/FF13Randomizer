using Bartz24.Rando;
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
            get => GetHighBound(maxCount);
        }

        public int GetHighBound(int count)
        {
            return list[list.Count - 1].Item1 + GetCountBoost(count);
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
                int minRank = LowBound, maxRank = HighBound;
                for (int rank = LowBound; rank <= HighBound; rank++)
                {
                    List<Tuple<T, int>> tuples = Get(rank, maxCount);
                    if (tuples.Where(tuple => tuple.Item1.Equals(obj) && tuple.Item2 >= count).Count() > 0)
                    {
                        minRank = rank;
                        break;
                    }
                }
                for (int rank = HighBound - 1; rank >= minRank; rank--)
                {
                    List<Tuple<T, int>> tuples = Get(rank, maxCount);
                    if (tuples.Where(tuple => tuple.Item1.Equals(obj) && tuple.Item2 <= count).Count() > 0)
                    {
                        maxRank = rank;
                        break;
                    }
                }
                return minRank;
            }
            return -1;
        }

        public int GetCount(int rankBoost, int max)
        {
            return Math.Min(Math.Min(max, maxCount), Math.Max(1, (int)Math.Pow(rankBoost, countScale)));
        }

        public int GetRandomCount(int rankBoost, int max)
        {
            int lower = GetCount(rankBoost,max);
            int upper = GetCount(rankBoost + 1,max);
            return lower >= upper ? lower : RandomNum.RandInt(lower, upper - 1);
        }

        public List<Tuple<T, int>> Get(int rank, int count, Func<T, bool> meetsReq = null, bool anyRandom = false)
        {
            if (meetsReq == null)
                meetsReq = t => true;
            if (anyRandom)
            {
                return new List<Tuple<T, int>>() { new Tuple<T, int>(list[RandomNum.RandInt(0, list.Count - 1)].Item2, count) };
            }
            if (rank < LowBound || rank > HighBound)
                return new List<Tuple<T, int>>();
            List<int> validIndexes = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                int upperBound = i == list.Count - 1 ? HighBound : list[i + 1].Item1;
                upperBound = Math.Max(upperBound, list[i].Item1 + GetCountBoost(maxCount));
                if (anyRandom || (rank >= list[i].Item1 && rank <= upperBound && meetsReq.Invoke(list[i].Item2)))
                    validIndexes.Add(i);
            }
            return validIndexes.Select(i => new Tuple<T, int>(list[i].Item2, GetRandomCount(rank - list[i].Item1,count))).ToList();
        }

    }
}
