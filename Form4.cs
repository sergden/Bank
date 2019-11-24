using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Bank
{
    public partial class Form4 : Form
    {
        int sum_pozitiv = 0;
        public Form4()
        {
            InitializeComponent();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e) //закрытие формы
        {
            this.Hide();
        }
        private void Form4_Shown(object sender, EventArgs e) //запись в таблицу при загрузке формы_4
        {
            //Чтение из файла
            String myStream = @"C:\Users\DEN\Documents\VS Projects\Bank\Data\DBase.txt"; //переменная подкючения к файлу
            //переменная myReader для чтения из файла, связанная с переменной открытия
            StreamReader myReader = new StreamReader(myStream);
            string[] str;
            int num = 0;
            //создается массив, считывающий до конца строки, учитывая пробелы
            string[] str1 = myReader.ReadToEnd().Split('\n');
            num = str1.Count() - 1;/*переменной num присваитвается кол-во строк, где учитывались пробелы;
                        num отвечает за кол-во строк */
            dgv1.RowCount = num;
            for (int i = 0; i < num; i++)
            {
                str = str1[i].Split('*'); //присваивает в str каждый элемент до *
                for (int j = 0; j < dgv1.ColumnCount; j++)
                {
                    string data = str[j].Replace(" ", " ");
                    dgv1[j, i].Value = str[j];
                }

            }
            myReader.Close();//закрытие чтения
            string myStream1 = @"C:\Users\DEN\Documents\VS Projects\Bank\Data\t_vozvr.txt";
            StreamReader myReader1 = new StreamReader(myStream1);
            sum_pozitiv = Convert.ToInt32(myReader1.ReadToEnd());
            myReader1.Close();
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            chart2.Series[0].Points.Clear();
            chart1.Series[0].Points.Clear();
            int sum_negativ = 0;
            for (int i = 0; i < dgv1.RowCount; i++) //выборка из таблицы сумм кредитов
            {
                sum_negativ += Convert.ToInt32(dgv1[4, i].Value);
            }

            //вычисление сколько процентов составляет одно число от другого
            int sum = sum_pozitiv + sum_negativ;
            double pozitiv = Math.Round(((sum_pozitiv * 1.0) / (sum * 1.0)) * 100);
            double negativ = Math.Round(((sum_negativ * 1.0) / (sum * 1.0)) * 100);

            //************************************************************диаграмма_1****************
            //запись в диаграмму данных о возвращенных кредитах в рублях
            chart1.Series[0].Points.Add(sum_pozitiv);
            chart1.Series[0].Points[0].Color = Color.Yellow;
            chart1.Series[0].Points[0].AxisLabel = "Возвр.";
            chart1.Series[0].Points[0].LegendText = "Возвр.";
            chart1.Series[0].Points[0].Label = Convert.ToString(sum_pozitiv);

            //запись в диаграмму данных о невозвращенных кредитах в рублях
            chart1.Series[0].Points.Add(sum_negativ);
            chart1.Series[0].Points[1].Color = Color.Red;
            chart1.Series[0].Points[1].AxisLabel = "Невозвр.";
            chart1.Series[0].Points[1].LegendText = "Невозвр.";
            chart1.Series[0].Points[1].Label = Convert.ToString(sum_negativ);


            //************************************************************диаграмма_2****************
            //запись в диаграмму данных о возвращенных кредитах в %
            chart2.Series[0].Points.Add(pozitiv);
            chart2.Series[0].Points[0].Color = Color.Yellow;
            chart2.Series[0].Points[0].AxisLabel = "Возвр.";
            chart2.Series[0].Points[0].LegendText = "Возвр.";
            chart2.Series[0].Points[0].Label = Convert.ToString(pozitiv);

            //запись в диаграмму данных о невозвращенных кредитах в %
            chart2.Series[0].Points.Add(negativ);
            chart2.Series[0].Points[1].Color = Color.Red;
            chart2.Series[0].Points[1].AxisLabel = "Невозвр.";
            chart2.Series[0].Points[1].LegendText = "Невозвр.";
            chart2.Series[0].Points[1].Label = Convert.ToString(negativ);
        }
        private void btn_clear_Click(object sender, EventArgs e) //очистка диаграмм
        {
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
        }
    }
}