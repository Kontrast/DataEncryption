using System;
using System.Collections.Generic;

namespace Zivs_4
{
    class LtableGenerator
    {
        public bool[,] Ltable;

        public void GenerateTable(int power, List<int> polynom)
        {
            int size = (int)Math.Pow(2, power);
            Ltable = new bool[size, size];
            bool[,] ltableTemp = new bool[size, size];

            CtableGenerator cGenerator = new CtableGenerator();
            TtableGenerator tGenerator = new TtableGenerator();
            cGenerator.GenerateTable(size);
            tGenerator.GenerateTable(power, polynom);

            bool[,] tranparentCMatirix = TransporateMatrix(cGenerator.Ctable, size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    ltableTemp[i, j] = MatrixCellMultResult(size, tranparentCMatirix, tGenerator.Ttable, i, j);
                }
            }
            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Ltable[i, j] = MatrixCellMultResult(size, ltableTemp, tranparentCMatirix, i, j);
                }
            }
        }

        private bool[,] TransporateMatrix(bool[,] inputMatrix, int size)
        {
            bool[,] result = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = inputMatrix[j, i];
                }
            }

            return result;
        }

        private bool MatrixCellMultResult(int size, bool[,] firstMatrix, bool[,] secondMatrix, int xCoordinate, int yCoordinate)
        {
            bool result = firstMatrix[0, xCoordinate] && secondMatrix[yCoordinate, 0];
            for (int i = 1; i < size; i++)
            {
                result = result || (firstMatrix[i, xCoordinate] && secondMatrix[yCoordinate, i]);
            }

            return result;
        }
    }
}
