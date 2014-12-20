using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MutexUI3
{
    public class MutexUI
    {
        Queue<Task> coldTasks = new Queue<Task>();

        private Mutex mutex = new Mutex();
        private object lockThis = new object();

        public Task Lock()
        {
            lock (lockThis)
            {
                coldTasks.Enqueue(Task.Factory.StartNew(() => { }));
                coldTasks.Enqueue(new Task(() => { }));
                return coldTasks.Peek(); 
            }
        }

        public void Release()
        {
            lock (lockThis)
            {
                if (coldTasks.Count > 0)
                {
                    coldTasks.Dequeue(); 
                    if (coldTasks.Peek().IsCompleted == false) 
                        coldTasks.Peek().Start(); 
                }
            }
        }
    }

   
}
