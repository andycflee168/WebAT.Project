using System;
using OpenQA.Selenium;
using WebAT.Interfaces;
using Newtonsoft.Json;

namespace WebAT.Classes
{
    // This class respresent the browser
    // It's interact as the view and take actions from the WebTask object
    public abstract class BrowserBase : IBrowserBase
    {
        private IWebDriver _driver;
        private WebTask _task;

        public BrowserBase()
        { }

        public IWebDriver GetDriver() => _driver;

        public void SetDriver(IWebDriver value) => _driver = value;

        public void GoToURL(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("message", nameof(url));
            }

            _driver.Navigate().GoToUrl(url);
        }

        public void OpenBrowser(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void PerformTaskActions(TaskAction taskAction, ref IWebElement webElement)
        {
            switch (taskAction.action)
            {
                case "findElement":
                    webElement = FindElement(taskAction);
                    break;
                case "sendKeys":
                    PerformSendKey(webElement, taskAction);
                    break;
                case "click":
                    PerformClick(webElement);
                    break;
            }
        }

        public void UploadFile(string path)
        {
            throw new NotImplementedException();
        }

        private IWebElement FindElement(TaskAction taskAction)
        {
            IWebElement result = null;

            WebElementHelper helper = WebElementHelper.GetInstance();
            result = _driver.FindElement(helper.getWebElementBy(taskAction.findBy, taskAction.value));

            return result;
        }

        private void PerformSendKey(IWebElement element, TaskAction taskAction)
        {
            try
            {
                if (element != null)
                {
                    element.SendKeys(taskAction.value);

                    if (!string.IsNullOrEmpty(taskAction.keys))
                    {
                        element.SendKeys(GetKey(taskAction.keys));
                    }
                }
            }
            catch (Exception ex)
            {
                Helpers.GetInstance().Logger.Error(ex, "Internal Error");
            }
        }

        private void PerformClick(IWebElement element)
        {
            if (element != null)
            {
                element.Click();
            }
        }

        public void Quit()
        {
            _driver.Close();
            _driver.Quit();
        }

        public void DoWork(object o)
        {
            try
            {
                _task = (WebTask)o;

                OpenBrowser(_task.url);

                IWebElement webElement = null;

                _task.actions.ForEach(action =>
                {
                    try
                    {
                        PerformTaskActions(action, ref webElement);
                    }
                    catch (Exception ex)
                    {
                        Helpers.GetInstance().Logger.Error(ex, $"{ JsonConvert.SerializeObject(_task) }");
                    }
                });

                if (_task.quitBrowserAfter)
                {
                    Quit();
                }

                Helpers.GetInstance().Logger.Info($"Finished - { JsonConvert.SerializeObject(_task) }");
            }
            catch (Exception ex)
            {
                Helpers.GetInstance().Logger.Error(ex, "Internal Error");
            }
        }

        private string GetKey(string key)
        {
            string result = string.Empty;

            switch (key)
            {
                case "Null": result = Keys.Null; break;
                case "Cancel": result = Keys.Cancel; break;
                case "Help": result = Keys.Help; break;
                case "Enter": result = Keys.Enter; break;
                case "Backspace": result = Keys.Backspace; break;
                case "Tab": result = Keys.Tab; break;
                case "Clear": result = Keys.Clear; break;
                case "Escape": result = Keys.Escape; break;
                case "Shift": result = Keys.Shift; break;
                case "Control": result = Keys.Control; break;
                case "Space": result = Keys.Space; break;
                case "PageUp": result = Keys.PageUp; break;
                case "PageDown": result = Keys.PageDown; break;
                case "Left": result = Keys.Left; break;
                case "Right": result = Keys.Right; break;
                case "Up": result = Keys.Up; break;
                case "Down": result = Keys.Down; break;
                case "Insert": result = Keys.Insert; break;
                case "Delete": result = Keys.Delete; break;
                case "Semicolon": result = Keys.Semicolon; break;
                case "Equal": result = Keys.Equal; break;
                case "Alt": result = Keys.Alt; break;
                case "Pause": result = Keys.Pause; break;
                // Number pad Keys
                case "NumberPad0": result = Keys.NumberPad0; break;
                case "NumberPad1": result = Keys.NumberPad1; break;
                case "NumberPad2": result = Keys.NumberPad2; break;
                case "NumberPad3": result = Keys.NumberPad3; break;
                case "NumberPad4": result = Keys.NumberPad4; break;
                case "NumberPad5": result = Keys.NumberPad5; break;
                case "NumberPad6": result = Keys.NumberPad6; break;
                case "NumberPad7": result = Keys.NumberPad7; break;
                case "NumberPad8": result = Keys.NumberPad8; break;
                case "NumberPad9": result = Keys.NumberPad9; break;
                case "Multiply": result = Keys.Multiply; break;
                case "Add": result = Keys.Add; break;
                case "Separator": result = Keys.Separator; break;
                case "Subtract": result = Keys.Subtract; break;
                case "Decimal": result = Keys.Decimal; break;
                case "Divide": result = Keys.Divide; break;
                // Function Keys
                case "F1": result = Keys.F1; break;
                case "F2": result = Keys.F2; break;
                case "F3": result = Keys.F3; break;
                case "F4": result = Keys.F4; break;
                case "F5": result = Keys.F5; break;
                case "F6": result = Keys.F6; break;
                case "F7": result = Keys.F7; break;
                case "F8": result = Keys.F8; break;
                case "F9": result = Keys.F9; break;
                case "F10": result = Keys.F10; break;
                case "F11": result = Keys.F11; break;
                case "F12": result = Keys.F12; break;
                case "Meta": result = Keys.Meta; break;
            }

            return result;
        }
    }
}