using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MutexUI3
{ 
    public partial class MutexUI
    {
            private readonly Task<IDisposable> _releaserTask;
            private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
            private readonly IDisposable _releaser;

            public Task<IDisposable> LockSection()
            {
                var waitTask = _semaphore.WaitAsync();

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

