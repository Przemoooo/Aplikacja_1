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
using System.Data.OleDb;
using System.Data;
using System.Threading;
using DocumentFormat.OpenXml.Framework;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.InkML;
using System.Diagnostics;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO.Packaging;
using System.IO;
using Vintasoft.Imaging.Office.Spreadsheet.Document;
using OfficeOpenXml;
using OpenDialogWindowHandler;
using System.Runtime.CompilerServices;
using Microsoft.Win32;
using static IPS7Lnk.IPS7;
using GemBox.Document;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using S7.Net.Types;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
using Org.BouncyCastle.Crypto.Tls;
using System.Management.Instrumentation;
using System.Security.Cryptography.X509Certificates;
using IPS7Lnk.Advanced;
using System.Data.Common;
//using OfficeOpenXml.Core.ExcelPackage;
//using Microsoft.Office.Interop.Excel;
//using OfficeOpenXml.Core.ExcelPackage;


#endregion

namespace HmiExample
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
       // private static object connection;
       // private object valu1;

       // public static short DintVar { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_Tick;
            timer.IsEnabled = true;
            txtIpAddress.Text = Settings.Default.IpAddress;
        }

        void timer_Tick(object receiver, EventArgs e)
        {
            btnConnect.IsEnabled = Plc.Instance.ConnectionState == ConnectionStates.Offline;
            btnDisconnect.IsEnabled = Plc.Instance.ConnectionState != ConnectionStates.Offline;
            lblConnectionState.Text = Plc.Instance.ConnectionState.ToString();
            //ledMachineInRun.Fill = Plc.Instance.Db111.BitVariable0 ? Brushes.Green : Brushes.Gray;

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


        private void btnSendFileToDB_Click(object sender, RoutedEventArgs e)
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


        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {

            int A;
            int B;

            string inputString1 = txtSetEndAdresDB.Text;
            string inputString = txtSetStartAdresDB.Text;

            if (inputString.Length > 7 && inputString1.Length > 7)
            {

                string lastThreeDigits = inputString.Substring(inputString.Length - 3);

                //Następnie, aby przekształcić odczytane cyfry w liczbę całkowitą, możemy użyć metody "Parse" klasy "Int32":

                int lastThreeDigitsInt = Int16.Parse(lastThreeDigits);


                //Jeśli chcemy ponownie zmienić tę liczbę całkowitą na ciąg znaków, możemy użyć metody "ToString":

                lastThreeDigitsString.Content = lastThreeDigitsInt.ToString();


                string lastThreeDigits1 = inputString1.Substring(inputString1.Length - 3);

                //Następnie, aby przekształcić odczytane cyfry w liczbę całkowitą, możemy użyć metody "Parse" klasy "Int32":

                int lastThreeDigitsInt1 = Int16.Parse(lastThreeDigits1);


                //Jeśli chcemy ponownie zmienić tę liczbę całkowitą na ciąg znaków, możemy użyć metody "ToString":

                lastThreeDigitsString1.Content = lastThreeDigitsInt1.ToString();

                A = lastThreeDigitsInt1 - lastThreeDigitsInt;
                B = lastThreeDigitsInt1 + lastThreeDigitsInt;
            
                OpenFileDialog openFileDialog1 = new OpenFileDialog();


            if (openFileDialog1.ShowDialog() != DialogResult.HasValue)
            {

                string filePath = openFileDialog1.FileName;

                //string filePath = "C:\\Users\\PGM61\\source\\repos\\Przemoooo\\Excel open file\\Excel open file\\Data.xlsx";
                FileInfo fileInfo = new FileInfo(filePath);


                using (var package = new ExcelPackage(fileInfo))
                {
                    var worksheet = package.Workbook.Worksheets[1];

                        int D = A + 1;

                        for (int row = 1; row <= A; row++)
                        {

                            int result = 0;
                            for (int column = 1; column <= worksheet.Dimension.Columns; column++)
                            {

                                if (int.TryParse(worksheet.Cells[row, 1].Value?.ToString(), out result))
                                    {
                                        int liczbaAdrConvS =  (row*2)-2;
                                        string liczbaAdrePoIncS = liczbaAdrConvS.ToString();

                                        string str = inputString;
                                        string last13 = str.Substring(str.Length - 12); // Pobierz ostatnie 13 znaków

                                        string replacedString = last13.Replace(lastThreeDigits, liczbaAdrePoIncS); // Zastąp "abc" przez "xyz" w ostatnich 13 znakach

                                         string Afterreplace = str.Substring(0, str.Length - 12) + replacedString; // Połącz zmienione ostatnie 13 znaków ze znakami przed nimi 
                                         Plc.Instance.Write(Afterreplace, result);

                                    //txtSetStartAdresDB_String.Text = Afterreplace;

                                     }

                                //   int result1;
                                //   if (int.TryParse(worksheet.Cells[1, 1].Value?.ToString(), out result1))
                                //   {
                                //      Plc.Instance.Write(txtSetEndAdresDB.Text, result); 

                                  }

                              }
                          }
                       }
                }
            ;
            
         }

        private void txtSetStartAdres_TextChanged(object sender, TextChangedEventArgs e)
        {


        }

        private void txtSetEndAdres_TextChanged1(object sender, TextChangedEventArgs e)
        {
        }



        public void btnSetAdresDB_Click(object sender, EventArgs e)
        {


            lastThreeDigitsString2.Content = Plc.Instance.Db999.DIntVariable1;

            lastThreeDigitsString3.Content = Plc.Instance.Db999.DIntVariable2;

            lastThreeDigitsString4.Content = Plc.Instance.Db999.DIntVariable3;

            OpenFileDialog openFileDialog2 = new OpenFileDialog();


            if (openFileDialog2.ShowDialog() != DialogResult.HasValue)
            {

                string filePath = openFileDialog2.FileName; ;
                FileInfo fileInfo = new FileInfo(filePath);


                using (var package = new ExcelPackage(fileInfo))
                {

                    string[] values = new string[3];

                   


                    //  values[0] = v0.ToString();

                    //   values[1] = v1.ToString();

                    //   values[2] = v2.ToString();




                    for (int row = 1; row <= 3; row++)
                    {
                        // for (int column = 1; column <= worksheet2.Dimension.Columns; column++)
                        // {}              

                        ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                        worksheet.Cells[row, 1].Value = values[row - 1];



                    }
                    package.Save();
                    // txtSetStartAdresDB_String.Text = Plc.Instance.Db111.DIntVariable.ToString();

                }


            }
        }



        private void txtIpAddress_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnEndAdresDB_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
