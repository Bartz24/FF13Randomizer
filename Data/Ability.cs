using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{

    public class Ability
    {
        public Role Role { get; }
        public bool Starting { get; private set; } = false;
        public string Name { get; }
        public Element[] Elements { get; private set; } = new Element[0];
        public Debuff[] Debuffs { get; private set; } = new Debuff[0];
        public class AbilityData : Identifier
        {
            public string Characters { get; set; }

            public bool HasCharacter(string character)
            {
                return Characters.Contains(character);
            }
        }

        private List<AbilityData> list = new List<AbilityData>();

        /// <summary>
        /// l=Lightning
        /// s=Snow
        /// v=Vanille
        /// z=Sazh
        /// h=Hope
        /// f=Fang
        /// </summary>
        /// <param name="role"></param>
        /// <param name="id"></param>
        /// <param name="characters"></param>
        public Ability(String name, Role role, string id, string characters = "lsvzhf", bool special = false)
        {
            this.Name = name;
            this.Special = special;
            Role = role;
            Add(id, characters);
            Abilities.abilities.Add(this);
        }

        public Ability Add(string id, string characters = "lsvzhf")
        {
            list.Add(new AbilityData() {ID = id, Characters = characters });
            return this;
        }

        public bool Special { get; }

        public bool HasCharacter(string character)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].HasCharacter(character))
                    return true;
            }
            return false;
        }

        public string GetAbility(string character)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].HasCharacter(character))
                    return list[i].ID;
            }
            throw new InvalidCastException("Character does not have the ability!");
        }

        public Ability SetStarting()
        {
            Starting = true;
            return this;
        }

        public Ability SetElements(params Element[] elements)
        {
            Elements = elements;
            return this;
        }

        public Ability SetDebuffs(params Debuff[] debuffs)
        {
            Debuffs = debuffs;
            return this;
        }

        public string[] GetIDs()
        {
            return list.Select(d => d.ID).ToArray();
        }
    }
}
