using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EyeXFramework;

namespace GazeToolBar
{
    public partial class DemoHome : Form
    {
        int buttonClickDelay = 1000;
        public void connectBehaveMap()
        {
            eyeXHost.Connect(bhavFORMMap);

            setupMap();
            setupDemoMap();
        }

        private void setupMap()
        {

        }

        private void setupDemoMap()
        {
            bhavFORMMap.Add(People, new GazeAwareBehavior(People_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(panel1, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(button2, new GazeAwareBehavior(button2_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(panel2, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(button3, new GazeAwareBehavior(button3_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(panel3, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(button4, new GazeAwareBehavior(button4_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(panel4, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(PeopleBack, new GazeAwareBehavior(PeopleBack_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(PeopleButtonPanel1, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(People1, new GazeAwareBehavior(People1_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(PeopleButtonPanel2, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(People2, new GazeAwareBehavior(People2_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(PeopleButtonPanel3, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(People3, new GazeAwareBehavior(People3_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(PeopleButtonPanel4, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(People4, new GazeAwareBehavior(People4_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(PeopleButtonPanel5, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(ProgrammeBack, new GazeAwareBehavior(ProgrammeBackButton_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(ProgrammeButtonPanel1, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(Programme1, new GazeAwareBehavior(ProgrammeButton1_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(ProgrammeButtonPanel2, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(Programme2, new GazeAwareBehavior(ProgrammeButton2_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(ProgrammeButtonPanel3, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(Programme3, new GazeAwareBehavior(ProgrammeButton3_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(ProgrammeButtonPanel4, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(Programme4, new GazeAwareBehavior(ProgrammeButton4_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(ProgrammeButtonPanel5, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(ProjectBack, new GazeAwareBehavior(ProjectBack_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(ProjectButtonPanel1, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(ProjectButton1, new GazeAwareBehavior(ProjectButton1_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(ProjectButtonPanel2, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(ProjectButton2, new GazeAwareBehavior(ProjectButton2_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(ProjectButtonPanel3, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(ProjectButton3, new GazeAwareBehavior(ProjectButton3_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(ProjectButtonPanel4, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMMap.Add(ProjectButton4, new GazeAwareBehavior(ProjectButton4_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(ProjectButtonPanel5, new GazeAwareBehavior(OnGazeChangeBTColour));

        }

        //toggle border on and off on gaze to gaze to give feed back.
        private void OnGazeChangeBTColour(object s, GazeAwareEventArgs e)
        {
            var sentButton = s as Panel;
            if (sentButton != null)
            {
                sentButton.BackColor = (e.HasGaze) ? Color.AliceBlue : Color.Blue;
            }
        }





    }
}
