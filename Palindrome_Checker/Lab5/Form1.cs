using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        string[] nums = new string[10];
        bool errorflag = false;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Palindromes by Byoungsul Lee";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Drawing basic UI
            Font FontBold = new Font("Arial", 30, FontStyle.Bold);
          
            Graphics g = e.Graphics;
            g.DrawString("Find Numeric Palindromes", FontBold, Brushes.Black, 150,10);
            g.DrawString("Enter a starting integer (0-1,000,000,000): ", Font, Brushes.Black, 40, 94);
            g.DrawString("Enter count(1-100): ", Font, Brushes.Black,500, 94);

            if (errorflag) // if try catch gets an exception draw error message
            {
                g.DrawString("Please enter a positive integer within range", Font, Brushes.Black, 300, 400);
            }
           
            errorflag = false;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); //Clear previous listbox 
            string input = textBox1.Text;
            string howmany = textBox2.Text;
            int currentinc = 0 ;
            


            try
            {
                long comparenum = Int32.Parse(input);// convert for comparison
                int until = Int32.Parse(howmany);
                if (Int32.Parse(input) <= 1000000000 && Int32.Parse(input) >= 0 )
                {
                    do
                    {
                        string temp = comp m
                            arenum.ToString(); // need to be converted due to increment every do while step
                        string reversed = new string(temp.ToCharArray().Reverse().ToArray()); //Reverse to check for palindrome
                        long converted = Int32.Parse(reversed);
                        if (comparenum == converted)
                        {
                            listBox1.Items.Add(comparenum);// add to list box
                            currentinc++;
                        }
                        comparenum = comparenum + 1;
                    } while (currentinc != until); 
                }
                else
                {
                    errorflag = true;

                }

            }          
            
            catch(Exception ex) // For datatype exceptions
            {
                errorflag = true;
               
            }
            
            this.Invalidate();

        }
    }
}
