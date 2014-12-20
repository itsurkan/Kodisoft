using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;


namespace MutexUI3
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Thread.CurrentThread.Name = "1-st";
        }

        private static MutexUI mutex = new MutexUI();

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void LockUIasync_OnClick(object sender, RoutedEventArgs e)
        {
           
        }

        private async void LockUIasyncLR_OnClick(object sender, RoutedEventArgs e)
        {

            tBox.Text = "";
            // Create the threads that will use the protected resource. 
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    Thread newThread = new Thread(new ThreadStart(DoTasksAsync));
                    newThread.Name = String.Format("Thread{0}", i + 1);
                    newThread.Start();
                }
            });
        }

        private async void DoTasksAsync()
        {
            //Start the Mutex
            await mutex.Lock();
            tBox.Dispatcher.Invoke(DispatcherPriority.Normal,
                new Action(
                    delegate()
                    {
                        tBox.Text += '\n' + String.Format("Thread has entered the protected area");
                    }
            ));

            // Simulate some work.
            Thread.Sleep(1000);

            tBox.Dispatcher.Invoke(DispatcherPriority.Normal,
                new Action(
                    delegate()
                    {
                        tBox.Text += '\n' + String.Format("Thread is leaving the protected area");
                    }
            ));
            //Release mutex
            mutex.Release();
        }
    }
}


