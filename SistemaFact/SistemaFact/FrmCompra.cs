using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaFact.Clases;
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
        }
    }
}
