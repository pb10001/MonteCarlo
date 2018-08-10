using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarlo
{
    public class SimulationResult
    {
        public SimulationResult()
        {
            Points = new List<Point>();
        }
        public List<Point> Points { get; }
        public IEnumerable<Point> Trues()
        {
            return Points.Where(p=>p.Judge());
        }
        public IEnumerable<Point> Falses()
        {
            return Points.Where(p => !p.Judge());
        }
    }
}
