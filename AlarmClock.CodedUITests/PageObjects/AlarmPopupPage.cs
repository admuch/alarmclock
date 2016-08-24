using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock.CodedUITests.PageObjects
{
    class AlarmPopupPage : WpfWindow
    {
        public static readonly WpfWindow window = new WpfWindow();
        public static string winTitle = "Alarm!";

        public AlarmPopupPage()
        {

            window.WindowTitles.Add(winTitle);
            window.SearchProperties.Add(WpfWindow.PropertyNames.Name, winTitle);
        }

        public WinText alarmText(string uiProp)
        {
            WinText resultsObj = new WinText(window);
            resultsObj.SearchProperties.Add(WinText.PropertyNames.Name, uiProp);
            resultsObj.WindowTitles.Add(winTitle);
            return resultsObj;
        }
    }

}
