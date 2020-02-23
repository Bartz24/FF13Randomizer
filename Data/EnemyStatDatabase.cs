using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class EnemyStatDatabase
    {

        private ByteArray section1, section40;

        private DataStorePointerList<DataStoreString> itemIDs;

        private DataStoreArray<DataStoreEnemy> enemies;

        public DataStoreArray<DataStoreEnemy> Enemies
        {
            get => enemies;
        }

        public DataStorePointerList<DataStoreString> ItemIDs
        {
            get => itemIDs;
        }

        public EnemyStatDatabase(string filePath)
        {
            ByteArray allData = new ByteArray(File.ReadAllBytes(filePath));

            int itemStart = (int)allData.ReadUInt(0x20);
            int enemyStart = (int)allData.ReadUInt(0xA0);

            section1 = new ByteArray(allData.Data.SubArray(0, itemStart));

            section40 = new ByteArray(allData.Data.SubArray(enemyStart - 0x400, 0x400));

            ByteArray section2 = allData.SubArray(itemStart, enemyStart - 0x400 - itemStart);
            itemIDs = new DataStorePointerList<DataStoreString>(4, new DataStoreString() { Value = "" });
            itemIDs.LoadData(section2);

            ByteArray section3 = allData.SubArray(enemyStart, allData.Data.Length - enemyStart);
            enemies = new DataStoreArray<DataStoreEnemy>((allData.Data.Length - enemyStart) / 0x168, 0x168, 0);
            enemies.LoadData(section3);
        }

        public void Save(string filePath)
        {
            int newSize = section1.Data.Length + itemIDs.GetSize() + section40.Data.Length + enemies.GetSize();
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
            enemies.SetData(data, newSize - enemies.GetSize());

            File.WriteAllBytes(filePath, data.Data);
        }
    }
}
