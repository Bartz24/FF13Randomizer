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

        public string GetCharacters()
        {
            return string.Join("", list.SelectMany(a => a.Characters.ToCharArray()).Distinct().OrderBy(c => "lsvzhf".ToCharArray().ToList().IndexOf(c)).Select(c =>
              {
                  switch (c)
                  {
                      case 'l':
                          return "L";
                      case 's':
                          return "Sn";
                      case 'v':
                          return "V";
                      case 'z':
                          return "Sz";
                      case 'h':
                          return "H";
                      case 'f':
                          return "F";
                      default:
                          return "";
                  }
              }));
        }

        public string GetAbility(string character)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].HasCharacter(character))
                    return list[i].ID;
            }
            throw new Exception($"{GetName(character)} cannot have the {Name} ability!");
        }

        private Character GetName(string character)
        {
            switch (character)
            {
                case "l":
                    return Character.Lightning;
                case "s":
                    return Character.Snow;
                case "v":
                    return Character.Vanille;
                case "z":
                    return Character.Sazh;
                case "h":
                    return Character.Hope;
                case "f":
                    return Character.Fang;
            }
            return Character.Lightning;
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
