using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MutexUI3
{
    public  class MutexLR2
    {
        // Using lock-release
        Mutex mutex;
        Dispatcher UserDispatcher;

        public MutexLR2()
        {
            mutex = new Mutex();
        }
        
        public async Task Lock()
        {
            await Task.Factory.StartNew(() =>
            {
                mutex.WaitOne();
                Console.WriteLine("ThreadOne, executing ThreadMethod, " +
                    "is {0} from the thread pool.",
                    Thread.CurrentThread.ManagedThreadId);
                UserDispatcher = Dispatcher.CurrentDispatcher;
            });
        }

        public void Release()
        {
            try
            {
                if (mutex != null && UserDispatcher != null)
                {
                    //UserDispatcher.Invoke(new Action(() =>
                    //{
                    //    Console.WriteLine("Releasing...");
                    mutex.ReleaseMutex();
                    //}));
                }
                else
                {
                    Console.WriteLine("Null");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

   
}
