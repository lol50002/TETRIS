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
                result.Add(location);
                result.Add(new Point(location.X+r, location.Y ));
                result.Add(new Point(location.X+2*r, location.Y));
                result.Add(new Point(location.X +r, location.Y+r));
                return result;
            }
        }



    }
}
