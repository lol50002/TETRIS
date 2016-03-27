using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int ochki=0;
        int[,] tetr = new int[18,24];
        public int r = 20;
        Color c = Color.Green;
        Point location = new Point();
        Figure figure;
       // bykvaT bykvaT = new bykvaT();
  
        List<Point> wwwpointwww = new List<Point>();
        
        public Form1()
        {
            InitializeComponent();
        }

            //public Figure(Color clr) 
            //    { 
            //        this.clr = clr; 
            //        clr = Color.Yellow; 
            //        Random rnd = new Random(); 
            //        MainPoint = new Point(rnd.Next(0, 13) * 15, 0);
            //    }




        public bool canmove()
        {
            bool can = figure.buttompoint.Y + figure.r < pictureBox1.Height;
            foreach (Point point in wwwpointwww)
            {
                foreach (Point point1 in figure.FillPoints)
                {
                    if (point.Equals(new Point(point1.X, point1.Y + figure.r)))
                        return false;
                }
            }
                return can;
        }




        public void timer1_Tick(object sender, EventArgs e)
        {
            if (canmove())
            {
                figure.step();
                pictureBox1.Invalidate();
            }
            else
            {
                
                End();
                foreach (Point p in figure.FillPoints)
                {
                   wwwpointwww.Add(p);
                   
                    tetr[p.X /r, p.Y / r] = 1;
                }

                checkLine();
                //figure = new Sqare();
                Shape_Generate();
                pictureBox1.Invalidate();
            }
        }
        



        public void End()
        {
            if (figure.location.Y < 1)
            {
                pictureBox1.Invalidate();
                timer1.Enabled = false;
                MessageBox.Show("Вы проиграли!");
                this.Close();
            }
        }


        


        
        
    
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            figure.DrowFigure(e.Graphics);
            drawallpoints(e.Graphics);
        }






        public void drawallpoints(Graphics gr)
        {
            Pen p = new Pen(Color.Black, 2);
            SolidBrush b = new SolidBrush(c);
            foreach (Point point in wwwpointwww)
            {
                gr.FillRectangle(b, point.X, point.Y, r, r);
                gr.DrawRectangle(p, point.X, point.Y, r, r);
            }
            for (int i = 0; i < tetr.GetLength(0); i++)
            {
                for (int j = 0; j < tetr.GetLength(1); j++)
                {
                    if (tetr[i, j] != 0)
                    {
                        SolidBrush Brush = new SolidBrush(Color.Red);
                        gr.FillEllipse(Brush, new Rectangle(new Point(i * 20, j * 20), new Size(5, 5)));
                    }
                }
            }
        }




        private bool canLeft()
        {
            bool result = figure.SLT.X - figure.r >= 0;
            foreach (Point point in wwwpointwww)
            {
                foreach (Point point2 in figure.FillPoints)
                {
                    if (point.Equals(new Point(point2.X - figure.r, point2.Y)))
                        return false;
                }
            }
            return result;
        }





        private bool canRight()
        {
            bool result = figure.RightPoint.X + figure.r < pictureBox1.Width - 1;
            foreach (Point point in wwwpointwww)
            {
                foreach (Point point2 in figure.FillPoints)
                {
                    if (point.Equals(new Point(point2.X + figure.r, point2.Y)))
                        return false;
                }
            }

            return result;
        }
        private void canFall()
        {
            while (canmove())
            {
                figure.step();
                pictureBox1.Invalidate();
            }
        }

        public bool canrotate()
        {
            figure.rotate();
            foreach (Point point1 in figure.FillPoints)
            {
                if(point1.X>=0 && point1.Y<pictureBox1.Height && point1.X<pictureBox1.Width)
                {
                    foreach (Point point in wwwpointwww)
                    {

                        if (point.Equals(new Point(point1.X, point1.Y)))
                        {
                            figure.unrotate();
                            return false;
                        }
                    }
                }
                else
                {
                    figure.unrotate();
                    return false;
                }
            }
            figure.unrotate();
            return true;
            
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    {
                        if (canRight())
                            figure.location = new Point(figure.location.X + figure.r, figure.location.Y);
                    }
                    break;
                case Keys.A:
                    {
                        if (canLeft())
                            figure.location = new Point(figure.location.X - figure.r, figure.location.Y);
                    }
                    break;
                case Keys.S:
                    {
                        canFall();
                    }
                    break;
                case Keys.Space:
                    if(canrotate())
                        figure.rotate();
                    break;
            }
            pictureBox1.Invalidate();
        }




        public void step()
        {
            location = new Point(location.X, location.Y + r);
        }

        private void checkLine()
        {
            int i,j,k;
            
            for (i = 0; i < tetr.GetLength(1); i++)
            {
                bool isDel = true;
                for (j = 0; j < tetr.GetLength(0); j++)
                {
                    if (tetr[j, i] == 0)
                    {
                        isDel = false;
                        break;
                    }
                }
                if (isDel)
                {
                    ochki += 100;
                    for (j = 0; j < tetr.GetLength(0); j++)
                    {
                        tetr[j, i] = 0;
                        for (k = i; k > 0; k--)
                        {
                            tetr[j, k] = tetr[j, k - 1];
                        }
                    }
                    wwwpointwww.Clear();
                    for (k = 0; k < tetr.GetLength(0); k++)
                    {
                        for (j = 0; j < tetr.GetLength(1); j++)
                        {
                            if (tetr[k, j] != 0)
                            {
                                wwwpointwww.Add(new Point(k * 20, j* 20));
                            }
                        }
                    }
                    this.Text = "Твои ОЧКИ:" + ochki;
                }

            }
                    
            


        }


        private void Form1_Load(object sender, EventArgs e)
        {


            Shape_Generate();

        }

        private void Shape_Generate()
        {
            Random r = new Random();
            switch (r.Next(0, 6))
            {
                case 0:
                    figure = new Sqare();
                    break;
                case 1:
                    figure = new bykvaT();
                    break;
                case 2:
                    figure = new Lineyka();
                    break;
                case 3:
                    figure = new perevernytayL();
                    break;
                case 4:
                    figure = new drperevernytayL();
                    break;
                case 5:
                    figure = new molniy();
                    break;
                case 6:
                    figure = new molniyperever();
                    break;
            }
        }
        
    }
}
