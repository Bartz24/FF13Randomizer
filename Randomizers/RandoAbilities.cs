using FF13Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FF13Randomizer
{
    public class RandoAbilities : Randomizer
    {
        DataStoreWDB<DataStoreAbility, DataStoreID> abilities;

        public RandoAbilities(FormMain formMain, RandomizerManager randomizers) : base(formMain, randomizers) { }

        public override string GetProgressMessage()
        {
            return "Randomizing Abilities...";
        }
        public override string GetID()
        {
            return "Abilities";
        }

        public override void Load()
        {
            abilities = new DataStoreWDB<DataStoreAbility, DataStoreID>();
            abilities.LoadData(File.ReadAllBytes($"{main.RandoPath}\\original\\db\\resident\\bt_ability.wdb"));
        }
        public override void Randomize(BackgroundWorker backgroundWorker)
        {
            Dictionary<Ability, int> plando = main.abilityPlando1.GetAbilities();
            RandomizeATBCosts(plando);
            backgroundWorker.ReportProgress(90);
            RandomizeTPCosts(plando);
            backgroundWorker.ReportProgress(100);
        }

        private void RandomizeATBCosts(Dictionary<Ability, int> plando)
        {
            if (Flags.AbilityFlags.ATBCost)
            {
                int variance = Flags.AbilityFlags.ATBCost.Range.Value;
                Flags.AbilityFlags.ATBCost.SetRand();

                RandoCrystarium crystarium = randomizers.Get<RandoCrystarium>("Crystarium");
                List<string> startingAbilityNodes = crystarium.crystariums.Values.SelectMany(c => c.DataList).Where(node => node.CPCost == 0 && node.Type == CrystariumType.Ability).Select(node => node.AbilityName).ToList();

                Abilities.abilities.Where(a => a.Role != Role.None).ForEach(aID =>
                {

                    if (abilities.IdList.IndexOf(aID.GetIDs()[0]) > -1)
                    {
                        int max = aID.GetIDs().Where(id => startingAbilityNodes.Contains(id)).Count() > 0 ? 3 : 6;
                        if (aID == Abilities.Attack || aID == Abilities.HandGrenade)
                            max = 2;
                        int cost = plando.ContainsKey(aID) ? (plando[aID] * 10) : abilities[aID.GetIDs()[0]].ATBCost;
                        if (cost > 0 && cost < 0xFFFF)
                        {
                            if (!plando.ContainsKey(aID))
                                cost = RandomNum.RandInt(Math.Max(1, cost / 10 - variance), Math.Min(max, cost / 10 + variance)) * 10;
                            if (cost == 60)
                                cost = 0xFFFF;
                            aID.GetIDs().ForEach(id =>
                            {
                                if (abilities.IdList.IndexOf(id) > -1)
                                {
                                    abilities[id].ATBCost = (ushort)cost;
                                }
                            });
                        }
                    }

                });

                RandomNum.ClearRand();
            }
        }
        private void RandomizeTPCosts(Dictionary<Ability, int> plando)
        {
            if (Flags.AbilityFlags.TPCost)
            {
                int variance = Flags.AbilityFlags.TPCost.Range.Value;
                Flags.AbilityFlags.TPCost.SetRand();

                Abilities.abilities.Where(a => a.Role == Role.None).ForEach(aID =>
                {
                    if (abilities.IdList.IndexOf(aID.GetIDs()[0]) > -1)
                    {
                        int max = 5;
                        int cost = plando.ContainsKey(aID) ? (plando[aID] * 10) : abilities[aID.GetIDs()[0]].ATBCost;
                        if (!plando.ContainsKey(aID))
                            cost = RandomNum.RandInt(Math.Max(1, cost / 10 - variance), Math.Min(max, cost / 10 + variance)) * 10;

                        aID.GetIDs().ForEach(id =>
                        {
                            if (abilities.IdList.IndexOf(id) > -1)
                            {
                                abilities[id].ATBCost = (ushort)cost;
                            }
                        });
                    }
                });
                RandomNum.ClearRand();
            }
        }

        public override void Save()
        {
            File.WriteAllBytes("db\\resident\\bt_ability.wdb", abilities.Data);
        }
    }
}
