using Bartz24.Docs;
using FF13Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FF13Data.PassiveSet;

namespace FF13Randomizer
{
    public class RandoEquip : Randomizer
    {
        public static string[] CharNames = new string[] { "lightning", "sazh", "snow", "hope", "vanille", "fang" };

        public DataStoreWDB<DataStoreEquip, DataStoreID> equips;

        public RandoEquip(FormMain formMain, RandomizerManager randomizers) : base(formMain, randomizers) { }

        public override string GetProgressMessage()
        {
            return "Randomizing Equipment...";
        }
        public override string GetID()
        {
            return "Equip";
        }

        public override void Load()
        {
            equips = new DataStoreWDB<DataStoreEquip, DataStoreID>();
            equips.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\item_weapon.wdb"));

            //File.WriteAllLines("weaponPassives.csv", Items.items.Where(i => i.ID.StartsWith("wea") || i.ID.StartsWith("acc")).Select(i => $"{i.Name},{equips[i].Passive},{equips[i].PassiveDisplayName},{equips[i].HelpDisplay},{equips[i].StatInitial},{equips[i].StatType1},{equips[i].StatType2}").ToList());
        }
        public override void Randomize(BackgroundWorker backgroundWorker)
        {
            if (Flags.ItemFlags.EquipmentStatsPassives)
            {
                Flags.ItemFlags.EquipmentStatsPassives.SetRand();

                Dictionary<Item, PassiveSet> plandoPassives = main.equipPassivesPlando1.GetPassives();

                Dictionary<Item, Tuple<int[], int[]>> plandoStats = main.equipPlando1.GetEquipment();

                if (plandoPassives.Where(p => p.Value.LockingLevel == LockingLevel.SameType && p.Key.EquipPassive.Item1.Type != p.Value.Type).Count() > 0)
                {
                    KeyValuePair<Item, PassiveSet> pair = plandoPassives.Where(p => p.Key.EquipPassive.Item1.LockingLevel == LockingLevel.SameType && p.Key.EquipPassive.Item1.Type != p.Value.Type).First();
                    throw new Exception($"{pair.Value.GetPassives()[0].Name} on {pair.Key.Name} cannot be applied to this type of equipment ({pair.Key.EquipPassive.Item1.Type})");
                }

                Dictionary<PassiveSet, PassiveSet> mappings = GetMappings(plandoPassives);

                Dictionary<Character, List<PassiveSet>> sets = ((Character[])(Enum.GetValues(typeof(Character)))).ToDictionary(c => c, c =>
                {
                    List<PassiveSet> list = Passives.passives
                    .Where(s => s.Type == PassiveType.Weapon)
    .Select(s => mappings[s])
    .Where(s => s.HasCharacter(Abilities.GetCharID(c.ToString().ToLower())) && s.LockingLevel > LockingLevel.Fixed)
    .ToList();
                    list = list.ShuffleWeighted(list.Select(s => s == Passives.None ? 3 : 1).ToList()).ToList();
                    return list.Take(Items.items.Where(i => i.ID.StartsWith("wea") && i.EquipPassive.Item1 != Passives.Uncapped && GetCharacter(i.ID) == c && i.EquipPassive.Item1.LockingLevel > LockingLevel.Fixed && i.EquipPassive.Item2 == 0 && !plandoPassives.ContainsKey(i)).Select(i => i.EquipPassive.Item1).Count()).ToList();
                });

                Dictionary<Item, Tuple<float, float>> weaponMults = GetWeaponMults(plandoPassives, sets);

                Dictionary<PassiveSet, int> tierCounts = Passives.passives.ToDictionary(s => s, s => Items.items.Where(i => (i.ID.StartsWith("wea") || i.ID.StartsWith("acc")) && i.EquipPassive.Item1 == s).Max(i => i.EquipPassive.Item2) + 1);

                plandoPassives.Keys.ToList().Where(i => equips[i].UpgradeInto != "").ForEach(i =>
                {
                    for (Item i2 = Items.items.Find(i3 => i3.ID == equips[i].UpgradeInto); ; i2 = Items.items.Find(i3 => i3.ID == equips[i2].UpgradeInto))
                    {
                        plandoPassives.Add(i2, plandoPassives[i]);
                        if (equips[i2].UpgradeInto == "" || i2.EquipPassive.Item1 != i.EquipPassive.Item1)
                            break;
                    }
                });

                Items.items.Where(i => i.ID.StartsWith("wea") || i.ID.StartsWith("acc")).ForEach(i =>
                {
                    DataStoreEquip equip = equips[i];
                    Character curChar = GetCharacter(i.ID);

                    int tier = i.EquipPassive.Item2;

                    PassiveSet initPassiveSet = i.EquipPassive.Item1;
                    PassiveSet finalPassiveSet = i.EquipPassive.Item1;

                    Passive initPassive = i.EquipPassive.Item1.GetPassive(Abilities.GetCharID(curChar.ToString().ToLower()), tier, tierCounts[i.EquipPassive.Item1]);
                    Passive finalPassive = initPassive;

                    if (i.EquipPassive.Item1.LockingLevel > LockingLevel.Fixed)
                    {
                        PassiveSet newSet;
                        if (plandoPassives.ContainsKey(i))
                            newSet = plandoPassives[i];
                        else
                            newSet = i.ID.StartsWith("wea") ? sets[curChar][0] : mappings[i.EquipPassive.Item1];

                        Passive passive = newSet.GetPassive(Abilities.GetCharID(curChar.ToString().ToLower()), tier, tierCounts[i.EquipPassive.Item1]);
                        finalPassive = passive;
                        finalPassiveSet = newSet;
                        equip.Passive = passive.ID;
                        equip.PassiveDisplayName = passive.PassiveDisplayName;
                        equip.HelpDisplay = passive.PassiveHelp;
                        equip.StatType1 = passive.StatType1;
                        equip.StatType2 = passive.StatType2;
                        equip.StatInitial = passive.StatInitial;
                    }

                    if (i.ID.StartsWith("wea"))
                    {
                        float strMult = (float)Math.Pow(finalPassive.StrengthModifier, 1f / Math.Pow(tier + 1, 1.5f)) * weaponMults[i].Item1;
                        float magMult = (float)Math.Pow(finalPassive.MagicModifier, 1f / Math.Pow(tier + 1, 1.5f)) * weaponMults[i].Item2;

                        float avgInit = ((initPassive.StrengthModifier == 0 ? 0 : equip.StrengthInitial / (float)Math.Pow(initPassive.StrengthModifier, 1f / Math.Pow(tier + 1, 1.5f))) + (initPassive.MagicModifier == 0 ? 0 : equip.MagicInitial / (float)Math.Pow(initPassive.MagicModifier, 1f / Math.Pow(tier + 1, 1.5f)))) / (equip.StrengthInitial == 0 || equip.MagicInitial == 0 || initPassive.StrengthModifier == 0 || initPassive.MagicModifier == 0 ? 1f : 2f);
                        float avgInc = ((initPassive.StrengthModifier == 0 ? 0 : equip.StrengthIncrease / (float)Math.Pow(initPassive.StrengthModifier, 0.5f / Math.Pow(tier + 1, 1.5f))) + (initPassive.MagicModifier == 0 ? 0 : equip.MagicIncrease / (float)Math.Pow(initPassive.MagicModifier, 0.5f / Math.Pow(tier + 1, 1.5f)))) / (equip.StrengthIncrease == 0 || equip.MagicIncrease == 0 || initPassive.StrengthModifier == 0 || initPassive.MagicModifier == 0 ? 1f : 2f);

                        equip.StrengthInitial = (short)(avgInit * strMult);
                        equip.StrengthIncrease = (ushort)(avgInc * Math.Sqrt(strMult));
                        equip.MagicInitial = (short)(avgInit * magMult);
                        equip.MagicIncrease = (ushort)(avgInc * Math.Sqrt(magMult));

                        if (equips[i].UpgradeInto == "")
                        {
                            if (initPassiveSet.LockingLevel > LockingLevel.Fixed && !plandoPassives.ContainsKey(i))
                                sets[curChar].RemoveAt(0);
                        }
                    }

                    if (plandoStats.ContainsKey(i))
                    {
                        if (plandoStats[i].Item1[0] != -1)
                            equip.StrengthInitial = (short)plandoStats[i].Item1[0];
                        if (plandoStats[i].Item2[0] != -1)
                            equip.StrengthIncrease = (ushort)plandoStats[i].Item2[0];
                        if (plandoStats[i].Item1[1] != -1)
                            equip.MagicInitial = (short)plandoStats[i].Item1[1];
                        if (plandoStats[i].Item2[1] != -1)
                            equip.MagicIncrease = (ushort)plandoStats[i].Item2[1];
                        if (plandoStats[i].Item1[2] != -1)
                            equip.StatInitial = (short)plandoStats[i].Item1[2];
                        if (plandoStats[i].Item2[2] != -1)
                            equip.StatIncrease = (ushort)plandoStats[i].Item2[2];
                    }
                });
                RandomNum.ClearRand();
            }
        }

        private Dictionary<Item, Tuple<float, float>> GetWeaponMults(Dictionary<Item, PassiveSet> plandoPassives, Dictionary<Character, List<PassiveSet>> sets)
        {
            Dictionary<Item, Tuple<float, float>> weaponMults = Items.items.Where(i => i.ID.StartsWith("wea") && i.EquipPassive.Item2 == 0).ToDictionary(i => i, i =>
            {
                PassiveSet s;
                if (plandoPassives.ContainsKey(i))
                    s = plandoPassives[i];
                else if (i.EquipPassive.Item1.LockingLevel == LockingLevel.Fixed)
                    s = i.EquipPassive.Item1;
                else
                    s = sets[GetCharacter(i.ID)][0];
                if (s.GetPassiveDirect(0, Int32.MaxValue).StrengthModifier > 0 && s.GetPassiveDirect(0, Int32.MaxValue).MagicModifier > 0)
                {
                    if (RandomNum.RandInt(0, 100) < 3)
                    {
                        if (RandomNum.RandInt(0, 100) < 50)
                        {
                            return new Tuple<float, float>(1.5f, 0);
                        }
                        else
                        {
                            return new Tuple<float, float>(0, 1.5f);
                        }
                    }
                    else
                    {
                        StatValues strMag = new StatValues(2);
                        strMag.Randomize(75);
                        return new Tuple<float, float>(strMag[0] / 100f, strMag[1] / 100f);
                    }
                }
                return new Tuple<float, float>(1, 1);
            });

            weaponMults.Keys.ToList().Where(i => equips[i].UpgradeInto != "").ForEach(i =>
            {
                for (Item i2 = Items.items.Find(i3 => i3.ID == equips[i].UpgradeInto); ; i2 = Items.items.Find(i3 => i3.ID == equips[i2].UpgradeInto))
                {
                    weaponMults.Add(i2, weaponMults[i]);
                    if (equips[i2].UpgradeInto == "")
                        break;
                }
            });
            return weaponMults;
        }

        private static Dictionary<PassiveSet, PassiveSet> GetMappings(Dictionary<Item, PassiveSet> plandoPassives)
        {
            Dictionary<PassiveSet, PassiveSet> mappings = new Dictionary<PassiveSet, PassiveSet>();

            Passives.passives.Where(s => s.LockingLevel < LockingLevel.Any).ForEach(s => mappings.Add(s, s));

            plandoPassives.Where(p => p.Key.EquipPassive.Item1.LockingLevel == LockingLevel.Any).ForEach(p => mappings.Add(p.Key.EquipPassive.Item1, p.Value));

            AddToMappings(mappings, Passives.passives.Where(s => s.LockingLevel == LockingLevel.Any && !plandoPassives.Values.Contains(s)).ToList().Shuffle().ToList());
            AddToMappings(mappings, Passives.passives.Where(s => !mappings.ContainsKey(s)).ToList().Shuffle().ToList());
            return mappings;
        }

        private static void AddToMappings(Dictionary<PassiveSet, PassiveSet> mappings, List<PassiveSet> setsOrder)
        {
            List<PassiveSet> weaponSets = setsOrder.Take(setsOrder.Where(s => s.Type == PassiveType.Weapon).Count()).ToList();
            List<PassiveSet> accessorySets = setsOrder.Skip(weaponSets.Count).Take(setsOrder.Where(s => s.Type == PassiveType.Accessory).Count()).ToList();

            Passives.passives.Where(s => setsOrder.Contains(s) && s.Type == PassiveType.Weapon && weaponSets.Contains(s)).ForEach(s =>
            {
                mappings.Add(s, s);
                weaponSets.Remove(s);
            });
            Passives.passives.Where(s => setsOrder.Contains(s) && s.Type == PassiveType.Weapon && !mappings.ContainsKey(s)).ForEach(s =>
            {
                mappings.Add(s, weaponSets[0]);
                weaponSets.RemoveAt(0);
            });
            Passives.passives.Where(s => setsOrder.Contains(s) && s.Type == PassiveType.Accessory && accessorySets.Contains(s)).ForEach(s =>
            {
                mappings.Add(s, s);
                accessorySets.Remove(s);
            });
            Passives.passives.Where(s => setsOrder.Contains(s) && s.Type == PassiveType.Accessory && !mappings.ContainsKey(s)).ForEach(s =>
            {
                mappings.Add(s, accessorySets[0]);
                accessorySets.RemoveAt(0);
            });
        }

        private Character GetCharacter(string weaponID)
        {
            switch (weaponID.Substring(4, 3))
            {
                case "lig":
                default:
                    return Character.Lightning;
                case "saz":
                    return Character.Sazh;
                case "sno":
                    return Character.Snow;
                case "hop":
                    return Character.Hope;
                case "van":
                    return Character.Vanille;
                case "fan":
                    return Character.Fang;
            }
        }

        public override void Save()
        {
            File.WriteAllBytes("db\\resident\\item_weapon.wdb", equips.Data);
        }
    }
}
