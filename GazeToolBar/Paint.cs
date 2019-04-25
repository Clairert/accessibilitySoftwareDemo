using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeXFramework.Forms;
using GazeToolBar.Properties;

namespace GazeToolBar
{
    public partial class Paint : Form
    {
        private Graphics graphic;
        private int count = 0;
        private Point[] points;
        private List<Point> pointList;


        private List<PaintLines> lines;
        private PaintLines newLine;
        bool drawing;
        //FixationSmootherAverage eyeFollower;
        FixationDetection eyeFollower;
        //CustomFixationDataStream eyeFollower;
        private ZoomMagnifier magnifier;
        private static FormsEyeXHost eyeXHost;
        private Graphics graphics;
        private Graphics bufferGraphics;
        private Bitmap bufferImage;
        private SolidBrush backgroundColor;
        private int brushSize;
        private string selectedSize;
        private string newSize;
        private Color brushColour;



        public Paint(FormsEyeXHost EyeXHost)
        {
            eyeXHost = EyeXHost;
            InitializeComponent();
            connectBehaveMap();

            //eyeFollower = new FixationSmootherAverage(30);
            eyeFollower = new FixationDetection(eyeXHost);
            //eyeFollower = new CustomFixationDataStream(eyeXHost);
            //eyeXHost.Start();
            dynamicResize();

            ////////////////////////////////////////////////////////////////////////////////
            ///

            int height = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenHeight));
            int width = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenWidth));
            //canvasPanel.Width = Convert.ToInt32(width * 0.7);
            //canvasPanel.Height = Convert.ToInt32(height * 0.7);
            //canvasPanel.Top = Convert.ToInt32(height * 0.15);
            //canvasPanel.Left = Convert.ToInt32(width * 0.15);


            graphics = CreateGraphics();
            bufferImage = new Bitmap(Convert.ToInt32(width * 0.9), Convert.ToInt32(height * 0.9));
            bufferGraphics = Graphics.FromImage(bufferImage);

            points = new Point[] { };
            pointList = new List<Point>();
            lines = new List<PaintLines>();
            drawing = false;
            //canvasPanel.Paint += new PaintEventHandler(canvasPanel_Paint);
            //canvasPanel.Paint += new PaintEventHandler(canvasPanel_Paint);
            //graphic = CreateGraphics();
            backgroundColor = new SolidBrush(Color.Green);
            brushSize = 20;
            selectedSize = "medium";
            newSize = "";
            brushColour = colourOptionButton12.BackColor;

        }


        private void dynamicResize()
        {
            int height = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenHeight));
            int width = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenWidth));
            int half = width / 2;
            int third = width / 3;
            int setttingpanel = third;




            //Resize panels
            //Settings Panel
            brushPanel.Width = width;
            brushPanel.Height = height;
            brushPanel.Top = 0;
            brushPanel.Left = 0;

            backgroundPanel.Width = width;
            backgroundPanel.Height = height;
            backgroundPanel.Top = 0;
            backgroundPanel.Left = 0;

            //Colour selector Panel
            brushColours.Height = Convert.ToInt32(height - (height * 0.2));
            brushColours.Top = Convert.ToInt32(height * 0.2);
            brushColours.Left = 0;
            brushColours.Width = width;
            //
            int colourPanelwidth = Convert.ToInt32((brushColours.Width - (brushColours.Width * 0.3)) / 9);
            int colourPanelheight = Convert.ToInt32((brushColours.Height - (brushColours.Height * 0.3)) / 4);
            int down = Convert.ToInt32(brushColours.Height * 0.075);
            int left = Convert.ToInt32(brushColours.Width * 0.075);

            //Brush Specification Panel
            panel20.Height = Convert.ToInt32(height - (height * 0.2));
            panel20.Top = Convert.ToInt32(height * 0.2);
            panel20.Left = 0;
            panel20.Width = width;


            //Resize buttons/panels in brushcolours
            int countLeft = 0;
            foreach (Panel pane in brushColours.Controls.OfType<Panel>())
            {

                pane.Height = colourPanelheight;
                pane.Top = down;
                pane.Left = left;
                pane.Width = colourPanelwidth;
                countLeft++;
                left += (colourPanelwidth*2);
                if (countLeft > 5)
                {
                    countLeft = 0;
                    left = Convert.ToInt32(brushColours.Width * 0.075);
                    down = down + (2 * colourPanelheight);
                }
                foreach (Button button in pane.Controls.OfType<Button>())
                {
                    button.Height = colourPanelheight - 6;
                    button.Width = colourPanelwidth - 6;
                }
            }

            //Resizing Buttons and panels in brush settings(sizes)




            int sizePanelwidth = Convert.ToInt32 (setttingpanel * 0.5);
            int sizePanelheight = Convert.ToInt32((panel20.Height - (panel20.Height * 0.3)) / 5);

            left = 0;
            foreach (Panel pane in panel20.Controls.OfType<Panel>())
            {
                    pane.Height = Convert.ToInt32(height - (height * 0.2));
                    pane.Width = setttingpanel;
                    pane.Top = Convert.ToInt32(height * 0.1);
                    countLeft = 0;
                    down = Convert.ToInt32(panel20.Height * 0.075);
                        foreach (Panel pane2 in pane.Controls.OfType<Panel>())
                        {
                                pane2.Height = sizePanelheight;
                                pane2.Top = down;
                                pane2.Width = sizePanelwidth;
                                pane2.Left = ((setttingpanel / 2) - (pane2.Width / 2));
                                down += (sizePanelheight * 2);
                                foreach (Button button in pane2.Controls.OfType<Button>())
                                {

                                   button.Height = sizePanelheight - 6;
                                   button.Width = sizePanelwidth - 6;
                                   button.Font = new Font(button.Font.FontFamily, width / 50);
                                }
                        }
             }

            panel9.Left = 0;
            panel22.Left = setttingpanel+ setttingpanel;
            //Button with painbrush Colour
            colourChangeButton.Height = Convert.ToInt32(panel20.Height * 0.25);
            colourChangeButton.Width = Convert.ToInt32(panel20.Height * 0.25);
            colourChangePanel.Height = colourChangeButton.Height + 6;
            colourChangePanel.Width = colourChangeButton.Width + 6;
            colourChangePanel.Left = ((setttingpanel / 2) + setttingpanel - (colourChangePanel.Width / 2));
            colourChangePanel.Top = ((panel20.Height / 2) - (colourChangePanel.Height / 2));









            //Labels

            label1.Font = new Font(label1.Font.FontFamily, width / 20);
            label1.Left = ((half) - (label1.Width / 2));

            label2.Font = new Font(label2.Font.FontFamily, width / 20);
            label2.Left = (half- (label2.Width / 2));



            //Brush Settings

            label3.Font = new Font(label3.Font.FontFamily, width / 40);
            label3.Left = ((setttingpanel / 2)- (label3.Width / 2));
            label4.Font = new Font(label4.Font.FontFamily, width / 40);
            label4.Left = ((setttingpanel / 2) + (setttingpanel*2) - (label4.Width / 2));
            label5.Font = new Font(label5.Font.FontFamily, width / 40);
            label5.Left = ((setttingpanel / 2) + setttingpanel - (label5.Width / 2));

            //Making invisible panels
            brushPanel.Left = ClientSize.Width + 2000;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = ClientSize.Width + 2000;//brushSize
            backgroundPanel.Left = ClientSize.Width + 2000;


            //Save Button
            panel24.Height = Convert.ToInt32(height * 0.12);
            panel24.Width = Convert.ToInt32(width * 0.12);
            panel24.Left = width - panel24.Width - 20;
            panel24.Top = 20;
            button40.Height = panel24.Height - 6;
            button40.Width = panel24.Width - 6;
            button40.Font = new Font(colourChangeButton.Font.FontFamily, width / 40);

            //Resizing Background colour options
            colourPanelwidth = Convert.ToInt32((backgroundPanel.Width - (backgroundPanel.Width * 0.3)) / 6);
            colourPanelheight = Convert.ToInt32((backgroundPanel.Height - (backgroundPanel.Height * 0.3)) / 4);
            down = Convert.ToInt32(backgroundPanel.Height * 0.30);
            left = Convert.ToInt32(backgroundPanel.Width * 0.075);
            countLeft = 0;
            foreach (Button button in backgroundPanel.Controls.OfType<Button>())
            {
                button.Height = colourPanelheight;
                button.Top = down;
                button.Left = left;
                button.Width = colourPanelwidth;
                countLeft++;
                left += (colourPanelwidth * 2);
                if (countLeft > 3)
                {
                    countLeft = 0;
                    left = Convert.ToInt32(brushColours.Width * 0.075);
                    down = down + (2 * colourPanelheight);
                }
            }


        }






        private void canvasPanel_Paint(object sender, PaintEventArgs e)
        {
            //var g = e.Graphics;
            //g.DrawImage(bufferImage, 0, 0);

        }




        private void paintLines()
        {
            int height = Convert.ToInt32(ClientSize.Height);
            int width = Convert.ToInt32(ClientSize.Width);
            bufferGraphics.FillRectangle(backgroundColor, Convert.ToInt32(width * 0.1), Convert.ToInt32(height * 0.15), Convert.ToInt32(width * 0.9), Convert.ToInt32(height * 0.9));
            foreach(PaintLines line in lines)
            {
                line.drawLine();
            }



            //Old Line Code
            ////////Brush brush = new SolidBrush(Color.DarkGreen);

            ////////g.FillRectangle(brush, new Rectangle(new Point(3,3),new Size(canvasPanel.Width-6,canvasPanel.Height-6)));
            ////////int height = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenHeight));
            ////////int width = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenWidth));

            ////////canvasPanel.Width = Convert.ToInt32(width * 0.7);
            ////////canvasPanel.Height = Convert.ToInt32(height * 0.7);
            ////////canvasPanel.Top = Convert.ToInt32(height * 0.15);
            ////////canvasPanel.Left = Convert.ToInt32(width * 0.15);
            //////Pen pen = new Pen(Color.Black, 3);
            //////SolidBrush brush = new SolidBrush(brushColour);
            //////////Draw lines to screen.
            ////////if ((pointList.Count > 1) && (pointList.Count < 20))
            //////if (pointList.Count > 1)
            //////{
            //////    //points = new Point[pointList.Count];
            //////    //Console.WriteLine("NewList");
            //////    for (int i = 0; i < pointList.Count; i++)
            //////    {
            //////        bufferGraphics.FillEllipse(brush, new Rectangle(pointList[i], new Size(brushSize, brushSize)));
            //////        //points[i] = pointList[i];
            //////        //Console.WriteLine(points[i]);
            //////    }
            //////    //g.DrawPath(pen,)
            //////    //bufferGraphics.DrawLines(pen, points);
            //////    //Console.WriteLine("paintLine");
            //////}
            ////////if (pointList.Count >= 20)
            ////////{
            ////////    Console.WriteLine("full");
            ////////    pointList = new List<Point>();
            ////////}
            
        }

        private void brushColours_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (drawing)
            //{
            //    Point newPoint = eyeFollower.getXY();

            //    pointList.Add(new Point(newPoint.X, newPoint.Y));
            //    //pointList.Add(new Point(newPoint.X, newPoint.Y));
            //    //Console.WriteLine(eyeFollower.getXY());
            //}
            paintLines();
            //bufferGraphics.FillRectangle(Brushes.Green, 0, 0, ClientSize.Width, ClientSize.Height);
            graphics.DrawImage(bufferImage, 0, 0);
            
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            if (drawing)
            {

                Point newPoint = eyeFollower.getXY();
                newLine.addPoint(newPoint.X, newPoint.Y);
                //pointList.Add(new Point(newPoint.X, newPoint.Y));
                //pointList.Add(new Point(newPoint.X, newPoint.Y));
                //Console.WriteLine(eyeFollower.getXY());
            }
        }

        private void canvasPanel_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!drawing)
            {
                //Start a new Line
                newLine = new PaintLines(brushSize, brushColour, bufferGraphics);
                //pointList = new List<Point>();
                eyeFollower.StartDetectingFixation();
                drawing = true;
                timer2.Enabled = true;
            }
            else
            {
                lines.Add(newLine);
                eyeFollower = new FixationDetection(eyeXHost);
                drawing = false;
                timer2.Enabled = false;
            }
        }








        /////////////////////////////Background colour buttons///////////////////////////////////


        private void button3_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = 0;
            buttonPanel.Left = ClientSize.Width + 2000;
        }

        private void backgroundColour1_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = ClientSize.Width + 2000;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour1.BackColor);
        }

        private void backgroundColour2_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = ClientSize.Width + 2000;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour2.BackColor);
        }

        private void backgroundColour3_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = ClientSize.Width + 2000;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour3.BackColor);
        }

        private void backgroundColour4_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = ClientSize.Width + 2000;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour4.BackColor);
        }

        private void backgroundColour5_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = ClientSize.Width + 2000;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour5.BackColor);
        }

        private void backgroundColour6_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = ClientSize.Width + 2000;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour6.BackColor);
        }

        private void backgroundColour7_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = ClientSize.Width + 2000;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour7.BackColor);
        }

        private void backgroundColour8_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = ClientSize.Width + 2000;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour8.BackColor);
        }





        /////////////////////////////Brush Size///////////////////////////////////


            //Small
        private void smallBrush_Click(object sender, EventArgs e)
        {
            newSize = "small";
            smallBrushPanel.BackColor = Color.Blue;
            largeBrushPanel.BackColor = button1.BackColor;
            medBrushPanel.BackColor = button1.BackColor;
        }

        private void medBrush_Click(object sender, EventArgs e)
        {
            newSize = "medium";
            medBrushPanel.BackColor = Color.Blue;
            smallBrushPanel.BackColor = button1.BackColor;
            largeBrushPanel.BackColor = button1.BackColor;
        }

        private void largeBrush_Click(object sender, EventArgs e)
        {
            newSize = "large";
            largeBrushPanel.BackColor = Color.Blue;
            smallBrushPanel.BackColor = button1.BackColor;
            medBrushPanel.BackColor = button1.BackColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonPanel.Left = ClientSize.Width + 2000;
            switch (selectedSize)
            {
                case "large":
                    largeBrushPanel.BackColor = Color.Blue;
                    smallBrushPanel.BackColor = button1.BackColor;
                    medBrushPanel.BackColor = button1.BackColor;
                    break;
                case "medium":
                    medBrushPanel.BackColor = Color.Blue;
                    smallBrushPanel.BackColor = button1.BackColor;
                    largeBrushPanel.BackColor = button1.BackColor;

                    break;
                case "small":
                    smallBrushPanel.BackColor = Color.Blue;
                    largeBrushPanel.BackColor = button1.BackColor;
                    medBrushPanel.BackColor = button1.BackColor;
                    break;

            }
            brushPanel.Left = 0;
            panel20.Left = 0;
            newSize = selectedSize;
            colourChangeButton.BackColor = brushColour;

            
        }

        private void button40_Click(object sender, EventArgs e)
        {
            selectedSize = newSize;
            //brushPanel.Visible = false;
            brushPanel.Left = ClientSize.Width + 2000;
            //brushColours.Visible = false;
            brushColours.Left = ClientSize.Width + 2000;
            buttonPanel.Left = 0;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            brushColours.Left = 0;
            brushColours.Visible = true;
            panel20.Left = ClientSize.Width + 2000;
        }



        //Paintbrush Colours
        private void colourOptionButton1_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton1.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton2_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton2.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton3_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton3.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton4_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton4.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton16_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton16.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton5_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton5.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton6_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton6.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton7_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton7.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton8_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton8.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton9_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton9.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton10_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton10.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton11_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton11.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton12_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton12.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton13_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton13.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton14_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton14.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton15_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton15.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton17_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton17.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }

        private void colourOptionButton18_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton18.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = ClientSize.Width + 2000;
            panel20.Left = 0;
        }



        private void button5_Click(object sender, EventArgs e)
        {

        }

    }
}
