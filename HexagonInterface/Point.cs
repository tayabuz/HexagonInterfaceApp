using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HexagonInterface
{

    public class Point
    {
        public Point()
        {

        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Point p = obj as Point;
            return Equals(p);
        }
        public bool Equals(Point p)
        {
            if ((object) p == null)
            {
                return false;
            }

            return (X == p.X) && (Y == p.Y);
        }

        public static bool operator ==(Point a, Point b)
        {

            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (((object) a == null) || ((object) b == null))
            {
                return false;
            }

            return (a.X == b.X) && (a.Y == b.Y);
        }
        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }
        public static int returnUserCoordinatesOrLength(string userString)
        {

            int userAnswer = 0;
            while (checkOutput(userString) == false)
            {
                try
                {
                    if (checkOutput(userString))
                    {
                        break; 
                    }
                    else
                    {
                        throw new FormatException("Uncorrect string");
                    }
                }
                catch (FormatException)
                {

                }
            }
            userAnswer = Int32.Parse(userString);
            return userAnswer;
        }
        public static bool checkOutput(string userAnswerString)
        {
            bool userAnswerValid = true;
            try
            {
                userAnswerValid = !string.IsNullOrEmpty(userAnswerString) && Regex.IsMatch(userAnswerString, @"[\d]");
            }
            catch (FormatException)
            {
                userAnswerValid = false;
            }
            return userAnswerValid;
        }
    }
}
