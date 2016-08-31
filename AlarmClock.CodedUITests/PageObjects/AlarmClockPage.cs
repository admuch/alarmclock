using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using System.IO;
using System.Configuration;

namespace AlarmClock.CodedUITests.PageObjects
{
    class AlarmClockPage : WpfWindow
    {
        public static readonly WpfWindow window = new WpfWindow();
        public static string winTitle = "Alarm Clock App";
        private static string currPath = ConfigurationManager.AppSettings["currentPath"];

        public AlarmClockPage()
        {
            window.WindowTitles.Add(winTitle);
            window.SearchProperties.Add(WpfWindow.PropertyNames.Name, winTitle);
        }

        public void startApp()
        {
            Directory.SetCurrentDirectory(currPath);
            ApplicationUnderTest.Launch(Directory.GetCurrentDirectory() + @"\AlarmClock\bin\Release\AlarmClock.exe");
            
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
