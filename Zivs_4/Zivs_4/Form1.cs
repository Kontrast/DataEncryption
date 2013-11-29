using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Zivs_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            List<int> polinomCoefficients = new List<int>();
            string labelText = "Polynom is ";
            int power = 1;

            if (checkBox1.Checked)
            {
                polinomCoefficients.Add(1);
                labelText += "x1 + ";
                power = 1;
            }

            if (checkBox2.Checked)
            {
                polinomCoefficients.Add(2);
                labelText += "x2 + ";
                power = 2;
            }

            if (checkBox3.Checked)
            {
                polinomCoefficients.Add(3);
                labelText += "x3 + ";
                power = 3;
            }

            if (checkBox4.Checked)
            {
                polinomCoefficients.Add(4);
                labelText += "x4 + ";
                power = 4;
            }

            if (checkBox5.Checked)
            {
                polinomCoefficients.Add(5);
                labelText += "x5 + ";
                power = 5;
            }

            if (checkBox6.Checked)
            {
                polinomCoefficients.Add(6);
                labelText += "x6 + ";
                power = 6;
            }

            LtableGenerator generator = new LtableGenerator();
            generator.GenerateTable(power, polinomCoefficients);

            int size = (int)Math.Pow(2, power);

            DataTable dt = new DataTable();

            for (int i = -1; i < size; i++)
            {
                dt.Columns.Add(i.ToString());
            }

            for (int i = 0; i < size; i++)
            {
                List<string> rowResult = new List<string>();
                rowResult.Add(i.ToString());
                for (int j = 0; j < size; j++)
                {
                    rowResult.Add(generator.Ltable[i, j] ? "1" : "0");
                }
                dt.Rows.Add(rowResult.ToArray());
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = dt;

            labelText += "1";
            label1.Text = labelText;
        }
    }
}
