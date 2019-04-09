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
    public partial class InformationPage : Form
    {

        int buttonClickDelay = 500;

        public void connectBehaveMap()
        {
            eyeXHost.Connect(bhavFORMap);

            setupMap();
            setupInfoMap();
        }

        private void setupMap()
        {

        }

        private void setupInfoMap()
        {
            bhavFORMap.Add(button1, new GazeAwareBehavior(button1_Click) { DelayMilliseconds = buttonClickDelay });
            bhavFORMap.Add(panel2, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMap.Add(button2, new GazeAwareBehavior(button2_Click) { DelayMilliseconds = buttonClickDelay });
            //bhavFORMap.Add(panel3, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMap.Add(button3, new GazeAwareBehavior(button3_Click) { DelayMilliseconds = buttonClickDelay });
            //bhavFORMap.Add(panel4, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMap.Add(button4, new GazeAwareBehavior(button4_Click) { DelayMilliseconds = buttonClickDelay });
            //bhavFORMap.Add(panel5, new GazeAwareBehavior(OnGazeChangeBTColour));

            bhavFORMap.Add(button5, new GazeAwareBehavior(button4_Click) { DelayMilliseconds = buttonClickDelay });
            //bhavFORMap.Add(panel6, new GazeAwareBehavior(OnGazeChangeBTColour));

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
