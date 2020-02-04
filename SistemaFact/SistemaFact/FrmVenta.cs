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
    public partial class FrmVenta : FormBase
    {
        cFunciones fun;
        DataTable tbVenta;
        public FrmVenta()
        {
            InitializeComponent();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            Inicializar();
        }

        public void Inicializar()
        {
            txtFechaAltaOrden.Text = DateTime.Now.ToShortDateString();  
            fun.LlenarCombo(cmbTipoDoc, "TipoDocumento", "Nombre", "CodTipoDoc");
            if (cmbTipoDoc.Items.Count > 0)
                cmbTipoDoc.SelectedIndex = 1;
            string Col = "CodArticulo;Nombre;Precio;Cantidad;Subtotal";
            tbVenta = fun.CrearTabla (Col);
            CargarTipoOperacion();
        }

        private void CargarTipoOperacion()
        {
            string Col = "Codigo;Nombre";
            DataTable tb = new DataTable();
            tb = fun.CrearTabla(Col);
            string Val = "";
            Val = "1;Consumidor Final";
            tb = fun.AgregarFilas(tb, Val);
            Val = "2;Tarjeta Credito";
            tb = fun.AgregarFilas(tb, Val);
            Val = "3;Tarjeta Débito";
            tb = fun.AgregarFilas(tb, Val);
            fun.LlenarComboDatatable(CmbTipoOperacion,tb, "Nombre", "Codigo");
            CmbTipoOperacion.SelectedIndex = 1;
        }

        private void txtNroDocumento_TextChanged(object sender, EventArgs e)
        {
            int b = 0;
            string NroDoc = txtNroDocumento.Text;
            if (NroDoc.Length < 3)
                return;
            cCliente cli = new cCliente();
            DataTable trdo = cli.GetClientesxNroDocumento(NroDoc);
            if (trdo.Rows.Count > 0)
                if (trdo.Rows[0]["CodCliente"].ToString() != "")
                {
                    Int32 CodCliente = Convert.ToInt32(trdo.Rows[0]["CodCliente"].ToString());
                    GetClientexCodigo(CodCliente);
                    b = 1;
                }
            if (b == 0)
            {
                txtCodCliente.Text = "";
                txtApellido.Text = "";
                txtNombre.Text = "";
            }
        }

        private void GetClientexCodigo(Int32 CodCliente)
        {
            cCliente cli = new cCliente();
            DataTable trdo = cli.GetClientexCodigo(CodCliente);
            if (trdo.Rows.Count > 0)
            {
                txtCodCliente.Text = trdo.Rows[0]["CodCliente"].ToString();
                txtNroDocumento.Text = trdo.Rows[0]["NroDocumento"].ToString();
                txtNombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txtApellido.Text = trdo.Rows[0]["Apellido"].ToString();
                txtTelefono.Text = trdo.Rows[0]["Telefono"].ToString();
                

               
            }
        }

        private void txt_Codigo_TextChanged(object sender, EventArgs e)
        {
            if (txt_Codigo.Text.Length <3)
            {
                return;
            }
            string Codigo = txt_Codigo.Text;
            cArticulo art = new cArticulo();
            DataTable trdo = art.GetArticulo("", "", Codigo);
            if (trdo.Rows.Count >0)
            {
                txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                // txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();
              //  if (txtPrecio.Text != "")
                //    txtPrecio.Text = txtPrecio.Text.Replace(",", ".");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            Principal.OpcionesdeBusqueda = "Codigo;Nombre;CodigoBarra";
            Principal.TablaPrincipal = "Articulo";
            Principal.OpcionesColumnasGrilla = "CodArticulo;Nombre;Costo";
            Principal.ColumnasVisibles = "0;1;1";
            Principal.ColumnasAncho = "0;390;190";
            Principal.NombreTablaSecundario = "Articulo";
            Principal.CampoIdSecundarioGenerado = "";
            FrmBuscadorGenerico form = new FrmBuscadorGenerico();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Principal.CodigoPrincipalAbm != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                switch (Principal.NombreTablaSecundario)
                {
                    case "Articulo":
                        BuscarArticuloxCodigo(Convert.ToInt32 (Principal.CodigoPrincipalAbm));
                        break;
                }
            }
        }

        private void BuscarArticuloxCodigo(Int32 CodArt)
        {
            cArticulo art = new cArticulo();
            DataTable trdo = art.GetArticuloxCodArt(CodArt);
            if (trdo.Rows.Count >0)
            {  
                txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                txtPrecio.Text = trdo.Rows[0]["PrecioEfectivo"].ToString();
                if (txtPrecio.Text != "")
                    txtPrecio.Text = txtPrecio.Text.Replace(",", ".");
            }
        }

        private void Agregar()
        {
            if (txtCodigo.Text =="")
            {
                Mensaje("Debe ingresar un articulo");
                return;
            }
            if (txtCantidad.Text =="")
            {
                Mensaje("Debe ingresar una cantidad");
                return;
            }

            if (txtPrecio.Text =="")
            {
                Mensaje("Debe ingresar un precio");
                return;
            }
            //string Col = "CodArticulo;Nombre;Precio;Cantidad;Subtotal";
            Int32 CodArticulo = Convert.ToInt32(txtCodigo.Text);
            int Cantidad = Convert.ToInt32(txtCantidad.Text);
            Double Precio = Convert.ToDouble(txtPrecio.Text);
            Double Subtotal = Precio * Cantidad;
            string Nombre = txt_Nombre.Text;

            if (fun.Buscar(tbVenta,"CodArticulo",CodArticulo.ToString ()) == true)
            {
                Mensaje("Ya se ha ingresado el articulo");
                return;
            }

            string Val = CodArticulo + ";" + Nombre;
            Val = Val + ";" + Precio.ToString();
            Val = Val + ";" + Cantidad.ToString();
            Val = Val + ";" + Subtotal.ToString();
            tbVenta = fun.AgregarFilas(tbVenta, Val);
            Grilla.DataSource = tbVenta; 
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar una fila");
                return;
            }
            string Codigo = Grilla.CurrentRow.Cells[0].Value.ToString();
            tbVenta = fun.EliminarFila(tbVenta, "CodArticulo", Codigo);
            Grilla.DataSource = tbVenta;
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                Agregar();
            }
        }
    }
}
