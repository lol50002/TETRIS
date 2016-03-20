using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    abstract class Figure
    {
        
        
        //Поля
        public int r = 20;
        Color c = Color.Green;
        public Point location = new Point();

        public Point RightPoint
        {
            get
            {
                Point res = location;
                foreach (Point p in FillPoints)
                {
                    if (res.X < p.X)
                    {
                        res = p;
                    }
                }
                return res;
            }
        }

        public virtual Point SLT
        {
            get
            {
                Point res = location;
                foreach (Point p in FillPoints)
                {
                    if (res.X > p.X)
                    {
                        res = p;
                    }
                }
                return res;
            }
        }
        public Point buttompoint
        {
            
            get
            {
                Point point1= new Point();
                point1= location;

                foreach (Point pointt in FillPoints)
                {
                    if (point1.Y < pointt.Y)
                        point1 = pointt;

                }
                return (point1);
            }
        }

        
        

        public abstract List<Point> FillPoints { get; }
        //Конструкторы

        public int state {get; set; }
        
        
        //Методы
        
        public void DrowFigure(Graphics gr)
        {
            Pen p = new Pen(Color.Black,2);
            SolidBrush b = new SolidBrush(c);
            foreach (Point point in FillPoints)
            {
                 gr.FillRectangle(b, point.X, point.Y, r, r);
                 gr.DrawRectangle(p,point.X,point.Y,r,r);
            }
        }


        public void step()
        {
            location = new Point(location.X,location.Y + r);
        }


        public virtual void rotate()
        {

        }


        public virtual void unrotate()
        {
        }
    }
}
