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
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void LockUIasync_OnClick(object sender, RoutedEventArgs e)
        { 
            AsyncLock lockUI = new AsyncLock();

            using (await lockUI.LockSection())
            { 
                lTest.Content = "Using block";
            }
        }

        private async void LockUIasyncLR_OnClick(object sender, RoutedEventArgs e)
        {
            AsyncLock mutexUI = new AsyncLock();
            await mutexUI.Lock();
           
            lTest.Content = "Using Lock-Release"; 
            mutexUI.Release();
        }
    }
}


