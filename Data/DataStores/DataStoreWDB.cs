using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public class DataStoreWDB<T> : DataStore where T : DataStore, new()
    {
        protected byte[] header;

        public DataStoreIDList IdList { get; set; }

        public DataStorePointerList<DataStoreString> StringList { get; set; }

        protected byte[] section;

        public DataStoreList<T> DataList { get; set; }

        public T this[string id]
        {
            get { return DataList[IdList.IndexOf(id) - 4]; }
        }
        public T this[Identifier id]
        {
            get { return this[id.ID]; }
        }


        public override void LoadData(byte[] data, int offset = 0)
        {
            header = data.SubArray(0, 0x10);
            int stringStart = (int)data.ReadUInt(0x20);
            IdList = new DataStoreIDList();
            IdList.LoadData(data.SubArray(0x10, stringStart - 0x10));

            StringList = new DataStorePointerList<DataStoreString>(new DataStoreString() { Value = "" });
            StringList.LoadData(data.SubArray(IdList[0].Offset, IdList[0].DataSize));

            section = data.SubArray(IdList[1].Offset, IdList[4].Offset - IdList[1].Offset);

            DataList = new DataStoreList<T>();
            DataList.LoadData(data.SubArray(IdList[4].Offset, data.Length - IdList[4].Offset));
            DataList.ToList().ForEach(d => d.UpdateStringPointers(StringList));
        }

        public override byte[] Data
        {
            get
            {
                DataList.ToList().ForEach(d => d.UpdateStringPointers(StringList));
                IdList["!!string"].DataSize = StringList.Length;                
                IdList.UpdateOffsets();
                return header.Concat(IdList.Data).Concat(StringList.Data).Concat(section).Concat(DataList.Data);
            }
        }

        public override int GetDefaultLength()
        {
            return -1;
        }
    }
}
