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
using Microsoft.VisualBasic;

namespace Bank
{
    public partial class Form2 : Form
    {
        int sum, sum_vklad_kredit, max_vklad, min_vklad, all_sum_kredit;
        string year_t, now_year;
        byte i, i_min, i_max, kol_zero;

        public Form2()
        {
            InitializeComponent();
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e) //Выход из аккаунта
        {
            Form1 PasswordForm = new Form1();
            PasswordForm.Show();
            this.Hide();
        }

        //*********************************************Сохранение и открытие************************************************************
        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e) //Сохранение в файл
        {
            Stream myStream;//переменная для подключения к файлу
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt"; //фильры для сохранения
            saveFileDialog1.FilterIndex = 2;//кол-во отображения фильтров
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter myWritet = new StreamWriter(myStream); /*переменная myWriter нужна для записи в файл;
                    она связана с переменной, которая подключается к файлу */
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                string data = dataGridView1.Rows[i].Cells[j].Value.ToString() + "*";
                                //переменной data присваивается каждая ячейка. "*" нужна для ограничителя при открытии
                                myWritet.Write(data + ""); //запись в файл
                            }
                            myWritet.WriteLine();//переход на новую строкy
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message); //сообщение об ошибке
                    }
                    finally
                    {
                        myWritet.Close();//закрытие записи
                    }
                    myStream.Close();//закрытие файла
                }
            }
        }
        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)//Oткрытие файла
        {
            Stream myStream = null; //переменная подкючения к файлу
            openFileDialog1.Filter = "txt files (*.txt)|*.txt"; //фильтры
            openFileDialog1.FilterIndex = 2; //кол-во отображения фильтров
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    StreamReader myReader = new StreamReader(myStream);
                    //переменная myReader для чтения из файла, связанная с переменной открытия
                    string[] str;
                    int num = 0;
                    try
                    {
                        //создается массив, считывающий до конца строки, учитывая пробелы
                        string[] str1 = myReader.ReadToEnd().Split('\n');
                        num = str1.Count() - 1;/*переменной num присваитвается кол-во строк, где учитывались пробелы;
                        num отвечает за кол-во строк */
                        dataGridView1.RowCount = num;
                        for (int i = 0; i < num; i++)
                        {
                            str = str1[i].Split('*'); //присваивает в str каждый элемент до *
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                string data = str[j].Replace(" ", " ");
                                dataGridView1[j, i].Value = str[j];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myReader.Close();//закрытие чтения
                    }
                }
            }
        }
        //*******************************************************************************************************************************

        //*********************************************Обработка клавиши Enter*************************************************
        private void MaskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    maskedTextBox2.Select();
                }
                return;
            }
        }
        private void MaskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    maskedTextBox3.Select();
                }
                return;
            }
        }
        private void MaskedTextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    maskedTextBox4.Select();
                }
                return;
            }

        }
        private void MaskedTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    maskedTextBox5.Select();
                }
                return;
            }

        }
        private void MaskedTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    dateTimePicker1.Select();
                }
                return;
            }

        }
        private void MaskedTextBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    maskedTextBox1.Select();
                }
                return;
            }
        }
        private void dateTimePicker1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button2.Select();
                }
                return;
            }
        }
        private void Form2_Shown(object sender, EventArgs e)
        {
            maskedTextBox6.Select();
        }
        //*******************************************************************************************************************************

        private void Button2_Click(object sender, EventArgs e) //кнопка "Ввод"
        {
            // dataGridView1.RowCount++;

            if (maskedTextBox5.Text == "" || maskedTextBox1.Text == " , ," || maskedTextBox2.Text == "" || maskedTextBox3.Text == "" || maskedTextBox4.Text == "" || maskedTextBox6.Text == "" || Convert.ToInt32(maskedTextBox5.Text) > Convert.ToInt32(maskedTextBox6.Text))
            {
                MessageBox.Show("Проверьте введенные данные", "Ошибка ввода");
            }
            else
            {
                dataGridView1.RowCount++;
                dataGridView1[4, dataGridView1.RowCount - 1].Value = maskedTextBox5.Text;//кредит
                dataGridView1[0, dataGridView1.RowCount - 1].Value = maskedTextBox1.Text;//фио
                dataGridView1[1, dataGridView1.RowCount - 1].Value = maskedTextBox2.Text;//филиал
                dataGridView1[2, dataGridView1.RowCount - 1].Value = maskedTextBox3.Text;//номер счета
                dataGridView1[3, dataGridView1.RowCount - 1].Value = maskedTextBox4.Text;//сумма на счете            
                dataGridView1[5, dataGridView1.RowCount - 1].Value = dateTimePicker1.Text;//дата
            }
            //очистка TextBox'ов
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            maskedTextBox5.Clear();
        }
        private void ОчиститьВыборкиToolStripMenuItem_Click(object sender, EventArgs e) //очистка выборок
        {
            dataGridView2.Rows.Clear();
            dataGridView6.Rows.Clear();
            dataGridView3.Rows.Clear();
            listBox1.Items.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox4.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void ОчиститьВсеToolStripMenuItem_Click(object sender, EventArgs e) //очистка всего
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView6.Rows.Clear();
            dataGridView3.Rows.Clear();
            listBox1.Items.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox4.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            maskedTextBox6.Clear();
        }
        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e) //открытие окна статистики
        {
            Form4 StatForm = new Form4();
            StatForm.Show();
        }
        //*****************************************************Выборки*******************************************************************
        private void Button1_Click(object sender, EventArgs e) //кнопка "Выборка | Вкладка 1"
        {
            dataGridView2.Rows.Clear();
            sum = 0;
            textBox1.Clear();

            for (i = 0; i < dataGridView1.RowCount; i++) //клиенты, у которых на счету >1000
            {
                if (Convert.ToInt32(dataGridView1[3, i].Value) > 1000)
                {
                    sum = sum + Convert.ToInt32(dataGridView1[3, i].Value);
                    dataGridView2.RowCount++;
                    dataGridView2[0, dataGridView2.RowCount - 1].Value = dataGridView1[0, i].Value; //Фамилия
                    dataGridView2[1, dataGridView2.RowCount - 1].Value = dataGridView1[1, i].Value; //филиал
                    dataGridView2[2, dataGridView2.RowCount - 1].Value = dataGridView1[2, i].Value; //номер счета
                    dataGridView2[3, dataGridView2.RowCount - 1].Value = dataGridView1[3, i].Value; //Сумма                
                }
            }
            textBox1.Text = Convert.ToString(sum);
        }
        private void button3_Click(object sender, EventArgs e) //Кнопка "Выборка | Вкладка 2"
        {
            dataGridView3.Rows.Clear();
            textBox2.Clear();
            sum_vklad_kredit = 0;

            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                if ((String)(dataGridView1[4, i].Value) != "0")
                {
                    dataGridView3.RowCount++;
                    dataGridView3[0, dataGridView3.RowCount - 1].Value = dataGridView1[0, i].Value; //фамилия
                    dataGridView3[1, dataGridView3.RowCount - 1].Value = dataGridView1[4, i].Value; //сумма кредита
                    dataGridView3[2, dataGridView3.RowCount - 1].Value = dataGridView1[3, i].Value; //сумма на счете
                    sum_vklad_kredit = sum_vklad_kredit + Convert.ToInt32(dataGridView3[1, dataGridView3.RowCount - 1].Value) + Convert.ToInt32(dataGridView3[2, dataGridView3.RowCount - 1].Value);
                }
            }
            textBox2.Text = Convert.ToString(sum_vklad_kredit);
        }
        private void button4_Click(object sender, EventArgs e) //Кнопка "Выборка | Вкладка 3"
        {
            listBox1.Items.Clear();
            kol_zero = 0;

            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                if ((String)(dataGridView1[3, i].Value) == "0")
                {
                    listBox1.Items.Add(dataGridView1[0, i].Value);
                    kol_zero++;
                }
            }
            textBox3.Text = Convert.ToString(kol_zero);
        }
        private void button5_Click(object sender, EventArgs e) //Кнопка "Выборка | Вкладка 4"
        {
            max_vklad = Convert.ToInt32(dataGridView1[3, 0].Value);
            min_vklad = Convert.ToInt32(dataGridView1[3, 0].Value);
            i_min = 0;
            i_max = 0;
            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToInt32(dataGridView1[3, i].Value) > max_vklad)
                {
                    max_vklad = Convert.ToInt32(dataGridView1[3, i].Value);
                    i_max = i;
                }
            }
            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToInt32(dataGridView1[3, i].Value) < min_vklad)
                {
                    min_vklad = Convert.ToInt32(dataGridView1[3, i].Value);
                    i_min = i;
                }
            }
            textBox5.Text = (String)(dataGridView1[0, i_max].Value); //фамилия
            textBox7.Text = (String)(dataGridView1[0, i_min].Value);

            textBox6.Text = Convert.ToString(max_vklad); //сумма вклада
            textBox8.Text = Convert.ToString(min_vklad);
        }
        private void button6_Click(object sender, EventArgs e) //Кнопка "Выборка | Вкладка 5"
        {
            dataGridView6.Rows.Clear();
            now_year = Convert.ToString(DateTime.Now.Year);
            // year_t = "";
            all_sum_kredit = 0;

            for (i = 0; i < dataGridView1.RowCount; i++)
            {
                year_t = Convert.ToString(dataGridView1[5, i].Value).Substring(6);
                //Subtring(m) копирует из выбранного элемента, начиная с 7 позиции и до конца строки
                //Substring (n,m) копирует с n позиции m символов
                //now_year = DateTime.Now.Year.ToString();
                if (year_t == now_year)
                {
                    dataGridView6.RowCount++;
                    dataGridView6[1, dataGridView6.RowCount - 1].Value = dataGridView1[4, i].Value;  //Cумма кредита
                    dataGridView6[0, dataGridView6.RowCount - 1].Value = dataGridView1[0, i].Value;    //Фамилия
                    all_sum_kredit = all_sum_kredit + Convert.ToInt32(dataGridView1[4, i].Value);
                }
            }
            textBox4.Text = all_sum_kredit.ToString();
        }
        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 AboutForm = new Form5();
            AboutForm.ShowDialog();
        }
    }
}