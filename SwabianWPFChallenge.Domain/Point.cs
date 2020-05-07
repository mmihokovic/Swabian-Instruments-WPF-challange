using System;
using System.Collections.Generic;
using System.Text;

namespace SwabianWPFChallenge.Domain
{
    public class Point
    {
        public Point(string x, string y)
        {
            X = double.Parse(x);
            Y = double.Parse(y);
        }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }
}
