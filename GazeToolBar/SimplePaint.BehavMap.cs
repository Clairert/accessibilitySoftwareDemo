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
    public partial class SimplePaint : Form
    {
        int buttonClickDelay = 250;

        private void connectBehaveMap()
        {
            eyeXHost.Connect(behaviorMap);

            setupMap();
            setupSimplePaintMap();
        }

        private void setupMap()
        {

        }

        private void setupSimplePaintMap()
        {
            behaviorMap.Add(backButton, new GazeAwareBehavior(backButton_Click) { DelayMilliseconds = buttonClickDelay });
            behaviorMap.Add(backPanel, new GazeAwareBehavior(OnGazeChangeBTColour));
            behaviorMap.Add(clearButton, new GazeAwareBehavior(clearButton_Click) { DelayMilliseconds = buttonClickDelay });
            behaviorMap.Add(clearPanel, new GazeAwareBehavior(OnGazeChangeBTColour));

            behaviorMap.Add(redButton, new GazeAwareBehavior(redButton_Click) { DelayMilliseconds = buttonClickDelay });
            behaviorMap.Add(redPanel, new GazeAwareBehavior(OnGazeChangeBTColour));
            behaviorMap.Add(blueButton, new GazeAwareBehavior(blueButton_Click) { DelayMilliseconds = buttonClickDelay });
            behaviorMap.Add(bluePanel, new GazeAwareBehavior(OnGazeChangeBTColour));
            behaviorMap.Add(yellowButton, new GazeAwareBehavior(yellowButton_Click) { DelayMilliseconds = buttonClickDelay });
            behaviorMap.Add(yellowPanel, new GazeAwareBehavior(OnGazeChangeBTColour));
            behaviorMap.Add(greenButton, new GazeAwareBehavior(greenButton_Click) { DelayMilliseconds = buttonClickDelay });
            behaviorMap.Add(greenPanel, new GazeAwareBehavior(OnGazeChangeBTColour));
            behaviorMap.Add(purpleButton, new GazeAwareBehavior(purpleButton_Click) { DelayMilliseconds = buttonClickDelay });
            behaviorMap.Add(purplePanel, new GazeAwareBehavior(OnGazeChangeBTColour));
            behaviorMap.Add(orangeButton, new GazeAwareBehavior(orangeButton_Click) { DelayMilliseconds = buttonClickDelay });
            behaviorMap.Add(orangePanel, new GazeAwareBehavior(OnGazeChangeBTColour));
            behaviorMap.Add(blackButton, new GazeAwareBehavior(blackButton_Click) { DelayMilliseconds = buttonClickDelay });
            behaviorMap.Add(blackPanel, new GazeAwareBehavior(OnGazeChangeBTColour));
            behaviorMap.Add(whiteButton, new GazeAwareBehavior(whiteButton_Click) { DelayMilliseconds = buttonClickDelay });
            behaviorMap.Add(whitePanel, new GazeAwareBehavior(OnGazeChangeBTColour));
        }

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
