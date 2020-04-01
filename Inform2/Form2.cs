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

namespace Inform2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.S && e.Control)
            {               

                SaveFileDialog file = new SaveFileDialog();                
                file.Filter = "Текстовые файлы (*.txt)|*.txt";
                file.FileName = "InformData";
                file.ShowDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(file.FileName))
                    {
                        StreamWriter first = new StreamWriter(File.Open(file.FileName, FileMode.Append));
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            if (Equ((Image)dataGridView1[0, i].Value, Properties.Resources.Memo))
                            {
                                first.Write(" 1 ");
                            }
                            else if (Equ((Image)dataGridView1[0, i].Value, Properties.Resources.Meeting))
                            {
                                first.Write(" 2 ");
                            }
                            else if (Equ((Image)dataGridView1[0, i].Value, Properties.Resources.Task))
                            {
                                first.Write(" 3 ");
                            }
                            first.Write(dataGridView1[1, i].Value.ToString() + " ");
                            first.Write(dataGridView1[2, i].Value.ToString() + " ");
                            first.Write(dataGridView1[3, i].Value.ToString());
                        }
                        first.Close();
                    }
                    else
                    {
                        StreamWriter first = new StreamWriter(File.Open(file.FileName, FileMode.OpenOrCreate));
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (Equ((Image)dataGridView1[0, i].Value, Properties.Resources.Memo))
                            {
                                first.Write(" 1 ");
                            }
                            else if (Equ((Image)dataGridView1[0, i].Value, Properties.Resources.Meeting))
                            {
                                first.Write(" 2 ");
                            }
                            else if (Equ((Image)dataGridView1[0, i].Value, Properties.Resources.Task))
                            {
                                first.Write(" 3 ");
                            }
                            first.Write(dataGridView1[1, i].Value.ToString() + " ");
                            first.Write(dataGridView1[2, i].Value.ToString() + " ");
                            first.Write(dataGridView1[3, i].Value.ToString());
                        }
                        first.Close();
                    }
                }
                e.Handled = true;
            }
            if (e.KeyCode == Keys.O && e.Control)
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Текстовые файлы (*.txt)|*.txt";
                file.FileName = "InformData";
                file.ShowDialog();
                if (file.ShowDialog() == DialogResult.OK)
                {
                    TextReader second = File.OpenText(file.FileName);
                    string text = second.ReadLine();
                    string[] S = text.Trim(' ').Split();
                    dataGridView1.Rows.Add();
                    int count = 0;
                    int j = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (j > S.Length - 1) { break; }
                        dataGridView1.Rows.Add();
                        while (j != -1)
                        {
                            if (S[j] == "1")
                            {
                                dataGridView1[0, i].Value = Properties.Resources.Memo;
                            }
                            else if (S[j] == "2")
                            {
                                dataGridView1[0, i].Value = Properties.Resources.Meeting;
                            }
                            else if (S[j] == "3")
                            {
                                dataGridView1[0, i].Value = Properties.Resources.Task;
                            }
                            dataGridView1[1, i].Value = S[j + 1];
                            dataGridView1[2, i].Value = S[j + 2];
                            dataGridView1[3, i].Value = S[j + 3];
                            j += 4;
                            count += 4;
                            break;
                        }                       
                    }
                    second.Close();
                }
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Delete)
            {
                int i= dataGridView1.CurrentRow.Index;
                if(i!=-1)dataGridView1.Rows.RemoveAt(i);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {            
            comboBox1.Items.Add("Memo");
            comboBox1.Items.Add("Meeting");
            comboBox1.Items.Add("Task");
            checkBox2.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Owner = this;
            form.ShowDialog();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Owner = this;
            form.ShowDialog();
            int i = dataGridView1.Rows.Add();
            if (form.monthCalendar1.SelectionRange.Start < form.monthCalendar1.TodayDate)
            {
                MessageBox.Show("Wrong date! Please repet");
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
            }
            else
            {
                if (form.comboBox1.Text == "Memo")
                {
                    dataGridView1[0, i].Value = Properties.Resources.Memo;
                }
                if (form.comboBox1.Text == "Meeting")
                {
                    dataGridView1[0, i].Value = Properties.Resources.Meeting;
                }
                if (form.comboBox1.Text == "Task")
                {
                    dataGridView1[0, i].Value = Properties.Resources.Task;
                }
                if (form.comboBox1.Text == "")
                {
                    MessageBox.Show("Please enter correct type");
                }
                dataGridView1[1, i].Value = form.monthCalendar1.SelectionRange.Start.ToShortDateString();
                dataGridView1[2, i].Value = form.dateTimePicker1.Value.ToLongTimeString();
                dataGridView1[3, i].Value = form.textBox1.Text.ToString();
            }
        }
        
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {           
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                if (comboBox1.Text == "Memo")
                {
                    foreach(DataGridViewRow row in dataGridView1.Rows)
                    {
                        if( !Equ((Image)row.Cells[0].Value,Properties.Resources.Memo) && row.Cells[1].Value !=null)
                        { 
                            row.Visible = false;
                        }
                    }
                }
                else if (comboBox1.Text == "Meeting")
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!Equ((Image)row.Cells[0].Value, Properties.Resources.Meeting) && row.Cells[1].Value != null)
                        {
                            row.Visible = false;
                        }
                    }
                }
                if (comboBox1.Text == "Task")
                {
                    foreach(DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!Equ((Image)row.Cells[0].Value, Properties.Resources.Task) && row.Cells[1].Value != null)
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
            if (checkBox1.Checked == false)
            {
                checkBox2.Checked = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

                    
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Visible = true;
            }  
        }
        public static bool Equ(Image A, Image B)
        {
            Bitmap Bm1 = (Bitmap)A;
            Bitmap Bm2 = (Bitmap)B;
            if (Bm1.Size == Bm2.Size)
            {
                for (int i = 0; i < Bm1.Width; i++)
                {
                    for (int j = 0; j < Bm1.Height; j++)
                    {
                        if (Bm1.GetPixel(i, j) != Bm2.GetPixel(i, j))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            string text = $"Are you sure you want to delete the record {dataGridView1[1, i].Value} {dataGridView1[2, i].Value} {dataGridView1[3, i].Value} ";
            if (MessageBox.Show(text, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dataGridView1.Rows.RemoveAt(i);
            }
            else
            {
                return;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
            int i = dataGridView1.CurrentRow.Index;
            dataGridView1[1, i].Value = form.monthCalendar1.SelectionRange.Start.ToShortDateString();
            dataGridView1[2, i].Value = form.dateTimePicker1.Value.ToLongTimeString();
            dataGridView1[3, i].Value = form.textBox1.Text.ToString();
            if (form.comboBox1.Text == "Memo")
            {
                dataGridView1[0, i].Value = Properties.Resources.Memo;
            }
            else if (form.comboBox1.Text == "Meeting")
            {
                dataGridView1[0, i].Value = Properties.Resources.Meeting;
            }
            else if (form.comboBox1.Text == "Task")
            {
                dataGridView1[0, i].Value = Properties.Resources.Task;
            }
            else if (form.comboBox1.Text == "")
            {
                MessageBox.Show("Please enter correct type");
            }
        }
    }
}
