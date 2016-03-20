using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Lineyka:Figure
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
                            result.Add(new Point(location.X + r, location.Y));
                            result.Add(new Point(location.X + 2 * r, location.Y));
                            result.Add(new Point(location.X + 3*r, location.Y));
                            //return result;
                    break;
                    case 1:
                            result.Add(location);
                            result.Add(new Point(location.X, location.Y+r));
                            result.Add(new Point(location.X, location.Y+r*2));
                            result.Add(new Point(location.X , location.Y+r*3));
                            //return result;


                    break;
                    
                }
                return result;
            }
        }

        public override void rotate()
        {
            state = (state + 1) % 2;
           
        }

        public override void unrotate()
        {            state = (state - 1);
            if (state == -1)
                state = 1;

        }


        public override Point SLT
        {
            get
            {

                Point result = new Point(location.X, location.Y );
                return result;
            }
        }



    }
}
