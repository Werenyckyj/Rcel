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

            Console.ReadLine();
        }


        public static void Calculations()
        {
            Dictionary<Points, Points> dd = FindRoots();
            foreach (var item in Roots(dd))
            {
                Console.WriteLine(item);
            }
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
                double fromY = item.Key.Y;
                double toY = item.Value.Y;
                double fromX = item.Key.X;
                double toX = item.Value.X;
                double halfOfX = (fromX + toX) / 2;
                double halfOfY = (fromY + toY) / 2;
                double dist = Math.Abs(toY - fromY);

                while (dist > 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000000000001)
                {
                    halfOfX = (fromX + toX) / 2;
                    halfOfY = (fromY + toY) / 2;
                    dist = Math.Abs(toY - fromY);
                    if (halfOfY * fromY < 0)
                    {
                        toX = halfOfX;
                        toY = halfOfY;
                    }
                    else
                    {
                        fromX = halfOfX;
                        fromY = halfOfY;
                    }
                }
                results.Add(halfOfX);
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
