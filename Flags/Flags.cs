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
        Enemies,
        Other,
        Boost,
        Challenge
    }

    public class Flags
    {
        public static List<Flag> flags = new List<Flag>();

        public class CrystariumFlags
        {
            public static FlagBool2 NewAbilities = (FlagBool2)new FlagBool2("Abilities Appear in Any Role", "Force Libra Start")
            {
                Text = "Include New Abilities",
                FlagID = "NewAbility",
                DescriptionFormat = "Randomize what abilities appear in each role for each character.\n" +
                "Only abilities compatible with the character (animations) and role will be given.",
                ExtraDescriptionFormat = "Allows all non starting abilities to appear in any role. Ally AI and Auto-battle may be slightly broken and stupid at times.",
                ExtraDescriptionFormat2 = "Libra is a forced starting ability."
            }.Register(FlagType.Crystarium);

            public static Flag ShuffleNodes = new Flag()
            {
                Text = "Shuffle Nodes in each Role",
                FlagID = "ShNodes",
                DescriptionFormat = "Shuffles all non-starting ability nodes inside a role.\n" +
                "This includes Stats, Abilities, ATB Levels, Accessories, and Role Levels."
            }.Register(FlagType.Crystarium);

            public static FlagValue RandStats = (FlagValue)new FlagValue(0, 0, 100)
            {
                Text = "Randomize Stats",
                FlagID = "RanStat",
                DescriptionFormat = "Characters and roles are given random stat affinities. Variance of ${Value}%.\n" +
                "Each character and role gets varied multipliers on stats based on the stage. These multipliers stack.\n" +
                "The amount of nodes that appear is also related to the stat multiplier. For example: Higher HP multiplier also means more HP nodes will appear."
            }.Register(FlagType.Crystarium);
        }


        public class ItemFlags
        {
            public static FlagValue Treasures = (FlagValue)new FlagValue(0, 0, 100)
            {
                Text = "Randomize Treasures",
                FlagID = "RandTreas",
                DescriptionFormat = "Treasures will be randomized.\n" +
                "Based on the 'rank' of each item.  New items will be by items 'rank' +/- ${Value}.\n" +
                "Material items (upgrade components) are given LESS weight and will appear less often in treasures."
            }.Register(FlagType.Items);

            public static FlagValue Drops = (FlagValue)new FlagValue(0, 0, 100)
            {
                Text = "Randomize Enemy Drops",
                FlagID = "RandDrop",
                DescriptionFormat = "Enemy common and rare will be randomized.\n" +
                "Based on the 'rank' of each item.  New items will be replaced by items 'rank' +/- ${Value}.\n" +
                "Material items (upgrade components) are given MORE weight and will appear more often as drops.\n" +
                "Bosses will drop accessories and weapons more often"
            }.Register(FlagType.Items);

            public static Flag Shops = new Flag()
            {
                Text = "Shuffle Shops",
                FlagID = "ShShop",
                DescriptionFormat = "All shops except Unicorn Mart will shuffle locations.\n" +
                "Includes shops from special battle drops and treasures.\n" +
                "Does not include Omnikit."
            }.Register(FlagType.Items);
        }

        public class EnemyFlags
        {
            public static Flag Resistances = new Flag()
            {
                Text = "Shuffle Elemental Resistances",
                FlagID = "ShElemRes",
                DescriptionFormat = "Elemental resistances will be shuffled between enemies.\n" +
                "Enemies resistant or immune to both physical and magical will only swap with those also resistant or immune.",
                Experimental = true
            }.Register(FlagType.Enemies);

            public static Flag Debuffs = new Flag()
            {
                Text = "Shuffle Debuff Resistances",
                FlagID = "ShDebffRes",
                DescriptionFormat = "Debuff resistances will be shuffled between enemies.",
                Experimental = true
            }.Register(FlagType.Enemies);


            public static FlagValue RandStats = (FlagValue)new FlagValue(0, 0, 100)
            {
                Text = "Randomize Stats",
                FlagID = "RanEStat",
                DescriptionFormat = "Enemies' HP, Strength, Magic, Stagger Point, and Chain Resistance get randomized. Variance of ${Value}%"
            }.Register(FlagType.Enemies);

            public static FlagValue RandLevel = (FlagValue)new FlagValue(0, 0, 50)
            {
                Text = "Randomize Enemy Levels",
                FlagID = "RanLevels",
                DescriptionFormat = "Enemies' Levels will be shifted by up to +/- ${Value} and affect CP, HP, Strength, and Magic."
            }.Register(FlagType.Enemies);
        }

        public class Other
        {
            public static Flag Music = new Flag()
            {
                Text = "Shuffle Music",
                FlagID = "ShMusic",
                DescriptionFormat = "Shuffles a decent amount of loopable music tracks"
            }.Register(FlagType.Other);

            public static FlagValue RunSpeed = (FlagValue)new FlagValue(0, 0, 50)
            {
                Text = "Randomize Run Speed",
                FlagID = "RanRunSpd",
                DescriptionFormat = "Randomizes run speed for characters on the field. Variance of ${Value}%"
            }.Register(FlagType.Other);
        }

        public Flags()
        {
            new CrystariumFlags();
            new ItemFlags();
            new EnemyFlags();
            new Other();
        }

        public static bool Import(string flagString, bool simulate)
        {
            try
            {
                List<string> flags = flagString.Split(' ').ToList();
                Flags.flags.ForEach(f =>
                {
                    if (!simulate)
                        f.FlagEnabled = false;
                    flags.ForEach(fs => f.SetFlagString(fs, simulate));
                });
                Tweaks.tweaks.ForEach(f =>
                {
                    if (!simulate)
                        f.FlagEnabled = false;
                    flags.ForEach(fs => f.SetFlagString(fs, simulate));
                });
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public static string GetFlagString()
        {
            List<string> flagStrings = Flags.flags.Select(f => f.GetFlagString()).Where(f => !String.IsNullOrEmpty(f)).ToList();
            flagStrings.AddRange(Tweaks.tweaks.Select(f => f.GetFlagString()).Where(f => !String.IsNullOrEmpty(f)).ToList());
            flagStrings.Sort();
            return String.Join(" ", flagStrings);
        }
    }
}
