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
        private SerialPort? serialPort;
        private ViewModelChart viewModelChart;
        private int counter = 1;

        public MainWindow()
        {
            InitializeComponent();

            //create db for chart
            viewModelChart = new ViewModelChart();
            DataContext = viewModelChart;
        }


        private void ConnectSerialPort()
        {
            //baudrate : 57600 -> ideal for serial connection
            //parity : none -> one way communication
            //databit : 8 -> ideal for serial connection
            //stopbits : one -> ideal for serial connection
            //serialPort = new SerialPort(
            //        cmbPort.SelectedItem.ToString() ?? throw new ArgumentNullException(nameof(cmbPort.SelectedItem)),
            //        57600,
            //        Parity.None,
            //        8,
            //        StopBits.One);

            if (txtBaudrate.Text == "")
            {
                MessageBox.Show("Please enter baudrate for connection.","ERROR");
                return;
            }

            serialPort = new SerialPort(txtPort.Text, Convert.ToInt32(txtBaudrate.Text));
            serialPort.Open();
            serialPort.DataReceived += SerialPort_DataReceived;

            if (serialPort.IsOpen)
            {
                txtConnectionStatus.Text = "Connected";
               
            }
            else
            {
                txtConnectionStatus.Text = "Not Connected";
                MessageBox.Show("Serial port cannot connect.","ERROR");
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //if (serialPort == null || !(serialPort.IsOpen))
            //{
            //    return;
            //}

            ////read data from HM-10
            //string data = serialPort.ReadLine();
            //int distance;
            //if (int.TryParse(data, out distance))
            //{
            //  //  viewModelChart.AddDataToViewModel(i++, i);
            //    // string veri başarıyla tamsayıya dönüştürüldü, işlemlere devam edebilirsiniz
            //}
            //else
            //{
            //    // string veri tamsayıya dönüştürülemedi, hata mesajı gösterilebilir
            //}

            //// add data to chart
            //Dispatcher.Invoke(() =>
            //{
            //    viewModelChart.AddDataToViewModel(distance, counter);
            //    counter++;
            //});
        }

        private void txtConnectionStatus_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (txtConnectionStatus.Text == "Not Connected")
            {
                txtConnectionStatus.Foreground = Brushes.Red;
                menuConnectBluetooth.IsEnabled = true;
                menuDisconnect.IsEnabled = false;
            }
            else
            {
                txtConnectionStatus.Foreground = Brushes.ForestGreen;
                menuConnectBluetooth.IsEnabled = false;
                menuDisconnect.IsEnabled = true;
            }
        }

        private void menuConnectBluetooth_Click(object sender, RoutedEventArgs e)
        {
            ConnectSerialPort();
        }

        private void menuDisconnect_Click(object sender, RoutedEventArgs e)
        {
            if (serialPort != null)
            {
                serialPort.Close();
                serialPort.DataReceived -= SerialPort_DataReceived;
            }

            txtConnectionStatus.Text = "Not Connected";
        }

        private void menuTest_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < 5; i++)
            {
                viewModelChart.AddDataToViewModel(i++, i);

            }

            //chartDistances.Series[0].Points.AddXY(xValue, yValue);

        }
    }
}

