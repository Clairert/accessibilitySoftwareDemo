using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    public class FixationSmootherNone : IFixationSmoother
    {
        public GazePoint UpdateAndGetSmoothPoint(double X, double Y)
        {
            return new GazePoint(X, Y);
        }
    }
}
