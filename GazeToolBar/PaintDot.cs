using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    class PaintDot
    {
        private Graphics graphics;
        private int brushSize = 40;
        private SolidBrush brush;
        private Point location;

        public PaintDot(Color brushColour, Graphics graphics, Point location)
        {
            this.graphics = graphics;
            this.location = location;
            brush = new SolidBrush(brushColour);
        }

        public void drawCircle()
        {
            graphics.FillEllipse(brush, new Rectangle(location, new Size(brushSize, brushSize)));
        }

    }
}
