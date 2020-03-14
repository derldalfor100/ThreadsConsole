using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
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

namespace WpfThreads
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void MyButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"1 ({Thread.CurrentThread.ManagedThreadId})");

            await Task.Run(async () =>
            {
                Debug.WriteLine($"2 ({Thread.CurrentThread.ManagedThreadId})");

                var webClient = new HttpClient();
                var html = await webClient.GetStringAsync("http://derldalfor.co.uk/");

                Debug.WriteLine($"3 ({Thread.CurrentThread.ManagedThreadId})");

                Dispatcher.Invoke(() =>
                {
                    Debug.WriteLine($"4 ({Thread.CurrentThread.ManagedThreadId})");

                    MyButton.Content = (string)MyButton.Content != "Logged In" ? "Logged In" : "Logged";
                });

                Debug.WriteLine($"5 ({Thread.CurrentThread.ManagedThreadId})");
            });

            Debug.WriteLine($"6 ({Thread.CurrentThread.ManagedThreadId})");
        }
    }
}
