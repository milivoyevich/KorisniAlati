using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KorisniAlati
{
    public  class StaticKlasa
    {
        public static List<Address> Tpersona =new LOcalcAuto().PersonaL();
        public static int broj { get; set; }
        public static string tekst { get; set; }
        public static DateTime datum { get; set; }
        public  DateTime datum1 { get; set; }
        //public static DataTable Personal=new personal();
    }
}
