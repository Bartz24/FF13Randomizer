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
                data.Add("runSpeed", main.runSpeedPlando1.GetJSONPlando());
                data.Add("enemyStats", main.enemyStatsPlando1.GetJSONPlando());
                data.Add("enemyElemResists", main.enemyElementResistPlando1.GetJSONPlando());
                data.Add("enemyDebuffResists", main.enemyDebuffResistPlando1.GetJSONPlando());

                File.WriteAllText(path, JsonConvert.SerializeObject(data));
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to export plando data: " + e.Message);
            }
        }
        public static void Read(string path, FormMain main)
        {
            try
            {
                Dictionary<string, object> data = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(path));

                JSONPlandoGeneralInfo general = JsonConvert.DeserializeObject<JSONPlandoGeneralInfo>(data["general"].ToString());
                if (FormMain.Version != general.Version)
                    MessageBox.Show($"This plando is version {general.Version} which may be incompatible with this version of rando. If it recent enough, it will be migrated to work in the current version.");
                Flags.Import(general.Flags, false);
                main.textBoxSeed.Text = general.Seed;

                LoadPlando<CrystariumPlando.JSONPlandoCrystarium>(data, "crystarium", l => main.crystariumPlando1.LoadJSONPlando(l, general.Version), () => main.crystariumPlando1.ReloadData(main));
                LoadPlando<TreasurePlando.JSONPlandoTreasure>(data, "treasures", l => main.treasurePlando1.LoadJSONPlando(l, general.Version), () => main.treasurePlando1.ReloadData(main));
                LoadPlando<ShopPlando.JSONPlandoShop>(data, "shops", l => main.shopPlando1.LoadJSONPlando(l, general.Version), () => main.shopPlando1.ReloadData(main));
                LoadPlando<ShopOrderPlando.JSONPlandoShopOrder>(data, "shopOrder", l => main.shopOrderPlando1.LoadJSONPlando(l, general.Version), () => main.shopOrderPlando1.ReloadData(main));
                LoadPlando<AbilityPlando.JSONPlandoAbility>(data, "abilities", l => main.abilityPlando1.LoadJSONPlando(l, general.Version), () => main.abilityPlando1.ReloadData(main));
                LoadPlando<EnemyDropPlando.JSONPlandoEnemyDrops>(data, "enemyDrops", l => main.enemyDropPlando1.LoadJSONPlando(l, general.Version), () => main.enemyDropPlando1.ReloadData(main));
                LoadPlando<RunSpeedPlando.JSONPlandoRunSpeed>(data, "runSpeed", l => main.runSpeedPlando1.LoadJSONPlando(l, general.Version), () => main.runSpeedPlando1.ReloadData(main));
                LoadPlando<EnemyStatsPlando.JSONPlandoEnemyStats>(data, "enemyStats", l => main.enemyStatsPlando1.LoadJSONPlando(l, general.Version), () => main.enemyStatsPlando1.ReloadData(main));
                LoadPlando<EnemyElementResistPlando.JSONPlandoEnemyElementResists>(data, "enemyElemResists", l => main.enemyElementResistPlando1.LoadJSONPlando(l, general.Version), () => main.enemyElementResistPlando1.ReloadData(main));
                LoadPlando<EnemyDebuffResistPlando.JSONPlandoEnemyDebuffResists>(data, "enemyDebuffResists", l => main.enemyDebuffResistPlando1.LoadJSONPlando(l, general.Version), () => main.enemyDebuffResistPlando1.ReloadData(main));
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to import plando data: " + e.Message);
            }
        }

        private static void LoadPlando<T>(Dictionary<string, object> data, string id, Action<List<T>> success, Action failed)
        {
            if (data.ContainsKey(id))
                success.Invoke(JsonConvert.DeserializeObject<List<T>>(data[id].ToString()));
            else
                failed.Invoke();
        }
    }
}
