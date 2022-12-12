using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VerilenDegereGoreHtmlKoduYazanProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btn_Kapat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        int sayac = 0;
        private void btn_Buyut_Click(object sender, RoutedEventArgs e)
        {
            if (sayac == 0)
            {
                sayac++;
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                sayac = 0;
                this.WindowState = WindowState.Normal;
            }
        }

        private void btn_Makeleİsle_Click(object sender, RoutedEventArgs e)
        {
            Makaleİsle makale = new Makaleİsle();
            UserCgetir getir = new UserCgetir();
            getir.Getir(İcerik, makale);
        }

        private void btn_KelimeEkle_Click(object sender, RoutedEventArgs e)
        {
            KelimeEkle ekle = new KelimeEkle();
            UserCgetir getir = new UserCgetir();
            getir.Getir(İcerik, ekle);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Makaleİsle isle = new Makaleİsle();
            UserCgetir getir = new UserCgetir();
            getir.Getir(İcerik, isle);
        }
        private void btn_Hakkımızda_Click(object sender, RoutedEventArgs e)
        {
            Process pro = new Process();
            try
            {
                pro.StartInfo.UseShellExecute = true;
                pro.StartInfo.FileName = "https://www.dijitalteknoloji.net/";
                pro.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_AltSimgeyeAt_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
