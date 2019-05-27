using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeXFramework;
using EyeXFramework.Forms;
using GazeToolBar.Properties;
using Tobii.EyeX.Framework;

namespace GazeToolBar
{
    public partial class Paint : Form
    {
        private DemoHome parent;
        //Bounds on screen
        private int canvasTop;
        private int canvasLeft;
        private int canvasHeight;
        private int canvasWidth;
        private int offScreen;
        private int onScreen;
        //Eye tracking
        CustomFixationDataStream eyeFollower;
        private static FormsEyeXHost eyeXHost;
        //Graphics
        private Graphics graphics;
        private Graphics bufferGraphics;
        private Bitmap bufferImage;
        private SolidBrush backgroundColor;
        //Lines
        private List<PaintLines> lines;
        private PaintLines newLine;
        private bool drawing;
        //Brush Settings
        private int brushSize;
        private Color brushColour;
        private bool shape;
        //Screen colours
        private Color mainColour;
        private Color accentColour;


        public Paint(FormsEyeXHost EyeXHost, DemoHome parent)
        {
            this.parent = parent;
            //Eye tracking
            eyeXHost = EyeXHost;
            eyeFollower = new CustomFixationDataStream(eyeXHost);
            InitializeComponent();
            connectBehaveMap();
            //Sizing Variables
            int height = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenHeight));
            int width = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenWidth));
            canvasTop = Convert.ToInt32(height * 0.15);
            canvasLeft = Convert.ToInt32(width * 0.1);
            canvasWidth = Convert.ToInt32(width * 0.9);
            canvasHeight = Convert.ToInt32(height * 0.9);
            offScreen = width + 2000;
            dynamicResize();
            onScreen = button16Panel.Left;
            //Colours
            mainColour = Color.WhiteSmoke;
            accentColour = Color.FromArgb(115, 220, 255);
            //Creating graphics
            graphics = CreateGraphics();
            bufferImage = new Bitmap(Convert.ToInt32(width * 0.9), Convert.ToInt32(height * 0.9));
            bufferGraphics = Graphics.FromImage(bufferImage);
            //Setting up drawing/painting
            shape = true;
            lines = new List<PaintLines>();
            drawing = false;
            newLine = new PaintLines(brushSize, brushColour, bufferGraphics, shape);
            backgroundColor = new SolidBrush(mainColour);
            brushSize = 40;
            brushColour = colourOptionButton12.BackColor;
            //starting timers
            timer2.Enabled = true;
            timer1.Enabled = true;

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
                left += (colourPanelwidth * 2);
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
            int sizePanelwidth = Convert.ToInt32(setttingpanel * 0.5);
            int sizePanelheight = Convert.ToInt32((panel20.Height - (panel20.Height * 0.3)) / 5);

            left = 0;
            //Getting the panels inside the brush setting options
            foreach (Panel pane in panel20.Controls.OfType<Panel>())
            {
                //Resizing to take up a third of space each
                pane.Height = Convert.ToInt32(height - (height * 0.2));
                pane.Width = setttingpanel;
                pane.Top = Convert.ToInt32(height * 0.1);
                countLeft = 0;
                down = Convert.ToInt32(panel20.Height * 0.075);
                //resizing the panels/buttons in size and shape
                foreach (Panel pane2 in pane.Controls.OfType<Panel>())
                {
                    pane2.Height = sizePanelheight;
                    pane2.Top = down;
                    pane2.Width = sizePanelwidth;
                    pane2.Left = ((setttingpanel / 2) - (pane2.Width / 2));
                    down += (sizePanelheight * 2);
                    //Resizing the buttons
                    foreach (Button button in pane2.Controls.OfType<Button>())
                    {

                        button.Height = sizePanelheight - 6;
                        button.Width = sizePanelwidth - 6;
                        button.Font = new Font(button.Font.FontFamily, width / 50);
                    }
                }
            }
            //Moving the size and shape panels into their spots
            panel9.Left = 0;
            panel22.Left = setttingpanel + setttingpanel;

            //Button with painbrush Colour
            colourChangeButton.Height = Convert.ToInt32(panel20.Height * 0.25);
            colourChangeButton.Width = Convert.ToInt32(panel20.Height * 0.25);
            colourChangePanel.Height = colourChangeButton.Height + 6;
            colourChangePanel.Width = colourChangeButton.Width + 6;
            colourChangePanel.Left = ((setttingpanel / 2) + setttingpanel - (colourChangePanel.Width / 2));
            colourChangePanel.Top = ((panel20.Height / 2) - (colourChangePanel.Height / 2));

            //Labels
            //Select background label
            label1.Font = new Font(label1.Font.FontFamily, width / 20);
            label1.Left = ((half) - (label1.Width / 2));
            //Brush Settings label
            label2.Font = new Font(label2.Font.FontFamily, width / 20);
            label2.Left = (half - (label2.Width / 2));

            //Brush Settings
            label3.Font = new Font(label3.Font.FontFamily, width / 40);
            label3.Left = ((setttingpanel / 2) - (label3.Width / 2));
            label4.Font = new Font(label4.Font.FontFamily, width / 40);
            label4.Left = ((setttingpanel / 2) + (setttingpanel * 2) - (label4.Width / 2));
            label5.Font = new Font(label5.Font.FontFamily, width / 40);
            label5.Left = ((setttingpanel / 2) + setttingpanel - (label5.Width / 2));

            //Moving panels offscreen
            brushPanel.Left = offScreen;
            brushColours.Left = offScreen;
            panel20.Left = offScreen; //brushSize
            backgroundPanel.Left = offScreen;


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
            //Getting all buttons
            foreach (Button button in backgroundPanel.Controls.OfType<Button>())
            {
                //Resizing
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
            button37.BackColor = Color.FromArgb(115, 220, 255);

            //Button panel at top of screen
            buttonPanel.Width = width;
            //Evenly spacing buttons
            int panelSize = Convert.ToInt32((width / 6) * 0.8); //Size of each button
            int panelTall = Convert.ToInt32(height * 0.1); //height
            int distance = (width / 6); //size alloted to each panel
            buttonPanel.Height = panelTall + 20;//Making sure the button panel has room for new button height

            //Resizing buttons
            //height
            button1Panel.Height = panelTall;
            button2Panel.Height = panelTall;
            button3Panel.Height = panelTall;
            button5Panel.Height = panelTall;
            button16Panel.Height = panelTall;
            clearPanel.Height = panelTall;
            stopPanel.Height = panelTall;
            //Width
            button1Panel.Width = panelSize;
            button2Panel.Width = panelSize;
            button3Panel.Width = panelSize;
            button5Panel.Width = panelSize;
            button16Panel.Width = panelSize;
            clearPanel.Width = panelSize;
            stopPanel.Width = panelSize;
            //resising buttons
            //width
            button1.Width = panelSize - 6;
            button2.Width = panelSize - 6;
            button3.Width = panelSize - 6;
            button5.Width = panelSize - 6;
            button16.Width = panelSize - 6;
            clearButton.Width = panelSize - 6;
            stopButton.Width = panelSize - 6;
            //Height
            button1.Height = panelTall - 6;
            button2.Height = panelTall - 6;
            button3.Height = panelTall - 6;
            button5.Height = panelTall - 6;
            button16.Height = panelTall - 6;
            clearButton.Height = panelTall - 6;
            stopButton.Height = panelTall - 6;
            //Relocating panels
            button1Panel.Left = 0;
            button2Panel.Left = button1Panel.Left + distance;
            button3Panel.Left = button2Panel.Left + distance;
            button5Panel.Left = button3Panel.Left + distance;
            button16Panel.Left = button5Panel.Left + distance;
            clearPanel.Left = button16Panel.Left + distance;
            stopPanel.Left = offScreen;
            //Resizing font for buttons
            button1.Font = new Font(button1.Font.FontFamily, width / 80);
            button2.Font = new Font(button2.Font.FontFamily, width / 80);
            button3.Font = new Font(button3.Font.FontFamily, width / 80);
            button5.Font = new Font(button5.Font.FontFamily, width / 80);
            button16.Font = new Font(button16.Font.FontFamily, width / 80);
            clearButton.Font = new Font(clearButton.Font.FontFamily, width / 80);
            stopButton.Font = new Font(stopButton.Font.FontFamily, width / 80);

        }





        /////////////////////////////Drawing methods///////////////////////////////////


        //Painting lines to screen from list
        private void paintLines()
        {
            bufferGraphics.FillRectangle(backgroundColor, canvasLeft, canvasTop, canvasWidth, canvasHeight);
            foreach (PaintLines line in lines)
            {
                line.drawLine();
            }
            newLine.drawLine();
        }

        //Drawing lines on canvas every 100ms
        private void timer1_Tick(object sender, EventArgs e)
        {
            paintLines();
            graphics.DrawImage(bufferImage, 0, 0);
        }

        //Tracking eye position every 1ms. Checks eye location is within canvas before adding to adding to paintline.
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (drawing)
            {
                Point newPoint = new Point(Convert.ToInt32(eyeFollower.gPAverage.X), Convert.ToInt32(eyeFollower.gPAverage.Y));
                if (((newPoint.Y >= (canvasTop)) && (newPoint.Y <= (canvasTop + canvasHeight-brushSize)))&&(newPoint.X>=canvasLeft))
                {
                    newLine.addPoint(newPoint.X, newPoint.Y);
                }
            }
        }

        //Off button
        private void stopButton_Click(object sender, EventArgs e)
        {
            turnOffPaint();
        }

        //Start new paint line. Switch button location with stopButton.
        private void button16_Click(object sender, EventArgs e)
        {
            newLine = new PaintLines(brushSize, brushColour, bufferGraphics, shape);
            drawing = true;
            stopPanel.Left = onScreen;
            button16Panel.Left = offScreen;
        }


        //Add current line to list of paintlines. Swap out paint and stop buttons.
        private void turnOffPaint()
        {
            lines.Add(newLine);
            button16Panel.Left = onScreen;
            stopPanel.Left = offScreen;
            drawing = false;
        }



        /////////////////////////////Other Buttons///////////////////////////////////

        //Clear canvas.
        private void button4_Click(object sender, EventArgs e)
        {
            turnOffPaint();                                                             //Stop any drawing going on
            lines = new List<PaintLines>();                                             //Start new list (Overwriting old one)
            newLine = new PaintLines(brushSize, brushColour, bufferGraphics, shape);    //Clear out current line
        }

        //Close paint. Show demo page again
        private void button1_Click(object sender, EventArgs e)
        {
            parent.showMaster();
            this.Close();
        }

        //remove last drawn line
        private void button5_Click(object sender, EventArgs e)
        {
            if (!drawing)
            {
                if (lines.Count >= 1)
                {
                    lines.RemoveAt(lines.Count - 1);
                }
            }
            if (drawing)
            {
                turnOffPaint();
            }
            newLine = new PaintLines(brushSize, brushColour, bufferGraphics, shape);

        }



        /////////////////////////////Background colour buttons///////////////////////////////////


        //Open background panel
        private void button3_Click(object sender, EventArgs e)
        {
            turnOffPaint();
            backgroundPanel.Left = 0;
            buttonPanel.Left = offScreen;
        }

        //Change colour of brush used to draw canvas.
        private void backgroundColour1_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = offScreen;                               //Move background panel off screen
            buttonPanel.Left = 0;                                           //move panel containing buttons back on screen
            backgroundColor = new SolidBrush(backgroundColour1.BackColor);  //Create brush using colour of button pressed
        }

        private void backgroundColour2_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = offScreen;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour2.BackColor);
        }

        private void backgroundColour3_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = offScreen;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour3.BackColor);
        }

        private void backgroundColour4_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = offScreen;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour4.BackColor);
        }

        private void backgroundColour5_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = offScreen;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour5.BackColor);
        }

        private void backgroundColour6_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = offScreen;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour6.BackColor);
        }

        private void backgroundColour7_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = offScreen;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour7.BackColor);
        }

        private void backgroundColour8_Click(object sender, EventArgs e)
        {
            backgroundPanel.Left = offScreen;
            buttonPanel.Left = 0;
            backgroundColor = new SolidBrush(backgroundColour8.BackColor);
        }


        /////////////////////////////Brush Settings///////////////////////////////////

        //Open panel. Highlight brush size and shape that has been previously selected.
        private void button2_Click(object sender, EventArgs e)
        {
            turnOffPaint();
            //highlight currently selected size
            switch (brushSize)
            {
                case 60:
                    largeBrushPanel.BackColor = accentColour;
                    smallBrushPanel.BackColor = mainColour;
                    medBrushPanel.BackColor = mainColour;
                    break;
                case 40:
                    medBrushPanel.BackColor = accentColour;
                    smallBrushPanel.BackColor = mainColour;
                    largeBrushPanel.BackColor = mainColour;
                    break;
                case 20:
                    smallBrushPanel.BackColor = accentColour;
                    largeBrushPanel.BackColor = mainColour;
                    medBrushPanel.BackColor = mainColour;
                    break;

            }
            colourChangeButton.BackColor = brushColour;

            //Move panels on and off screen
            buttonPanel.Left = offScreen;
            brushPanel.Left = 0;
            panel20.Left = 0;
        }

        //Save selected settings. Move setting panel and show button panel.
        private void button40_Click(object sender, EventArgs e)
        {
            brushPanel.Left = offScreen;
            brushColours.Left = offScreen;
            buttonPanel.Left = 0;
        }

        //Show panel with different paint colour options.
        private void button41_Click(object sender, EventArgs e)
        {
            brushColours.Left = 0;
            brushColours.Visible = true;
            panel20.Left = offScreen;
        }

        /////////////////////////////Brush Size///////////////////////////////////


        //Small
        private void smallBrush_Click(object sender, EventArgs e)
        {
            brushSize = 20;                                 //Change size
            smallBrushPanel.BackColor = accentColour;       //Highlight burron selected
            largeBrushPanel.BackColor = mainColour;         //Change other buttons to normal colour
            medBrushPanel.BackColor = mainColour;           //Change other buttons to normal colour
        }

        //Medium
        private void medBrush_Click(object sender, EventArgs e)
        {
            medBrushPanel.BackColor = accentColour;
            smallBrushPanel.BackColor = mainColour;
            largeBrushPanel.BackColor = mainColour;
            brushSize = 40;
        }

        //Large
        private void largeBrush_Click(object sender, EventArgs e)
        {
            largeBrushPanel.BackColor = accentColour;
            smallBrushPanel.BackColor = mainColour;
            medBrushPanel.BackColor = mainColour;
            brushSize = 60;
        }

        /////////////////////////////Brush Size///////////////////////////////////
        
        //Change colour of paintbrush based on selected button
        private void colourOptionButton1_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton1.BackColor;    //Change colour of brush
            colourChangeButton.BackColor = brushColour;     //Change colour of button on setting menu
            brushColours.Left = offScreen;                  //Move colour panel off screen
            panel20.Left = 0;                               //Move setting options back on screen
        }

        private void colourOptionButton2_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton2.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton3_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton3.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton4_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton4.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton16_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton16.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton5_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton5.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton6_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton6.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton7_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton7.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton8_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton8.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton9_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton9.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton10_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton10.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton11_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton11.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton12_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton12.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton13_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton13.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton14_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton14.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton15_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton15.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton17_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton17.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }

        private void colourOptionButton18_Click(object sender, EventArgs e)
        {
            brushColour = colourOptionButton18.BackColor;
            colourChangeButton.BackColor = brushColour;
            brushColours.Left = offScreen;
            panel20.Left = 0;
        }



        /////////////////////////////Brush Shape///////////////////////////////////


        //Square
        private void button39_Click(object sender, EventArgs e)
        {
            shape = false;                      //false = square shape
            button37.BackColor = mainColour;    //Change highlighted button
            button39.BackColor = accentColour;  //Highlight "Square" button
        }

        //Circle
        private void button37_Click(object sender, EventArgs e)
        {
            shape = true;
            button39.BackColor = mainColour;
            button37.BackColor = accentColour;
        }






    }
}
