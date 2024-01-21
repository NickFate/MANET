using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MANET.Classes
{
    public class Point
    {
        public double x;
        public double y;

        public Point()
        {
            x = 0; 
            y = 0;
        }

        public Point(double X, double Y)
        {
            x = X;
            y = Y;
        }


        public static double DistanceBetweenTwoPoint(Point from, Point to)
        {
            return Math.Round(Math.Sqrt(Math.Pow(to.x - from.x, 2) + Math.Pow(to.y - from.y, 2)), 2);
        }
    }
}
