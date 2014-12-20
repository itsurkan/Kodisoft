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

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void LockUIasync_OnClick(object sender, RoutedEventArgs e)
        {
           // AsyncMutex mutexUI = new AsyncMutex();
            /*
            using (await lockUI.LockSection())
            { 
                lTest.Content = "Using block";
                Thread.Sleep(3000);
                lTest.Content = Thread.CurrentThread.Name;
            }*/
        }

        private async void LockUIasyncLR_OnClick(object sender, RoutedEventArgs e)
        {
            lTest1.Content = "Start";
            MutexUI mutexUI = new MutexUI();
            await mutexUI.Lock();
            
            
            Thread.Sleep(3000);
            lTest1.Content = "Using lock-release";
            
            mutexUI.Release();
        }
    }
}


