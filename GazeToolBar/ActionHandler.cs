using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GazeToolBar
{
    /*
     *  Subscribes to sidebar events
     */
    public class ActionHandler
    {
        public ActionHandler()
        {
            //TODO:
            //Subscribe to all the events
            //Change methods to accept sender and event args
            
        }

        public void HandleLeftClick(Object sender, EventArgs e)
        {

            SetAction(ActionToBePerformed.LeftClick);
        }
    
        public void HandleDoubleLeftClick()
        {
            SetAction(ActionToBePerformed.DoubleClick);
        }

        public void HandleRightClick()
        {
            SetAction(ActionToBePerformed.RightClick);
        }

        public void HandleScrollClick()
        {
            SetAction(ActionToBePerformed.Scroll);
        }

        public void HandleKeyboardClick()
        {

        }

        public void SetAction(ActionToBePerformed action)
        {
            SystemFlags.actionButtonSelected = true;
            SystemFlags.actionToBePerformed = action;
        }
    }
}
