using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Continuation_2
{
 

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Task task1 = Task.Run(() => Test());
            task1.ContinueUI(()=>{label1.Content = "Action Finished";});
            label1.Content = "Action in process";
        }
        
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(t => Test(),  TaskScheduler.Default).
                ContinueUI(t => label1.Content = "Action<Task> test finished");
            label1.Content = "Action in process";
        }
        
        private void Test()
        {
            Thread.Sleep(5000);
        }
    }
}
