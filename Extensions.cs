using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public static class Extensions
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static void SetSubArray<T>(this T[] data, int index, T[] subArray)
        {
            for (int i = 0; i < subArray.Length; i++)
                data[index + i] = subArray[i];
        }

        public static T[] ReverseArray<T>(this T[] data)
        {
            T[] newArray = new T[data.Length];
            Array.Copy(data, newArray, data.Length);
            Array.Reverse(newArray);
            return newArray;
        }

        public static T[] Concat<T>(this T[] data, T[] data2)
        {
            T[] newArray = new T[data.Length+data2.Length];
            Array.Copy(data, newArray, data.Length);
            Array.Copy(data2, 0, newArray, data.Length, data2.Length);
            return newArray;
        }

        public static List<int> IndexesOf<T>(this T[] data, T[] data2)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < data.Length - data2.Length; i++)
            {
                if (data.SubArray(i, data2.Length).SequenceEqual(data2))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        public static T[] Replace<T>(this T[] data, T[] data2, T[] newData)
        {
            IndexesOf(data, data2).ForEach(i => data.SetSubArray(i, newData));
            return data;
        }        

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = RandomNum.randInt(0, n);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        public static void Shuffle<T>(this IList<T> list, Action<T, T> swapFunc)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = RandomNum.randInt(0, n);
                swapFunc.Invoke(list[n], list[k]);
            }
        }
    }
}
