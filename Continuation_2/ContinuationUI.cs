using System;
using System.Threading.Tasks;

public static class Continuation
{

    public static Task ContinueUI(this Task task, Action action)
    {
        return task.ContinueWith(t => action.Invoke(),
            TaskScheduler.FromCurrentSynchronizationContext());
    }

    public static Task ContinueUI(this Task task, Action<Task> action)
    {
        return task.ContinueWith((t) => action.Invoke(t),
            TaskScheduler.FromCurrentSynchronizationContext());
    }

    public static Task<T> ContinueUI<T>(this Task<T> task, Func<T> action)
    {
        return task.ContinueWith(t => action.Invoke(), 
            TaskScheduler.FromCurrentSynchronizationContext());
    }

    public static Task<T> ContinueUI<T>(this Task<T> task, Func<Task, T> action)
    {
        return task.ContinueWith((t) => action.Invoke(t), 
            TaskScheduler.FromCurrentSynchronizationContext());
    }

}
