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
    public enum SystemState { Wait, ActionButtonSelected, Zooming, ZoomWait, ApplyAction, ScrollWait }

    //The actions that can be performed by the program
    public enum ActionToBePerformed { RightClick, LeftClick, DoubleClick, Scroll, none }

    public partial class DemoHome : Form
    {
        Paint paint;
        SimplePaint simplePaint;
        private static FormsEyeXHost eyeXHost;
        private double right;
        private double left;
        private ScrollControl scroll;
        public DemoHome()
        {
            eyeXHost = new FormsEyeXHost();
            eyeXHost.Start();
            InitializeComponent();
            connectBehaveMap();
            paint = new Paint(eyeXHost, this);
            simplePaint = new SimplePaint(eyeXHost, this);
            foreach (Control control  in this.Controls)
            {
                foreach (RichTextBox richT in control.Controls.OfType<RichTextBox>())
                {
                    richT.ReadOnly = true;
                }                   
            }
            //Create Panels
            showMaster();
            trialPanel.Width = 0;
            trialPanel.Height = 0;

            scroll = new ScrollControl(eyeXHost);
            scroll.StartScroll();

        }

        //Show People
        private void People_Click(object sender, EventArgs e)
        {
            showPeople();
        }

        //Show Programme Panel
        private void button2_Click(object sender, EventArgs e)
        {
            showProgramme();
        }

        //Show projects panel
        private void button3_Click(object sender, EventArgs e)
        {
            showProject();
        }

        //Close any old paint forms. Create and show new Paint form.
        private void button4_Click(object sender, EventArgs e)
        {
            //paint.Close();
            //paint = new Paint(eyeXHost, this);
            //showPaint();
            scroll.stopScroll();
            simplePaint.Close();
            simplePaint = new SimplePaint(eyeXHost, this);
            showPaint();
        }

        //Show paint. Relocate Panels
        private void showPaint()
        {
            //paint.Show();
            simplePaint.Show();
            MasterPanel.Location = new Point(5000, 5000);
            MasterPeoplePanel.Location = new Point(5000, 5000);
            MasterProgrammePanel.Location = new Point(5000, 5000);
            MasterProjectPanel.Location = new Point(5000, 5000);
        }

        //Show master panel, hide all other panels
        public void showMaster()
        {
            setupMasterPanel();
            setupMasterPanel(); //fixes bug :/
            paint.Location = new Point(5000, 5000);
            MasterPeoplePanel.Location = new Point(5000, 5000);
            MasterProgrammePanel.Location = new Point(5000, 5000);
            MasterProjectPanel.Location = new Point(5000, 5000);
        }

        //Show people panel. Hide other panels
        private void showPeople()
        {
            setupMasterPeoplePanel();
            paint.Location = new Point(5000, 5000);
            MasterPanel.Location = new Point(5000, 5000);
            MasterProgrammePanel.Location = new Point(5000, 5000);
            MasterProjectPanel.Location = new Point(5000, 5000);
        }

        //Show programme panel. Hide other panels
        private void showProgramme()
        {
            setupMasterProgrammePanel();
            paint.Location = new Point(5000, 5000);
            MasterPeoplePanel.Location = new Point(5000, 5000);
            MasterPanel.Location = new Point(5000, 5000);
            MasterProjectPanel.Location = new Point(5000, 5000);
        }

        //Show project panel. Hide other panels
        private void showProject()
        {
            setupMasterProjectPanel();
            paint.Location = new Point(5000, 5000);
            MasterPeoplePanel.Location = new Point(5000, 5000);
            MasterPanel.Location = new Point(5000, 5000);
            MasterProgrammePanel.Location = new Point(5000, 5000);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            paint.Location = new Point(5000, 5000);
            MasterPeoplePanel.Location = new Point(5000, 5000);
            MasterPanel.Location = new Point(5000, 5000);
            MasterProgrammePanel.Location = new Point(5000, 5000);
            MasterProjectPanel.Location = new Point(5000, 5000);
            trialPanel.Width = 1000;
            trialPanel.Height = 1000;
            //trialPanel.Focus();
            
        }

        //Set up master panel with buttons spaced evenly around the screen and the logo.
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
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        //Set up Panels and buttons for people panel
        private void setupMasterPeoplePanel()
        {
            MasterPeoplePanel.Top = 0;
            MasterPeoplePanel.Left = 0;
            MasterPeoplePanel.Height = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenHeight));
            MasterPeoplePanel.Width = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenWidth));

            double top = ClientSize.Height * 0.25;
            right = ClientSize.Width * 0.75;
            left = ClientSize.Width * 0.25;
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


            adonPanel.Height = PeopleButtonPanel1.Height;
            adonPanel.Width = PeopleButtonPanel1.Width;
            adonPanel.Top = Convert.ToInt32((bottom+top)-(adonPanel.Height+30));
            adonPanel.Left = PeopleButtonPanel1.Left;

            adonButton.Location = new Point(2, 2);
            adonButton.Height = adonPanel.Height - 4;
            adonButton.Width = adonPanel.Width - 4;
            Random rgen = new Random();
            adonButton.BackColor = Color.FromArgb(rgen.Next(255), rgen.Next(255), rgen.Next(255));
            adonButton.Font = new Font(adonButton.Font.FontFamily, Convert.ToInt32(right) / 40);




            //title - top,right section
            PeopleLabel.Text = "People";
            PeopleLabel.Font = new Font(PeopleLabel.Font.FontFamily, Convert.ToInt32(right) / 20);
            PeopleLabel.Left = ((Convert.ToInt32(right) - PeopleLabel.Width) / 2) + Convert.ToInt32(left);

            //Panel
            PeopleInfoPanel.Top = Convert.ToInt32(top);
            PeopleInfoPanel.Left = Convert.ToInt32(left + (right * 0.025));
            PeopleInfoPanel.Height = Convert.ToInt32(bottom - (bottom * 0.05));
            PeopleInfoPanel.Width = Convert.ToInt32(right - (right * 0.05));



            PeoplePictureBox.Location = new Point(2, 2);
            PeoplePictureBox.Width = (PeopleInfoPanel.Width - 2);
            PeoplePictureBox.Height = (PeopleInfoPanel.Height - 2);
            //PeoplePictureBox.Image = GazeToolBar.Properties.Resources.David;

        }

        //Set up Panels and buttons for programme panel
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


            //Back button - top,Left sectionC:\Users\hanspj2\Desktop\Demo\accessibilitySoftwareDemo\GazeToolBar\Resources\20190502_140420.jpg
            ProgrammeButtonPanel1.Height = buttonHeight;
            ProgrammeButtonPanel1.Width = buttonWidth;
            ProgrammeButtonPanel1.Top = Convert.ToInt32(top * 0.1);
            ProgrammeButtonPanel1.Left = buttonLeft;

            ProgrammeBack.Location = new Point(2, 2);
            ProgrammeBack.Height = ProgrammeButtonPanel1.Height - 4;
            ProgrammeBack.Width = ProgrammeButtonPanel1.Width - 4;
            ProgrammeBack.Text = "Back";



            //Buttons on bottom half of screen - bottom,left section


            //title - top,right section
            ProgrammeLabel.Text = "Programmes";
            ProgrammeLabel.Font = new Font(ProgrammeLabel.Font.FontFamily, Convert.ToInt32(right) / 20);
            ProgrammeLabel.Left = ((Convert.ToInt32(right) - ProgrammeLabel.Width) / 2) + Convert.ToInt32(left);

            //Panel
            ProgrammeInfoPanel.Top = Convert.ToInt32(top);
            ProgrammeInfoPanel.Left = Convert.ToInt32(left + (right * 0.025));
            ProgrammeInfoPanel.Height = Convert.ToInt32(bottom - (bottom * 0.05));
            ProgrammeInfoPanel.Width = Convert.ToInt32(right - (right * 0.05));

            

            ProgrammeInfoPanel.Size = ProgrammeInfoPanel.Size;

            ProgrammePictureBox.Location = new Point(2, 2);
            ProgrammePictureBox.Width = (ProgrammeInfoPanel.Width - 2);
            ProgrammePictureBox.Height = (ProgrammeInfoPanel.Height - 2);
            ProgrammeInfoPanel.Focus();



        }

        //Set up Panels and buttons for project panel
        private void setupMasterProjectPanel()
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



            MasterProjectPanel.Top = 0;
            MasterProjectPanel.Left = 0;
            MasterProjectPanel.Height = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenHeight));
            MasterProjectPanel.Width = Convert.ToInt32(Math.Abs(System.Windows.SystemParameters.PrimaryScreenWidth));


            //Back button - top,Left section
            ProjectButtonPanel1.Height = buttonHeight;
            ProjectButtonPanel1.Width = buttonWidth;
            ProjectButtonPanel1.Top = Convert.ToInt32(top * 0.1);
            ProjectButtonPanel1.Left = buttonLeft;

            ProjectBack.Location = new Point(2, 2);
            ProjectBack.Height = ProjectButtonPanel1.Height - 4;
            ProjectBack.Width = ProjectButtonPanel1.Width - 4;
            ProjectBack.Text = "Back";



            //Buttons on bottom half of screen - bottom,left section


            //title - top,right section
            ProjectLabel.Text = "Project";
            ProjectLabel.Font = new Font(ProjectLabel.Font.FontFamily, Convert.ToInt32(right) / 20);
            ProjectLabel.Left = ((Convert.ToInt32(right) - ProjectLabel.Width) / 2) + Convert.ToInt32(left);

            //Panel
            ProjectInfoPanel.Top = Convert.ToInt32(top);
            ProjectInfoPanel.Left = Convert.ToInt32(left + (right * 0.025));
            ProjectInfoPanel.Height = Convert.ToInt32(bottom - (bottom * 0.05));
            ProjectInfoPanel.Width = Convert.ToInt32(right - (right * 0.05));

            ProjectInfoPanel.Size = ProjectInfoPanel.Size;

            ProjectPictureBox.Location = new Point(2, 2);
            ProjectPictureBox.Width = (ProjectInfoPanel.Width - 2);
            ProjectPictureBox.Height = (ProjectInfoPanel.Height - 2);
            //ProjectPictureBox.Image = GazeToolBar.Properties.Resources.David;






        }


        //Back button
        private void PeopleBack_Click(object sender, EventArgs e)
        {
            showMaster();
        }


        private void changeDisplay(String title, String changeText, Label label, RichTextBox textBox, PictureBox picture,Bitmap pic, int panelWidth, PictureBox picture2, Bitmap pic2)
        {
            textBox.Text = changeText;

            label.Text = title;
            right = ClientSize.Width * 0.75;
            left = ClientSize.Width * 0.25;
            label.Left = ((Convert.ToInt32(right) - label.Width) / 2) + Convert.ToInt32(left);
            picture.Image = pic;
            picture2.Image = pic2;

        }

        private void changeDisplay(String title, String changeText, Label label, RichTextBox textBox, PictureBox picture, Bitmap pic, int panelWidth)
        {
            textBox.Text = changeText;

            label.Text = title;
            right = ClientSize.Width * 0.75;
            left = ClientSize.Width * 0.25;
            label.Left = ((Convert.ToInt32(right) - label.Width) / 2) + Convert.ToInt32(left);
            picture.Image = pic;

        }

        /////////////////////////////////////Clicking buttons////////////////////////////////////////
        ///Programme
        private void ProgrammeBackButton_Click(object sender, EventArgs e)
        {
            showMaster();
        }

        /////////////////////////////////////Clicking buttons////////////////////////////////////////
        ///Project
        private void ProjectBack_Click(object sender, EventArgs e)
        {
            showMaster();
        }





        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void adonButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://kate.ict.op.ac.nz/~toshcr1/PotteryAndTees/");
            this.Hide();
        }
    }
}
