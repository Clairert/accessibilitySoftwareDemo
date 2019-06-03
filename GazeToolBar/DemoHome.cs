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
            scroll = new ScrollControl(eyeXHost);
            scroll.StartScroll();
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
            PeoplePictureBox.Image = GazeToolBar.Properties.Resources.David;

            //peoplePictureBox2.Location = new Point((PeopleInfoPanel.Width / 4 * 0) + 2, PeopleInfoPanel.Height / 2);
            //peoplePictureBox2.Size = new Size(300, 300);
            //peoplePictureBox2.Width = (PeopleInfoPanel.Width / 4);
            //peoplePictureBox2.Image = GazeToolBar.Properties.Resources.David;
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
            ProgrammePictureBox.Image = GazeToolBar.Properties.Resources.David;



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
            ProjectPictureBox.Image = GazeToolBar.Properties.Resources.David;






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
        ///People
        ///

        private void peopleButtonClick(String title, Bitmap picture, String changeText)
        {
            //changeDisplay(title, changeText, PeopleLabel, PeopleRichTextbox1, peoplePictureBox1, picture, PeopleInfoPanel.Width);
            //peoplePictureBox1.Location = new Point((PeopleInfoPanel.Width / 4 * 3) + 2,PeopleRichTextbox1.Top);
            //peoplePictureBox1.Width = (PeopleInfoPanel.Width / 4);
        }

        private void People1_Click(object sender, EventArgs e)
        {
            //peopleButtonClick(People1.Text, GazeToolBar.Properties.Resources.David, GazeToolBar.Properties.Resources.David_Rozado_text);
        }

        private void People2_Click(object sender, EventArgs e)
        {
            //peopleButtonClick(People2.Text, GazeToolBar.Properties.Resources.KrissiW, GazeToolBar.Properties.Resources.Krissi_Wood_Text);
            //PeopleRichTextbox1.Width = (PeopleInfoPanel.Width / 4 * 3) - 4;
            //PeopleRichTextbox1.Height = PeopleInfoPanel.Height - 4;
            //PeopleRichTextbox1.Location = new Point(2, 2);
            //PeopleRichTextbox1.Text = GazeToolBar.Properties.Resources.Krissi_Wood_Text;


            //peoplePictureBox1.Location = new Point((PeopleInfoPanel.Width / 4 * 3) + 2, 2);
            //peoplePictureBox1.Width = (PeopleInfoPanel.Width / 4);
            //peoplePictureBox1.Image = GazeToolBar.Properties.Resources.Krissi;
        }

        private void People3_Click(object sender, EventArgs e)
        {
            //peopleButtonClick(People3.Text, GazeToolBar.Properties.Resources.Adon_Moskal, GazeToolBar.Properties.Resources.Adon_Moskal_Text);
        }

        private void People4_Click(object sender, EventArgs e)
        {
            //peopleButtonClick(People4.Text, GazeToolBar.Properties.Resources.Dale_Parsons, GazeToolBar.Properties.Resources.Dale_Parsons_Text);
        }

        /////////////////////////////////////Clicking buttons////////////////////////////////////////
        ///Programme
        private void ProgrammeBackButton_Click(object sender, EventArgs e)
        {
            showMaster();
        }


        private void programmeButtonClick(String title, Bitmap picture, String changeText, String changeText2, Bitmap picture2)
        {
            //changeDisplay(title, changeText, ProgrammeLabel, ProgrammeRichTextBox, ProgrammePictureBox, picture, ProgrammeInfoPanel.Width, programmePictureBox2, picture2);
            //ProgrammeRichTextBox2.Text = changeText2;
            

        }

        private void ProgrammeButton1_Click(object sender, EventArgs e)
        {
            //programmeButtonClick(Programme1.Text, GazeToolBar.Properties.Resources.CIT_Image, GazeToolBar.Properties.Resources.CIT3, GazeToolBar.Properties.Resources.CIT32, GazeToolBar.Properties.Resources.CIT3Image2);
        }

        private void ProgrammeButton2_Click(object sender, EventArgs e)
        {
            //programmeButtonClick(Programme2.Text, GazeToolBar.Properties.Resources.CIT_Image, GazeToolBar.Properties.Resources.Certificate_Programme, GazeToolBar.Properties.Resources.Certificate_Programme2, GazeToolBar.Properties.Resources.CIT4Image2);
        }

        private void ProgrammeButton3_Click(object sender, EventArgs e)
        {
            //programmeButtonClick(Programme3.Text, GazeToolBar.Properties.Resources.BIT_Image, GazeToolBar.Properties.Resources.BIT_Programme, GazeToolBar.Properties.Resources.BIT_Programme2, GazeToolBar.Properties.Resources.BITImage2);
        }

        private void ProgrammeButton4_Click(object sender, EventArgs e)
        {
            //programmeButtonClick(Programme4.Text, GazeToolBar.Properties.Resources.Graduate_Diploma1, GazeToolBar.Properties.Resources.Graduate_Diploma, GazeToolBar.Properties.Resources.Graduate_Diploma2, GazeToolBar.Properties.Resources.GraduateImage2);
            //ProgrammeRichTextBox.Text = GazeToolBar.Properties.Resources.Graduate_Diploma;
            ////ProgrammePictureBox.Location = new Point((ProgrammeInfoPanel.Width / 4 * 3) + 2, 2);
            //ProgrammePictureBox.Width = (ProgrammeInfoPanel.Width / 4);
            //ProgrammePictureBox.Image = GazeToolBar.Properties.Resources.Graduate_Diploma1;
        }



        /////////////////////////////////////Clicking buttons////////////////////////////////////////
        ///Project
        private void ProjectBack_Click(object sender, EventArgs e)
        {
            showMaster();
        }






        /*private void projectButtonClick(String title, Bitmap picture, String changeText, String changeText2, Bitmap picture2)
        {
            changeDisplay(title, changeText, ProjectLabel, ProjectRichTextBox, ProjectPictureBox, picture, ProjectInfoPanel.Width, projectPictureBox2, picture2);
            ProjectPictureBox.Location = new Point((ProjectInfoPanel.Width / 4 * 3) + 2, 2);
            ProjectPictureBox.Width = (ProjectInfoPanel.Width / 4);
            projectPictureBox2.Location = new Point(10, ProjectInfoPanel.Height / 2);
            projectPictureBox2.Size = (ProjectPictureBox.Size);
            ProjectRichTextBox2.Text = changeText2;
        }

        private void ProjectButton1_Click(object sender, EventArgs e)
        {
            projectButtonClick(ProjectButton1.Text, GazeToolBar.Properties.Resources._20190502_140411, GazeToolBar.Properties.Resources.MobileVR, GazeToolBar.Properties.Resources.MobileVR2, GazeToolBar.Properties.Resources.VRHeadSet);
        }

        private void ProjectButton2_Click(object sender, EventArgs e)
        {
            projectButtonClick(ProjectButton2.Text, GazeToolBar.Properties.Resources._20190502_130432, GazeToolBar.Properties.Resources.Volunteering, GazeToolBar.Properties.Resources.Volunteering2, GazeToolBar.Properties.Resources.Volunteer_Website);
        }

        private void ProjectButton3_Click(object sender, EventArgs e)
        {
            projectButtonClick(ProjectButton3.Text, GazeToolBar.Properties.Resources._20190502_142720, GazeToolBar.Properties.Resources.IOT, GazeToolBar.Properties.Resources.IOT2, GazeToolBar.Properties.Resources.pastedImage);
        }

        private void ProjectButton4_Click(object sender, EventArgs e)
        {
            projectButtonClick(ProjectButton4.Text, GazeToolBar.Properties.Resources.pastedImage, GazeToolBar.Properties.Resources.GazeToolBar, GazeToolBar.Properties.Resources.GazeToolBar2, GazeToolBar.Properties.Resources.Volunteer_Website);
        }*/

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
