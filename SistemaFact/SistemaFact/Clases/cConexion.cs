using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFact.Clases
{
    public static class cConexion
    {
        public static string GetConexion()
        {
            //home DESKTOP-QKECIIE
            string cadena = "Data Source=DESKTOP-QKECIIE;Initial Catalog=LIBRERIA;Integrated Security=True";
            //schol
         //   string cadena = "Data Source=SECRETARIA-2\\SQLEXPRESS;Initial Catalog=FACTURACION;Integrated Security=True";
            return cadena;
        }
    }
}
