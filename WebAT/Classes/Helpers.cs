using NLog;
using NLog.Targets;
using Ninject;

namespace WebAT.Classes 
{
    public class Helpers {
        public Helpers() {}
        private static Helpers _instance;
        private static readonly object _lock = new object();
        public static Helpers GetInstance()
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
                        _instance = new Helpers();
                    }
                }
            }
            return _instance;
        }
        public readonly Logger Logger = NLog.LogManager.LoadConfiguration("NLog.config").GetCurrentClassLogger();

        public StandardKernel Kernel = new StandardKernel();                    

        public void SetCustomLog(string file) {
            var target_logfile = (FileTarget)NLog.LogManager.Configuration.FindTargetByName("logfile");
            target_logfile.FileName = $"{file}.log";

            var target_error = (FileTarget)NLog.LogManager.Configuration.FindTargetByName("error");
            target_error.FileName = $"{file}.Error.log";
                       
            LogManager.ReconfigExistingLoggers();
        }
    }
}