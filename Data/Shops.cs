using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class Shops
    {
        public static List<Shop> shops = new List<Shop>();

        public static Shop bwOutfitter = new Shop("B&W Outfitters", "shop_acc_a", 9);
        public static Shop magicalMoments = new Shop("Magical Moments", "shop_acc_b", 5);
        public static Shop moogleworks = new Shop("Moogleworks", "shop_acc_c", 2);
        public static Shop sanctumLabs = new Shop("Sanctum Labs", "shop_acc_d", 1);
        public static Shop unicornMart = new Shop("Unicorn Mart", "shop_item_a", 6);
        public static Shop edenPharmaceuticals = new Shop("Eden Pharmaceuticals", "shop_item_b", 1);
        public static Shop creatureComforts = new Shop("Creature Comforts", "shop_mat_a", 4);
        public static Shop theMotherlode = new Shop("The Motherlode", "shop_mat_b", 4);
        public static Shop lenorasGarage = new Shop("Lenora's Garage", "shop_mat_c", 4);
        public static Shop rdDepot = new Shop("R&D Depot", "shop_mat_d", 1);
        public static Shop upInArms = new Shop("Up In Arms", "shop_wea_a", 3);
        public static Shop plautusWorkshop = new Shop("Plautus's Workshop", "shop_wea_b", 5);
        public static Shop gilgameshInc = new Shop("Gilgamesh, Inc.", "shop_wea_d", 1);
    }
}
