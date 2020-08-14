using WebAT.Interfaces;
using OpenQA.Selenium;

namespace WebAT.Classes
{
    public class WebPerformance : IWebPerformance
    {
        private int _taskId;
        private IWebDriver _driver;
        private IJavaScriptExecutor _jse;
        private object _navigationStart;
        private object _responseStart;
        private object _domComplete;

        public WebPerformance(IWebDriver driver, int taskId) {
            _taskId = taskId;
            _driver = driver;
            _jse = (IJavaScriptExecutor) driver;
        }

        public void NavigationStart() {
            _navigationStart = _jse.ExecuteScript("return window.performance.timing.navigationStart");
        }

        public void ResponseStart() {
            _responseStart = _jse.ExecuteScript("return window.performance.timing.responseStart");
        }

        public void DomComplete() {
            _domComplete = _jse.ExecuteScript("return window.performance.timing.domComplete");
        }
        
        public performanceResult GetPerformanceResult() {            
            
            var backendPerformance_calc = double.Parse(_responseStart.ToString()) - double.Parse(_navigationStart.ToString());
            var frontendPerformance_calc = double.Parse(_domComplete.ToString()) - double.Parse(_responseStart.ToString());

            return new performanceResult { frontendPerformance = frontendPerformance_calc, backendPerformance = backendPerformance_calc };
        }        
    }
}