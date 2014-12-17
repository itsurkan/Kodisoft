using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MutexUI3
{
    public  class MutexLR1
    {
        LinkedList<Task> coldTasks = new LinkedList<Task>(new[] { Task.Factory.StartNew(() => { }) });

        public Task Lock()
        {
            Task ret = coldTasks.Last.Value;
            coldTasks.AddLast(new Task(() => { }));
            return ret;
        }

        public void Release()
        {
            Task first = coldTasks.First.Value;
            coldTasks.RemoveFirst();
            first.Start();
        }
    }

   
}
