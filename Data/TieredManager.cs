using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class TieredManager<T>
    {
        public List<Tiered<T>> list = new List<Tiered<T>>();

        public List<Tiered<T>> GetTiered(int rank)
        {
            return list.Where(t => rank >= t.LowBound && rank <= t.HighBound).ToList();
        }

        public Tuple<T,int> Get(int rank, Func<Tiered<T>,int> weightFunc = null)
        {
            if (weightFunc == null)
                weightFunc = t => t.Weight;
            List<Tiered<T>> items = GetTiered(rank);
            List<Tuple<T, int>> possible = RandomNum.SelectRandomWeighted(items, weightFunc).Get(rank);
            if (possible.Count == 0)
                return new Tuple<T, int>(default(T), 0);
            return possible[RandomNum.randInt(0, possible.Count - 1)];
        }

        public int GetRank(T obj, int count)
        {
            int avg = 0, avgCount = 0;
            foreach(Tiered<T> tiered in list)
            {
                int rank = tiered.GetRank(obj, count);
                if (rank != -1)
                {
                    avg += rank;
                    avgCount++;
                }
                    
            }
            return avgCount == 0 ? -1 : (int)Math.Round((float)avg / avgCount);
        }
    }
}
