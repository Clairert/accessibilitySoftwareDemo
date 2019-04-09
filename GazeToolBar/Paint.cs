﻿using System;
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
    public partial class Paint : Form
    {
        public Paint()
        {
            InitializeComponent();

            dynamicResize();





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
            button41.Height = Convert.ToInt32(panel20.Height * 0.25);
            button41.Width = Convert.ToInt32(panel20.Height * 0.25);
            panel23.Height = button41.Height + 6;
            panel23.Width = button41.Width + 6;
            panel23.Left = ((setttingpanel / 2) + setttingpanel - (panel23.Width / 2));
            panel23.Top = ((panel20.Height / 2) - (panel23.Height / 2));


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
            //brushColours.Visible = false;
            //panel20.Visible = false;//brushSize

            //Save Button
            panel24.Height = Convert.ToInt32(height * 0.12);
            panel24.Width = Convert.ToInt32(width * 0.12);
            panel24.Left = width - panel24.Width - 20;
            panel24.Top = 20;
            button40.Height = panel24.Height - 6;
            button40.Width = panel24.Width - 6;
            button40.Font = new Font(button41.Font.FontFamily, width / 40);

        }




        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void canvasPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void brushColours_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
