using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MutexUI3
{
    public class AsyncLock
    {
        // Using lock-release
        Mutex mutx = new Mutex();
        Dispatcher UserDispatcher;

        public async Task Lock()
        {
            await Task.Factory.StartNew(() =>
            {
                mutx.WaitOne();
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
                if (mutx != null && UserDispatcher != null)
                {
                    //UserDispatcher.Invoke(new Action(() =>
                    //{
                    //    Console.WriteLine("Releasing...");
                       mutx.ReleaseMutex();
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

        // Using block
        private readonly Task<IDisposable> _releaserTask;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 2);
        private readonly IDisposable _releaser;

        public AsyncLock()
        {
            _releaser = new Releaser(_semaphore);
            _releaserTask = Task.FromResult(_releaser);
        }
        public Task<IDisposable> LockSection()
        {
            Task waitTask = _semaphore.WaitAsync();
            return waitTask.IsCompleted
                ? _releaserTask
                : waitTask.ContinueWith(
                    (_, releaser) => (IDisposable)releaser,
                    _releaser,
                    CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
        }

        private class Releaser : IDisposable
        {
            private readonly SemaphoreSlim _semaphore;

            public Releaser(SemaphoreSlim semaphore)
            {
                _semaphore = semaphore;
            }

            public void Dispose()
            {
                _semaphore.Release();
            }
        }
    }
}
