using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    public class GazePoint
    {
        public double X { get; set; }
        public double Y { get; set; }

        public GazePoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public GazePoint() : this(0,0)
        {
        }
    }
}
