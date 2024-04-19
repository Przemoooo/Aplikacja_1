using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using S7.Net;


namespace PLC_S7_Conection
{
    /// <summary>    
    /// Logica di interazione per MainWindow.xaml    
    /// </summary>    
    public partial class MainWindow : Window
    {
        Plc _S71200 = new Plc(CpuType.S71200, "172.16.254.129", 0, 1);

        public MainWindow()
        {
            InitializeComponent();
            /*Apro la comunicazione con il plc*/
            _S71200.Open();
        }

        private void btnSetBit_Click(object sender, RoutedEventArgs e)
        {
            /*Se il plc è connesso*/
            if (_S71200.IsConnected)
            {
                /*Vado a leggere il valore del bit DBX0.0 sul blocco dati DB1*/
#pragma warning disable CS8605 // Unboxing a possibly null value.
                bool uscita = (bool)_S71200.Read("DB3.DBX8.0");
#pragma warning restore CS8605 // Unboxing a possibly null value.

                /*Se il valore del bit e false*/
                if (uscita.Equals(false))
                {
                    /*Imposto a true il bit DBX0.0*/
                    _S71200.Write("DB3.DBX8.0", true);
                    /*Visualizzo lo stato attuale sull'interfaccia*/
                    tbkValore.Text = uscita.ToString();
                }
            }
        }

        private void btnRESetBit_Click(object sender, RoutedEventArgs e)
        {
            /*Se il plc è connesso*/
            if (_S71200.IsConnected)
            {
                /*Vado a leggere il valore del bit DBX0.0 sul blocco dati DB1*/
#pragma warning disable CS8605 // Unboxing a possibly null value.
                bool data1 = (bool)_S71200.Read("DB3.DBX8.0");
#pragma warning restore CS8605 // Unboxing a possibly null value.

                /*Se il valore del bit e true*/
                if (data1.Equals(true))
                {
                    /*Imposto a false il bit DBX0.0*/
                    _S71200.Write("DB3.DBX8.0", false);
                    /*Visualizzo lo stato attuale sull'interfaccia*/
                    tbkValore.Text = data1.ToString();
                }
            }
        }
    }
} 