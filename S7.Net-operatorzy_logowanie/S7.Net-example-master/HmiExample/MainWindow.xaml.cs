#region Using
using HmiExample.PlcConnectivity;
using S7NetWrapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
using System.Windows.Threading;
using HmiExample.Properties;
using System.Xml;
#endregion

namespace HmiExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_Tick;
            timer.IsEnabled = true;
            txtIpAddress.Text = Settings.Default.IpAddress;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            btnConnect.IsEnabled = Plc.Instance.ConnectionState == ConnectionStates.Offline;
            btnDisconnect.IsEnabled = Plc.Instance.ConnectionState != ConnectionStates.Offline;
            lblConnectionState.Text = Plc.Instance.ConnectionState.ToString();
           //ledMachineInRun.Fill = Plc.Instance.Db3.BitVariable0 ? Brushes.Green : Brushes.Gray;
            lblSpeed.Content = Plc.Instance.Db3.IntVariable;
            lblTemperature.Content = Plc.Instance.Db3.RealVariable;
            lblAutomaticSpeed.Content = Plc.Instance.Db3.DIntVariable;
            lblSetDwordVariable.Content = Plc.Instance.Db3.DWordVariable;
            
            // statusbar
            lblReadTime.Text = Plc.Instance.CycleReadTime.TotalMilliseconds.ToString(CultureInfo.InvariantCulture);
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Plc.Instance.Connect(txtIpAddress.Text);
                Settings.Default.IpAddress = txtIpAddress.Text;
                Settings.Default.Save();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Plc.Instance.Disconnect();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// Writes a bit to 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Plc.Instance.Read(PlcTags.BitVariable0, 1);
               
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// Writes a bit to 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Plc.Instance.Read(PlcTags.BitVariable0, 0);
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        //-------------------------------------------------
        private void Eclipse(object sender, RoutedEventArgs a)
        {

            bool databool1 = true;// Plc.Instance.Db3.BitVariable0;


               // string Datasy = databool1.ToString();

                if (databool1)
                {


                ledMachineInRun.Fill = Brushes.Green; 

            }
                else
                {
                ledMachineInRun.Fill = Brushes.Gray;
                }
            
        }
            
        //------------------------------------------------------

        private void txtSetRealVariable_TextChanged(object sender, TextChangedEventArgs e)
        {
            double realVar;
            bool canConvert = Double.TryParse(txtSetTemperature.Text, out realVar);
            if (canConvert)
            {
                Plc.Instance.Read(PlcTags.DoubleVariable, realVar);
            }
        }

        private void txtSetWordVariable_TextChanged(object sender, TextChangedEventArgs e)
        {
            short wordVar;
            bool canConvert = short.TryParse(txtSetSpeed.Text, out wordVar);
            if (canConvert)
            {
                Plc.Instance.Read(PlcTags.IntVariable, wordVar);
         
            }
        }

        private void txtSetDIntVariable_TextChanged(object sender, TextChangedEventArgs e)
        {
            int dintVar;
            bool canConvert = int.TryParse(txtSetAutomaticSpeed.Text, out dintVar);
            if (canConvert)
            {
                Plc.Instance.Read(PlcTags.DIntVariable, dintVar);
            }
        }

        private void txtSetSetDwordVariable_TextChanged(object sender, TextChangedEventArgs e)
        {
            ushort dwordVar;
            bool canConvert = ushort.TryParse(txtSetDwordVariable.Text, out dwordVar);
            if (canConvert)
            {
                Plc.Instance.Read(PlcTags.DwordVariable, dwordVar);
            }
        }   

private void txtIpAddress_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
