using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FF13Randomizer
{
    class UserFlagsSeed
    {
        public static void Export(string folder, string seed, string version)
        {            
            Directory.CreateDirectory(folder);
            //string fileName = $"{folder}\\Flags{seed}.{DateTime.Now.ToString().Replace("-",".").Replace(":","")}.ff13fs";
            string fileName = $"{folder}\\latestSeed.txt";
            File.WriteAllText(fileName, seed);
            return;
            XmlWriter xmlWriter = XmlWriter.Create(fileName);

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("Seed");
            xmlWriter.WriteString(seed);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Version");
            xmlWriter.WriteString(version);
            xmlWriter.WriteFullEndElement();

            xmlWriter.WriteStartElement("Flags");
            Flags.flags.ForEach(f =>
              {
                  if (!f.FlagEnabled)
                      return;
                  xmlWriter.WriteStartElement("Flag");
                  xmlWriter.WriteAttributeString("id", f.FlagID);
                  xmlWriter.WriteEndElement();
              });
            xmlWriter.WriteFullEndElement();

            xmlWriter.WriteEndDocument();

            xmlWriter.Close();
        }

        public static string Import(string fileName, string version)
        {
            XmlReader xmlReader = XmlReader.Create(fileName);
            string seed = "";
            Flags.flags.ForEach(f => f.FlagEnabled = false);
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    if(xmlReader.Name == "Seed")
                    {
                        seed = xmlReader.Value;
                    }
                    if (xmlReader.Name == "Version")
                    {
                        // TODO
                    }
                    if (xmlReader.Name == "Flags")
                    {
                        // TODO
                    }
                    if (xmlReader.Name == "Flag")
                    {
                        Flags.flags.Where(f => f.FlagID == xmlReader.GetAttribute("id")).First().FlagEnabled = true;
                    }
                }
            }
            xmlReader.Close();
            return seed;
        }
    }
}
