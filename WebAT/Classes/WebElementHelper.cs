using OpenQA.Selenium;

namespace WebAT.Classes
{
    public class WebElementHelper
    {
        private WebElementHelper() { }
        private static WebElementHelper _instance;

        private static readonly object _lock = new object();

        public static WebElementHelper GetInstance()
        {
            // This conditional is needed to prevent threads stumbling over the
            // lock once the instance is ready.
            if (_instance == null)
            {
                // Now, imagine that the program has just been launched. Since
                // there's no Singleton instance yet, multiple threads can
                // simultaneously pass the previous conditional and reach this
                // point almost at the same time. The first of them will acquire
                // lock and will proceed further, while the rest will wait here.
                lock (_lock)
                {
                    // The first thread to acquire the lock, reaches this
                    // conditional, goes inside and creates the Singleton
                    // instance. Once it leaves the lock block, a thread that
                    // might have been waiting for the lock release may then
                    // enter this section. But since the Singleton field is
                    // already initialized, the thread won't create a new
                    // object.
                    if (_instance == null)
                    {
                        _instance = new WebElementHelper();
                    }
                }
            }
            return _instance;
        }

        // We'll use this property to prove that our Singleton really works.
        //public string Value { get; set; }

        public By getWebElementBy(string name, string value)
        {
            By result = null;

            switch (name)
            {
                case "id":
                    result = By.Id(value);
                    break;
                case "cssSelector":
                    result = By.CssSelector(value);
                    break;
                case "className":
                    result = By.ClassName(value);
                    break;
                case "partialLinkText":
                    result = By.PartialLinkText(value);
                    break;
                case "linkText":
                    result = By.LinkText(value);
                    break;
            }

            return result;
        }
    }
}