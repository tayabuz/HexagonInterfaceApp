using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net.NetworkInformation;

namespace HexagonInterface
{
    public class Hexagon
    {
        const double PROPORTION_HEIGTH_HEXAGON = (double)1 / 2;
        const double PROPORTION_WIDTH_HEXAGON = (double)58 / 108;

        public Point P1, P2, P3, P4, P5, P6;
        public Hexagon(Point PointFirst, Point PointSecond)
        {
            getHexagonPoints(PointFirst, PointSecond);
        }
        public Hexagon(Point PointFirst, int Height, int Width)
        {
            int x1 = PointFirst.X + Width;
            int y1 = PointFirst.Y + Height;
            Point PointSecond = new Point(x1, y1);
            getHexagonPoints(PointFirst, PointSecond);
        }

        public Hexagon(Point p1, Point p2, Point p3, Point p4, Point p5, Point p6)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
            P5 = p5;
            P6 = p6;
        }
        private void getHexagonPoints(Point PointOne, Point PointTwo)
        {
            int widthLength = Convert.ToInt32((PointTwo.X - PointOne.X) * PROPORTION_WIDTH_HEXAGON);
            int pointFirstWidthX = PointOne.X + ((PointTwo.X - PointOne.X) / 2) + (widthLength / 2);
            int pointSecondWidthX = PointOne.X + ((PointTwo.X - PointOne.X) / 2) - (widthLength / 2);

            int heigthLength = Convert.ToInt32((PointTwo.Y - PointOne.Y) * PROPORTION_HEIGTH_HEXAGON);
            int pointY = PointOne.Y + heigthLength;

            P1 = new Point(pointFirstWidthX, PointOne.Y);
            P2 = new Point(pointSecondWidthX, PointOne.Y);
            P3 = new Point(PointOne.X, pointY);
            P4 = new Point(pointSecondWidthX, PointTwo.Y);
            P5 = new Point(pointFirstWidthX, PointTwo.Y);
            P6 = new Point(PointTwo.X, pointY);
        }
        public bool IsPointInside(Point point)
        {
            int B = Convert.ToInt32((P1.X - P2.X));
            double K1 = RFunctionConjunction(Convert.ToDouble(point.X - P2.X), Convert.ToDouble(point.Y - P2.Y));
            int Z = (-1) * (point.X - P2.X) + B;
            double K2 = RFunctionConjunction(K1, Convert.ToDouble(Z));
            int A = Convert.ToInt32((P4.Y - P2.Y));
            int Z1 = (-1) * (point.Y - P2.Y) + A;
            double K3 = RFunctionConjunction(K2, Convert.ToDouble(Z1));
            if ((K3 >= 0.0) && ((point.X != 0) || (point.Y != 0)))
            {
                return true;
            }
            /*Математическая часть - векторное и псевдоскалярное произведение.
            Реализация - считаются произведения (1,2,3 - вершины треугольника, 0 - точка):
            (x1-x0)*(y2-y1)-(x2-x1)*(y1-y0)
            (x2-x0)*(y3-y2)-(x3-x2)*(y2-y0)
            (x3-x0)*(y1-y3)-(x1-x3)*(y3-y0)
            Если они одинакового знака, то точка внутри треугольника, если что-то из этого - ноль, то точка лежит на стороне, иначе точка вне треугольника.*/
            int FirstTriaglePl1, FirstTriaglePl2, FirstTriaglePl3;
            FirstTriaglePl1 = (P4.X - point.X) * (P3.Y - P4.Y) - (P3.X - P4.X) * (P4.Y - point.Y);
            FirstTriaglePl2 = (P3.X - point.X) * (P2.Y - P3.Y) - (P2.X - P3.X) * (P3.Y - point.Y);
            FirstTriaglePl3 = (P2.X - point.X) * (P4.Y - P2.Y) - (P4.X - P2.X) * (P2.Y - point.Y);

            if ((FirstTriaglePl1 >= 0 && FirstTriaglePl2 >= 0 && FirstTriaglePl3 >= 0) || (FirstTriaglePl1 <= 0 && FirstTriaglePl2 <= 0 && FirstTriaglePl3 <= 0))
            {
                return true;
            }

            int SecondTriaglePl1, SecondTriaglePl2, SecondTriaglePl3;
            SecondTriaglePl1 = (P1.X - point.X) * (P6.Y - P1.Y) - (P6.X - P1.X) * (P1.Y - point.Y);
            SecondTriaglePl2 = (P6.X - point.X) * (P5.Y - P6.Y) - (P5.X - P6.X) * (P6.Y - point.Y);
            SecondTriaglePl3 = (P5.X - point.X) * (P1.Y - P5.Y) - (P1.X - P5.X) * (P5.Y - point.Y);

            if ((SecondTriaglePl1 >= 0 && SecondTriaglePl2 >= 0 && SecondTriaglePl3 >= 0) || (SecondTriaglePl1 <= 0 && SecondTriaglePl2 <= 0 && SecondTriaglePl3 <= 0))
            {
                return true;
            }

            return false;
        }
        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Hexagon hex = obj as Hexagon;
            return Equals(hex);
        }

        public bool Equals(Hexagon hex)
        {
            if ((object)hex == null)
            {
                return false;
            }

            return (hex.P1.Equals(P1)) && (hex.P2.Equals(P2)) && (hex.P3.Equals(P3)) && (hex.P4.Equals(P4)) && (hex.P5.Equals(P5)) && (hex.P6.Equals(P6));
        }
        public static bool operator ==(Hexagon h1, Hexagon h2)
        {

            if (System.Object.ReferenceEquals(h1, h2))
            {
                return true;
            }

            if (((object)h1 == null) || ((object)h2 == null))
            {
                return false;
            }

            return (h1.P1.Equals(h2.P1)) && (h1.P2.Equals(h2.P2)) && (h1.P3.Equals(h2.P3)) && (h1.P4.Equals(h2.P4)) && (h1.P5.Equals(h2.P5)) && (h1.P6.Equals(h2.P6));
        }

        public static bool operator !=(Hexagon h1, Hexagon h2)
        {
            return !Equals(h1, h2);
        }
        public static double RFunctionConjunction(double X, double Y)
        {
            double result = X + Y - Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            return result;
        }
    }

}
