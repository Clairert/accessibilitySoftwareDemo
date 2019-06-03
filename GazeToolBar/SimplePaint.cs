using EyeXFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazeToolBar
{
    public partial class SimplePaint : Form
    {
        private DemoHome parent;
        CustomFixationDataStream eyeFollower;
        private static FormsEyeXHost eyeXHost;
        private Graphics graphics;
        private Graphics bufferGraphics;
        private Bitmap bufferImage;
        private SolidBrush backgroundColor;
        private Color brushColour;
        private List<PaintDot> lines;
        private Color mainColour = Color.WhiteSmoke;
        int height;
        int width;

        public SimplePaint(FormsEyeXHost EyeXHost, DemoHome parent)
        {
            this.parent = parent;
            //Eye tracking
            eyeXHost = EyeXHost;
            eyeFollower = new CustomFixationDataStream(eyeXHost);
            InitializeComponent();
            connectBehaveMap();
            height = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenHeight));
            width = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenWidth));
            lines = new List<PaintDot>();
            backgroundColor = new SolidBrush(mainColour);
            graphics = CreateGraphics();
            bufferImage = new Bitmap(width, height);
            bufferGraphics = Graphics.FromImage(bufferImage);
            brushColour = Color.Black;
            dynamicResize();
        }

        private void dynamicResize()
        {
            //Resizing Back Button
            double height = Math.Abs(System.Windows.SystemParameters.PrimaryScreenHeight);
            double width = Math.Abs(System.Windows.SystemParameters.PrimaryScreenWidth);
            backPanel.Width = Convert.ToInt32(width * 0.12);
            backPanel.Height = Convert.ToInt32(height * 0.12);
            backButton.Width = backPanel.Width - 6;
            backButton.Height = backPanel.Height - 6;
            backButton.Font = new Font(backButton.Font.FontFamily, Convert.ToInt32(width / 40));

            resizeButtons(height, width);
        }



        private void resizeButtons(double height, double width)
        {
            //Resizing colour buttons
            double quarterScreen = width * 0.25;
            int emptyScreen = Convert.ToInt32(width * 0.75);
            double sectionWidth = quarterScreen / 2;
            double sectionHeight = height / 4;

            redPanel.Width = Convert.ToInt32(sectionWidth * 0.70);
            redButton.Width = redPanel.Width - 6;
            yellowPanel.Width = Convert.ToInt32(sectionWidth * 0.70);
            yellowButton.Width = yellowPanel.Width - 6;
            purplePanel.Width = Convert.ToInt32(sectionWidth * 0.70);
            purpleButton.Width = purplePanel.Width - 6;
            blackPanel.Width = Convert.ToInt32(sectionWidth * 0.70);
            blackButton.Width = blackPanel.Width - 6;


            bluePanel.Width = Convert.ToInt32(sectionWidth * 0.70);
            blueButton.Width = bluePanel.Width - 6;
            greenPanel.Width = Convert.ToInt32(sectionWidth * 0.70);
            greenButton.Width = greenPanel.Width - 6;
            orangePanel.Width = Convert.ToInt32(sectionWidth * 0.70);
            orangeButton.Width = orangePanel.Width - 6;
            whitePanel.Width = Convert.ToInt32(sectionWidth * 0.70);
            whiteButton.Width = whitePanel.Width - 6;

            //Height Buttons
            redPanel.Height = Convert.ToInt32(sectionHeight * 0.70);
            redButton.Height = redPanel.Height - 6;
            yellowPanel.Height = Convert.ToInt32(sectionHeight * 0.70);
            yellowButton.Height = yellowPanel.Height - 6;
            purplePanel.Height = Convert.ToInt32(sectionHeight * 0.70);
            purpleButton.Height = purplePanel.Height - 6;
            blackPanel.Height = Convert.ToInt32(sectionHeight * 0.70);
            blackButton.Height = blackPanel.Height - 6;

            bluePanel.Height = Convert.ToInt32(sectionHeight * 0.70);
            blueButton.Height = bluePanel.Height - 6;
            greenPanel.Height = Convert.ToInt32(sectionHeight * 0.70);
            greenButton.Height = greenPanel.Height - 6;
            orangePanel.Height = Convert.ToInt32(sectionHeight * 0.70);
            orangeButton.Height = orangePanel.Height - 6;
            whitePanel.Height = Convert.ToInt32(sectionHeight * 0.70);
            whiteButton.Height = whitePanel.Height - 6;

            repositionButtons(emptyScreen, sectionHeight, sectionWidth);
        }


        private void repositionButtons(int emptyScreen, double sectionHeight, double sectionWidth)
        {
            //Repositioning
            int topLevel = Convert.ToInt32(sectionHeight);
            int secondCol = Convert.ToInt32(sectionWidth + emptyScreen);
            redPanel.Location = new Point(emptyScreen, 0);
            bluePanel.Location = new Point(secondCol, 0);

            yellowPanel.Location = new Point(emptyScreen, topLevel);
            greenPanel.Location = new Point(secondCol, topLevel);

            purplePanel.Location = new Point(emptyScreen, topLevel * 2);
            orangePanel.Location = new Point(secondCol, topLevel * 2);

            blackPanel.Location = new Point(emptyScreen, topLevel * 3);
            whitePanel.Location = new Point(secondCol, topLevel * 3);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            parent.showMaster();
            this.Close();
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            brushColour = redButton.BackColor;
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            brushColour = blueButton.BackColor;
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            brushColour = yellowButton.BackColor;
        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            brushColour = greenButton.BackColor;
        }

        private void purpleButton_Click(object sender, EventArgs e)
        {
            brushColour = purpleButton.BackColor;
        }

        private void orangeButton_Click(object sender, EventArgs e)
        {
            brushColour = orangeButton.BackColor;
        }

        private void blackButton_Click(object sender, EventArgs e)
        {
            brushColour = blackButton.BackColor;
        }

        private void whiteButton_Click(object sender, EventArgs e)
        {
            brushColour = whiteButton.BackColor;
        }

        private void trackingTimer_Tick(object sender, EventArgs e)
        {
            lines.Add(new PaintDot(brushColour, bufferGraphics, new Point(Convert.ToInt32(eyeFollower.gPAverage.X-20), Convert.ToInt32(eyeFollower.gPAverage.Y-20))));
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            paintDots();
        }


        private void paintDots()
        {
            bufferGraphics.FillRectangle(backgroundColor, 0, 0, width, height);
            foreach (PaintDot line in lines)
            {
                line.drawCircle();
            }
            graphics.DrawImage(bufferImage, 0, 0);
        }
    }
}
