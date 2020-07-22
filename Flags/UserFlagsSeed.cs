using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{
    public class UserFlagsSeed
    {
        public static void Export(string folder, string seed, string version)
        {
            Directory.CreateDirectory(folder);
            string fileName = $"{folder}\\seedFlagHistory.csv";
            string output;
            if (File.Exists(fileName))
            {
                output = ReadFile(fileName);
            }
            else
            {
                output = "Version,Time/Date,Seed,Flags\n";
            }
            List<string> flagStrings = Flags.flags.Select(f => f.GetFlagString()).ToList();
            flagStrings.Sort();
            string newRow = $"{version},{DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss")},{seed},{String.Join(" ", flagStrings)}\n";
            string[] oldRows = output.Substring(output.IndexOf('\n') + 1).Split('\n');
            List<string> oldRowsList = new List<string>();
            for (int i = 0; i < 19 && i < oldRows.Length; i++)
            {
                oldRowsList.Add(oldRows[i]);
            }
            output = output.Substring(0, output.IndexOf('\n') + 1) + newRow + "\n" + String.Join("\n", oldRowsList);
            File.WriteAllText(fileName, output);
        }

        public static string ReadFile(string fileName)
        {
            if (!File.Exists(fileName))
                return "";
            string import = File.ReadAllText(fileName);
            return import;
        }
        public static List<UserFlagsSeed> Import(string folder)
        {
            List<UserFlagsSeed> list = new List<UserFlagsSeed>();
            string fileName = $"{folder}\\seedFlagHistory.csv";

            string import = ReadFile(fileName);
            bool firstLine = false;
            foreach (String line in import.Split('\n'))
            {
                if (!firstLine)
                {
                    firstLine = true;
                    continue;
                }

                string[] values = line.Split(',');
                if (values.Length == 4)
                {
                    try
                    {
                        UserFlagsSeed flagsSeed = new UserFlagsSeed();
                        flagsSeed.Version = values[0].Trim();
                        flagsSeed.TimeDate = values[1].Trim();
                        flagsSeed.Seed = values[2].Trim();
                        flagsSeed.FlagString = values[3].Trim();
                        flagsSeed.Valid = Flags.Import(flagsSeed.FlagString, true);
                        list.Add(flagsSeed);
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            return list;
        }

        public String Version { get; set; }
        public String TimeDate { get; set; }
        public String Seed { get; set; }
        public String FlagString { get; set; }
        public bool Valid { get; set; }
    }
}
