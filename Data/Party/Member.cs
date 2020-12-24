using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class Member
    {
        public Character Character { get; }
        public Role[] RolesAvailable { get; }

        public Member(Character character, params Role[] roles)
        {
            Character = character;
            RolesAvailable = roles;
        }
        public Member(Character character) :
            this(character, Role.Commando, Role.Ravager, Role.Sentinel, Role.Synergist, Role.Saboteur, Role.Medic)
        {
        }

        public List<Ability> GetAbilitiesAvailable(int stage, DataStoreWDB<DataStoreCrystarium, DataStoreIDCrystarium> crystarium, bool leader, bool skytank)
        {
            if(stage == 0)
            {
                List<Ability> list = new List<Ability>();
                list.Add(Abilities.Attack);
                if (Character == Character.Snow)
                    list.Add(Abilities.HandGrenade);
                return list;
            }

            return crystarium.DataList.Where(c => c.Stage <= stage && RolesAvailable.Contains(c.Role) && c.Type == CrystariumType.Ability).Select(c => Abilities.GetAbility(Character.ToString().ToLower(), c))
                .Where(a => RolesAvailable.Contains(a.Role) && a.Starting).Select(a =>
                {
                    if (skytank)
                    {
                        if (a == Abilities.Attack && Character != Character.Lightning)
                            return Abilities.Ruin;
                        if (a == Abilities.Flamestrike)
                            return Abilities.Fire;
                        if (a == Abilities.Aquastrike)
                            return Abilities.Water;
                        if (a == Abilities.Froststrike)
                            return Abilities.Blizzard;
                        if (a == Abilities.Sparkstrike)
                            return Abilities.Thunder;
                    }
                    return a;
                }).ToList();
        }
    }
}
