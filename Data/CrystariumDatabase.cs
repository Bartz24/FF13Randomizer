using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class CrystariumDatabase
    {

        private ByteArray section1, section40;

        private DataStorePointerList<DataStoreString> abilityIDs;

        private DataStoreArray<DataStoreCrystarium> crystarium;

        public DataStoreArray<DataStoreCrystarium> Crystarium
        {
            get => crystarium;
        }

        public DataStorePointerList<DataStoreString> AbilityIDs
        {
            get => abilityIDs;
        }

        public CrystariumDatabase(string filePath)
        {
            ByteArray allData = new ByteArray(File.ReadAllBytes(filePath));

            int abilityStart = (int)allData.ReadUInt(0x20);
            int crystariumStart = (int)allData.ReadUInt(0xA0);

            section1 = new ByteArray(allData.Data.SubArray(0, abilityStart));

            section40 = new ByteArray(allData.Data.SubArray(crystariumStart - 40, 40));

            ByteArray section2 = allData.SubArray(abilityStart, crystariumStart - 40 - abilityStart);
            abilityIDs = new DataStorePointerList<DataStoreString>(4,new DataStoreString() { Value = "" });
            abilityIDs.LoadData(section2);

            ByteArray section3 = allData.SubArray(crystariumStart, allData.Data.Length - crystariumStart);
            crystarium = new DataStoreArray<DataStoreCrystarium>((allData.Data.Length - crystariumStart) / 0xC, 0xC, 0);
            crystarium.LoadData(section3);
        }

        public void Save(string filePath)
        {
            int newSize = section1.Data.Length + abilityIDs.GetSize() + section40.Data.Length + crystarium.GetSize();
            ByteArray data = new ByteArray(new byte[newSize]);

            section1.SetUInt(0x24, (uint)abilityIDs.GetSize());

            int count = (int)section1.ReadUInt(0x4);
            for (int i = 2; i <= count;i++)
            {
                section1.SetUInt(i * 0x20, section1.ReadUInt((i-1)*0x20) + section1.ReadUInt((i - 1) * 0x20 + 4));
            }

            data.SetSubArray(0, section1.Data);
            abilityIDs.SetData(data, section1.Data.Length);
            data.SetSubArray(section1.Data.Length + abilityIDs.GetSize(), section40.Data);
            crystarium.SetData(data, newSize - crystarium.GetSize());

            File.WriteAllBytes(filePath, data.Data);
        }
    }
}
