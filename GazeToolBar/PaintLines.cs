using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    class PaintLines
    {
        private Graphics graphics;
        private List<Point> pointList;
        private int brushSize;
        private SolidBrush brush;

        public PaintLines(int brushSize, Color brushColour, Graphics graphics)
        {
            this.graphics = graphics;
            this.brushSize = brushSize;
            pointList = new List<Point>();
            brush = new SolidBrush(brushColour);
        }


        public void addPoint(int x, int y)
        {
            pointList.Add(new Point(x, y));
        }
        
        public void drawLine()
        {
            if (pointList.Count > 1)
            {
                for (int i = 0; i < pointList.Count; i++)
                {
                    graphics.FillEllipse(brush, new Rectangle(pointList[i], new Size(brushSize, brushSize)));
                }
            }

        }



    }
}
