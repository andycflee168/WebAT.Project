using System;
using System.IO;
using WebAT.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAT.Classes
{
    public class FirefoxBrowser : BrowserBase
    {
        private string _parentWindowHandle = string.Empty;

        public FirefoxBrowser() : base()
        {
            try
            {
                SetDriver(new FirefoxDriver(Directory.GetCurrentDirectory()));
                _parentWindowHandle = GetDriver().CurrentWindowHandle;
                GetDriver().SwitchTo().Window(_parentWindowHandle);
            }
            catch (WebDriverException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}