﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{

    public class Item : Identifier
    {
        public string Name { get; set; }
        public Shop PreferredShop { get; set; }

        public Item(string name, string id, Shop shop)
        {
            this.Name = name;
            this.ID = id;
            this.PreferredShop = shop;
            Items.items.Add(this);
        }
    }
}
