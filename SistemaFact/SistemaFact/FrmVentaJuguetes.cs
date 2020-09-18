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
    public partial class FrmVentaJuguetes : FormBase
    {
        Boolean PuedeAgregar = false;
        int Indice = 0;
        DataTable tbVenta;
        cFunciones fun;
        public FrmVentaJuguetes()
        {
            InitializeComponent();
        }

        private void txt_CodigoBarra_TextChanged(object sender, EventArgs e)
        {
            int b = 0;
            int Operacion = 0;
            if (CmbTipoOperacion.SelectedIndex > 0)
                Operacion = Convert.ToInt32(CmbTipoOperacion.SelectedValue);
            if (txt_CodigoBarra.Text.Length < 5)
            {
                return;
            }
            string Codigo = txt_CodigoBarra.Text;
            cJuguete art = new cJuguete();
            DataTable trdo = art.GetArticulo("", Codigo, "");
            if (trdo.Rows.Count > 0)
            {
                b = 1;
                txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                txt_Nombre.SelectedValue = trdo.Rows[0]["CodArticulo"].ToString();
                txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();


                if (Operacion == 1)
                    txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();
                if (Operacion == 2)
                {
                    txtPrecio.Text = trdo.Rows[0]["PrecioTarjeta"].ToString();
                    Double Precio = Convert.ToDouble(trdo.Rows[0]["PrecioTarjeta"].ToString());
                    Precio = Precio - 0.10 * Precio;
                    txtDescuento.Text = Precio.ToString();
                }

                if (Operacion == 3)
                    txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();

                if (txtPrecio.Text != "")
                {
                    Double Precio = Convert.ToDouble(txtPrecio.Text);
                    Precio = Math.Round(Precio, 0);
                    txtPrecio.Text = Precio.ToString();
                }

                if (txtDescuento.Text != "")
                {
                    Double Precio = Convert.ToDouble(txtDescuento.Text);
                    Precio = Math.Round(Precio, 0);
                    txtDescuento.Text = Precio.ToString();
                }

                if (b == 1)
                {
                    PuedeAgregar = false;
                    txtCantidad.Focus();
                }

            } 
        }

        private void CargarTipoOperacion()
        {
            cTipoOperacion tipo = new cTipoOperacion();
            DataTable tb = tipo.GetTipos();
            fun.LlenarComboDatatable(CmbTipoOperacion, tb, "Nombre", "Codigo");
            CmbTipoOperacion.SelectedIndex = 1;
        }

        private void FrmVentaJuguetes_Load(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void Inicializar()
        {
            DateTime Fecha = DateTime.Now;
            txtFecha.Text = Fecha.ToShortDateString();
            fun = new Clases.cFunciones();
            CargarTipoOperacion();
            string Col = "CodArticulo;Nombre;Precio;Cantidad;Subtotal;Indice";
            tbVenta = fun.CrearTabla(Col);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (PuedeAgregar == false)
            {
                if (txtCodigo.Text != "")
                {
                    txt_Nombre.SelectedValue = txtCodigo.Text;
                }
                PuedeAgregar = true;
                return;
            }

            if (txtCodigo.Text == "")
            {
                Mensaje("Debe ingresar un articulo");
                return;
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtCodigo.Text == "")
                {
                    Mensaje("Debe ingresar un articulo");
                    return;
                }
                if (txtCantidad.Text == "")
                {
                    txtCantidad.Text = "1";
                }
                Agregar();
            }
        }

        private void Agregar()
        {
            if (txtCodigo.Text == "")
            {
                Mensaje("Debe ingresar un articulo");
                return;
            }
            if (txtCantidad.Text == "")
            {
                Mensaje("Debe ingresar una cantidad");
                return;
            }

            if (txtPrecio.Text == "")
            {
                Mensaje("Debe ingresar un precio");
                return;
            }
            Boolean Des = false;
            if (chkDescuento.Visible == true)
                if (chkDescuento.Checked == true)
                    Des = true;
            //string Col = "CodArticulo;Nombre;Precio;Cantidad;Subtotal";
            Int32 CodArticulo = Convert.ToInt32(txtCodigo.Text);
            int Cantidad = Convert.ToInt32(txtCantidad.Text);
            Double Precio = 0;
            if (Des == false)
                Precio = Convert.ToDouble(txtPrecio.Text);
            if (Des == true)
                Precio = Convert.ToDouble(txtDescuento.Text);
            Double Subtotal = Precio * Cantidad;
            string Nombre = txt_Nombre.Text;

            if (fun.Buscar(tbVenta, "CodArticulo", CodArticulo.ToString()) == true)
            {
                Mensaje("Ya se ha ingresado el articulo");
                return;
            }

            string Val = CodArticulo + ";" + Nombre;
            Val = Val + ";" + Precio.ToString();
            Val = Val + ";" + Cantidad.ToString();
            Val = Val + ";" + Subtotal.ToString();
            Val = Val + ";" + Indice.ToString();
            tbVenta = fun.AgregarFilas(tbVenta, Val);
            Indice = Indice + 1;
            //Grilla.Sort(Grilla.Columns[3]), ListSortDirection.Ascending)
            if (tbVenta.Rows.Count > 1)
                Grilla.Sort(Grilla.Columns[5], ListSortDirection.Descending);
            Grilla.DataSource = tbVenta;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[5].Visible = false;
            Grilla.Columns[1].Width = 370;
            Double Total = fun.TotalizarColumna(tbVenta, "Subtotal");
            txtTotal.Text = Total.ToString();
            txtTotalConDescuento.Text = Total.ToString();
            txtCodigo.Text = "";
            txt_Codigo.Text = "";
            txt_CodigoBarra.Text = "";
            txt_Stock.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txt_Nombre.Text = "";
           // Valida = false;
            txt_CodigoBarra.Focus();
            Grilla.Refresh();
            if (tbVenta.Rows.Count > 0)
            {
                for (int i = 0; i < Grilla.Rows.Count - 1; i++)
                {
                    if (i == 0)
                        Grilla.Rows[0].Selected = true;
                    else
                        Grilla.Rows[i].Selected = false;
                }
            }
            //    
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow == null)
            {
                Mensaje("Debe seleccionar una fila");
                return;
            }
            string Codigo = Grilla.CurrentRow.Cells[0].Value.ToString();
            tbVenta = fun.EliminarFila(tbVenta, "CodArticulo", Codigo);
            Grilla.DataSource = tbVenta;
            Double Total = fun.TotalizarColumna(tbVenta, "Subtotal");
            txtTotal.Text = Total.ToString();
            txtTotalConDescuento.Text = Total.ToString();
        }
    }
}
