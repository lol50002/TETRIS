﻿using System;
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
                result.Add(location);
                result.Add(new Point(location.X + r, location.Y));
                result.Add(new Point(location.X + 2 * r, location.Y));
                result.Add(new Point(location.X + 3*r, location.Y));
                return result;
            }
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