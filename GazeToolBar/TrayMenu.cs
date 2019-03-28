using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GazeToolBar
{
    public class TrayMenu : IContainer
    {
        private NotifyIcon icon;
        private ContextMenu menu;
        public MenuItem menuStartOnOff, menuExit, menuSettings;

        public TrayMenu()
        {
            icon = new NotifyIcon(this);
            menu = new ContextMenu();
            menuStartOnOff = new MenuItem();
            menuExit = new MenuItem();
            menuSettings = new MenuItem();
        }

        private void Init()
        {
            //Set the menu item's text
            menuExit.Text = "Exit";
            menuSettings.Text = "Setting";
            menuStartOnOff.Text = Constants.AUTO_START_OFF;

            //Add all components to the menu
            menu.MenuItems.Add(menuSettings);
            menu.MenuItems.Add(menuStartOnOff);
            menu.MenuItems.Add(menuExit);
            icon.ContextMenu = menu;

            //Set the text on the Autostart option to the correct value
            OnStartTextChange();
        }

        //Update the text shown on the autostart menu button
        public void OnStartTextChange()
        {
            menuStartOnOff.Text = Program.onStartUp ? Constants.AUTO_START_ON : Constants.AUTO_START_OFF;
        }

        ////////////////////////////////////////////////////////////////////////////
        //Below here is used to make a notifyicon appear without a form
        private ComponentCollection components;

        public ComponentCollection Components
        {
            get { return components; }
        }

        public void Add(IComponent component)
        {  }

        public void Add(IComponent component, string name)
        {
        }

        public void Remove(IComponent component)
        {
        }

        public void Dispose()
        {
            components = null;
        }
        /////////////////////////////////////////////////////////////////////////
    }
}
