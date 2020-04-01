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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Form2 main = Owner as Form2;
            for (int i = 0; i < main.dataGridView1.Rows.Count - 1; i++)
            {
                comboBox1.Items.Add(main.dataGridView1[1,i].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 main = Owner as Form2;
            foreach (DataGridViewRow row in main.dataGridView1.Rows)
            {
                row.Visible = true;
            }
            for (int i = 0; i < main.dataGridView1.Rows.Count - 1; i++)
            {
                if (comboBox1.Text != main.dataGridView1[1, i].Value.ToString())
                {
                    main.dataGridView1.Rows[i].Visible = false;
                }
            }
        }
    }
}
