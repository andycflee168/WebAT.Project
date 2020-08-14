using System.Collections.Generic;
using WebAT.Classes;

namespace WebAT.Interfaces
{
    public interface IWebTask
    {
        int id { get; set; }
        string name { get; set; }
        string description { get; set; }
        string browser { get; set; }
        string url { get; set; }
        bool quitBrowserAfter { get; set; }
        List<TaskAction> actions { get; set; }
    }
}