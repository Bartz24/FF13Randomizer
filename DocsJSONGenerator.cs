using FF13Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FF13Randomizer
{
    public class JSONCrystarium
    {
        public int HP { get; set; }
        public int Strength { get; set; }
        public int Magic { get; set; }
        public int RoleLevels { get; set; }
        public int Accessories { get; set; }
        public string[] Abilities { get; set; }
    }

    public class JSONCrystariumRole
    {
        public Dictionary<int, JSONCrystarium> Stages { get; set; }
        public bool PrimaryRole { get; set; }
    }

    public class JSONTreasure
    {
        public string Item { get; set; }
        public int Count { get; set; }
        public int Rank { get; set; }
    }

    public class DocsJSONGenerator
    {
        public static void CreateCrystariumDocs(Dictionary<string, DataStoreWDB<DataStoreCrystarium>> crystariums, Dictionary<string, Role[]> primaryRoles)
        {
            Dictionary<string, Dictionary<string, JSONCrystariumRole>> jsons = new Dictionary<string, Dictionary<string, JSONCrystariumRole>>();
            crystariums.Keys.ToList().ForEach(name =>
            {
                Dictionary<string, JSONCrystariumRole> jsonRoles = new Dictionary<string, JSONCrystariumRole>();
                DataStoreWDB<DataStoreCrystarium> crystarium = crystariums[name];
                foreach (Role role in Enum.GetValues(typeof(Role)))
                {
                    if (role == Role.None)
                        continue;
                    JSONCrystariumRole roleJson = new JSONCrystariumRole();
                    roleJson.Stages = new Dictionary<int, JSONCrystarium>();
                    roleJson.PrimaryRole = primaryRoles[name].Contains(role);
                    IEnumerable<DataStoreCrystarium> nodesRole = crystarium.DataList.Where(c => c.Role == role);
                    for (int stage = 1; stage <= 10; stage++)
                    {
                        IEnumerable<DataStoreCrystarium> nodesStage = nodesRole.Where(c => c.Stage == stage);
                        JSONCrystarium crystJson = new JSONCrystarium()
                        {
                            HP = nodesStage.Where(c => c.Type == CrystariumType.HP).Sum(c => c.Value),
                            Strength = nodesStage.Where(c => c.Type == CrystariumType.Strength).Sum(c => c.Value),
                            Magic = nodesStage.Where(c => c.Type == CrystariumType.Magic).Sum(c => c.Value),
                            RoleLevels = nodesStage.Where(c => c.Type == CrystariumType.RoleLevel).Count(),
                            Accessories = nodesStage.Where(c => c.Type == CrystariumType.Accessory).Count(),
                            Abilities = nodesStage.Where(c => c.Type == CrystariumType.Ability).Select(c=> {
                                Ability ability = Abilities.abilities.Where(a => a.HasCharacter(getCharID(name)) && a.GetAbility(getCharID(name)) == c.AbilityName).FirstOrDefault();
                                return ability.Name;
                            }).ToArray()
                        };
                        roleJson.Stages.Add(stage, crystJson);
                    }
                    jsonRoles.Add(role.ToString(), roleJson);
                }
                jsons.Add(name, jsonRoles);
            });

            string data = JsonConvert.SerializeObject(jsons, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("logs/crystarium.json", data);
        }

        private static string getCharID(string character)
        {
            if (character == "sazh")
                return "z";
            return character.Substring(0, 1);
        }

        public static void CreateTreasureDocs(DataStoreWDB<DataStoreTreasure> treasures, int[] ranks)
        {
            JSONTreasure[] jsons = new JSONTreasure[treasures.DataList.Count];
            for (int i = 0; i < treasures.DataList.Count; i++)
            {
                Item item = Items.items.Where(it => it.ID == treasures.DataList[i].ItemID).FirstOrDefault();
                JSONTreasure treasJson = new JSONTreasure()
                {
                    Item = item == null ? treasures.DataList[i].ItemID : item.Name,
                    Count = (int)treasures.DataList[i].Count,
                    Rank = ranks[i]
                };
                jsons[i] = treasJson;
            }

            string data = JsonConvert.SerializeObject(jsons, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("logs/treasures.json", data);
        }
    }
}
