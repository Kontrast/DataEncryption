using System;
using System.Collections.Generic;

namespace Zivs_4
{
    class LtableGenerator
    {
        public double[,] Ltable;

        private int power;

        public void GenerateTable(int power, List<int> polynom)
        {
            this.power = power;
            int size = (int)Math.Pow(2, power);
            Ltable = new double[size, size];
            double[,] ltableTemp = new double[size, size];

            CtableGenerator cGenerator = new CtableGenerator();
            TtableGenerator tGenerator = new TtableGenerator();
            cGenerator.GenerateTable(size);
            tGenerator.GenerateTable(power, polynom);

            double[,] tranparentCMatirix = TransporateMatrix(cGenerator.Ctable, size);

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

        private double[,] TransporateMatrix(double[,] inputMatrix, int size)
        {
            double[,] result = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = inputMatrix[j, i];
                }
            }

            return result;
        }

        private double MatrixCellMultResult(int size, double[,] firstMatrix, double[,] secondMatrix, int yCoordinate, int xCoordinate)
        {
            double result = 0;
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
