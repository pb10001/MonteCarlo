using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    public class Simulator
    {
        public Simulator()
        {
            random = new Random(Environment.TickCount);
        }
        Random random;
        public Point Execute()
        {
            var x = random.NextDouble();
            var y = random.NextDouble();
            var p = new Point(x, y);
            return p;
        }
    }
}
