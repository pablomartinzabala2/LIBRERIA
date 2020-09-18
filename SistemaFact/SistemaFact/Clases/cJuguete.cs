using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SistemaFact.Clases
{
    public  class cJuguete
    {
        public DataTable GetArticulo(string Nombre, string CodigoBarra, string Codigo)
        {
            string sql = "select a.CodArticulo, a.Codigo,a.CodigoBarra,a.Nombre, a.stock ";
            sql = sql + ",Costo,PrecioEfectivo,PrecioTarjeta";
            sql = sql + " from juguete a";
            if (Nombre != "")
            {
                sql = sql + " where a.Nombre like " + "'%" + Nombre + "%'";
            }
            if (CodigoBarra != "")
            {
                sql = sql + " where a.CodigoBarra =" + "'" + CodigoBarra + "'";
            }

            if (Codigo != "")
            {
                sql = sql + " where a.Codigo =" + "'" + Codigo + "'";
            }

            return cDb.GetDatatable(sql);
        }
    }
}
