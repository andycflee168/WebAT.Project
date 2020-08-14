using System.IO;
using WebAT.Interfaces;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebAT.Classes
{
    public class ChromeBrowser : BrowserBase
    {
        private string _parentWindowHandle = string.Empty;

        public ChromeBrowser(WebTask Task) : base()
        {
            try
            {
                SetDriver(new ChromeDriver(Directory.GetCurrentDirectory()));
                _parentWindowHandle = GetDriver().CurrentWindowHandle;
                GetDriver().SwitchTo().Window(_parentWindowHandle);
            }
            catch (WebDriverException ex)
            {
                throw new System.Exception(ex.Message, ex.InnerException);
            }
        }
    }
}