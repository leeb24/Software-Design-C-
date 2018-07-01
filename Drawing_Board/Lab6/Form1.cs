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
namespace Lab6
{
    
    public partial class Form1 : Form
    {
        private ArrayList shapearray = new ArrayList();

        bool clicknum = false; //false == 1st True == second 

        Form2 settings = new Form2();

        int howmany = 0;

        Point tempcoord1;
        Point tempcoord2;
        bool outline;
        bool fill;
        

        Brush Penco = Brushes.Black;
        Brush Recco = null;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Lab6 by Byoungsul Lee";

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapearray.Clear();
            howmany = 0;
            panel1.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (howmany - 1 >= 0)
            {
                shapearray.RemoveAt(howmany - 1);
                howmany--;
                panel1.Invalidate();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen custompen = new Pen(Penco, settings.list3 + 1);


            foreach (Shapes obj in shapearray)
            {
                obj.Draw(  settings.list3, e);
            }
        }

        public class Shapes 
        {
            public Point coord1;
            public Point coord2;
            public bool fillcheck;
            public bool outlinecheck;
            public Brush linecolor;
            public Brush fillcolor;
            public int penwidth;

            public virtual void Draw( int Width, PaintEventArgs a)
            {
                
            }
           

        }

        public class Line :Shapes
        {
            public Line(Point one , Point two)
            {
                coord1 = one;
                coord2 = two;
            }
            
            public override void Draw(  int Width , PaintEventArgs a)
            {
                Pen custompen = new Pen(linecolor, penwidth);

                a.Graphics.DrawLine(custompen, coord1, coord2);
                //a.Graphics.DrawString("print this", DefaultFont, Brushes.Blue, coord2);
            } 
        }

        public class Rectangle : Shapes
        {
            public Rectangle(Point one, Point two)
            {
                coord1 = one;
                coord2 = two;
            }
            public override void Draw(int Width, PaintEventArgs a)
            {
                Pen custompen = new Pen(linecolor, penwidth);
                if (coord1.X > coord2.X)
                {
                    int temp1 = coord1.X;
                    int temp2 = coord2.X;

                    coord1.X = temp2;
                    coord2.X = temp1;
                }
                if (coord1.Y > coord2.Y)
                {
                    int temp1 = coord1.Y;
                    int temp2 = coord2.Y;

                    coord1.Y = temp2;
                    coord2.Y = temp1;
                }
                if (fillcheck)
                {
                    a.Graphics.FillRectangle(fillcolor, coord1.X, coord1.Y, coord2.X - coord1.X, coord2.Y - coord1.Y);
                }
                if(outlinecheck)
                    a.Graphics.DrawRectangle(custompen,coord1.X,coord1.Y,coord2.X-coord1.X,coord2.Y-coord1.Y);
            }
        }

        public class Elipse : Shapes
        {
            public Elipse(Point one, Point two)
            {
                coord1 = one;
                coord2 = two;
            }
            public override void Draw( int Width, PaintEventArgs a)
            {
                Pen custompen = new Pen(linecolor, penwidth);

                if (coord1.X > coord2.X)
                {
                    int temp1 = coord1.X;
                    int temp2 = coord2.X;

                    coord1.X = temp2;
                    coord2.X = temp1;
                }
                if (coord1.Y > coord2.Y)
                {
                    int temp1 = coord1.Y;
                    int temp2 = coord2.Y;

                    coord1.Y = temp2;
                    coord2.Y = temp1;
                }
                if (fillcheck)
                {
                    a.Graphics.FillEllipse(fillcolor, coord1.X, coord1.Y, coord2.X - coord1.X, coord2.Y - coord1.Y);
                }
                if(outlinecheck)
                    a.Graphics.DrawEllipse(custompen, coord1.X, coord1.Y, coord2.X - coord1.X, coord2.Y - coord1.Y);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            settings.ShowDialog();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

            if(LineRadio.Checked)
            {
                if(clicknum == false)
                {
                    //MessageBox.Show("first click");
                    tempcoord1.X = e.X;
                    tempcoord1.Y = e.Y;

                    clicknum = true;
                }

                else if(clicknum)
                {
                    
                    tempcoord2.X = e.X;
                    tempcoord2.Y = e.Y;
 
                    Line newline = new Line(tempcoord1,tempcoord2);
                    
                    clicknum = false;
                    switch (settings.list1)
                    {
                        case 0:
                            Penco = Brushes.Black;
                            break;
                        case 1:
                            Penco = Brushes.Red;
                            break;
                        case 2:
                            Penco = Brushes.Blue;
                            break;
                        case 3:
                            Penco = Brushes.Green;
                            break;

                    }
                    newline.linecolor = Penco;
                    switch (settings.list2)
                    {
                        case 0:
                            Recco = Brushes.White;
                            break;
                        case 1:
                            Recco = Brushes.Black;
                            break;
                        case 2:
                            Recco = Brushes.Red;
                            break;
                        case 3:
                            Recco = Brushes.Blue;
                            break;
                        case 4:
                            Recco = Brushes.Green;
                            break;
                    }
                    newline.penwidth = settings.list3 + 1;
                    newline.fillcolor = Recco;
                    newline.fillcheck = settings.checkBox1.Checked;
                    newline.outlinecheck = settings.checkBox2.Checked;
                    shapearray.Add(newline);
                    howmany++;
                    panel1.Invalidate();
                }

               
            }
            if(Rectangleradio.Checked)
            {
                if (clicknum == false)
                {
                    
                    tempcoord1.X = e.X;
                    tempcoord1.Y = e.Y;

                    clicknum = true;
                }

                else if (clicknum)
                {
                   
                    tempcoord2.X = e.X;
                    tempcoord2.Y = e.Y;
                    clicknum = false;
                    if (settings.checkBox1.Checked || settings.checkBox2.Checked)
                    {
                        Rectangle newsq = new Rectangle(tempcoord1, tempcoord2);

                        

                        switch (settings.list1)
                        {
                            case 0:
                                Penco = Brushes.Black;
                                break;
                            case 1:
                                Penco = Brushes.Red;
                                break;
                            case 2:
                                Penco = Brushes.Blue;
                                break;
                            case 3:
                                Penco = Brushes.Green;
                                break;

                        }
                        newsq.linecolor = Penco;
                        switch (settings.list2)
                        {
                            case 0:
                                Recco = Brushes.White;
                                break;
                            case 1:
                                Recco = Brushes.Black;
                                break;
                            case 2:
                                Recco = Brushes.Red;
                                break;
                            case 3:
                                Recco = Brushes.Blue;
                                break;
                            case 4:
                                Recco = Brushes.Green;
                                break;
                        }
                        newsq.penwidth = settings.list3 + 1;
                        newsq.fillcolor = Recco;
                        newsq.fillcheck = settings.checkBox1.Checked;
                        newsq.outlinecheck = settings.checkBox2.Checked;
                        shapearray.Add(newsq);
                        howmany++;
                    }
                    else
                    {
                        MessageBox.Show("Fill or Outline Must be Checked");
                    }
                    panel1.Invalidate();
                }
            }
            if(ElipseRadio.Checked)
            {
                if (clicknum == false)
                {

                    tempcoord1.X = e.X;
                    tempcoord1.Y = e.Y;

                    clicknum = true;
                }

                else if (clicknum)
                {

                    tempcoord2.X = e.X;
                    tempcoord2.Y = e.Y;
                    clicknum = false;
                    if (settings.checkBox1.Checked || settings.checkBox2.Checked)
                    {
                        Elipse newci = new Elipse(tempcoord1, tempcoord2);

                        
                        switch (settings.list1)
                        {
                            case 0:
                                Penco = Brushes.Black;
                                break;
                            case 1:
                                Penco = Brushes.Red;
                                break;
                            case 2:
                                Penco = Brushes.Blue;
                                break;
                            case 3:
                                Penco = Brushes.Green;
                                break;

                        }
                        newci.linecolor = Penco;
                        switch (settings.list2)
                        {
                            case 0:
                                Recco = Brushes.White;
                                break;
                            case 1:
                                Recco = Brushes.Black;
                                break;
                            case 2:
                                Recco = Brushes.Red;
                                break;
                            case 3:
                                Recco = Brushes.Blue;
                                break;
                            case 4:
                                Recco = Brushes.Green;
                                break;
                        }

                        newci.penwidth = settings.list3 + 1;
                        newci.fillcolor = Recco;
                        newci.fillcheck = settings.checkBox1.Checked;
                        newci.outlinecheck = settings.checkBox2.Checked;
                        shapearray.Add(newci);
                        howmany++;
                    }
                    else
                    {
                        MessageBox.Show("Fill or Outline Must be Checked");
                    }
                    panel1.Invalidate();
                }
            }

            this.Invalidate();
        }

        
  }

   
}
