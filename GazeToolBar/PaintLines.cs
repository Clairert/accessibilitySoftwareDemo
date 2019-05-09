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
        private bool shape;

        public PaintLines(int brushSize, Color brushColour, Graphics graphics, bool shape)
        {
            this.graphics = graphics;
            this.brushSize = brushSize;
            this.shape = shape;
            pointList = new List<Point>();
            brush = new SolidBrush(brushColour);
        }


        public void addPoint(int x, int y)
        {
            pointList.Add(new Point(x, y));
        }

        //Draws a circle/square at each location in list
        public void drawLine()
        {
            //Checking list has started
            if (pointList.Count > 1)
            {
                for (int i = 0; i < pointList.Count - 1; i++)
                {
                    //Checking shape of line
                    if (shape)
                    {
                        drawCircle(pointList[i]);
                    }
                    else
                    {
                        drawSquare(pointList[i]);
                    }
                }
            }

        }

        //Drawing Circle
        public void drawCircle(Point drawPoint)
        {
            graphics.FillEllipse(brush, new Rectangle(drawPoint, new Size(brushSize, brushSize)));
        }

        //Drawing Square
        public void drawSquare(Point drawPoint)
        {
            graphics.FillRectangle(brush, new Rectangle(drawPoint, new Size(brushSize, brushSize)));
        }



    }
}
