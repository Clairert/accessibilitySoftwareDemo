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
    public partial class InformationPage : Form
    {
        public InformationPage()
        {
            InitializeComponent();
            
            //Splitting screen into sections
            double top = ClientSize.Height * 0.25;
            double right = ClientSize.Width * 0.75;
            double left = ClientSize.Width * 0.25;
            double bottom = ClientSize.Height * 0.75;


            //Back button - top,Left section
            button1.Height = Convert.ToInt32(top - (top * 0.2));
            button1.Width = Convert.ToInt32((left * 0.8));
            button1.Top = Convert.ToInt32(top * 0.1);
            button1.Left = Convert.ToInt32(left * 0.1);


            //Buttons on bottom half of screen - bottom,left section
            double step = 0.05;
            int buttonHeight = Convert.ToInt32((bottom * 0.75) / 4);
            int buttonWidth = Convert.ToInt32(left * 0.75);
            int buttonLeft = Convert.ToInt32(left * 0.12);

            button2.Height = buttonHeight;
            button2.Width = buttonWidth;
            button2.Top = Convert.ToInt32((bottom * step)+top);
            button2.Left = buttonLeft;
            step += 0.25;

            button3.Height = buttonHeight;
            button3.Width = buttonWidth;
            button3.Top = Convert.ToInt32((bottom * step) + top);
            button3.Left = buttonLeft;
            step += 0.25;

            button4.Height = buttonHeight;
            button4.Width = buttonWidth;
            button4.Top = Convert.ToInt32((bottom * step) + top);
            button4.Left = buttonLeft;
            step += 0.25;

            button5.Height = buttonHeight;
            button5.Width = buttonWidth;
            button5.Top = Convert.ToInt32((bottom * step) + top);
            button5.Left = buttonLeft;

            //title - top,right section
            label1.Text = "Section Title";
            label1.Font = new Font(label1.Font.FontFamily, Convert.ToInt32(right) / 20);
            label1.Left = ((Convert.ToInt32(right) - label1.Width) / 2) + Convert.ToInt32(left);

            //Panel
            panel1.Top = Convert.ToInt32(top);
            panel1.Left = Convert.ToInt32(left);
            panel1.Height = Convert.ToInt32(bottom -(bottom*0.05));
            panel1.Width = Convert.ToInt32(right - (right*0.05));






        }
    }
}
