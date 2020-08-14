using OpenQA.Selenium;
using OpenQA.Selenium.Safari;

namespace WebAT.Classes
{
    public class SafariBrowser : BrowserBase
    {
        private string _parentWindowHandle = string.Empty;

        public SafariBrowser() : base()
        {
            try
            {
                SetDriver(new SafariDriver());
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