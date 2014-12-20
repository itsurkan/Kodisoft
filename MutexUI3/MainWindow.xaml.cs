using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;


namespace MutexUI3
{

    public partial class MainWindow : Window
    {
        public static MutexUI mutex = new MutexUI();
        public int i = 0;
        public MainWindow()
        {
            InitializeComponent();
            Thread.CurrentThread.Name = "1-st";
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void LockUIasync_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private async void LockUIasyncLR_OnClick(object sender, RoutedEventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    Thread newThread = new Thread(DoTasksAsync);
                    newThread.Name = String.Format("Thread{0}", i + 1);
                    newThread.Start();
                }
            });
        }

        private async void DoTasksAsync()
        {
            await mutex.Lock();
            
            tbLog.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                    { 
                        i++;
                        tbLog.Text += '\n' + String.Format("Thread enter "+i);
                    }
            ));

            Thread.Sleep(1000);

            tbLog.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate()
                    {i++;
                        tbLog.Text += '\n' + String.Format("Thread exit "+i);
                    }
            ));
            mutex.Release();
        }
    }
}


