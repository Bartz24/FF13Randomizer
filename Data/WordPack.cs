using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class WordPack
    {
        private ByteArray[] sections = new ByteArray[15];

        public WordPack(string filePath)
        {
            ByteArray allData = new ByteArray(File.ReadAllBytes(filePath));
            int sectionI = 0;
            for (int i = 0; i < sections.Length; i++)
            {
                int start = (int)allData.ReadUInt((i + 1) * 4);
                int end = (int)allData.ReadUInt((i + 2) * 4);
                if (start == end)
                    continue;                
                sections[sectionI] = new ByteArray(allData.Data.SubArray(start, (end == 0 ? allData.Data.Length : end) - start - 4));
                sectionI++;
            }
        }

        public void Write()
        {
            for (int i = 0; i < sections.Length; i++)
            {
                File.WriteAllBytes($"word{i}.bin", sections[i].Data);
            }
        }
    }
}
