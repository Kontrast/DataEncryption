using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Zivs_4
{
    public class CtableGenerator
    {
        public BigInteger[,] Ctable;

        public void GenerateTable(int size)
        {
            Ctable = new BigInteger[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Ctable[i, j] = GetCValue(i, j);
                }
            }
        }

        private BigInteger GetCValue(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }
            return (GetFactorial(n) / (GetFactorial(k) * GetFactorial(n - k)) % 2);
        }

        private BigInteger GetFactorial(int x)
        {
            return x < 2 ? 1 : x * GetFactorial(x - 1);
        }
    }
}
