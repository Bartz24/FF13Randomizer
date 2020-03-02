using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{

    public class Item
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public Item(string name, string id)
        {
            this.Name = name;
            this.ID = id;
            Items.items.Add(this);
        }
    }
}
