using WebAT.Classes;

namespace WebAT.Interfaces
{
    interface IWebPerformance
    {
        void NavigationStart();
        void ResponseStart();
        void DomComplete();
        performanceResult GetPerformanceResult();        
    }
}