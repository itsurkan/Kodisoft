using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MutexUI3
{
    public class MutexUI
    {
        Queue<Task> Tasks = new Queue<Task>();
         
        public MutexUI()
        {
            Tasks.Enqueue(Task.Factory.StartNew(() => { }));
        }
        public Task Lock()
        {
            lock (Tasks)
            {
                Tasks.Enqueue(new Task(() => { }));
                return Tasks.Peek(); 
            }
        }

        public void Release()
        {
            lock (Tasks)
            {
                if (Tasks.Count > 0)
                {
                    Tasks.Dequeue();
                    if (Tasks.Peek().IsCompleted == false) 
                        Tasks.Peek().Start(); 
                }
            }
        }
    }



   
}
