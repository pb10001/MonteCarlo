using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    public class Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public Func<double, double, bool> Func { get; set; }
        public bool Judge()
        {
            if(Func == null)
            {
                throw new InvalidOperationException("Funcを設定してください");
            }
            return Func(X, Y);
        }
    }
}
