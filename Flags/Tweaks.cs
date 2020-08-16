using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{   
    public class Tweaks
    {
        public static List<Flag> tweaks = new List<Flag>();

        public class Boosts
        {
            public static Flag ScaledCPCost = new Flag()
            {
                Text = "Scaled CP Cost",
                FlagID = "ScCPCost",
                DescriptionFormat = "CP Cost scales down as stage increases.\n" +
                "Stage 1 is 1x multiplier\n" +
                "Stage 5 is 0.7x multiplier\n" +
                "Stage 9 and 10 are 0.5x multiplier"
            }.Register(FlagType.Boost, true);


            public static Flag HalfSecondaryCPCost = new Flag()
            {
                Text = "Half Secondary CP Cost",
                FlagID = "HfSecCP",
                DescriptionFormat = "CP Cost is halved on secondary roles. Applies on top of Scaled CP Cost."
            }.Register(FlagType.Boost, true);

            public static FlagValue RunSpeedMultiplier = (FlagValue)new FlagValue(0,0,100)
            {
                Text = "Run Speed Multiplier",
                FlagID = "RunSpdMult",
                DescriptionFormat = "Increases the run speed of all characters by ${Value}%"
            }.Register(FlagType.Boost, true);
        }

        public class Challenges
        {
            public static FlagValue BoostLevel = (FlagValue)new FlagValue(0,0,100)
            {
                Text = "Boost Enemy Levels",
                FlagID = "BstLevels",
                DescriptionFormat = "Enemies' Levels will be effectively increased by ${Value} and affect HP, Strength, and Magic. In-game level is not changed!",
            }.Register(FlagType.Challenge, true);

            public static Flag Stats1StageBehind = new Flag()
            {
                Text = "Stats One Stage Behind",
                FlagID = "St1Bhnd",
                DescriptionFormat = "Stat node values are one stage behind\n" +
                "Stage 1 stat nodes are 0.\n" +
                "Stage 10 stat nodes are based on stage 9. So stage 10 stats are impossible."
            }.Register(FlagType.Challenge, true);

            public static Flag NoShops = new Flag()
            {
                Text = "No Shops",
                FlagID = "NoShop",
                DescriptionFormat = "All shops are empty."
            }.Register(FlagType.Challenge, true);
        }

        public Tweaks()
        {
            new Boosts();
            new Challenges();
        }
    }
}
