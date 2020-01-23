using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace SistemaFact.Clases
{
    public static class cDb
    {
        public static DataTable GetDatatable(string sql)
        {
            SqlConnection con = new SqlConnection(cConexion.GetConexion ());
            SqlCommand comando = new SqlCommand();
            comando.CommandText = sql;
            comando.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comando;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public static void Grabar(string sql)
        {
            SqlConnection con = new SqlConnection(cConexion.GetConexion());
            SqlCommand comando = new SqlCommand();
            comando.CommandText = sql;
            comando.Connection = con;
            con.Open();
            comando.ExecuteNonQuery();
            con.Close();
        }
    }
        
}
