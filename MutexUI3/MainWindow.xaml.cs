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
            /*AsyncLock lockUI = new AsyncLock();

            using (await lockUI.LockSection())
            { 
                lTest.Content = "Using block";
            }*/
            int sum = 5;
           // MutexAsync mut = new MutexAsync();
           // await mut.Lock();
            for (int i = 1; i < 5; i++)
            {
                sum = sum*i;
            }
            lTest.Content = Thread.CurrentThread.Name;
            Thread.Sleep(3000);
            //mut.Release();
        }

        private async void LockUIasyncLR_OnClick(object sender, RoutedEventArgs e)
        {
            MutexLR2 mutexUI = new MutexLR2();
            await mutexUI.Lock();
            
            lTest1.Content = Thread.CurrentThread.Name+Func(150) ;
            mutexUI.Release();
        }

        public int Func(int num)
        {
            int sum = 1;
            for (int i = 1; i < num * num*num; i++)
            {
                sum = sum * i;
            }
            Thread.Sleep(3000);
            return sum;
        }
    }
}


