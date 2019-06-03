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

            bhavFORMMap.Add(ProgrammeBack, new GazeAwareBehavior(ProgrammeBackButton_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(ProgrammeButtonPanel1, new GazeAwareBehavior(OnGazeChangeBTColour));


            bhavFORMMap.Add(ProjectBack, new GazeAwareBehavior(ProjectBack_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMMap.Add(ProjectButtonPanel1, new GazeAwareBehavior(OnGazeChangeBTColour));

        }

        //toggle border on and off on gaze to gaze to give feed back.
        private void OnGazeChangeBTColour(object s, GazeAwareEventArgs e)
        {
            var sentButton = s as Panel;
            if (sentButton != null)
            {
                sentButton.BackColor = (e.HasGaze) ? Color.FromArgb(115, 220, 255) : Color.FromArgb(14, 90, 165);
            }
        }





    }
}
