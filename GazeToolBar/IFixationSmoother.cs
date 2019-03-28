using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    public interface IFixationSmoother
    {
        GazePoint UpdateAndGetSmoothPoint(double X, double Y);
    }
}
