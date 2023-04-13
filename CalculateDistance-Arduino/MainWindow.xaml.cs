using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculateDistance_Arduino
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //get active ports in pc for connect to Arduino
            GetActivePorts();

            //create db for chart
            var viewModel = new MainViewModel();
            DataContext = viewModel;
        }

        private void ConnectToArduino_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TestConnection_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DisconnectFromArduino_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetActivePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (var item in ports)
            {
                cmbPort.Items.Add(item);
            }
        }

        private void ConnectSerialPort()
        {
            //baudrate : 57600 -> ideal for serial connection
            //parity : none -> one way communication
            //databit : 8 -> ideal for serial connection
            //stopbits : one -> ideal for serial connection
            SerialPort serialPort = new SerialPort(
                    cmbPort.SelectedItem.ToString() ?? throw new ArgumentNullException(nameof(cmbPort.SelectedItem)),
                    57600,
                    Parity.None,
                    8,
                    StopBits.One);
        }

        private void txtConnectionStatus_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtConnectionStatus.Text == "Not Connected")
            {
                txtConnectionStatus.Foreground = Brushes.Red;
            }
            else
            {
                txtConnectionStatus.Foreground = Brushes.ForestGreen;
            }
        }
    }
}

