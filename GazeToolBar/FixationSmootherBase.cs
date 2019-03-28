using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    public abstract class FixationSmootherBase : IFixationSmoother
    {
        protected int bufferSize;
        protected double[] xBuffer, yBuffer;  //TODO: 2d array? 

        public FixationSmootherBase(int BufferSize)
        {
            bufferSize = BufferSize;

            yBuffer = new double[BufferSize];
            xBuffer = new double[BufferSize];

            for (int i = 0; i < bufferSize; i++)
            {
                xBuffer[i] = -1;
            }
        }

        public GazePoint UpdateAndGetSmoothPoint(double X, double Y)
        {
            AddCoordinateToBuffer(X, Y);

            return SmoothPointsFromBuffer();
        }

        public abstract void AddCoordinateToBuffer(double x, double y);
        public abstract GazePoint SmoothPointsFromBuffer();
    }
}
