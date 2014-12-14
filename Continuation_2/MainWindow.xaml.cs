using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Continuation_2
{
  public  static class Continuation
     {

         public static Task ContinueTask(this Task task, Action continuationAction)
         {
             Task UITask = task.ContinueWith((arg) =>
             {
                 MessageBox.Show(DateTime.Now.Second.ToString());
             }, TaskScheduler.FromCurrentSynchronizationContext());
             return UITask;
         }

         public  static Task ContinueTask(this Task task, Action<Task> continuationAction)
         {
             Task UITask = task.ContinueWith((arg) =>
             {
                 MessageBox.Show(DateTime.Now.Second.ToString());
             }, TaskScheduler.FromCurrentSynchronizationContext());
             return UITask;
         }

         public static Task ContinueTask<T>(Func<T> function, Func<Task<T>> TaskFunction)
         {
             return null;
         }
         public static Task ContinueTask<T>(Func<Task<T>> TaskFunction, Func<Task, Task<T>> newFunc)
         {
             return null;
         }
     }


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Task task = new Task(() => { MessageBox.Show("Hello from first"); }  );
            
            task.ContinueTask(Test);
            task.Start();
        }

        public void Test()
        {
            label1.Content = "Test continue with";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("It is OK");
        }

    }
}
