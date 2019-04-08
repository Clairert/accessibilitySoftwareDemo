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
    public partial class Paint : Form
    {
        public Paint()
        {
            InitializeComponent();

            dynamicResize();





        }


        private void dynamicResize()
        {
            int height = Convert.ToInt32(ClientSize.Height);
            int width = Convert.ToInt32(ClientSize.Width);

            //Labels
            label1.Font = new Font(label1.Font.FontFamily, width / 20);
            label1.Left = ((width - label1.Width) / 2);

            label2.Font = new Font(label1.Font.FontFamily, width / 20);
            label2.Left = ((width - label1.Width) / 2);

            label3.Font = new Font(label1.Font.FontFamily, width / 40);
            label3.Left = ((width - label1.Width) / 2);
            label4.Font = new Font(label1.Font.FontFamily, width / 40);
            label4.Left = ((width - label1.Width) / 2);

            brushPanel.Width = width;
            brushPanel.Height = height;
            brushPanel.Top = 0;
            brushPanel.Left = 0;
            //Resize panels
            foreach (Control control in brushPanel.Controls)
            {
                foreach(Panel pane in control.Controls.OfType<Panel>())
                {
                    pane.Height = Convert.ToInt32(height - (height * 0.2));
                    pane.Top = Convert.ToInt32(height * 0.2);
                    pane.Left = 0;
                    pane.Width = width;
                }
            }

            int colourPanelwidth = brushColours.Width / 11;
            int colourPanelheight = brushColours.Height / 5;
            int down = Convert.ToInt32(brushColours.Height * 0.075);
            int left = Convert.ToInt32(brushColours.Height * 0.075);
            //Resize buttons/panels in brushcolours
            int count = 0;
            int countLeft = 0;
            foreach (Control control in brushColours.Controls)
            {
                foreach (Panel pane in control.Controls.OfType<Panel>())
                {

                    pane.Height = colourPanelheight;
                    pane.Top = down;
                    pane.Left = left+(countLeft*colourPanelwidth);
                    pane.Width = colourPanelwidth;
                    countLeft += 2;
                    if(countLeft>=10)
                    {
                        countLeft = 0;
                        down=down+(count*colourPanelheight);
                        count += 2;
                    }
                }
                foreach (Button button in control.Controls.OfType<Button>())
                {
                }
            }
            panel20.Visible = false;




        }




        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void canvasPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
