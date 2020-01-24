﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaFact.Clases;
using System.Data.SqlClient;
namespace SistemaFact
{
    public partial class FrmCompra : FormBase
    {
        cFunciones fun;
        DataTable tbCompra;
        public FrmCompra()
        {
            InitializeComponent();
        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            string Col = "CodArticulo;Nombre;Cantidad;Precio;Descuento;Subtotal";
            tbCompra = fun.CrearTabla(Col);
        }

        private void txt_Codigo_TextChanged(object sender, EventArgs e)
        {
            string Codigo = txt_Codigo.Text;
            cArticulo art = new cArticulo();
            DataTable trdo = art.GetArticulo("", "", Codigo);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["CodArticulo"].ToString() != "")
                {
                    txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                    txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                    txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                    txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                }
        }

        private void txt_CodigoBarra_TextChanged(object sender, EventArgs e)
        {
            if (txt_CodigoBarra.Text != "")
            {
                string CodigoBarra = txt_CodigoBarra.Text;
                cArticulo art = new cArticulo();
                DataTable trdo = art.GetArticulo("", CodigoBarra, "");
                if (trdo.Rows.Count > 0)
                    if (trdo.Rows[0]["CodArticulo"].ToString() != "")
                    {
                        txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                        txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                        txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                        txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text =="")
            {
                Mensaje("Debe ingresar un articulo");
                return;
            }
            if (txtCantidad.Text =="")
            {
                Mensaje("Debe ingresar una cantidad");
                return;
            }

            if (txtPrecio.Text  == "")
            {
                Mensaje("Debe ingresar un precio");
                return;
            }

            string Codigo = txtCodigo.Text;
            if (fun.Buscar(tbCompra ,"CodArticulo",Codigo)==true)
            {
                Mensaje("Ya se ha ingresado el articulo");
                return;
            }
            string Nombre = txt_Nombre.Text;
            Int32  Cantidad =Convert.ToInt32 (txtCantidad.Text);
            Double Precio = fun.ToDouble(txtPrecio.Text);
            Double Descuento = 0;
            Double SubTotal = Cantidad * Precio  - Descuento;
            string Val = Codigo + ";" + Nombre;
            Val = Val + ";" + Cantidad.ToString();
            Val = Val + ";" + Precio.ToString();
            Val = Val + ";" + Descuento.ToString();
            Val = Val + ";" + SubTotal;
            tbCompra = fun.AgregarFilas(tbCompra, Val);
            Grilla.DataSource = tbCompra;
            CalcularTotal();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar una fila");
                return;
            }
            string Codigo = Grilla.CurrentRow.Cells[0].Value.ToString();
            tbCompra = fun.EliminarFila(tbCompra , "CodArticulo", Codigo);
            Grilla.DataSource = tbCompra;
            CalcularTotal();
        }

        private void Grupo_Enter(object sender, EventArgs e)
        {

        }

        private void CalcularTotal()
        {
           double Total = fun.TotalizarColumna(tbCompra, "Subtotal");
            txtTotal.Text = Total.ToString();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            SqlTransaction Transaccion;
            SqlConnection con = new SqlConnection(cConexion.GetConexion());
            con.Open();
            Transaccion = con.BeginTransaction();
            try
            {
                Int32 CodCompra = GrabarCompra(con, Transaccion);
                GrabarDetalleCompra(con, Transaccion, CodCompra);
                Mensaje("Datos grabados Correctamente");
            }
            catch (Exception exa)
            {
                Transaccion.Rollback();
                con.Close();
                Mensaje("Hubo un error en el proceso de grabacion");
                Mensaje(exa.Message);
                
            }
        }

        public Int32 GrabarCompra(SqlConnection con, SqlTransaction Transaccion)
        {
            DateTime Fecha = DateTime.Now;
            cCompra compra = new Clases.cCompra();
            return compra.GrabarCompra(con, Transaccion, Fecha);
        }

        public void GrabarDetalleCompra(SqlConnection con, SqlTransaction Transaccion,Int32 CodCompra)
        {
            Int32 CodArticulo = 0;
            int Cantidad = 0;
            Double Costo = 0;
            Double Descueneto = 0;
            Double Subtotal = 0;
            cDetalleCompra detalle = new cDetalleCompra();
            //string Col = "CodArticulo;Nombre;Cantidad;Precio;Descuento;Subtotal";
            for (int i=0;i< tbCompra.Rows.Count;i++)
            {
                CodArticulo = Convert.ToInt32(tbCompra.Rows[i]["CodArticulo"].ToString());
                Cantidad = Convert.ToInt32(tbCompra.Rows[i]["Cantidad"].ToString());
                Costo = fun.ToDouble(tbCompra.Rows[i]["Precio"].ToString());
                Descueneto = fun.ToDouble(tbCompra.Rows[i]["Descuento"].ToString());
                Subtotal = fun.ToDouble (tbCompra.Rows[i]["Subtotal"].ToString());
                detalle.Insertar(con, Transaccion, CodCompra, CodArticulo, Cantidad, Costo, Descueneto, Subtotal);
            }
        }
    }
}