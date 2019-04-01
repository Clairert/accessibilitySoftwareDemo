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
using GazeToolBar;

namespace GazeToolBar
{
    public partial class DemoHome : Form
    {
        private static FormsEyeXHost eyeXHost;
        public DemoHome()
        {
            eyeXHost = new FormsEyeXHost();
            eyeXHost.Start();
            InitializeComponent();
            connectBehaveMap();

            int panelWidth = panel1.Width;
            int panelHeight = panel1.Height;
            int taskBHeight = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenHeight - System.Windows.SystemParameters.WorkArea.Height));

            panel1.Top = 50;
            panel1.Left = 50;

            panel2.Top = 50;
            panel2.Left = (ClientSize.Width-50)-panelWidth;

            panel3.Top = (ClientSize.Height + taskBHeight) - (panelHeight);
            panel3.Left = 50;

            panel4.Top = (ClientSize.Height + taskBHeight) - (panelHeight);
            panel4.Left = (ClientSize.Width - 50) - panelWidth;

        }

        private void People_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
