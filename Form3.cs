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
    public partial class Form3 : Form
    {
        byte k;
        int sum_poz;
        public Form3()
        {
            InitializeComponent();
        }
        private void выходToolStripMenuItem1_Click(object sender, EventArgs e) //выход из аккаунта и автоматическое сохранение
        {
            Form1 PasswordForm = new Form1();
            //сохрание базы данных
            string myStream = @"C:\Users\DEN\Documents\VS Projects\Bank\Data\DBase.txt";//переменная для подключения к файлу
            StreamWriter myWritet = new StreamWriter(myStream); /*переменная myWriter нужна для записи в файл;
                    она связана с переменной, которая подключается к файлу */
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
            myWritet.Close();//закрытие записи
            PasswordForm.Show();
            this.Hide();
        }
        private void Form3_Load(object sender, EventArgs e) //запись в таблицу при загрузке формы_3
        {
            this.Height = 355;
            this.Width = 536;
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
            myReader.Close();//закрытие чтения
            Random day = new Random();
            textBox3.Text = Convert.ToString(day.Next(1, 61));//количество оставшихся дней
        }
        public void Form3_Shown(object sender, EventArgs e) //дозаполнение формы
        {
            textBox2.Text = Convert.ToString(dateTimePicker2.Text); //текущая дата
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToString(userNameToolStripMenuItem.Text) == Convert.ToString(dataGridView1[0, i].Value))
                {
                    textBox1.Text = Convert.ToString(dataGridView1[4, i].Value);
                    toolStripMenuItem2.Text = Convert.ToString(dataGridView1[2, i].Value);
                    toolStripMenuItem1.Text = Convert.ToString(dataGridView1[1, i].Value);
                    k = (byte)(i);
                }
            }
            if (Convert.ToInt32(textBox1.Text) == 0)
            {
                textBox3.Text = "0";
            }
        }

        //********************************************************оплата наличными**************************************************
        private void button2_Click(object sender, EventArgs e) //наличные
        {
            this.Height = 355;
            radioButton4.Visible = Convert.ToBoolean(1);
            radioButton5.Visible = Convert.ToBoolean(1);
            radioButton6.Visible = Convert.ToBoolean(1);
            label6.Visible = Convert.ToBoolean(1);
            label7.Visible = Convert.ToBoolean(1);
            label13.Visible = Convert.ToBoolean(1);
            maskedTextBox1.Visible = Convert.ToBoolean(1);
            maskedTextBox2.Visible = Convert.ToBoolean(1);
            panel4.Visible = Convert.ToBoolean(1);
            panel5.Visible = Convert.ToBoolean(1);
            OK_Cash.Visible = Convert.ToBoolean(1);
        }
        private void radioButton4_Click(object sender, EventArgs e) //оплата в рублях
        {
            MessageBox.Show("Для оплаты наличными вам необходимо воспользоваться ближайшим терминалом оплаты.", "Оплата", MessageBoxButtons.OK, MessageBoxIcon.Information);
            radioButton4.Visible = Convert.ToBoolean(0);
            radioButton5.Visible = Convert.ToBoolean(0);
            radioButton6.Visible = Convert.ToBoolean(0);
            label6.Visible = Convert.ToBoolean(0);
            label7.Visible = Convert.ToBoolean(0);
            label13.Visible = Convert.ToBoolean(0);
            maskedTextBox1.Visible = Convert.ToBoolean(0);
            maskedTextBox2.Visible = Convert.ToBoolean(0);
            OK_Cash.Visible = Convert.ToBoolean(0);
            radioButton4.Checked = Convert.ToBoolean(0);
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)//Оплата в долларах
        {
            if (radioButton5.Checked)
            {
                maskedTextBox1.ReadOnly = Convert.ToBoolean(0);
            }
            else
            {
                maskedTextBox1.ReadOnly = Convert.ToBoolean(1);
            }
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)//Oплата в евро
        {
            if (radioButton6.Checked)
            {
                maskedTextBox2.ReadOnly = Convert.ToBoolean(0);
            }
            else
            {
                maskedTextBox2.ReadOnly = Convert.ToBoolean(1);
            }
        }
        private void OK_Cash_Click(object sender, EventArgs e) //Подтверждение
        {
            if (radioButton5.Checked)
            {
                if (maskedTextBox1.Text == "  ,")
                {
                    MessageBox.Show("Введите курс валюты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Для оплаты наличными вам необходимо воспользоваться ближайшим терминалом оплаты.", "Оплата", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    radioButton4.Visible = Convert.ToBoolean(0);
                    radioButton5.Visible = Convert.ToBoolean(0);
                    radioButton6.Visible = Convert.ToBoolean(0);
                    label6.Visible = Convert.ToBoolean(0);
                    label7.Visible = Convert.ToBoolean(0);
                    label13.Visible = Convert.ToBoolean(0);
                    maskedTextBox1.Visible = Convert.ToBoolean(0);
                    maskedTextBox2.Visible = Convert.ToBoolean(0);
                    panel4.Visible = Convert.ToBoolean(0);
                    panel5.Visible = Convert.ToBoolean(0);
                    OK_Cash.Visible = Convert.ToBoolean(0);
                    radioButton5.Checked = Convert.ToBoolean(0);
                }
            }
            if (radioButton6.Checked)
            {
                if (maskedTextBox2.Text == "  ,")
                {
                    MessageBox.Show("Введите курс валюты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Для оплаты наличными вам необходимо воспользоваться ближайшим терминалом оплаты.", "Оплата", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    radioButton4.Visible = Convert.ToBoolean(0);
                    radioButton5.Visible = Convert.ToBoolean(0);
                    radioButton6.Visible = Convert.ToBoolean(0);
                    label6.Visible = Convert.ToBoolean(0);
                    label7.Visible = Convert.ToBoolean(0);
                    label13.Visible = Convert.ToBoolean(0);
                    maskedTextBox1.Visible = Convert.ToBoolean(0);
                    maskedTextBox2.Visible = Convert.ToBoolean(0);
                    OK_Cash.Visible = Convert.ToBoolean(0);
                    radioButton6.Checked = Convert.ToBoolean(0);
                }
            }
        }

        //*******************************************************оплата чеком********************************************************
        private void button1_Click(object sender, EventArgs e)
        {
            this.Height = 355;
            this.Width = 536;
            radioButton4.Visible = Convert.ToBoolean(0);
            radioButton5.Visible = Convert.ToBoolean(0);
            radioButton6.Visible = Convert.ToBoolean(0);
            label6.Visible = Convert.ToBoolean(0);
            label7.Visible = Convert.ToBoolean(0);
            label13.Visible = Convert.ToBoolean(0);
            maskedTextBox1.Visible = Convert.ToBoolean(0);
            maskedTextBox2.Visible = Convert.ToBoolean(0);
            panel4.Visible = Convert.ToBoolean(0);
            panel5.Visible = Convert.ToBoolean(0);
            OK_Cash.Visible = Convert.ToBoolean(0);
            radioButton5.Checked = Convert.ToBoolean(0);
            MessageBox.Show("Вам необходимо посетить отделение банка и предъявить расчетный банковский чек.", "Оплата", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //*******************************************************оплата картой********************************************************  
        private void maskedTextBox4_Click(object sender, EventArgs e)
        {
            maskedTextBox4.Clear();
        }
        private void maskedTextBox5_Click(object sender, EventArgs e)
        {
            maskedTextBox5.Clear();
        }
        private void maskedTextBox6_Click(object sender, EventArgs e)
        {
            maskedTextBox6.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Height = 495;
            radioButton4.Visible = Convert.ToBoolean(0);
            radioButton5.Visible = Convert.ToBoolean(0);
            radioButton6.Visible = Convert.ToBoolean(0);
            label6.Visible = Convert.ToBoolean(0);
            label7.Visible = Convert.ToBoolean(0);
            label13.Visible = Convert.ToBoolean(0);
            maskedTextBox1.Visible = Convert.ToBoolean(0);
            maskedTextBox2.Visible = Convert.ToBoolean(0);
            panel4.Visible = Convert.ToBoolean(0);
            panel5.Visible = Convert.ToBoolean(0);
            OK_Cash.Visible = Convert.ToBoolean(0);
            radioButton5.Checked = Convert.ToBoolean(0);

        }
        private void Pay_Click(object sender, EventArgs e) //подтверждение
        {
            sum_poz = 6573;
            if (maskedTextBox3.Text == "               " || maskedTextBox7.Text == "" || maskedTextBox4.Text == "" || maskedTextBox4.Text == "" || maskedTextBox5.Text == "" || maskedTextBox6.Text == "")
            {
                MessageBox.Show("Проверьте введенные данные", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (Convert.ToInt32(textBox1.Text) < Convert.ToInt32(maskedTextBox7.Text))
                {
                    MessageBox.Show("Сумма платежа не может быть больше суммы кредита", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    maskedTextBox7.Clear();
                }
                else
                {
                    string date = "20" + maskedTextBox5.Text + maskedTextBox4.Text;
                    string now_date = dateTimePicker1.Text;
                    //проверка срока действия карты
                    if (Convert.ToInt32(date) < Convert.ToInt32(now_date))
                    {
                        MessageBox.Show("Срок действия карты истек","Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //если срок не истек
                        if (maskedTextBox7.Text == textBox1.Text)
                        {
                            sum_poz += Convert.ToInt32(maskedTextBox7.Text);
                        }

                        int credit_t = Convert.ToInt32(dataGridView1[4, k].Value);
                        credit_t -= Convert.ToInt32(maskedTextBox7.Text);
                        dataGridView1[4, k].Value = Convert.ToString(credit_t);
                        MessageBox.Show("Оплата произведена успешно","Оплата", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maskedTextBox3.Clear();
                        maskedTextBox4.Clear();
                        maskedTextBox5.Clear();
                        maskedTextBox6.Clear();
                        maskedTextBox7.Clear();
                        Form3_Shown(sender, e);
                        this.Height = 355;
                    }
                }
            }
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 AboutForm = new Form5();
            AboutForm.ShowDialog();
        }
    }
}