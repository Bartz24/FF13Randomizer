using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class Party
    {
        public Member[] Members { get; }

        public int MaxStage { get; }
        public bool LeaderSwap { get; }

        public Party(int stage, bool leaderSwap, params Member[] members)
        {
            Members = members;
            MaxStage = stage;
            LeaderSwap = leaderSwap;
            Parties.parties.Add(this);
        }
        public Party(int stage) :
            this(stage, new Character[0])
        {
        }
        public Party(int stage, params Character[] excluded) :
            this(stage, true, new Member[] { new Member(Character.Lightning), new Member(Character.Snow), new Member(Character.Sazh), new Member(Character.Vanille), new Member(Character.Hope), new Member(Character.Fang) }.Where(m => !excluded.Contains(m.Character)).ToArray())
        {
        }
    }
}
