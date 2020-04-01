using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inform2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_MouseMove(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(checkBox1, "Поставьте галочку, чтобы увидеть пароль");
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void textBox1_TextChange(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Введите логин");
        }

        private void textBox2_MouseMove(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox2, "Введите пароль");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = (char)0;
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "User" && textBox2.Text == "hello")
            {
                Hide();
                Form2 form = new Form2();
                form.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Wrong Login or Password");
            }
        }
    }
}
