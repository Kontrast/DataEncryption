using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zivs_4
{
    class TtableGenerator
    {
        public bool[,] Ttable;

        public void GenerateTable(int size, List<int> polynom)
        {
            Ttable = new bool[size, size];

            LFSRInfo valueSets = LFSR.GenerateAllSets(polynom, size);
            for (int i = 0; i < valueSets.Sets.Count; i++)
            {
                Ttable[GenerateIndex(valueSets.Sets[i+1]),GenerateIndex(valueSets.Sets[i])] = true;
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
