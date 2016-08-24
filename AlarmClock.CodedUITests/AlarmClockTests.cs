using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlarmClock.CodedUITests.PageObjects;
using System;
using System.Threading;

namespace AlarmClock.CodedUITests
{
    [CodedUITest]
    public class AlarmClockTests
    {
        [TestMethod]
        public void CheckIfAppCouldBeOpened()
        {
            bool validator = true;
            try
            {
                AlarmClockPage alarm = new AlarmClockPage();
                alarm.startApp();
            }
            catch(Exception e)
            {
                validator = false;
                Console.WriteLine(e);
            }

            Assert.IsTrue(validator);
        }

        [TestMethod]
        public void CheckIfUserCanSetAlarm()
        {
            bool validator = true;

            try
            {

                AlarmClockPage alarm = new AlarmClockPage();
                alarm.startApp();
                var txtBox = alarm.editBox("Set time to invoke alarm:");
                txtBox.Text = alarm.timeToSet();

                var btn_set = alarm.uIBtn("Set");
                Mouse.Click(btn_set);
            }
            catch(Exception e)
            {
                validator = false;
                Console.WriteLine(e);
            }
            Assert.IsTrue(validator);

        }

        [TestMethod]
        public void CheckIfAlarmIsTriggered()
        {
            var expectedAlarmVal = "Alarm!";

            AlarmClockPage alarm = new AlarmClockPage();
            alarm.startApp();
            var txtBox = alarm.editBox("Set time to invoke alarm:");
            txtBox.Text = alarm.timeToSet();

            var btn_set = alarm.uIBtn("Set");
            Mouse.Click(btn_set);

            Thread.Sleep(TimeSpan.FromSeconds(10));

            AlarmPopupPage popup = new AlarmPopupPage();
            var actualAlarmVal = popup.alarmText("Alarm!").DisplayText.ToString();

            Assert.AreEqual(expectedAlarmVal, actualAlarmVal);
        }

        [TestMethod]
        public void CheckIfUserCanSetStop()
        {
            AlarmClockPage alarm = new AlarmClockPage();
            alarm.startApp();
            var txtBox = alarm.editBox("Set time to invoke alarm:");
            txtBox.Text = alarm.timeToSet();

            var btn_set = alarm.uIBtn("Set");
            Mouse.Click(btn_set);

            var btn_stop = alarm.uIBtn("Stop");
            Mouse.Click(btn_stop);

            var lblSetActual = alarm.lblAlarmText("00:00:00").FriendlyName.ToString();
            Assert.AreEqual("00:00:00", lblSetActual);
        }
    }
}
