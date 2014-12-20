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
        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker();
        private static MutexUI mutex = new MutexUI();
        private static int i = 0;

        public MainWindow()
        {
            InitializeComponent();
            Thread.CurrentThread.Name = "1-st";
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //tBox.Text += '\n' + String.Format("COMPLETED");
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            i = 0;
            for (int j = 0; j < 3; j++)
            {
                Thread newThread = new Thread(new ThreadStart(DoTasks));
                newThread.Name = String.Format("Thread{0}", j + 1);
                newThread.Start();
            }
        }

        private void DoTasks()
        {

            var baseMutex = new Mutex();
            baseMutex.WaitOne();
            lock (tBox)
            {
                i++;
                tBox.Dispatcher.Invoke(DispatcherPriority.Normal,
                    new Action(
                        delegate()
                        {
                            tBox.Text += '\n' + String.Format("Thread #{0} start", i);
                        }
                        ));

                // Simulate some work.
                Thread.Sleep(1000);

                tBox.Dispatcher.Invoke(DispatcherPriority.Normal,
                    new Action(
                        delegate()
                        {
                            tBox.Text += '\n' + String.Format("Thread #{0} stop", i);
                        }
                        ));
            }
            //Release mutex
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void LockUIasyncLR_OnClick(object sender, RoutedEventArgs e)
        {
            i = 0;
            tBox.Text = "";
            // Create the threads that will use the protected resource. 
            await Task.Factory.StartNew(() =>
            {
                for (int j = 0; j < 3; j++)
                {
                    Thread newThread = new Thread(new ThreadStart(DoTasksAsync));
                    newThread.Name = String.Format("Thread{0}", j + 1);
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
                        i++;
                        tBox.Text += '\n' + String.Format("Thread #{0} start", i);
                    }
            ));

            // Simulate some work.
            Thread.Sleep(5000);
            i = 0;
            tBox.Dispatcher.Invoke(DispatcherPriority.Normal,
                new Action(
                    delegate()
                    {
                        i++;
                        tBox.Text += '\n' + String.Format("Thread #{0} stop", i);
                    }
            ));
            //Release mutex
            mutex.Release();
        }

        private void WithBackgroundWorker_OnClick(object sender, RoutedEventArgs e)
        {
            tBox.Text = "";
            backgroundWorker.RunWorkerAsync();
        }
    }
}


