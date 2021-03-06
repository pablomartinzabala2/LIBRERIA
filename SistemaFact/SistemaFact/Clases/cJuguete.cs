﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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

        public DataTable GetDetalleArticulo(string Nombre, string CodigoBarra, string Codigo, Int32? CodMarca )
        {
            int b = 0;
            string sql = "select a.CodArticulo, a.Codigo,a.CodigoBarra,a.Nombre, a.stock ";
            sql = sql + ",Costo,PrecioTarjeta,";
            sql = sql + "(PrecioTarjeta - 0.10*PrecioTarjeta) as Descuento ";
            sql = sql + ",PrecioEfectivo";
            sql = sql + " from Juguete a ";
            if (Nombre != "")
            {
                b = 1;
                sql = sql + " where a.Nombre like " + "'%" + Nombre + "%'";
            }
            if (CodigoBarra != "")
            {
                b = 1;
                sql = sql + " where a.CodigoBarra =" + "'" + CodigoBarra + "'";
            }

            if (Codigo != "")
            {
                b = 1;
                sql = sql + " where a.Codigo =" + "'" + Codigo + "'";
            }

            if (CodMarca !=null)
            {
                if (b ==0)
                    sql = sql + " where CodMarca=" + CodMarca.ToString();
                else
                    sql = sql + " and CodMarca=" + CodMarca.ToString();
            }

            sql = sql + " order by a.Nombre";

            return cDb.GetDatatable(sql);
        }

        public DataTable GetTodosJuguetes()
        {
            string sql = "select a.CodArticulo,a.Nombre ";
            sql = sql + ",Costo,PrecioTarjeta";
            sql = sql + ",PrecioEfectivo";
            sql = sql + " from Juguete a";
            DataTable trdo = cDb.GetDatatable(sql);
            return trdo;
        }

        public void ActualizarStockResta(SqlConnection con, SqlTransaction Transaccion, Int32 CodArticulo, int Cantidad)
        {
            string sql = " update Juguete ";
            sql = sql + " set Stock = isnull(Stock,0) - " + Cantidad.ToString();
            sql = sql + " where CodArticulo=" + CodArticulo.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetArticuloxCodArt(Int32 CodArt)
        {
            string sql = "select * from Juguete where CodArticulo=" + CodArt.ToString();
            DataTable trdo = cDb.GetDatatable(sql);
            return trdo;
        }

        public DataTable GetJuguetexCodigo(string  Codigo)
        {
            string sql = "select * from Juguete where Codigo=" + "'" + Codigo.ToString() + "'";
            DataTable trdo = cDb.GetDatatable(sql);
            return trdo;
        }

        public void ActualizarPrecioxMarca(Int32 CodMarca,int Por)
        {   //PrecioTarjeta
            string sql = "update Juguete set PrecioEfectivo= PrecioEfectivo + " + Por + " * PrecioEfectivo /100";
            sql = sql + " , PrecioTarjeta= PrecioTarjeta + " + Por + " * PrecioTarjeta /100"; 
            sql = sql + " where CodMarca=" + CodMarca.ToString();
            cDb.Grabar(sql);
        }

        public DataTable GetJuguetes()
        {
            string sql = "select j.CodArticulo,j.Nombre";
            sql = sql + " from Juguete j";
            sql = sql + " order by j.Nombre ";
            return cDb.GetDatatable(sql);
        }

        public void ActualizarCosto(SqlConnection con, SqlTransaction Transaccion,
         Int32 CodArticulo, Double Costo)
        {
            string sql = "Update Juguete set Costo = " + Costo.ToString().Replace(",", ".");
            sql = sql + " where CodArticulo =" + CodArticulo.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

        public DataTable GetJuguetexCodBarra(string CodigoBarra)
        {
            string sql = "select * from juguete a";
            sql = sql + " where a.CodigoBarra=" + "'" + CodigoBarra + "'";
            return cDb.GetDatatable(sql);
        }

        public void ActualizarPorcentajes(SqlConnection con, SqlTransaction Transaccion, Int32 CodArticulo, Double PorEfe, Double PorTar)
        {
            string sql = "update juguete ";
            string var = "";
            if (PorEfe > 0)
                var = "1";
            else
                var = "0";
            if (PorTar > 0)
                var = var + "1";
            else
                var = var + "0";
            switch (var)
            {
                case "10":
                    sql = sql + " set PorEfe =" + PorEfe.ToString().Replace(",", ".");
                    break;
                case "11":
                    sql = sql + " set PorEfe =" + PorEfe.ToString().Replace(",", ".");
                    sql = sql + " , PorTar =" + PorTar.ToString().Replace(",", ".");
                    break;
                case "01":
                    sql = sql + " set PorTar =" + PorTar.ToString().Replace(",", ".");
                    break;

            }
            sql = sql + " where CodArticulo=" + CodArticulo.ToString();
            cDb.EjecutarNonQueryTransaccion(con, Transaccion, sql);
        }

    }
}
