using System;
using System.Linq;
using System.IO;
using Ninject;
using System.Reflection;

using WebAT.Classes;
using WebAT.Interfaces;

namespace WebAT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try 
            {                        
                if (args.Select(s => s.ToLowerInvariant()).Intersect(new[] { "help" }).Any())
                {
                    Console.WriteLine($"Type: WebAT \"TaskFile.json\" \"logfile.log\" eg: WebAt google.json OR WebAt google.json custom.log");
                    return;
                }
                
                if (args.Length >= 1)
                {
                    string filePath = args[0];

                    Helpers.GetInstance().Logger.Info("File {0} Loaded", filePath);

                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine("File {0} does not exist!", filePath);
                        return;
                    }

                    if (args.Length == 2 && args[1].Length > 0)
                    {
                        Helpers.GetInstance().SetCustomLog(args[1]);
                    }

                    Helpers.GetInstance().Kernel.Load(Assembly.GetExecutingAssembly());

                    var _browserStrategy = Helpers.GetInstance().Kernel.Get<IWebAutomation>();

                    if (!_browserStrategy.ReadConfig(filePath)) 
                    {
                        return;
                    }

                    ((WebAutomation)_browserStrategy).PreformActions();
                }
                else
                {
                    Console.WriteLine($"Type: \"WebAT help\" for help");
                }
            }
            catch (Exception ex)
            {
                Helpers.GetInstance().Logger.Error(ex, "Internal Error");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }
    }
}
