using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace VerilenDegereGoreHtmlKoduYazanProgram
{
    public class UserCgetir
    {
        MainWindow main = new MainWindow();
       public void Getir(Grid grd, UserControl us)
        {
            if (main.İcerik != null)
            {
                grd.Children.Clear();
                grd.Children.Add(us);
            }
            else
            {               
                grd.Children.Add(us);
            }
        }
    }
}
