using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class Shop : Identifier
    {
        public string Name { get; set; }
        public int Tiers { get; set; }

        public Shop(string name, string id, int tiers)
        {
            this.Name = name;
            this.ID = id;
            this.Tiers = tiers;
            Shops.shops.Add(this);
        }

        public List<string> GetAllIds()
        {
            return Enumerable.Range(0, Tiers).Select(i => ID + i.ToString()).ToList();
        }
    }
}
