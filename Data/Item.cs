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

        public Item(string id)
        {
            this.ID = id;
            Items.items.Add(this);
        }
    }
}
