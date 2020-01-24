using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SistemaFact.Clases
{
   public  class cCompra
    {
        public Int32 GrabarCompra(SqlConnection con, SqlTransaction Transaccion,DateTime Fecha)
        {
            string sql = "insert into Compra(Fecha";
            sql = sql + ")";
            sql = sql + " values(" + "'" + Fecha.ToShortDateString() + "'";
            sql = sql + ")";
            return cDb.EjecutarEscalarTransaccion(con, Transaccion, sql);
        }
    }
}
