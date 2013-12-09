using System;
using System.Collections.Generic;
using System.Numerics;

namespace Zivs_4
{
    class LtableGenerator
    {
        public BigInteger[,] Ltable;

        private int power;

        public void GenerateTable(int power, List<int> polynom)
        {
            this.power = power;
            int size = (int)Math.Pow(2, power);
            Ltable = new BigInteger[size, size];
            BigInteger[,] ltableTemp = new BigInteger[size, size];

            CtableGenerator cGenerator = new CtableGenerator();
            TtableGenerator tGenerator = new TtableGenerator();
            cGenerator.GenerateTable(size);
            tGenerator.GenerateTable(power, polynom);

            BigInteger[,] tranparentCMatirix = TransporateMatrix(cGenerator.Ctable, size);

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

        private BigInteger[,] TransporateMatrix(BigInteger[,] inputMatrix, int size)
        {
            BigInteger[,] result = new BigInteger[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = inputMatrix[j, i];
                }
            }

            return result;
        }

        private BigInteger MatrixCellMultResult(int size, BigInteger[,] firstMatrix, BigInteger[,] secondMatrix, int yCoordinate, int xCoordinate)
        {
            BigInteger result = 0;
            for (int i = 0; i < size; i++)
            {
                result += firstMatrix[yCoordinate, i] * secondMatrix[i, xCoordinate];
            }

            return result % 2;
        }

        public bool CheckLinearity()
        {
            bool result = true;
            int rowIndex = (int)Math.Pow(2, power - 1);
            List<double> twos = new List<double>();
            for (int i = 0; i < power; i++)
            {
                twos.Add(Math.Pow(2, i));
            }
            for (int i = 0; i < Math.Pow(2, power); i++)
            {
                if (!twos.Contains(i) && Ltable[rowIndex, i] != 0)
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
