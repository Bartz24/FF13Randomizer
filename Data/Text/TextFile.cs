using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FF13Data
{
    public class TextFile
    {
        public string Format { get; set; }
        public List<TextDialog> Text { get; set; } = new List<TextDialog>();

        public TextFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            Format = lines[0];
            string lineMode = "START";
            for (int l = 1; l < lines.Length; l++)
            {
                if (lineMode == "START")
                {
                    Regex regex = new Regex("{dialog (\\d+)(?:, singular=\"([^\"]*)\")?(?:, plural=\"([^\"]*)\")?}");
                    Match match = regex.Match(lines[l]);
                    if (match.Success)
                    {
                        Text.Add(new TextDialog() { Singular = match.Groups[2].Value, Plural = match.Groups[3].Value });
                        lineMode = "TEXT";
                    }
                }
                else if (lineMode == "TEXT")
                {
                    if (lines[l].Trim() != "{/dialog}")
                    {
                        if (String.IsNullOrEmpty(Text[Text.Count - 1].Text))
                            Text[Text.Count - 1].Text = lines[l];
                        else
                            Text[Text.Count - 1].Text += "\n" + lines[l];
                    }
                    else
                        lineMode = "START";
                }
            }
        }
    }
}
