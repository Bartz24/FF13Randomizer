using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{   
public enum FlagType
    {
        Crystarium,
        Items,
        Enemies
    }

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
            }.Register(FlagType.Crystarium);

            public static Flag AbilitiesAnyRole = new Flag()
            {
                Text = "Abilities Appear in Any Role",
                FlagID = "AnyRoleAblty",
                DescriptionFormat = "Allows all non starting abilities to appear in any role.",
                FullDescriptionFormat = "Allows all non starting abilities to appear in any role."
            }.Register(FlagType.Crystarium);

            public static Flag ShuffleNodes = new Flag()
            {
                Text = "Shuffle Nodes in each Role",
                FlagID = "ShNodes",
                DescriptionFormat = "Shuffles all non-starting ability nodes inside a role.",
                FullDescriptionFormat = "Shuffles all non-starting ability nodes inside a role.\n" +
                "-This includes Stats, Abilities, ATB Levels, Accessories, and Role Levels."
            }.Register(FlagType.Crystarium);

            public static Flag RandStats = new Flag()
            {
                Text = "Randomize Stats",
                FlagID = "RanStat",
                DescriptionFormat = "Characters and roles are given random stat affinities. Variance of ${Value}%",
                FullDescriptionFormat = "Characters and roles are given random stat affinities. Variance of ${Value}%.\n" +
                "-Each character and role gets varied multipliers on stats based on the stage. These multipliers stack.\n" +
                "-The amount of nodes that appear is also related to the stat multiplier. For example: Higher HP multiplier also means more HP nodes will appear."
            }.Register(FlagType.Crystarium);

            public static Flag ScaledCPCost = new Flag()
            {
                Text = "Scaled CP Cost",
                FlagID = "ScCPCost",
                DescriptionFormat = "CP Cost scales down as stage increases.",
                FullDescriptionFormat = "CP Cost scales down as stage increases.\n" +
                "-Stage 1 is 1x multiplier\n" +
                "-Stage 5 is 0.7x multiplier\n" +
                "-Stage 9 and 10 are 0.5x multiplier"
            }.Register(FlagType.Crystarium);


            public static Flag HalfSecondaryCPCost = new Flag()
            {
                Text = "Half Secondary CP Cost",
                FlagID = "HfSecCP",
                DescriptionFormat = "CP Cost is halved on secondary roles.",
                FullDescriptionFormat = "CP Cost is halved on secondary roles. Applies on top of Scaled CP Cost."
            }.Register(FlagType.Crystarium);


            public static Flag LibraStart = new Flag()
            {
                Text = "Force Libra Start",
                FlagID = "Libra",
                DescriptionFormat = "Libra is a forced starting ability.",
                FullDescriptionFormat = "Libra is a forced starting ability."
            }.Register(FlagType.Crystarium);

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
            }.Register(FlagType.Items);

            public static Flag Drops = new Flag()
            {
                Text = "Randomize Enemy Drops",
                FlagID = "RandDrop",
                DescriptionFormat = "Enemy common and rare will be randomized. 'Rank' +/- ${Value}",
                FullDescriptionFormat = "Enemy common and rare will be randomized.\n" +
                "-Based on the 'rank' of each item.  New items will be replaced by items 'rank' +/- ${Value}.\n" +
                "-Material items (upgrade components) are given MORE weight and will appear more often as drops.\n" +
                "-Bosses will drop accessories and weapons more often"
            }.Register(FlagType.Items);

            public static Flag Shops = new Flag()
            {
                Text = "Shuffle Shops",
                FlagID = "ShShop",
                DescriptionFormat = "All shops except Unicorn Mart will shuffle locations.",
                FullDescriptionFormat = "All shops except Unicorn Mart will shuffle locations.\n" +
                "-Includes shops from special battle drops and treasures.\n" +
                "-Does not include Omnikit."
            }.Register(FlagType.Items);

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
                DescriptionFormat = "Elemental resistances will be shuffled between enemies.",
                FullDescriptionFormat = "Elemental resistances will be shuffled between enemies.\n" +
                "-Enemies resistant or immune to both physical and magical will only swap with those also resistant or immune.",
                Experimental = true
            }.Register(FlagType.Enemies);

            public static Flag Debuffs = new Flag()
            {
                Text = "Shuffle Debuff Resistances",
                FlagID = "ShDebffRes",
                DescriptionFormat = "Debuff resistances will be shuffled between enemies.",
                FullDescriptionFormat = "Debuff resistances will be shuffled between enemies.",
                Experimental = true
            }.Register(FlagType.Enemies);


            public static Flag RandStats = new Flag()
            {
                Text = "Randomize Stats",
                FlagID = "RanStat",
                DescriptionFormat = "Enemies' HP, Strength, Magic, Stagger Point, and Chain Resistance get randomized. Variance of ${Value}%",
                FullDescriptionFormat = "Enemies' HP, Strength, Magic, Stagger Point, and Chain Resistance get randomized. Variance of ${Value}%"
            }.Register(FlagType.Enemies);

            public static Flag RandLevel = new Flag()
            {
                Text = "Randomize Enemy Levels",
                FlagID = "RanLevels",
                DescriptionFormat = "Enemies' Levels will be shifted by up to +/- ${Value} and affect CP, HP, Strength, and Magic.",
                FullDescriptionFormat = "Enemies' Levels will be shifted by up to +/- ${Value} and affect CP, HP, Strength, and Magic.",
                Experimental = true
            }.Register(FlagType.Enemies);

            public static Flag BoostLevel = new Flag()
            {
                Text = "Boost Enemy Levels",
                FlagID = "BstLevels",
                DescriptionFormat = "[NOT AFFECTED BY PICKING PRESETS] Enemies' Levels will be effectively increased by ${Value} and affect HP, Strength, and Magic. In-game level is not changed!",
                FullDescriptionFormat = "[NOT AFFECTED BY PICKING PRESETS] Enemies' Levels will be effectively increased by ${Value} and affect HP, Strength, and Magic. In-game level is not changed!",
            }.Register(FlagType.Enemies);

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

                FlagValue levels = new FlagValue(RandLevel);
                levels.Range.MinRange.MinRange = 0;
                levels.Range.MaxRange.MaxRange = 50;
                levels.Range.Value = 0;
                RandLevel.SetFlagData(levels);

                FlagValue boost = new FlagValue(BoostLevel);
                boost.Range.MinRange.MinRange = 0;
                boost.Range.MaxRange.MaxRange = 100;
                boost.Range.Value = 0;
                BoostLevel.SetFlagData(boost);
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
