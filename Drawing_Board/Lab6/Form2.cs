using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form2 : Form
    {
        public bool initial = true;
        public int list1=0;
        public int list2=0;
        public int list3=0;
        public bool check1;
        public bool check2;
        public Form2()
        {
            InitializeComponent();

            this.Text = "Settings";
            this.AcceptButton = button1;


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (initial)
            {
                listBox1.SelectedIndex = 0;
                listBox2.SelectedIndex = 0;
                listBox3.SelectedIndex = 0;
                checkBox2.Checked = true;
                initial = false;
            }
            else
            {
                listBox1.SelectedIndex = list1;
                listBox2.SelectedIndex = list2;
                listBox3.SelectedIndex = list3;
                checkBox1.Checked = check1;
                checkBox2.Checked = check2;
            }
        }

        private void button1_Click(object sender, EventArgs e) //OK
        {
            list1 = listBox1.SelectedIndex;
            list2 = listBox2.SelectedIndex;
            list3 = listBox3.SelectedIndex;
            check1 = checkBox1.Checked;
            check2 = checkBox2.Checked;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) //Cancel
        {
            this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
