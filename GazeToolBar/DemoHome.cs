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
        Paint paint;
        private static FormsEyeXHost eyeXHost;

        public DemoHome()
        {
            eyeXHost = new FormsEyeXHost();
            eyeXHost.Start();
            InitializeComponent();
            connectBehaveMap();
            paint = new Paint(eyeXHost, this);


            //Create Panels
            showMaster();


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
            paint.Close();
            paint = new Paint(eyeXHost, this);
            showPaint();
        }

        //Show paint. Relocate Panels
        private void showPaint()
        {
            paint.Show();
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
            //Maths is hard
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
            PeopleLabel.Text = "People";
            PeopleLabel.Font = new Font(PeopleLabel.Font.FontFamily, Convert.ToInt32(right) / 20);
            PeopleLabel.Left = ((Convert.ToInt32(right) - PeopleLabel.Width) / 2) + Convert.ToInt32(left);

            //Panel
            PeopleInfoPanel.Top = Convert.ToInt32(top);
            PeopleInfoPanel.Left = Convert.ToInt32(left + (right * 0.025));
            PeopleInfoPanel.Height = Convert.ToInt32(bottom - (bottom * 0.05));
            PeopleInfoPanel.Width = Convert.ToInt32(right - (right * 0.05));

            PeopleRichTextbox1.Width = (PeopleInfoPanel.Width / 4 * 3) - 4;
            PeopleRichTextbox1.Height = PeopleInfoPanel.Height - 4;
            PeopleRichTextbox1.Location = new Point(2, 2);
            PeopleRichTextbox1.Text = GazeToolBar.Properties.Resources.David_Rozado_text;


            peoplePictureBox1.Location = new Point((PeopleInfoPanel.Width / 4 * 3) + 2, 2);
            peoplePictureBox1.Width = (PeopleInfoPanel.Width / 4);
            peoplePictureBox1.Image = GazeToolBar.Properties.Resources.David;

            peoplePictureBox2.Location = new Point((PeopleInfoPanel.Width / 4 * 0) + 2, PeopleInfoPanel.Height / 2);
            peoplePictureBox2.Size = new Size(300, 300);
            peoplePictureBox2.Width = (PeopleInfoPanel.Width / 4);
            peoplePictureBox2.Image = GazeToolBar.Properties.Resources.David;
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
            ProgrammeLabel.Text = "Programmes";
            ProgrammeLabel.Font = new Font(ProgrammeLabel.Font.FontFamily, Convert.ToInt32(right) / 20);
            ProgrammeLabel.Left = ((Convert.ToInt32(right) - ProgrammeLabel.Width) / 2) + Convert.ToInt32(left);

            //Panel
            ProgrammeInfoPanel.Top = Convert.ToInt32(top);
            ProgrammeInfoPanel.Left = Convert.ToInt32(left + (right * 0.025));
            ProgrammeInfoPanel.Height = Convert.ToInt32(bottom - (bottom * 0.05));
            ProgrammeInfoPanel.Width = Convert.ToInt32(right - (right * 0.05));

            ProgrammeInfoPanel.Size = ProgrammeInfoPanel.Size;

            ProgrammeRichTextBox.Width = (ProgrammeInfoPanel.Width / 4 * 3) - 4;
            ProgrammeRichTextBox.Height = ProgrammeInfoPanel.Height - 4;
            ProgrammeRichTextBox.Location = new Point(2, 2);
            ProgrammeRichTextBox.Text = GazeToolBar.Properties.Resources.BIT_Programme;


            ProgrammePictureBox.Location = new Point((ProgrammeInfoPanel.Width / 4 * 2) + (ProgrammeInfoPanel.Height / 2));
            ProgrammePictureBox.Width = (ProgrammeInfoPanel.Width / 2);
            ProgrammePictureBox.Height = (ProgrammeInfoPanel.Height / 2);
            ProgrammePictureBox.Image = GazeToolBar.Properties.Resources.BIT_Image;

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

            ProjectButtonPanel2.Height = buttonHeight;
            ProjectButtonPanel2.Width = buttonWidth;
            ProjectButtonPanel2.Top = Convert.ToInt32((bottom * step) + top);
            ProjectButtonPanel2.Left = buttonLeft;

            ProjectButton1.Location = new Point(2, 2);
            ProjectButton1.Height = ProjectButtonPanel2.Height - 4;
            ProjectButton1.Width = ProjectButtonPanel2.Width - 4;
            ProjectButton1.Text = "Project1";
            step += 0.25;



            ProjectButtonPanel3.Height = buttonHeight;
            ProjectButtonPanel3.Width = buttonWidth;
            ProjectButtonPanel3.Top = Convert.ToInt32((bottom * step) + top);
            ProjectButtonPanel3.Left = buttonLeft;

            ProjectButton2.Location = new Point(2, 2);
            ProjectButton2.Height = ProjectButtonPanel3.Height - 4;
            ProjectButton2.Width = ProjectButtonPanel3.Width - 4;
            ProjectButton2.Text = "Project2";
            step += 0.25;



            ProjectButtonPanel4.Height = buttonHeight;
            ProjectButtonPanel4.Width = buttonWidth;
            ProjectButtonPanel4.Top = Convert.ToInt32((bottom * step) + top);
            ProjectButtonPanel4.Left = buttonLeft;


            ProjectButton3.Location = new Point(2, 2);
            ProjectButton3.Height = ProjectButtonPanel4.Height - 4;
            ProjectButton3.Width = ProjectButtonPanel4.Width - 4;
            ProjectButton3.Text = "Project3";
            step += 0.25;



            ProjectButtonPanel5.Height = buttonHeight;
            ProjectButtonPanel5.Width = buttonWidth;
            ProjectButtonPanel5.Top = Convert.ToInt32((bottom * step) + top);
            ProjectButtonPanel5.Left = buttonLeft;


            ProjectButton4.Location = new Point(2, 2);
            ProjectButton4.Height = ProjectButtonPanel5.Height - 4;
            ProjectButton4.Width = ProjectButtonPanel5.Width - 4;
            ProjectButton4.Text = "Project4";

            //title - top,right section
            ProjectLabel.Text = "Projects";
            ProjectLabel.Font = new Font(ProjectLabel.Font.FontFamily, Convert.ToInt32(right) / 20);
            ProjectLabel.Left = ((Convert.ToInt32(right) - ProjectLabel.Width) / 2) + Convert.ToInt32(left);

            //Panel
            ProjectInfoPanel.Top = Convert.ToInt32(top);
            ProjectInfoPanel.Left = Convert.ToInt32(left + (right * 0.025));
            ProjectInfoPanel.Height = Convert.ToInt32(bottom - (bottom * 0.05));
            ProjectInfoPanel.Width = Convert.ToInt32(right - (right * 0.05));

            ProjectInfoPanel.Size = ProjectInfoPanel.Size;

            ProjectRichTextBox.Width = (ProjectInfoPanel.Width / 4 * 3) - 4;
            ProjectRichTextBox.Height = ProjectInfoPanel.Height - 4;
            ProjectRichTextBox.Location = new Point(2, 2);
            ProjectRichTextBox.Text = GazeToolBar.Properties.Resources.David_Rozado_text;


            ProjectPictureBox.Location = new Point((ProjectInfoPanel.Width / 4 * 3) + 2, 2);
            ProjectPictureBox.Width = (ProjectInfoPanel.Width / 4);
            ProjectPictureBox.Image = GazeToolBar.Properties.Resources._20190502_142720;




        }


        //Back button
        private void PeopleBack_Click(object sender, EventArgs e)
        {
            showMaster();
        }


        /////////////////////////////////////Clicking buttons////////////////////////////////////////
        ///People
        private void People1_Click(object sender, EventArgs e)
        {
            PeopleRichTextbox1.Width = (PeopleInfoPanel.Width / 4 * 3) - 4;
            PeopleRichTextbox1.Height = PeopleInfoPanel.Height - 4;
            PeopleRichTextbox1.Location = new Point(2, 2);
            PeopleRichTextbox1.Text = GazeToolBar.Properties.Resources.David_Rozado_text;


            peoplePictureBox1.Location = new Point((PeopleInfoPanel.Width / 4 * 3) + 2, 2);
            peoplePictureBox1.Width = (PeopleInfoPanel.Width / 4);
            peoplePictureBox1.Image = GazeToolBar.Properties.Resources.David;

            
        }

        private void People2_Click(object sender, EventArgs e)
        {
            PeopleRichTextbox1.Width = (PeopleInfoPanel.Width / 4 * 3) - 4;
            PeopleRichTextbox1.Height = PeopleInfoPanel.Height - 4;
            PeopleRichTextbox1.Location = new Point(2, 2);
            PeopleRichTextbox1.Text = GazeToolBar.Properties.Resources.Krissi_Wood_Text;


            peoplePictureBox1.Location = new Point((PeopleInfoPanel.Width / 4 * 3) + 2, 2);
            peoplePictureBox1.Width = (PeopleInfoPanel.Width / 4);
            peoplePictureBox1.Image = GazeToolBar.Properties.Resources.Krissi;
        }

        private void People3_Click(object sender, EventArgs e)
        {
            PeopleRichTextbox1.Width = (PeopleInfoPanel.Width / 4 * 3) - 4;
            PeopleRichTextbox1.Height = PeopleInfoPanel.Height - 4;
            PeopleRichTextbox1.Location = new Point(2, 2);
            PeopleRichTextbox1.Text = GazeToolBar.Properties.Resources.Adon_Moskal_Text;


            peoplePictureBox1.Location = new Point((PeopleInfoPanel.Width / 4 * 3) + 2, 2);
            peoplePictureBox1.Width = (PeopleInfoPanel.Width / 4);
            peoplePictureBox1.Image = GazeToolBar.Properties.Resources.Adon_Moskal;
        }

        private void People4_Click(object sender, EventArgs e)
        {
            PeopleRichTextbox1.Width = (PeopleInfoPanel.Width / 4 * 3) - 4;
            PeopleRichTextbox1.Height = PeopleInfoPanel.Height - 4;
            PeopleRichTextbox1.Location = new Point(2, 2);
            PeopleRichTextbox1.Text = GazeToolBar.Properties.Resources.Dale_Parsons_Text;


            peoplePictureBox1.Location = new Point((PeopleInfoPanel.Width / 4 * 3) + 2, 2);
            peoplePictureBox1.Width = (PeopleInfoPanel.Width / 4);
            peoplePictureBox1.Image = GazeToolBar.Properties.Resources.Dale;
        }

        /////////////////////////////////////Clicking buttons////////////////////////////////////////
        ///Programme
        private void ProgrammeBackButton_Click(object sender, EventArgs e)
        {
            showMaster();
        }

        private void ProgrammeButton1_Click(object sender, EventArgs e)
        {
            ProgrammeRichTextBox.Width = (ProgrammeInfoPanel.Width / 4 * 3) - 4;
            ProgrammeRichTextBox.Height = ProgrammeInfoPanel.Height - 4;
            ProgrammeRichTextBox.Location = new Point(2, 2);
            ProgrammeRichTextBox.Text = GazeToolBar.Properties.Resources.BIT_Programme;


            //ProgrammePictureBox.Location = new Point((ProgrammeInfoPanel.Width / 4 * 2) + 2, 2);
            ProgrammePictureBox.Width = (ProgrammeInfoPanel.Width / 4);
            ProgrammePictureBox.Image = GazeToolBar.Properties.Resources.BIT_Image;
        }

        private void ProgrammeButton2_Click(object sender, EventArgs e)
        {
            ProgrammeRichTextBox.Width = (ProgrammeInfoPanel.Width / 4 * 3) - 4;
            ProgrammeRichTextBox.Height = ProgrammeInfoPanel.Height - 4;
            ProgrammeRichTextBox.Location = new Point(2, 2);
            ProgrammeRichTextBox.Text = GazeToolBar.Properties.Resources.Certificate_Programme;


            //ProgrammePictureBox.Location = new Point((ProgrammeInfoPanel.Width / 4 * 3) + 2, 2);
            ProgrammePictureBox.Width = (ProgrammeInfoPanel.Width / 4);
            ProgrammePictureBox.Image = GazeToolBar.Properties.Resources.CIT_Image;
        }

        private void ProgrammeButton3_Click(object sender, EventArgs e)
        {
            ProgrammeRichTextBox.Width = (ProgrammeInfoPanel.Width / 4 * 3) - 4;
            ProgrammeRichTextBox.Height = ProgrammeInfoPanel.Height - 4;
            ProgrammeRichTextBox.Location = new Point(2, 2);
            ProgrammeRichTextBox.Text = GazeToolBar.Properties.Resources.Graduate_Diploma;


            //ProgrammePictureBox.Location = new Point((ProgrammeInfoPanel.Width / 4 * 3) + 2, 2);
            ProgrammePictureBox.Width = (ProgrammeInfoPanel.Width / 4);
            ProgrammePictureBox.Image = GazeToolBar.Properties.Resources.Graduate_Diploma1;
        }

        private void ProgrammeButton4_Click(object sender, EventArgs e)
        {
            ProgrammeRichTextBox.Width = (ProgrammeInfoPanel.Width / 4 * 3) - 4;
            ProgrammeRichTextBox.Height = ProgrammeInfoPanel.Height - 4;
            ProgrammeRichTextBox.Location = new Point(2, 2);
            ProgrammeRichTextBox.Text = GazeToolBar.Properties.Resources.BIT_Programme;


            //ProgrammePictureBox.Location = new Point((ProgrammeInfoPanel.Width / 4 * 3) + 2, 2);
            ProgrammePictureBox.Width = (ProgrammeInfoPanel.Width / 4);
            ProgrammePictureBox.Image = GazeToolBar.Properties.Resources.BIT_Image;
        }



        /////////////////////////////////////Clicking buttons////////////////////////////////////////
        ///Project
        private void ProjectBack_Click(object sender, EventArgs e)
        {
            showMaster();
        }

        private void ProjectButton1_Click(object sender, EventArgs e)
        {
            ProjectRichTextBox.Width = (ProjectInfoPanel.Width / 4 * 3) - 4;
            ProjectRichTextBox.Height = ProjectInfoPanel.Height - 4;
            ProjectRichTextBox.Location = new Point(2, 2);
            ProjectRichTextBox.Text = GazeToolBar.Properties.Resources.David_Rozado_text;


            ProjectPictureBox.Location = new Point((ProjectInfoPanel.Width / 4 * 3) + 2, 2);
            ProjectPictureBox.Width = (ProjectInfoPanel.Width / 4);
            ProjectPictureBox.Image = GazeToolBar.Properties.Resources._20190502_142720;


        }

        private void ProjectButton2_Click(object sender, EventArgs e)
        {
            ProjectRichTextBox.Width = (ProjectInfoPanel.Width / 4 * 3) - 4;
            ProjectRichTextBox.Height = ProjectInfoPanel.Height - 4;
            ProjectRichTextBox.Location = new Point(2, 2);
            ProjectRichTextBox.Text = GazeToolBar.Properties.Resources.David_Rozado_text;


            ProjectPictureBox.Location = new Point((ProjectInfoPanel.Width / 4 * 3) + 2, 2);
            ProjectPictureBox.Width = (ProjectInfoPanel.Width / 4);
            ProjectPictureBox.Image = GazeToolBar.Properties.Resources._20190502_130432;
            
        }

        private void ProjectButton3_Click(object sender, EventArgs e)
        {
            ProjectRichTextBox.Width = (ProjectInfoPanel.Width / 4 * 3) - 4;
            ProjectRichTextBox.Height = ProjectInfoPanel.Height - 4;
            ProjectRichTextBox.Location = new Point(2, 2);
            ProjectRichTextBox.Text = GazeToolBar.Properties.Resources.David_Rozado_text;


            ProjectPictureBox.Location = new Point((ProjectInfoPanel.Width / 4 * 3) + 2, 2);
            ProjectPictureBox.Width = (ProjectInfoPanel.Width / 4);
            ProjectPictureBox.Image = GazeToolBar.Properties.Resources._20190502_140411;
        }

        private void ProjectButton4_Click(object sender, EventArgs e)
        {
            ProjectRichTextBox.Width = (ProjectInfoPanel.Width / 4 * 3) - 4;
            ProjectRichTextBox.Height = ProjectInfoPanel.Height - 4;
            ProjectRichTextBox.Location = new Point(2, 2);
            ProjectRichTextBox.Text = GazeToolBar.Properties.Resources.David_Rozado_text;


            ProjectPictureBox.Location = new Point((ProjectInfoPanel.Width / 4 * 3) + 2, 2);
            ProjectPictureBox.Width = (ProjectInfoPanel.Width / 4);
            ProjectPictureBox.Image = GazeToolBar.Properties.Resources.pastedImage;
        }
    }
}
