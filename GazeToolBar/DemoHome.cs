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


            //Create Panels
            showMaster();


        }

        private void People_Click(object sender, EventArgs e)
        {
            showPeople();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showProgramme();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void showMaster()
        {
            setupMasterPanel();
            MasterPeoplePanel.Location = new Point(5000, 5000);
            MasterProgrammePanel.Location = new Point(5000, 5000);
        }

        private void showPeople()
        {
            setupMasterPeoplePanel();
            MasterPanel.Location = new Point(5000, 5000);
            MasterProgrammePanel.Location = new Point(5000, 5000);
        }

        private void showProgramme()
        {
            setupMasterProgrammePanel();
            MasterPeoplePanel.Location = new Point(5000, 5000);
            MasterPanel.Location = new Point(5000, 5000);
        }

        private void setupMasterPanel()
        {
            MasterPanel.Top = 0;
            MasterPanel.Left = 0;
            MasterPanel.Height = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenHeight));
            MasterPanel.Width = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenWidth));

            int panelWidth = panel1.Width;
            int panelHeight = panel1.Height;
            int taskBHeight = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenHeight - System.Windows.SystemParameters.WorkArea.Height));

            panel1.Top = 50;
            panel1.Left = 50;
            People.Location = new Point(2, 2);
            People.Height = panel1.Height - 4;
            People.Width = panel1.Width - 4;

            panel2.Top = 50;
            panel2.Left = (ClientSize.Width - 50) - panelWidth;

            panel3.Top = (Screen.FromControl(this).Bounds.Height - panel3.Height) - 50;
            panel3.Left = 50;

            panel4.Top = (Screen.FromControl(this).Bounds.Height - panel4.Height) - 50;
            panel4.Left = (ClientSize.Width - 50) - panelWidth;

            pictureBox2.Location = new Point((MasterPanel.Width / 2) - pictureBox2.Size.Width / 2, (MasterPanel.Height / 2) - pictureBox2.Size.Height / 2);
        }

        private void setupMasterPeoplePanel()
        {
            MasterPeoplePanel.Top = 0;
            MasterPeoplePanel.Left = 0;
            MasterPeoplePanel.Height = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenHeight));
            MasterPeoplePanel.Width = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenWidth));

            double top = ClientSize.Height * 0.25;
            double right = ClientSize.Width * 0.75;
            double left = ClientSize.Width * 0.25;
            double bottom = ClientSize.Height * 0.75;

            double step = 0.05;
            int buttonHeight = Convert.ToInt32((bottom * 0.75) / 4);
            int buttonWidth = Convert.ToInt32(left * 0.75);
            int buttonLeft = Convert.ToInt32(left * 0.12);


            //Back button - top,Left section
            PeopleButtonPanel1.Height = buttonHeight;
            PeopleButtonPanel1.Width = buttonWidth;
            PeopleButtonPanel1.Top = Convert.ToInt32(top * 0.1);
            PeopleButtonPanel1.Left = buttonLeft;

            PeopleBack.Location = new Point(2, 2);
            PeopleBack.Height = PeopleButtonPanel1.Height - 4;
            PeopleBack.Width = PeopleButtonPanel1.Width - 4;
            PeopleBack.Text = "Back";



            //Buttons on bottom half of screen - bottom,left section

            PeopleButtonPanel2.Height = buttonHeight;
            PeopleButtonPanel2.Width = buttonWidth;
            PeopleButtonPanel2.Top = Convert.ToInt32((bottom * step) + top);
            PeopleButtonPanel2.Left = buttonLeft;

            People1.Location = new Point(2, 2);
            People1.Height = PeopleButtonPanel2.Height - 4;
            People1.Width = PeopleButtonPanel2.Width - 4;
            People1.Text = "Person1";
            step += 0.25;



            PeopleButtonPanel3.Height = buttonHeight;
            PeopleButtonPanel3.Width = buttonWidth;
            PeopleButtonPanel3.Top = Convert.ToInt32((bottom * step) + top);
            PeopleButtonPanel3.Left = buttonLeft;

            People2.Location = new Point(2, 2);
            People2.Height = PeopleButtonPanel3.Height - 4;
            People2.Width = PeopleButtonPanel3.Width - 4;
            People2.Text = "Person2";
            step += 0.25;



            PeopleButtonPanel4.Height = buttonHeight;
            PeopleButtonPanel4.Width = buttonWidth;
            PeopleButtonPanel4.Top = Convert.ToInt32((bottom * step) + top);
            PeopleButtonPanel4.Left = buttonLeft;


            People3.Location = new Point(2, 2);
            People3.Height = PeopleButtonPanel4.Height - 4;
            People3.Width = PeopleButtonPanel4.Width - 4;
            People3.Text = "Person3";
            step += 0.25;



            PeopleButtonPanel5.Height = buttonHeight;
            PeopleButtonPanel5.Width = buttonWidth;
            PeopleButtonPanel5.Top = Convert.ToInt32((bottom * step) + top);
            PeopleButtonPanel5.Left = buttonLeft;


            People4.Location = new Point(2, 2);
            People4.Height = PeopleButtonPanel5.Height - 4;
            People4.Width = PeopleButtonPanel5.Width - 4;
            People4.Text = "Person4";

            //title - top,right section
            PeopleLabel.Text = "Section Title";
            PeopleLabel.Font = new Font(PeopleLabel.Font.FontFamily, Convert.ToInt32(right) / 20);
            PeopleLabel.Left = ((Convert.ToInt32(right) - PeopleLabel.Width) / 2) + Convert.ToInt32(left);

            //Panel
            PeopleInfoPanel.Top = Convert.ToInt32(top);
            PeopleInfoPanel.Left = Convert.ToInt32(left + (right * 0.025));
            PeopleInfoPanel.Height = Convert.ToInt32(bottom - (bottom * 0.05));
            PeopleInfoPanel.Width = Convert.ToInt32(right - (right * 0.05));
        }

        private void setupMasterProgrammePanel()
        {
            double top = ClientSize.Height * 0.25;
            double right = ClientSize.Width * 0.75;
            double left = ClientSize.Width * 0.25;
            double bottom = ClientSize.Height * 0.75;

            double step = 0.05;
            int buttonHeight = Convert.ToInt32((bottom * 0.75) / 4);
            int buttonWidth = Convert.ToInt32(left * 0.75);
            int buttonLeft = Convert.ToInt32(left * 0.12);


            //Back button - top,Left section



            MasterProgrammePanel.Top = 0;
            MasterProgrammePanel.Left = 0;
            MasterProgrammePanel.Height = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenHeight));
            MasterProgrammePanel.Width = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenWidth));


            //Back button - top,Left section
            ProgrammeButtonPanel1.Height = buttonHeight;
            ProgrammeButtonPanel1.Width = buttonWidth;
            ProgrammeButtonPanel1.Top = Convert.ToInt32(top * 0.1);
            ProgrammeButtonPanel1.Left = buttonLeft;

            ProgrammeBack.Location = new Point(2, 2);
            ProgrammeBack.Height = ProgrammeButtonPanel1.Height - 4;
            ProgrammeBack.Width = ProgrammeButtonPanel1.Width - 4;
            ProgrammeBack.Text = "Back";



            //Buttons on bottom half of screen - bottom,left section

            ProgrammeButtonPanel2.Height = buttonHeight;
            ProgrammeButtonPanel2.Width = buttonWidth;
            ProgrammeButtonPanel2.Top = Convert.ToInt32((bottom * step) + top);
            ProgrammeButtonPanel2.Left = buttonLeft;

            Programme1.Location = new Point(2, 2);
            Programme1.Height = ProgrammeButtonPanel2.Height - 4;
            Programme1.Width = ProgrammeButtonPanel2.Width - 4;
            Programme1.Text = "Programme1";
            step += 0.25;



            ProgrammeButtonPanel3.Height = buttonHeight;
            ProgrammeButtonPanel3.Width = buttonWidth;
            ProgrammeButtonPanel3.Top = Convert.ToInt32((bottom * step) + top);
            ProgrammeButtonPanel3.Left = buttonLeft;

            Programme2.Location = new Point(2, 2);
            Programme2.Height = ProgrammeButtonPanel3.Height - 4;
            Programme2.Width = ProgrammeButtonPanel3.Width - 4;
            Programme2.Text = "Programme2";
            step += 0.25;



            ProgrammeButtonPanel4.Height = buttonHeight;
            ProgrammeButtonPanel4.Width = buttonWidth;
            ProgrammeButtonPanel4.Top = Convert.ToInt32((bottom * step) + top);
            ProgrammeButtonPanel4.Left = buttonLeft;


            Programme3.Location = new Point(2, 2);
            Programme3.Height = ProgrammeButtonPanel4.Height - 4;
            Programme3.Width = ProgrammeButtonPanel4.Width - 4;
            Programme3.Text = "Programme3";
            step += 0.25;



            ProgrammeButtonPanel5.Height = buttonHeight;
            ProgrammeButtonPanel5.Width = buttonWidth;
            ProgrammeButtonPanel5.Top = Convert.ToInt32((bottom * step) + top);
            ProgrammeButtonPanel5.Left = buttonLeft;


            Programme4.Location = new Point(2, 2);
            Programme4.Height = ProgrammeButtonPanel5.Height - 4;
            Programme4.Width = ProgrammeButtonPanel5.Width - 4;
            Programme4.Text = "Programme4";

            //title - top,right section
            ProgrammeLabel.Text = "Section Title";
            ProgrammeLabel.Font = new Font(ProgrammeLabel.Font.FontFamily, Convert.ToInt32(right) / 20);
            ProgrammeLabel.Left = ((Convert.ToInt32(right) - ProgrammeLabel.Width) / 2) + Convert.ToInt32(left);

            //Panel
            ProgrammeInfoPanel.Top = Convert.ToInt32(top);
            ProgrammeInfoPanel.Left = Convert.ToInt32(left + (right * 0.025));
            ProgrammeInfoPanel.Height = Convert.ToInt32(bottom - (bottom * 0.05));
            ProgrammeInfoPanel.Width = Convert.ToInt32(right - (right * 0.05));

        }

        private void setupPanels()
        {

        }

        private void PeopleBack_Click(object sender, EventArgs e)
        {
            showMaster();
        }

        private void People1_Click(object sender, EventArgs e)
        {

        }

        private void People2_Click(object sender, EventArgs e)
        {

        }

        private void People3_Click(object sender, EventArgs e)
        {

        }

        private void People4_Click(object sender, EventArgs e)
        {

        }

        private void ProgrammeBackButton_Click(object sender, EventArgs e)
        {
            showMaster();
        }

        private void ProgrammeButton1_Click(object sender, EventArgs e)
        {

        }

        private void ProgrammeButton2_Click(object sender, EventArgs e)
        {

        }

        private void ProgrammeButton3_Click(object sender, EventArgs e)
        {

        }

        private void ProgrammeButton4_Click(object sender, EventArgs e)
        {

        }

        private void DemoHome_Load(object sender, EventArgs e)
        {

        }
    }
}
