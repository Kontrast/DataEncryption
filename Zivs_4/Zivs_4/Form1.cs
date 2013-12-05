using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

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
            StringBuilder labelText = new StringBuilder("Polynom is ");
            int power = 0;

            if (checkBox6.Checked)
            {
                polinomCoefficients.Add(6);
                labelText.Append("x6");
                power = power < 6 ? 6 : power;
            }

            if (checkBox5.Checked)
            {
                polinomCoefficients.Add(5);
                if (labelText[labelText.Length - 1] != ' ')
                {
                    labelText.Append(" + ");
                }
                labelText.Append("x5");
                power = power < 5 ? 5 : power;
            }

            if (checkBox4.Checked)
            {
                polinomCoefficients.Add(4);
                if (labelText[labelText.Length - 1] != ' ')
                {
                    labelText.Append(" + ");
                }
                labelText.Append("x4");
                power = power < 4 ? 4 : power;
            }

            if (checkBox3.Checked)
            {
                polinomCoefficients.Add(3);
                if (labelText[labelText.Length - 1] != ' ')
                {
                    labelText.Append(" + ");
                }
                labelText.Append("x3");
                power = power < 3 ? 3 : power;
            }

            if (checkBox2.Checked)
            {
                polinomCoefficients.Add(2);
                if (labelText[labelText.Length - 1] != ' ')
                {
                    labelText.Append(" + ");
                }
                labelText.Append("x2");
                power = power < 2 ? 2 : power;
            }

            if (checkBox1.Checked)
            {
                polinomCoefficients.Add(1);
                if (labelText[labelText.Length - 1] != ' ')
                {
                    labelText.Append(" + ");
                }
                labelText.Append("x1");
                power = power < 1 ? 1 : power;
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

            label1.Text = labelText.ToString();

            string messageText;

            if (generator.CheckLinearity())
            {
                messageText = "Generator is linear";
            }
            else
            {
                messageText = "Generator is not linear";
            }

            MessageBox.Show(messageText);
        }
    }
}
