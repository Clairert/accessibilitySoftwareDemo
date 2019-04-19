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
using EyeXFramework.Forms;

namespace GazeToolBar
{
    public partial class Paint : Form
    {
        int buttonClickDelay = 500;

        private void connectBehaveMap()
        {
            eyeXHost.Connect(behavPaint);

            setupMap();
            setupPaintMap();
        }

        private void setupMap()
        {

        }

        private void setupPaintMap()
        {
            //Brush Settings
            behavPaint.Add(button2, new GazeAwareBehavior(button2_Click) { DelayMilliseconds = buttonClickDelay }); //look at button to activate it
            behavPaint.Add(button2Panel, new GazeAwareBehavior(OnGazeChangeBTColour));//look at the panel to light up the area behind the button so you know where you are looking on the keyboard
            //Brush Save Button
            behavPaint.Add(button40, new GazeAwareBehavior(button40_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(panel24, new GazeAwareBehavior(OnGazeChangeBTColour));
            //Brush Sizes
            behavPaint.Add(smallBrush, new GazeAwareBehavior(smallBrush_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(smallBrushPanel, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(medBrush, new GazeAwareBehavior(medBrush_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(medBrushPanel, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(largeBrush, new GazeAwareBehavior(largeBrush_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(largeBrushPanel, new GazeAwareBehavior(OnGazeChangeBTColour));
            //Open panel for brush colours
            behavPaint.Add(colourChangeButton, new GazeAwareBehavior(button41_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourChangePanel, new GazeAwareBehavior(OnGazeChangeBTColour));

            //Brush colour options
            behavPaint.Add(colourOptionButton1, new GazeAwareBehavior(colourOptionButton1_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel1, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton2, new GazeAwareBehavior(colourOptionButton2_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel2, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton3, new GazeAwareBehavior(colourOptionButton3_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel3, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton4, new GazeAwareBehavior(colourOptionButton4_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel4, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton5, new GazeAwareBehavior(colourOptionButton5_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel5, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton6, new GazeAwareBehavior(colourOptionButton6_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel6, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton7, new GazeAwareBehavior(colourOptionButton7_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel7, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton8, new GazeAwareBehavior(colourOptionButton8_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel8, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton9, new GazeAwareBehavior(colourOptionButton9_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel9, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton10, new GazeAwareBehavior(colourOptionButton10_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel10, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton11, new GazeAwareBehavior(colourOptionButton11_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel11, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton12, new GazeAwareBehavior(colourOptionButton12_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel12, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton13, new GazeAwareBehavior(colourOptionButton13_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel13, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton14, new GazeAwareBehavior(colourOptionButton14_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel14, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton15, new GazeAwareBehavior(colourOptionButton15_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel15, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton16, new GazeAwareBehavior(colourOptionButton16_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel16, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton17, new GazeAwareBehavior(colourOptionButton17_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel17, new GazeAwareBehavior(OnGazeChangeBTColour));
            behavPaint.Add(colourOptionButton18, new GazeAwareBehavior(colourOptionButton18_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(colourOptionPanel18, new GazeAwareBehavior(OnGazeChangeBTColour));

            //Background Colour choice buttons
            behavPaint.Add(backgroundColour1, new GazeAwareBehavior(backgroundColour1_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(backgroundColour2, new GazeAwareBehavior(backgroundColour2_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(backgroundColour3, new GazeAwareBehavior(backgroundColour3_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(backgroundColour4, new GazeAwareBehavior(backgroundColour4_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(backgroundColour5, new GazeAwareBehavior(backgroundColour5_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(backgroundColour6, new GazeAwareBehavior(backgroundColour6_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(backgroundColour7, new GazeAwareBehavior(backgroundColour7_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(backgroundColour8, new GazeAwareBehavior(backgroundColour8_Click) { DelayMilliseconds = buttonClickDelay });


            //Background Colour Panel
            behavPaint.Add(button3, new GazeAwareBehavior(button3_Click) { DelayMilliseconds = buttonClickDelay });
            behavPaint.Add(button3Panel, new GazeAwareBehavior(OnGazeChangeBTColour));
            




        }


        private void OnGazeChangeBTColour(object s, GazeAwareEventArgs e)
        {
            var sentButton = s as Panel;
            if (sentButton != null)
            {
                sentButton.BackColor = (e.HasGaze) ? Color.FromArgb(115, 220, 255) : Color.White;
            }
        }


    }
}
