using System;
using System.Collections.Generic;
using System.Text;

namespace Zivs_4
{
    class TtableGenerator
    {
        public bool[,] Ttable;

        public void GenerateTable(int power, List<int> polynom)
        {
            int size = (int)Math.Pow(2, power);
            Ttable = new bool[size, size];

            LFSRInfo valueSets = LFSR.GenerateAllSets(polynom, power);
            for (int i = 0; i < valueSets.Sets.Count - 1; i++)
            {
                Ttable[GenerateIndex(valueSets.Sets[i + 1]),GenerateIndex(valueSets.Sets[i])] = true;
            }
        }

        private int GenerateIndex(List<bool> set)
        {
            int result;
            StringBuilder b = new StringBuilder();
            foreach (var s in set)
            {
                b.Append(s == false ? "0" :"1");
            }
            result = Convert.ToInt32(b.ToString(), 2);
            return result;
        }
    }


}
