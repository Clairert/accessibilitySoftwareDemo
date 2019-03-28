using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GazeToolBar
{
    class KeyConverter //Converts Key type into the correct format for Send Keys.
    {
        public const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string Convert(Key key)
        {
            string convertedKey = Constants.KEY_NOT_VALID_MESSAGE;

            if(ALPHABET.Contains((key.ToString().ToUpper())))
            {
                return key.ToString();
            }

            switch (key)
            {
                case Key.D0:
                    convertedKey = "0";
                    break;
                case Key.D1:
                    convertedKey = "1";
                    break;
                case Key.D2:
                    convertedKey = "2";
                    break;
                case Key.D3:
                    convertedKey = "3";
                    break;
                case Key.D4:
                    convertedKey = "4";
                    break;
                case Key.D5:
                    convertedKey = "5";
                    break;
                case Key.D6:
                    convertedKey = "6";
                    break;
                case Key.D7:
                    convertedKey = "7";
                    break;
                case Key.D8:
                    convertedKey = "8";
                    break;
                case Key.D9:
                    convertedKey = "9";
                    break;
                case Key.NumLock:
                    convertedKey = "{NUMLOCK}";
                    break;
                case Key.NumPad0:
                    convertedKey = "{NUMPAD0}";
                    break;
                case Key.NumPad1:
                    convertedKey = "{NUMPAD1}";
                    break;
                case Key.NumPad2:
                    convertedKey = "{NUMPAD2}";
                    break;
                case Key.NumPad3:
                    convertedKey = "{NUMPAD3}";
                    break;
                case Key.NumPad4:
                    convertedKey = "{NUMPAD4}";
                    break;
                case Key.NumPad5:
                    convertedKey = "{NUMPAD5}";
                    break;
                case Key.NumPad6:
                    convertedKey = "{NUMPAD6}";
                    break;
                case Key.NumPad7:
                    convertedKey = "{NUMPAD7}";
                    break;
                case Key.NumPad8:
                    convertedKey = "{NUMPAD8}";
                    break;
                case Key.NumPad9:
                    convertedKey = "{NUMPAD9}";
                    break;
                case Key.F1:
                    convertedKey = "{F1}";
                    break;
                case Key.F2:
                    convertedKey = "{F2}";
                    break;
                case Key.F3:
                    convertedKey = "{F3}";
                    break;
                case Key.F4:
                    convertedKey = "{F4}";
                    break;
                case Key.F5:
                    convertedKey = "{F5}";
                    break;
                case Key.F6:
                    convertedKey = "{F6}";
                    break;
                case Key.F7:
                    convertedKey = "{F7}";
                    break;
                case Key.F8:
                    convertedKey = "{F8}";
                    break;
                case Key.F9:
                    convertedKey = "{F9}";
                    break;
                case Key.F10:
                    convertedKey = "{F10}";
                    break;
                case Key.F11:
                    convertedKey = "{F11}";
                    break;
                case Key.F12:
                    convertedKey = "{F12}";
                    break;
                case Key.Back:
                    convertedKey = "{BACKSPACE}";
                    break;
                case Key.CapsLock:
                    convertedKey = "{CAPSLOCK}";
                    break;
                case Key.Delete:
                    convertedKey = "{DELETE}";
                    break;
                case Key.Down:
                    convertedKey = "{DOWN}";
                    break;
                case Key.Up:
                    convertedKey = "{UP}";
                    break;
                case Key.Left:
                    convertedKey = "{LEFT}";
                    break;
                case Key.Right:
                    convertedKey = "{RIGHT}";
                    break;
                case Key.End:
                    convertedKey = "{END}";
                    break;
                case Key.Enter:
                    convertedKey = "{ENTER}";
                    break;
                case Key.Escape:
                    convertedKey = "{ESC}";
                    break;
                case Key.Home:
                    convertedKey = "{HOME}";
                    break;
                case Key.Insert:
                    convertedKey = "{INSERT}";
                    break;
                case Key.PageDown:
                    convertedKey = "{PGDN}";
                    break;
                case Key.PageUp:
                    convertedKey = "{PGUP}";
                    break;
                case Key.PrintScreen:
                    convertedKey = "{PRTSC}";
                    break;
                case Key.Scroll:
                    convertedKey = "{SCROLLLOCK}";
                    break;
                case Key.Tab:
                    convertedKey = "{TAB}";
                    break;
                default:
                    break;
            }
            return convertedKey;
        }
    }
}
