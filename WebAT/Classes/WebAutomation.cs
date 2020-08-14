using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Ninject;
using WebAT.Interfaces;
using System.Threading;

namespace WebAT.Classes
{
    // As a Browser it would to open URL and perform list of actions
    public class WebAutomation : IWebAutomation
    {
        private List<WebTask> _tasks;
        private bool _readTaskListSuccess = false;

        public WebAutomation() { }

        public bool ReadConfig(string filePath)
        {
            try
            {
                // deserialize JSON directly from a file
                using (StreamReader file = File.OpenText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    _tasks = (List<WebTask>)serializer.Deserialize(file, typeof(List<WebTask>));
                }
            }
            catch
            {
                _readTaskListSuccess = false;
                return _readTaskListSuccess;
            }

            _readTaskListSuccess = true;
            return _readTaskListSuccess;
        }

        public void PreformActions()
        {
            List<Thread> threadsList = new List<Thread>();

            foreach (var task in _tasks)
            {
                var browser = Helpers.GetInstance().Kernel.Get<IBrowserBase>(task.browser);
                var t = new Thread(new ParameterizedThreadStart(browser.DoWork));
                t.Start(task);
                threadsList.Add(t);
            }

            threadsList.ForEach((e) => e.Join());

            // HashSet<int> set = new HashMap<int>();
            // foreach (var x in nums1) {
            //     set.Add(x);
            // }
        }
    }
}