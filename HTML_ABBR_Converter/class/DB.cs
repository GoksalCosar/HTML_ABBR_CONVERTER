using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerilenDegereGoreHtmlKoduYazanProgram
{
    public static class DB
    {
		private static string db = "Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Environment.CurrentDirectory + "\\VeriTabanı.accdb";

		public static string MyDB
		{
			get { return db; }			
		}
    }
}
