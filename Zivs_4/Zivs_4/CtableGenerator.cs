using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zivs_4
{
    public class CtableGenerator
    {
        public bool[,] Ctable;

        public void GenerateTable(int size)
        {
            Ctable = new bool[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Ctable[i, j] = GetCValue(i, j);
                }
            }
        }

        private bool GetCValue(int n, int k)
        {
            if (k > n)
            {
                return false;
            }
            return (Math.Round(GetFactorial(n) / (GetFactorial(k) * GetFactorial(n - k))) % 2) == 1 ? true : false;
        }

        private double GetFactorial(int x)
        {
            return x < 2 ? 1 : x * GetFactorial(x - 1);
        }
    }
}
