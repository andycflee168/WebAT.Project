using Ninject.Modules;
using WebAT.Interfaces;
using WebAT.Classes;

namespace WebAT
{
    public class Blindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IWebAutomation>().To<WebAutomation>();
            Bind<IWebPerformance>().To<WebPerformance>().Named("webPerformance");
            
            Bind<IBrowserBase>().To<ChromeBrowser>().Named("chrome");
            Bind<IBrowserBase>().To<SafariBrowser>().Named("safari");
            Bind<IBrowserBase>().To<FirefoxBrowser>().Named("firefox");
        }
    }
}