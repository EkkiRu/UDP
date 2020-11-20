using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
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

namespace UDPClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<string> messages = new ObservableCollection<string>();
        private object receiverClient;

        public MainWindow()
        {
            InitializeComponent();
            ConclusionListBox.ItemsSource = messages;

        }


        private async void Send(object sender, RoutedEventArgs e)
        {


            var udpClient = new UdpClient();
            try
            {
                //udpClient.Connect(IPAddress.Parse("127.0.0.1"), 8000);
                var datagrams = Encoding.UTF8.GetBytes(textBox.Text);
                messages.Add(textBox.Text);
                await udpClient.SendAsync(datagrams, datagrams.Length, "127.0.0.1", 8000);
                while (true)
                {
                    var result = await udpClient.ReceiveAsync();
                    messages.Add(Encoding.UTF8.GetString(result.Buffer));
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
