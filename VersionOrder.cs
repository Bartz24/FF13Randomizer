﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF13Randomizer
{
    public class VersionOrder
    {
        private static List<string> VersionHistory = new List<string>() { 
            "1.8.0.Pre",
            "1.8.0.Pre-2",
            "1.8.0.Pre-3",
            "1.8.0",
            "1.8.1",
            "1.8.2",
            "1.8.3",
            "1.8.4",
            "1.9.0.Pre",
            "1.9.0.Pre-2",
            "1.9.0.Pre-3",
            "1.9.0.Pre-4",
            "1.9.0.Pre-5",
            "1.9.0.Pre-6",
            "1.9.0.Pre-7",
            "1.9.0.Pre-8",
            FormMain.Version
        };

        public static int Compare(string a, string b)
        {
            return VersionHistory.IndexOf(a).CompareTo(VersionHistory.IndexOf(b));
        }
    }
}
