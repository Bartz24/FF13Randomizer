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
                Text = "Shuffle Special Nodes",
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
                DescriptionFormat = "Characters and roles are given random stat affinities. Variance of ${Value}%",
                FullDescriptionFormat = "Characters and roles are given random stat affinities. Variance of ${Value}%.\n" +
                "-Each character and role gets varied multipliers on stats based on the stage. These multipliers stack.\n" +
                "-The amount of nodes that appear is also related to the stat multiplier. For example: Higher HP multiplier also means more HP nodes will appear."
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


            public static Flag HalfSecondaryCPCost = new Flag()
            {
                Text = "Half Secondary CP Cost",
                FlagID = "HfSecCP",
                DescriptionFormat = "CP Cost is halved on secondary roles.",
                FullDescriptionFormat = "CP Cost is halved on secondary roles. Applies on top of Scaled CP Cost."
            }.Register();


            public static Flag LibraStart = new Flag()
            {
                Text = "Force Libra Start",
                FlagID = "Libra",
                DescriptionFormat = "Libra is a forced starting ability.",
                FullDescriptionFormat = "Libra is a forced starting ability."
            }.Register();

            static CrystariumFlags()
            {
                FlagValue stats = new FlagValue(RandStats);
                stats.Range.MinRange.MinRange = 0;
                stats.Range.MaxRange.MaxRange = 100;
                stats.Range.Value = 0;
                RandStats.SetFlagData(stats);
            }
        }


        public class ItemFlags
        {
            public static Flag Treasures = new Flag()
            {
                Text = "Randomize Treasures",
                FlagID = "RandTreas",
                DescriptionFormat = "Treasures will be randomized. 'Rank' +/- ${Value}",
                FullDescriptionFormat = "Treasures will be randomized.\n" +
                "-Based on the 'rank' of each item.  New items will be by items 'rank' +/- ${Value}.\n" +
                "-Material items (upgrade components) are given LESS weight and will appear less often in treasures."
            }.Register();

            public static Flag Drops = new Flag()
            {
                Text = "Randomize Enemy Drops",
                FlagID = "RandDrop",
                DescriptionFormat = "Enemy common and rare will be randomized. 'Rank' +/- ${Value}",
                FullDescriptionFormat = "Enemy common and rare will be randomized.\n" +
                "-Based on the 'rank' of each item.  New items will be replaced by items 'rank' +/- ${Value}.\n" +
                "-Material items (upgrade components) are given MORE weight and will appear more often as drops.\n" +
                "-Bosses will drop accessories and weapons more often"
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

            static ItemFlags()
            {
                FlagValue treasures = new FlagValue(Treasures);
                treasures.Range.MinRange.MinRange = 0;
                treasures.Range.MaxRange.MaxRange = 100;
                treasures.Range.Value = 0;
                Treasures.SetFlagData(treasures);

                FlagValue drops = new FlagValue(Drops);
                drops.Range.MinRange.MinRange = 0;
                drops.Range.MaxRange.MaxRange = 100;
                drops.Range.Value = 0;
                Drops.SetFlagData(drops);
            }
        }

        public class EnemyFlags
        {
            public static Flag Resistances = new Flag()
            {
                Text = "Shuffle Elemental Resistances",
                FlagID = "ShElemRes",
                DescriptionFormat = "Elemental and physical/magical resistances will be shuffled between enemies.",
                FullDescriptionFormat = "Elemental and physical/magical resistances will be shuffled between enemies.\n" +
                "-Enemies resistant or immune to both physical and magical will only swap with those also resistant or immune.",
                Experimental = true
            }.Register();

            public static Flag Debuffs = new Flag()
            {
                Text = "Shuffle Debuff Resistances",
                FlagID = "ShDebffRes",
                DescriptionFormat = "Debuff resistances will be shuffled between enemies.",
                FullDescriptionFormat = "Debuff resistances will be shuffled between enemies.",
                Experimental = true
            }.Register();


            public static Flag RandStats = new Flag()
            {
                Text = "Randomize Stats",
                FlagID = "RanStat",
                DescriptionFormat = "Enemies' HP, Strength, Magic, Stagger Point, and Chain Resistance get randomized. Variance of ${Value}%",
                FullDescriptionFormat = "Enemies' HP, Strength, Magic, Stagger Point, and Chain Resistance get randomized. Variance of ${Value}%",
                Experimental = true
            }.Register();

            static EnemyFlags()
            {
                /*FlagBool res = new FlagBool(Resistances);
                res.Name = "No Physical/Magical Immunity";
                Resistances.SetFlagData(res);*/

                FlagValue stats = new FlagValue(RandStats);
                stats.Range.MinRange.MinRange = 0;
                stats.Range.MaxRange.MaxRange = 100;
                stats.Range.Value = 0;
                RandStats.SetFlagData(stats);
            }
        }

        public class Other
        {
            /*public static Flag Music = new Flag()
            {
                Text = "Shuffle Music",
                FlagID = "ShMusic",
                DescriptionFormat = "Shuffles all music tracks.",
                FullDescriptionFormat = "Shuffles all music tracks.\n" +
                "-Enemies resistant or immune to both physical and magical will only swap with those also resistant or immune.",
                Experimental = true
            }.Register();*/
        }

        public Flags()
        {
            new CrystariumFlags();
            new ItemFlags();
            new EnemyFlags();
            new Other();
        }
    }
}
