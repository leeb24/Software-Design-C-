using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {

        private int Queens = 0;
        private Board_SQ[,] Board = new Board_SQ[9, 9];// new datatype that holds multiple values for each square on the board
        bool win = false;

        public Form1()
        {
            InitializeComponent();

            this.Text = "Eight Queens by Byoungsul Lee";

            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    Board[i, j] = new Board_SQ(); // Create custom class for every block
                }

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            //Starting Coords 
            int startx = 100;
            int starty = 100;
            Pen border = new Pen(Brushes.Black, 2f);
            Graphics g = e.Graphics;
            string QNum = "You have ";
            QNum = QNum + Queens.ToString() + " queens on the board."; // message to display # of queens on board
            g.DrawString(QNum, Font, Brushes.Black, 225, 30);
        
            for (int y = 1; y <= 8; y++) // y axis squares 
            {
                for (int x = 1; x <= 8; x++) // x axis squares
                {
                    g.DrawRectangle(border, startx, starty, 50, 50); // Start from 100,100 coord

                    if (y % 2 == 0)
                    {
                        if (x % 2 == 0)
                        {
                            g.FillRectangle(Brushes.White, 100 + ((x - 1) * 50), 100 + ((y - 1) * 50), 50, 50);
                        }
                        else
                        {
                            g.FillRectangle(Brushes.Black, 100 + ((x - 1) * 50), 100 + ((y - 1) * 50), 50, 50);

                        }
                    }
                    else 
                    {
                        if ( x % 2 == 1)
                        {
                            g.FillRectangle(Brushes.White, 100 + ((x - 1) * 50), 100 + ((y - 1) * 50), 50, 50);
                            
                        }
                        else
                        {
                            g.FillRectangle(Brushes.Black, 100 + ((x - 1) * 50), 100 + ((y - 1) * 50), 50, 50);
                           
                        }
                    }
                    
                    if(checkBox1.Checked==true && Board[x, y].Threat == true)
                    {
                       
                        g.FillRectangle(Brushes.Red, 100 + ((x - 1) * 50), 100 + ((y - 1) * 50), 50, 50);
                       
                    }
                   
                    if(Queens == 8 && win == false)
                    {
                        MessageBox.Show("You did it!");
                        win = true;
                        
                    }
                    //Font myfont1 = new Font("arial", 10, FontStyle.Bold);
                    //int ov = Board[x, y].Overlap;
                    //string yay = ov.ToString();
                    //g.DrawString(yay, myfont1, Brushes.Blue, 100 + ((x - 1) * 50), 100 + ((y - 1) * 50));
                    
                    startx = startx + 50; // Increment x axis

                }

                startx = 100; //Reset X axis
                starty = starty + 50; //Increment Y

            }

            //End of Drawing Base Board

            //Now check for queens and draw them
            for(int y =1; y <= 8; y++)
            {
                for ( int x = 1; x <= 8; x++)
                {   
                    
                    if(Board[x,y].Queen == true && x%2 == 1 && y%2 == 1) //white tiles black queens
                    {
                        Font myfont = new Font("arial", 30, FontStyle.Bold);
                        g.DrawString("Q", myfont, Brushes.Black,100 + ((x-1)*50) , 100 + ((y - 1) * 50));
                    }
                    if (Board[x, y].Queen == true && x % 2 == 0 && y % 2 == 0)
                    {
                        Font myfont = new Font("arial", 30, FontStyle.Bold);
                        g.DrawString("Q", myfont, Brushes.Black, 100 + ((x - 1) * 50), 100 + ((y - 1) * 50));
                    }
                    if (Board[x, y].Queen == true && x % 2 == 0 && y % 2 == 1) //black tiles white queens
                    {
                        Font myfont = new Font("arial", 30, FontStyle.Bold);
                        g.DrawString("Q", myfont, Brushes.White, 100 + ((x - 1) * 50), 100 + ((y - 1) * 50));
                    }
                    if (Board[x, y].Queen == true && x % 2 == 1 && y % 2 == 0)
                    {
                        Font myfont = new Font("arial", 30, FontStyle.Bold);
                        g.DrawString("Q", myfont, Brushes.White, 100 + ((x - 1) * 50), 100 + ((y - 1) * 50));
                    }
                }
            }

            


        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (e.X >= 100 && e.Y >= 100 && e.X <= 500 && e.Y <= 500)
            {
                if (e.Button == MouseButtons.Left && Board[((e.X - 100) / 50) + 1 , ((e.Y - 100) / 50) + 1].Threat == false)
                {
                    int Bx;
                    int By;

                    Bx = ((e.X - 100) / 50) + 1;
                    By = ((e.Y - 100) / 50) + 1;
                    if (Board[Bx, By].Queen == false)
                    {

                        Board[Bx, By].Queen = true;
                        Queens++;
                        is_safe(); //Process threat for each square everytime queen is added
                    }
                   
                    this.Invalidate();

                }
                else //if (e.Button == MouseButtons.Left && Board[((e.X - 100) / 50) + 1, ((e.Y - 100) / 50) + 1].Threat == true)
                {
                    System.Media.SystemSounds.Beep.Play();
                    this.Invalidate();
                }

                if (e.Button == MouseButtons.Right && Board[((e.X - 100) / 50) + 1, ((e.Y - 100) / 50) + 1].Queen == true)
                {
                    int Bxx;
                    int Byy;

                    Bxx = ((e.X - 100) / 50) + 1;
                    Byy = ((e.Y - 100) / 50) + 1;
                    
                    Board[Bxx, Byy].Queen = false;
                    Queens--;

                    foreach (Board_SQ square in Board) //Re-calculate Board without deleted queen
                    {
                        square.Overlap = 0;
                        square.Brandnew = true;
                        square.Threat = false;
                        
                    }

                    is_safe();
                    this.Invalidate();
                    

                }
            }
           
        }

        public void is_safe()
        {
            

            for (int y = 1; y <= 8; y++)
            {
                for (int x = 1; x <= 8; x++)
                {
                    if(Board[x,y].Queen == true && Board[x,y].Brandnew == true)
                    {
                        // Start with diagonal squares and mark them threatend 
                        Board[x, y].Brandnew = false;
                        int By = y;
                        int By2 = y;
                        for(int Bx = x; Bx <= 8;Bx++ )
                        {
                            if (By <= 8)
                            {
                                Board[Bx,By].Threat = true;
                                Board[Bx, By].Overlap++;
                                By++;
                            }
                            if (By2 > 0)
                            {
                                Board[Bx, By2].Threat = true;
                                Board[Bx, By2].Overlap++;
                                By2--;
                            }
                        }

                        int By3 = y;
                        int By4 = y;

                        for (int Bx2 = x; Bx2 >0; Bx2--)
                        {
                            if (By3 <= 8)
                            {
                                Board[Bx2, By3].Threat = true;
                                Board[Bx2, By3].Overlap++;
                                By3++;
                            }
                            if (By4 > 0)
                            {
                                Board[Bx2, By4].Threat = true;
                                Board[Bx2, By4].Overlap++;
                                By4--;
                            }
                        }

                        // end of diagonal squares now cross zone 
                        int V1 = x;
                        int V2 = x;
                        int H1 = y;
                        int H2 = y;
                        for (; V1 <= 8; V1++ )
                        {
                            Board[V1,y].Threat = true;
                            Board[V1, y].Overlap++;
                        }
                        for (; V2 >0 ; V2--)
                        {
                            Board[V2, y].Threat = true;
                            Board[V2, y].Overlap++;
                        }

                        for (; H1 <= 8; H1++)
                        {
                            Board[x,H1].Threat = true;
                            Board[x,H1].Overlap++;
                        }
                        for (; H2 > 0; H2--)
                        {
                            Board[x, H2].Threat = true;
                            Board[x, H2].Overlap++;
                        }

                        Board[x, y].Overlap = 1;
                    }
                    
                }
            }
            
        }


        public class Board_SQ 
        {
            
            private bool threat ;
            private bool queen ;
            private int overlap;
            private bool brandnew;

            public Board_SQ()
            {
                threat = false;
                queen = false;
                overlap = 0;
                brandnew = true;
            }

           

            public bool Threat
            {
                get
                {
                    return threat;
                }
                set
                {
                    threat = value;

                }
            }

            public bool Queen
            {
                get
                {
                    return queen;
                }
                set
                {
                    queen = value;
                }
            }

            public int Overlap
            {
                get
                {
                    return overlap;
                }

                set
                {
                    overlap = value;
                }
            }
            public bool Brandnew
            {
                get
                {
                    return brandnew;
                }
                set
                {
                    brandnew = value;
                }
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            //RESET THE BOARD
            foreach (Board_SQ square in Board)
            {
                square.Threat = false;
                square.Queen = false;
                square.Overlap = 0;
                Queens = 0;
                win = false;
                square.Brandnew = true;
                this.Invalidate();
            }
        }
    }
}
