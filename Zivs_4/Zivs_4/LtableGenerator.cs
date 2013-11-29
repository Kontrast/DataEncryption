using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zivs_4
{
    class LtableGenerator
    {
        public bool[,] Ltable;

        public void GenerateTable(int size, List<int> polynom)
        {
            Ltable = new bool[size, size];

            CtableGenerator cGenerator = new CtableGenerator();
            TtableGenerator tGenerator = new TtableGenerator();
            cGenerator.GenerateTable(size);
            tGenerator.GenerateTable(size, polynom);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    
                }
            }
        }


        private static int[][] ParallelMatrixMult(int size, int[][] m1, int[][] m2)
        {
            var result = new int[size][];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = new int[result.Length];
            }
            Parallel.For(0, size, delegate(int i)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i][j] = m1[i][0] * m2[0][j];
                    for (int k = 1; k < size; k++)
                    {
                        result[i][j] = result[i][j].Xor(m1[i][k] * m2[k][j]);
                    }
                }
            });

            return result;
        }
    }
}
