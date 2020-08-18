﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Data
{
    public static class Extensions
    {
        public static double CubeRoot(double x)
        {
            if (x < 0)
                return -Math.Pow(-x, 1d / 3d);
            else
                return Math.Pow(x, 1d / 3d);
        }

        public static void Swap<T>(this List<T> list, int i1, int i2)
        {
            T temp = list[i1];
            list.Insert(i1, list[i2]);
            list.RemoveAt(i1 + 1);
            list.Insert(i2, temp);
            list.RemoveAt(i2 + 1);
        }
    }
}
