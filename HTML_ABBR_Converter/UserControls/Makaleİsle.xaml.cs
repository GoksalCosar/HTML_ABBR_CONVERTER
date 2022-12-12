using System;
using System.Collections.Generic;
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
using System.Globalization;
using System.Threading;
using System.Data;

namespace VerilenDegereGoreHtmlKoduYazanProgram
{
    /// <summary>
    /// Interaction logic for Makaleİsle.xaml
    /// </summary>
    public partial class Makaleİsle : UserControl
    {
        int sonuc;
        List<string> Data = new List<string>();
        List<string> Data_A = new List<string>();       
        public Makaleİsle()
        {
            InitializeComponent();           
        }       

        private void SelectSorgusu()
        {
            using (OleDbConnection baglanti = new OleDbConnection(DB.MyDB))
            {
                try
                {
                    baglanti.Open();
                    OleDbCommand sorgu = new OleDbCommand("select * from Data", baglanti);
                    OleDbDataReader rdr = sorgu.ExecuteReader();

                    while (rdr.Read())
                    {
                        Data.Add(rdr["Title"].ToString());
                        Parm.Kelimler.Add(rdr["Title"].ToString());
                        Data_A.Add(rdr["Acıklama"].ToString());
                        Parm.Aciklamalar.Add(rdr["Acıklama"].ToString());
                    }
                    baglanti.Close();
                    MessageBox.Show("Kelimeler Çekildi", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    baglanti.Close();
                }
            }
        }

        private void btn_Donustur_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if(Data.Count == 0 || Data_A.Count == 0)
            {
                for (int i = 0; i < Parm.Kelimler.Count; i++)
                {
                    Data.Add(Parm.Kelimler[i]);
                    Data_A.Add(Parm.Aciklamalar[i]);
                }
            }
            
            for (int i = 0; i < Data.Count; i++)
            {
                if (txt_Baslangıc.Text.Contains(Data[i].ToLower()))
                {                    
                    dic.Add(Data[i].ToLower(), Data_A[i].ToString());
                }
                else if (txt_Baslangıc.Text.Contains(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Data[i])))
                {
                    dic.Add(Data[i], Data_A[i]);
                }

                string output = txt_Baslangıc.Text;
                foreach (KeyValuePair<string,string> item in dic)
                {
                    string key = item.Key;
                    string value = item.Value;
                    output = output.Replace(key, $@"<abbr title=""{value}"">{ key }</abbr>");
                }
                txt_Sonuc.Text = output;
            }
        }

        private void btn_KelimeCek_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Kelimeler Çekiliyor...", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);
            SelectSorgusu();                  
        }
    }
}
