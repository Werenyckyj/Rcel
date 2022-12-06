using System;
using System.Collections.Generic;
using System.Linq;

namespace Rce
{
    class Program
    {
        static void Main(string[] args)
        {
            string rce = "x3 - 4,5x2 + 5x - 1,5 = 0";
            Calculations();
        }


        public static void Calculations()
        {
            Dictionary<Points, Points> dd = FindRoots();
            //Roots(dd);
        }

        private static Dictionary<Points, Points> FindRoots()
        {
            List<Points> points = new List<Points>();
            for (double i = -5; i < 5; i += 0.2)
            {
                double point = i * i * i - 4.5 * (i * i) + 5 * i - 1.5;
                Points p = new Points(i, point);
                points.Add(p);
            }

            int index = 0;
           Dictionary<Points, Points> sortedPoints = new Dictionary<Points, Points>();
            while (index < points.Count - 1)
            {
                if (points.ElementAt(index).Y * points.ElementAt(index + 1).Y < 0)
                {
                    sortedPoints.Add(points.ElementAt(index), points.ElementAt(index + 1));
                }

                index++;
            }

            return sortedPoints;
        }

        private static List<double> Roots(Dictionary<Points, Points> sortedPoints)
        {
            List<double> results = new List<double>();

            foreach (var item in sortedPoints)
            {
                double from = item.Key.Y;
                double to = item.Value.Y;
                double d = (from + to) / 2;
                double dist = double.MaxValue;

                while (Math.Abs(dist) > 0.001)
                {
                    d = (from + to) / 2;
                    //dist = 

                    if (d * from < 0)
                    {
                        to = d;
                    }
                    else
                    {
                        from = d;
                    }
                }

                results.Add(d);
            }

            return results;
        }

        class Points
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Points(double x, double y)
            {
                X = x;
                Y = y;
            }
        }
    }
}
