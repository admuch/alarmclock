using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System.IO;

namespace AlarmClock.CodedUITests.PageObjects
{
    class AlarmClockPage : WpfWindow
    {
        public static readonly WpfWindow window = new WpfWindow();
        public static string winTitle = "Alarm Clock App";

        public AlarmClockPage()
        {
            window.WindowTitles.Add(winTitle);
            window.SearchProperties.Add(WpfWindow.PropertyNames.Name, winTitle);
        }

        public void startApp()
        {
            ApplicationUnderTest.Launch(@"C:\AlarmClock\bin\Release");
            
       }

        public UITestControl uIBtn(string uiProp)
        {
            UITestControl resultsObj = new UITestControl(window);
            resultsObj.SearchProperties.Add(UITestControl.PropertyNames.ControlType, "Button", UITestControl.PropertyNames.Name, uiProp);
            resultsObj.WindowTitles.Add(winTitle);
            return resultsObj;
        }


        public WinEdit editBox(string txtName)
        {
            WinEdit textControl = new WinEdit(window);
            textControl.SearchProperties.Add(WinEdit.PropertyNames.Name, txtName);
            textControl.WindowTitles.Add(winTitle);
            return textControl;
        }

        public string timeToSet()
        {
            DateTime resultTimeToSet = DateTime.Now;
            return resultTimeToSet.AddSeconds(5).ToString("HH:mm:ss");
        }

        public UITestControl lblAlarmText(string uiProp)
        {
          
            UITestControl resultsObj = new UITestControl(window);
            resultsObj.SearchProperties.Add(UITestControl.PropertyNames.ControlType, "Window", UITestControl.PropertyNames.Name, uiProp);
            resultsObj.WindowTitles.Add(winTitle);

            return resultsObj;
        }

    }
}
