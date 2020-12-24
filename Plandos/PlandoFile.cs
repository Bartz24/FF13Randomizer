using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF13Randomizer
{
    public class PlandoFile
    {
        public class JSONPlandoGeneralInfo
        {
            public string Seed { get; set; }
            public string Flags { get; set; }
            public string Version { get; set; }
        }

        public static void Write(string path, FormMain main)
        {
            try
            {
                Dictionary<string, object> data = new Dictionary<string, object>();

                data.Add("general", new JSONPlandoGeneralInfo() { Flags = Flags.GetFlagString(), Seed = main.textBoxSeed.Text, Version = FormMain.Version });

                data.Add("crystarium", main.crystariumPlando1.GetJSONPlando());
                data.Add("treasures", main.treasurePlando1.GetJSONPlando());
                data.Add("shops", main.shopPlando1.GetJSONPlando());
                data.Add("shopOrder", main.shopOrderPlando1.GetJSONPlando());
                data.Add("abilities", main.abilityPlando1.GetJSONPlando());
                data.Add("enemyDrops", main.enemyDropPlando1.GetJSONPlando());

                File.WriteAllText(path, JsonConvert.SerializeObject(data));
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to export plando data");
            }
        }
        public static void Read(string path, FormMain main)
        {
            try
            {
                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(path));

                JSONPlandoGeneralInfo general = JsonConvert.DeserializeObject<JSONPlandoGeneralInfo>(data["general"].ToString());
                if (FormMain.Version != general.Version)
                    MessageBox.Show($"This plando is version {general.Version} which may be incompatible with this version of rando.");
                Flags.Import(general.Flags, false);
                main.textBoxSeed.Text = general.Seed;

                main.crystariumPlando1.LoadJSONPlando(JsonConvert.DeserializeObject<List<CrystariumPlando.JSONPlandoCrystarium>>(data["crystarium"].ToString()));
                main.treasurePlando1.LoadJSONPlando(JsonConvert.DeserializeObject<List<TreasurePlando.JSONPlandoTreasure>>(data["treasures"].ToString()));
                main.shopPlando1.LoadJSONPlando(JsonConvert.DeserializeObject<List<ShopPlando.JSONPlandoShop>>(data["shops"].ToString()));
                main.shopOrderPlando1.LoadJSONPlando(JsonConvert.DeserializeObject<List<ShopOrderPlando.JSONPlandoShopOrder>>(data["shopOrder"].ToString()));
                main.abilityPlando1.LoadJSONPlando(JsonConvert.DeserializeObject<List<AbilityPlando.JSONPlandoAbility>>(data["abilities"].ToString()));
                main.enemyDropPlando1.LoadJSONPlando(JsonConvert.DeserializeObject<List<EnemyDropPlando.JSONPlandoEnemyDrops>>(data["enemyDrops"].ToString()));
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to import plando data");
            }
        }
    }
}
