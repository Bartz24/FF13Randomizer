using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreShop : DataStore
    {
        private byte[] header;
        private string[] itemIDs = new string[32];

        public override byte[] Data 
        {
            get 
            {
                byte[] itemData = new byte[itemPointers.Length * 4];
                for (int i = 0;i<itemPointers.Length;i++)
                {
                    itemData.SetUInt(i * 4, itemPointers[i]);
                }
                return header.Concat(itemData).Concat(new byte[] { 0, 0, 0, 0 });
            }
        }

        public string GetItemID(int i)
        {
            return itemIDs[i];
        }
        public void SetItemID(int i, string value)
        {
            itemIDs[i] = value;
        }

        public int ItemCount => itemIDs.Where(id => !string.IsNullOrEmpty(id)).Count();

        private uint[] itemPointers = new uint[32];

        public override void LoadData(byte[] data, int offset = 0)
        {
            byte[] shopData = data.SubArray(offset, GetDefaultLength());
            header = shopData.SubArray(0, 0x18);
            itemPointers = Enumerable.Range(0, itemPointers.Length).Select(i => shopData.ReadUInt(0x18 + 0x4 * i)).ToArray();
        }        

        public override int GetDefaultLength()
        {
            return 0x9C;
        }

        public override void UpdateStringPointers(DataStorePointerList<DataStoreString> list)
        {
            for (int i = 0; i < itemPointers.Length; i++)
            {
                UpdateStringPointer(list, itemIDs[i], itemPointers[i], v => itemIDs[i] = v, v => itemPointers[i] = v);
            }
        }
    }
}
