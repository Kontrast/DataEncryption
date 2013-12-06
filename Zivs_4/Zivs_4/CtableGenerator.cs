using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zivs_4
{
    public class CtableGenerator
    {
        public double[,] Ctable;

        public void GenerateTable(int size)
        {
            Ctable = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Ctable[i, j] = GetCValue(i, j);
                }
            }
        }

        private double GetCValue(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }
            return (GetFactorial(n) / (GetFactorial(k) * GetFactorial(n - k)) % 2);
        }

        private double GetFactorial(int x)
        {
            return x < 2 ? 1 : x * GetFactorial(x - 1);
        }
    }
}
