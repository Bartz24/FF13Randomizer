using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class TreasureDatabase
    {

        private ByteArray section1, section40;

        private DataStorePointerList<DataStoreString> itemIDs;

        private DataStoreArray<DataStoreTreasure> treasures;

        public DataStoreArray<DataStoreTreasure> Treasures
        {
            get => treasures;
        }

        public DataStorePointerList<DataStoreString> ItemIDs
        {
            get => itemIDs;
        }

        public TreasureDatabase(string filePath)
        {
            ByteArray allData = new ByteArray(File.ReadAllBytes(filePath));

            int itemStart = (int)allData.ReadUInt(0x20);
            int treasureStart = (int)allData.ReadUInt(0xA0);

            section1 = new ByteArray(allData.Data.SubArray(0, itemStart));

            section40 = new ByteArray(allData.Data.SubArray(treasureStart - 0x1C, 0x1C));

            ByteArray section2 = allData.SubArray(itemStart, treasureStart - 0x1C - itemStart);
            itemIDs = new DataStorePointerList<DataStoreString>(4, new DataStoreString() { Value = "" });
            itemIDs.LoadData(section2);

            ByteArray section3 = allData.SubArray(treasureStart, allData.Data.Length - treasureStart);
            treasures = new DataStoreArray<DataStoreTreasure>((allData.Data.Length - treasureStart) / 0xC, 0xC, 0);
            treasures.LoadData(section3);
        }

        public void Save(string filePath)
        {
            int newSize = section1.Data.Length + itemIDs.GetSize() + section40.Data.Length + treasures.GetSize();
            ByteArray data = new ByteArray(new byte[newSize]);

            section1.SetUInt(0x24, (uint)itemIDs.GetSize());

            int count = (int)section1.ReadUInt(0x4);
            for (int i = 2; i <= count;i++)
            {
                section1.SetUInt(i * 0x20, section1.ReadUInt((i-1)*0x20) + section1.ReadUInt((i - 1) * 0x20 + 4));
            }

            data.SetSubArray(0, section1.Data);
            itemIDs.SetData(data, section1.Data.Length);
            data.SetSubArray(section1.Data.Length + itemIDs.GetSize(), section40.Data);
            treasures.SetData(data, newSize - treasures.GetSize());

            File.WriteAllBytes(filePath, data.Data);
        }
    }
}
