using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class Crystarium
    {
        public static Dictionary<DataStoreIDCrystarium, string> GetDisplayNames(DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium> crystarium)
        {
            Dictionary<DataStoreIDCrystarium, string> names = new Dictionary<DataStoreIDCrystarium, string>();
            List<DataStoreIDCrystarium> ids = crystarium.IdList.Skip(4).ToList();
            ids.Sort((a, b) => a.CompareTo(b));

            int val = 0, node = 0;
            for (int i = 0; i < crystarium.DataList.Count; i++)
            {
                val++;
                if (i == 0 || ids[i].Node != ids[i - 1].Node)
                    node++;
                if (i > 0)
                {
                    if (ids[i].Stage > ids[i - 1].Stage || ids[i].Prefix != ids[i - 1].Prefix)
                    {
                        val = 1;
                        node = 1;
                    }
                }

                string dispName = $"{node}";
                if (ids[i].SubNode > 0)
                {
                    int highestSub = ids.Where(id => id.Prefix == ids[i].Prefix && id.Stage == ids[i].Stage && id.Node == ids[i].Node).Select(id => id.SubNode).Max();
                    if (highestSub > 1)
                        dispName += $"-{ids[i].SubNode}";
                    int highestSubSub = ids.Where(id => id.Prefix == ids[i].Prefix && id.Stage == ids[i].Stage && id.Node == ids[i].Node).Select(id => id.SubSubNode).Max();
                    if (highestSubSub > 1)
                        dispName += $"-{ids[i].SubSubNode}";
                }

                names.Add(ids[i], dispName);
            }
            return names;
        }
    }
}
