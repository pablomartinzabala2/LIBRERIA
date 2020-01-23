using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace SistemaFact.Clases
{
    public class cArticulo
    {
        public void Insertar(string Nombre,Double? Costo,Double? Precio,
            int? CodColor,string Ruta, int? CodTipoPrenda,string CodigoBarra)
        {
            string sql = "insert into Articulo(";
            sql = sql + "Nombre,Costo,Precio,CodColor,Ruta,CodTipoPrenda,CodigoBarra)";
            sql = sql + " Values(";
            sql = sql + "'" + Nombre + "'";
            if (Costo != null)
                sql = sql + "," + Costo.ToString().Replace(",",".");
            else
                sql = sql + ",null";
            if (Precio != null)
                sql = sql + "," + Precio.ToString().Replace(",",".");
            else
                sql = sql + ",null";
            if (CodColor != null)
                sql = sql + "," + CodColor.ToString();
            else
                sql = sql + ",null";
            sql = sql + "," + "'" + Ruta + "'";
            if (CodTipoPrenda  != null)
                sql = sql + "," + CodTipoPrenda.ToString();
            else
                sql = sql + ",null";
            if (CodigoBarra != null)
                sql = sql + "," + "'" + CodigoBarra + "'";
            else
                sql = sql + ",null";
            sql = sql + ")";
            cDb.Grabar(sql);
        }

        public DataTable GetArticulo(string Nombre,string CodigoBarra,string Codigo)
        {
            string sql = "select a.Codigo,a.CodigoBarra, a.CodArticulo,a.Nombre";
            
            sql = sql + " from articulo a";
            if (Nombre !="")
            {
                sql = sql + " where a.Nombre like " + "'%" + Nombre + "%'";
            }
            if (CodigoBarra !="")
            {
                sql = sql + " where a.CodigoBarra =" + "'" + CodigoBarra +"'";
            }

            if (Codigo != "")
            {
                sql = sql + " where a.Codigo =" + "'" + Codigo + "'";
            }

            return cDb.GetDatatable(sql);
        }

        public void InsertarArticulo(string Codigo,string CodigoBarra,string Nombre,Double? Costo)
        {
            string sql = "insert into Articulo(Nombre,Codigo,CodigoBarra,Costo)";
            sql = sql + " Values(" + "'" + Nombre + "'";
            if (Codigo != null)
                sql = sql + "," + "'" + Codigo + "'";
            else
                sql = sql + ",null";

            if (CodigoBarra  != null)
                sql = sql + "," + "'" + CodigoBarra  + "'";
            else
                sql = sql + ",null";

            if (Costo != null)
                sql = sql + "," + Costo.ToString().Replace(",", ".");
            else
                sql = sql + ",null";

            sql = sql + ")";
            //verifico si existe
            Int32 CodArticulo = Existe(Codigo, CodigoBarra);
            if (CodArticulo == 0)
                cDb.Grabar(sql);
            else
                ModificarArticulo(CodArticulo, Costo);
        }

        public Int32  Existe(string Codigo,string CodigoBarra)
        {
            Int32 CodArticulo = 0;
            string sql = "select CodArticulo";
            sql = sql + " from Articulo";
            if (CodigoBarra !="")
            {
                sql = sql + " where CodigoBarra=" + "'" + CodigoBarra + "'";
            }
            else
            {
                if (Codigo !="")
                    sql = sql + " where Codigo=" + "'" + Codigo + "'";
            }
            DataTable trdo = cDb.GetDatatable(sql);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["CodArticulo"].ToString() != "")
                    CodArticulo = Convert.ToInt32(trdo.Rows[0]["CodArticulo"].ToString());
            return CodArticulo;
        }

        public void ModificarArticulo(Int32 CodArticulo, Double? Costo)
        {
            string sql = "Update Articulo ";
            if (Costo != null)
                sql = sql + " set Costo=" + Costo.ToString().Replace(",", ".");
            else
                sql = sql + " set Costo=null";

            sql = sql + " where CodArticulo=" + CodArticulo.ToString();
            cDb.Grabar(sql);
        }
    }
}
