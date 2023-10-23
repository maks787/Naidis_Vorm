using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naidis_Vorm
{
    public class Triangle
    {
        public double a;
        public double b;
        public double c;

        public Triangle(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
            
        }
        public string outputA() { return Convert.ToString(a); }
        public string outputB() { return Convert.ToString(b); }
        
        public string outputC()
        {
            return Convert.ToString(c);
        }
        public double Perimeter()
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                return a + b + c;
            }
            else
            {
                return 0; 
            }
        }
        public double Surface()
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
            else
            {
                return 0; 
            }
        }
        public double GetSetA
        {
            get { return a; }
            set
            {
                a = value;
            }
        }
        public double GetSetB
        {
            get { return b; }
            set { b = value; }
        }
        public double GetSetC
        {
            get { return c; }
            set
            {
                c = value;
            }
        }
        public bool ExistTriange
        {
            get
            {
                if (a >= b + c || b >= a + c || c >= a + b)
                    return false;
                else
                    return true;
            }
        }

        public double Height()
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                double s = Surface();
                return (2 * s) / a;
            }
            else
            {
                return 0; 
            }
        }

        public double Surface2(double a, double h)
        {
            double s = (a * h) / 2;
            return s;
        }
    }
}
