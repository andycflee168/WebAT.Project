using System;
using OpenQA.Selenium;

using WebAT.Classes;

namespace WebAT.Interfaces
{
    public interface IBrowserBase
    {
        void OpenBrowser(string url);
        void GoToURL(string url);
        void UploadFile(string path);
        void PerformTaskActions(TaskAction taskAction, ref IWebElement foundElement);
        void SetDriver(IWebDriver value);
        IWebDriver GetDriver();        
        void Quit();
        void DoWork(object o);
    }
}