using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.OleDb;

namespace VerilenDegereGoreHtmlKoduYazanProgram
{
    /// <summary>
    /// Interaction logic for KelimeEkle.xaml
    /// </summary>
    public partial class KelimeEkle : UserControl
    {       
        DataTable tablo = new DataTable();
        public KelimeEkle()
        {
            InitializeComponent();
        }     

        private void btn_Kayit_Click(object sender, RoutedEventArgs e)
        {
            using (OleDbConnection baglanti = new OleDbConnection(DB.MyDB))
            {
                try
                {
                    string[] kelimeler = txt_KelimeEkle.Text.Split(',', '-');
                    string[] aciklamalar = txt_AcıklamaEkle.Text.Split(',', '-');
                    if (kelimeler.Length == aciklamalar.Length)
                    {
                        baglanti.Open();
                        for (int i = 0; i < kelimeler.Length; i++)
                        {
                            OleDbCommand sorgu = new OleDbCommand("insert into Data(Title,Acıklama) values('" + kelimeler[i] + "','" + aciklamalar[i] + "')", baglanti);
                            sorgu.ExecuteNonQuery();
                        }
                        baglanti.Close();
                        MessageBox.Show("Kelimeler Eklendi", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);
                        DataGrid_Guuncelle();
                    }
                    else
                        MessageBox.Show("Hata! Yazdığınız Kelimelerin Karşılığı Olan Açıklamasını Yazmadınız veya Yazdığınız Kelimelerden Fazla Açıklama Yaptınız!", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btn_KelimeleriGetir_Click(object sender, RoutedEventArgs e)
        {
            DataGrid_Guuncelle();
        }

        private void DataGrid_Guuncelle()
        {
            dtgrid.ItemsSource = null;
            tablo.Clear();
            using (OleDbConnection baglanti = new OleDbConnection(DB.MyDB))
            {
                try
                {
                    baglanti.Open();
                    OleDbCommand sorgu = new OleDbCommand("select*from Data", baglanti);
                    OleDbDataAdapter odp = new OleDbDataAdapter(sorgu);
                    odp.Fill(tablo);
                    dtgrid.Items.Refresh();
                    dtgrid.ItemsSource = tablo.DefaultView;                  
                    baglanti.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
