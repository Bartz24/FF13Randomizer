using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{
    public class Flags
    {
        public static List<Flag> flags = new List<Flag>();

        public class CrystariumFlags
        {
            public static Flag NewAbilities = new Flag()
            {
                Text = "Include New Abilities",
                FlagID = "NewAbility",
                DescriptionFormat = "Randomize what abilities appear in each role for each character.",
                FullDescriptionFormat = "Randomize what abilities appear in each role for each character.\n" +
                "-Only abilities compatible with the character (animations) and role will be given."
            }.Register();

            public static Flag ShuffleATBAccessory = new Flag()
            {
                Text = "Shuffle ATB Levels, Accessories, and Techniques",
                FlagID = "ShATBAcc",
                DescriptionFormat = "Shuffles the ATB Level node, Accessory nodes and techniques across all roles.",
                FullDescriptionFormat = "Shuffles the ATB Level node, Accessory nodes and techniques across all roles."
            }.Register();

            public static Flag ShuffleNonStat = new Flag()
            {
                Text = "Shuffle Non Stats in Role",
                FlagID = "ShNonStat",
                DescriptionFormat = "Shuffles all non-stat nodes inside a role.",
                FullDescriptionFormat = "Shuffles all non-stat nodes inside a role.\n" +
                "-This includes Abilities, ATB Levels, Accessories, and Role Levels."
            }.Register();

            public static Flag RandStats = new Flag()
            {
                Text = "Randomize Stats",
                FlagID = "RanStat",
                DescriptionFormat = "Stat nodes are shuffled across all character, and then adjusted.",
                FullDescriptionFormat = "Stat nodes are shuffled across all character, and then adjusted.\n" +
                "-Nodes across all characters are shuffled to provide a random balance of HP, Strength, and Magic.\n" +
                "-Each character is then assigned 300 'stat points' randomly to specialize in HP, Strength, or Magic. For example:\n" +
                "   -100 stat points in HP = no adjustments to HP nodes\n" +
                "   -50 stat points in HP = HP nodes cut in half\n" +
                "   -150 stat points in HP = HP nodes are 1.5x higher"
            }.Register();

            public static Flag ShuffleStage = new Flag()
            {
                Text = "Shuffle Node Order in Stage",
                FlagID = "ShNodeOrd",
                DescriptionFormat = "The order nodes appear in on a stage level is randomized.",
                FullDescriptionFormat = "The order nodes appear in on a stage level is randomized.\n" +
                "-Does not affect CP Cost.  CP Cost is based on location."
            }.Register();

            public static Flag ScaledCPCost = new Flag()
            {
                Text = "Scaled CP Cost",
                FlagID = "ScCPCost",
                DescriptionFormat = "CP Cost scales down as stage increases.",
                FullDescriptionFormat = "CP Cost scales down as stage increases.\n" +
                "-Stage 1 is 1x multiplier\n" +
                "-Stage 5 is 0.7x multiplier\n" +
                "-Stage 9 and 10 are 0.5x multiplier"
            }.Register();
        }


        public class ItemFlags
        {
            public static Flag Treasures = new Flag()
            {
                Text = "Randomize Treasures",
                FlagID = "RandTreas",
                DescriptionFormat = "Treasures will be randomized.",
                FullDescriptionFormat = "Treasures will be randomized.\n" +
                "-Based on the 'rank' of each item.  New items will be of similar 'rank'.\n" +
                "-Material items (upgrade components) are given LESS weight and will appear less often in treasures."
            }.Register();

            public static Flag Drops = new Flag()
            {
                Text = "Randomize Enemy Drops",
                FlagID = "RandDrop",
                DescriptionFormat = "Enemy common and rare will be randomized.",
                FullDescriptionFormat = "Enemy common and rare will be randomized.\n" +
                "-Based on the 'rank' of each item.  New items will be of similar 'rank'.\n" +
                "-Material items (upgrade components) are given MORE weight and will appear more often as drops."
            }.Register();

            public static Flag Shops = new Flag()
            {
                Text = "Shuffle Shops",
                FlagID = "ShShop",
                DescriptionFormat = "All shops except Unicorn Mart will shuffle locations.",
                FullDescriptionFormat = "All shops except Unicorn Mart will shuffle locations.\n" +
                "-Includes shops from special battle drops and treasures.\n" +
                "-Does not include Omnikit."
            }.Register();
        }

            public Flags()
        {
            new CrystariumFlags();
            new ItemFlags();
        }
    }
}
