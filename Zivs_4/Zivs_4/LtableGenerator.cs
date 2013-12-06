using System;
using System.Collections.Generic;

namespace Zivs_4
{
    class LtableGenerator
    {
        public bool[,] Ltable;

        private int power;

        public void GenerateTable(int power, List<int> polynom)
        {
            this.power = power;
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
            int result = 0;
            for (int i = 0; i < size; i++)
            {
                result += firstMatrix[i, xCoordinate] && secondMatrix[yCoordinate, i] ? 1 : 0;
            }

            return result % 2 == 1;
        }

        public bool CheckLinearity()
        {
            bool result = true;
            int rowIndex = power - 1;
            for (int i = 0; i < power; i++)
            {
                int columnIndex = (int) Math.Pow(2, i);
                result = result && Ltable[rowIndex, columnIndex];
            }
            return result;
        }
    }
}
