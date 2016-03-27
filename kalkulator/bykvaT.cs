using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class bykvaT : Figure
    {

        public override List<Point> FillPoints
        {
           
            
            get
            {  
                List<Point> result = new List<Point>();
                switch(state)
                {
                    case 0:
                        result.Add(location);
                        result.Add(new Point(location.X+r, location.Y ));
                        result.Add(new Point(location.X+2*r, location.Y));
                        result.Add(new Point(location.X +r, location.Y+r));
                        break;
                    case 1:
                        result.Add(location);
                        result.Add(new Point(location.X, location.Y+r ));
                        result.Add(new Point(location.X-r, location.Y+r));
                        result.Add(new Point(location.X , location.Y+r*2));
                        break;
                    case 2:
                        result.Add(location);
                        result.Add(new Point(location.X-r, location.Y));
                        result.Add(new Point(location.X-r, location.Y-r));
                        result.Add(new Point(location.X-2*r, location.Y));
                        break;
                    case 3:
                        result.Add(location);
                        result.Add(new Point(location.X, location.Y - r));
                        result.Add(new Point(location.X+r , location.Y - r));
                        result.Add(new Point(location.X, location.Y - r * 2));
                        break;
                }

                return result;
            }

        }

        public override void rotate()
        {
            state = (state + 1) % 4;

        }

        public override void unrotate()
        {
            state = (state - 1);
            if (state == -1)
                state = 3;
        }



    }


    
}
