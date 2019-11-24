using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank
{
    public partial class Form1 : Form
    {
        Form2 MainForm = new Form2();
        Form3 UserForm = new Form3();
        Form4 StatForm = new Form4();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //login
        {
            if (textBox1.Text == "ADMIN" && textBox2.Text == "ADMIN")
            {
                MainForm.Show();
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
            }
            else if (textBox1.Text == "Д.Л.Иванов" && textBox2.Text == "User")
            {
                UserForm.Show();
                UserForm.userNameToolStripMenuItem.Text = this.textBox1.Text; //передача логина на форму 3
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
            }
            else if (textBox1.Text == "П.Д.Семёнов" && textBox2.Text == "User")
            {
                UserForm.Show();
                UserForm.userNameToolStripMenuItem.Text = this.textBox1.Text; //передача логина на форму 3
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
            }
            else if (textBox1.Text == "П.П.Петров" && textBox2.Text == "User")
            {
                UserForm.Show();
                UserForm.userNameToolStripMenuItem.Text = this.textBox1.Text; //передача логина на форму 3
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
            }
            else if (textBox1.Text == "Ф.Х.Клён" && textBox2.Text == "User")
            {
                UserForm.Show();
                UserForm.userNameToolStripMenuItem.Text = this.textBox1.Text; //передача логина на форму 3
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
            }
            else if (textBox1.Text == "С.С.Яблочкин" && textBox2.Text == "User")
            {
                UserForm.Show();
                UserForm.userNameToolStripMenuItem.Text = this.textBox1.Text; //передача логина на форму 3
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
            }
            else if (textBox1.Text == "Г.Г.Сидоров" && textBox2.Text == "User")
            {
                UserForm.Show();
                UserForm.userNameToolStripMenuItem.Text = this.textBox1.Text; //передача логина на форму 3
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
            }
            else if (textBox1.Text == "Л.В.Шаманов" && textBox2.Text == "User")
            {
                UserForm.Show();
                UserForm.userNameToolStripMenuItem.Text = this.textBox1.Text; //передача логина на форму 3
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
            }
            else if (textBox1.Text == "Н.Р.Петров" && textBox2.Text == "User")
            {
                UserForm.Show();
                UserForm.userNameToolStripMenuItem.Text = this.textBox1.Text; //передача логина на форму 3
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
            }
            else if (textBox1.Text == "Я.М.Яковлев" && textBox2.Text == "User")
            {
                UserForm.Show();
                UserForm.userNameToolStripMenuItem.Text = this.textBox1.Text; //передача логина на форму 3
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
            }
            else if (textBox1.Text == "SuperUser" && textBox2.Text == "SuperUser")
            {
                textBox1.Clear();
                textBox2.Clear();
                UserForm.Show();
                StatForm.Show();
                UserForm.userNameToolStripMenuItem.Text = "Д.Л.Иванов";
                MainForm.Show();
            }
            else
            {
                MessageBox.Show("Ошибка ввода логина/пароля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Select();
            }
        }
        private void button3_Click(object sender, EventArgs e) //exit
        {
            Application.Exit();
        }

        //****************************************обработка клавиши enter******************************************
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    textBox2.Select();
                }
                return;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button1.PerformClick();
                }
                return;
            }
        }
    }
}