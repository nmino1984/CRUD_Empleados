using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.DataLayer
{
    public class Conection
    {
        public static string Cadena = ConfigurationManager.ConnectionStrings["strSQLConnection"].ToString();


    }
}
