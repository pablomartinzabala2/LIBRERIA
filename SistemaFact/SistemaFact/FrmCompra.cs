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
using System.Data.SqlClient;
namespace SistemaFact
{
    public partial class FrmCompra : FormBase
    {
        cFunciones fun;
        DataTable tbCompra;
        Boolean PuedeAgregar;
        int Indice;
        public FrmCompra()
        {
            InitializeComponent();
        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {
            fun = new Clases.cFunciones();
            string Col = "CodArticulo;Nombre;Cantidad;Precio;Descuento;Efectivo;Tarjeta;Subtotal;Libreria;PorEfe;PorTar;Indice";
            tbCompra = fun.CrearTabla(Col);
           
            DateTime Fecha = DateTime.Now;
            txtFecha.Text = Fecha.ToShortDateString();
            fun.LlenarCombo(cmbProveedor, "Proveedor", "Nombre", "CodProveedor");
            if (Principal.CodPrincipalCompra != null)
            {
                Int32 CodCompra = Convert.ToInt32(Principal.CodPrincipalCompra);
                BuscarCompraCompleta(CodCompra);
            }
            else
            {
                LlenarComboArticulo();
            }
            txtCodigo.Focus();
            CargarPorcentajesLibreria();
            Indice = 0;
        }

        public void CargarPorcentajesLibreria()
        {  
            cPorcentaje obj = new Clases.cPorcentaje();
            DataTable trdo = obj.GetPorcentaje();
            if (trdo.Rows.Count > 0)
            {
                txtPorGlobalEfectivo.Text = trdo.Rows[0]["PorEfeLibreria"].ToString();
                if (txtPorGlobalEfectivo.Text != "")
                {
                    Double Efectivo = Convert.ToDouble(txtPorGlobalEfectivo.Text.Replace(".", ","));
                    txtPorGlobalEfectivo.Text = Math.Round(Efectivo, 0).ToString();
                }
                txtPorGlobalTarjeta.Text = trdo.Rows[0]["PorTarLibreria"].ToString();
                if (txtPorGlobalTarjeta.Text != "")
                {
                    Double Efectivo = Convert.ToDouble(txtPorGlobalTarjeta.Text.Replace(".", ","));
                    txtPorGlobalTarjeta.Text = Math.Round(Efectivo, 0).ToString();
                }
            }
        }

        public void CargarPorcentajesJuguetes()
        {
            cPorcentaje obj = new Clases.cPorcentaje();
            DataTable trdo = obj.GetPorcentaje();
            if (trdo.Rows.Count > 0)
            {
                txtPorGlobalEfectivo.Text = trdo.Rows[0]["PorEfeJuguete"].ToString();
                if (txtPorGlobalEfectivo.Text != "")
                {
                    Double Efectivo = Convert.ToDouble(txtPorGlobalEfectivo.Text.Replace(".", ","));
                    txtPorGlobalEfectivo.Text = Math.Round(Efectivo, 0).ToString();
                }

                txtPorGlobalTarjeta.Text = trdo.Rows[0]["PorTarJuguete"].ToString();
                if (txtPorGlobalTarjeta.Text != "")
                {
                    Double Efectivo = Convert.ToDouble(txtPorGlobalTarjeta.Text.Replace(".", ","));
                    txtPorGlobalTarjeta.Text = Math.Round(Efectivo, 0).ToString();
                }
            }
        }

        private void txt_Codigo_TextChanged(object sender, EventArgs e)
        {
            if (txt_Codigo.Text.Length <3)
            {
                txt_Nombre.Text = "";
                txt_CodigoBarra.Text = "";
               // txt_Codigo.Text = "";
                txt_Stock.Text = "";
                return;
            }
            string Codigo = txt_Codigo.Text;
            cArticulo art = new cArticulo();
            DataTable trdo = art.GetArticulo("", "", Codigo);
            if (trdo.Rows.Count > 0)
            {
                if (trdo.Rows[0]["CodArticulo"].ToString() != "")
                {
                    txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                    txt_Nombre.Text = trdo.Rows[0]["Nombre"].ToString();
                    txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                    // txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                    txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                }
                else
                {
                    txt_Nombre.Text = "";
                    txt_CodigoBarra.Text = "";
                    txt_Stock.Text = "";
                }
            }
            else
            {
                txt_Nombre.Text = "";
                txt_CodigoBarra.Text = "";
                txt_Stock.Text = "";
            }

        }

        private void txt_CodigoBarra_TextChanged(object sender, EventArgs e)
        {
            if (chkLibreria.Checked == true)
                BuscarLibreriaxCodigoBarra();
            else
                BuscarJuguetexCodigoBarra();
        }

        private void BuscarLibreriaxCodigoBarra()
        {
            int b = 0;
            if (txt_CodigoBarra.Text.Length > 7)
            {
                string CodigoBarra = txt_CodigoBarra.Text;
                cArticulo art = new cArticulo();
                DataTable trdo = art.GetArticuloxCodigoBarra(CodigoBarra);
                if (trdo.Rows.Count > 0)
                    if (trdo.Rows[0]["CodArticulo"].ToString() != "")
                    {
                        b = 1;
                        txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                        txt_Nombre.SelectedValue = txtCodigo.Text;
                        txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                        txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                        txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                        txtPrecio.Text = trdo.Rows[0]["Costo"].ToString();
                        txtPrecio.Text = trdo.Rows[0]["Costo"].ToString();
                        txtPorEfe.Text = trdo.Rows[0]["PorEfe"].ToString();
                        txtPorTar.Text = trdo.Rows[0]["PorTar"].ToString();
                        if (trdo.Rows[0]["Costo"].ToString()!="")
                        {
                            Double Costo = Math.Round(Convert.ToDouble(trdo.Rows[0]["Costo"]), 0);
                            txtPrecio.Text = Costo.ToString();
                            CalcularPrecioTarjetaEfectivo(Costo);
                        }
                        

                        if (txtPorEfe.Text != "")
                        {
                            txtPorEfe.Text = fun.SepararDecimales(txtPorEfe.Text);
                        }

                        if (txtPorTar.Text != "")
                        {
                            txtPorTar.Text = fun.SepararDecimales(txtPorTar.Text);
                        }
                    }
                if (b == 1)
                {
                    PuedeAgregar = false;
                    txtCantidad.Text = "";
                    txtCantidad.Focus();
                }
            }
        }

        private void BuscarJuguetexCodigoBarra()
        {
            int b = 0;
            if (txt_CodigoBarra.Text.Length > 7)
            {
                string CodigoBarra = txt_CodigoBarra.Text;
                cJuguete art = new Clases.cJuguete();
                DataTable trdo = art.GetJuguetexCodBarra(CodigoBarra);
                if (trdo.Rows.Count > 0)
                    if (trdo.Rows[0]["CodArticulo"].ToString() != "")
                    {
                        b = 1;
                        txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                        txtNombreJuguete.Text = trdo.Rows[0]["Nombre"].ToString();
                        txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                        txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                        txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                        txtPrecio.Text = trdo.Rows[0]["Costo"].ToString();
                        txtPorEfe.Text = trdo.Rows[0]["PorEfe"].ToString();
                        txtPorTar.Text = trdo.Rows[0]["PorTar"].ToString();
                        if (txtPrecio.Text !="")
                        {
                            txtPrecio.Text = fun.SepararDecimales(txtPrecio.Text);
                        }
                        if (txtPorEfe.Text != "")
                        {
                            txtPorEfe.Text = fun.SepararDecimales(txtPorEfe.Text);
                        }

                        if (txtPorTar.Text != "")
                        {
                            txtPorTar.Text = fun.SepararDecimales(txtPorTar.Text);
                        }
                    }
                if (b == 1)
                {
                    PuedeAgregar = false;
                    txtCantidad.Text = "";
                    txtCantidad.Focus();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar();
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

            string Codigo = txtCodigo.Text;
            if (fun.Buscar(tbCompra, "CodArticulo", Codigo) == true)
            {
                Mensaje("Ya se ha ingresado el articulo");
                return;
            }
            int Libreria = 0;
            string Nombre = "";
            if (chkLibreria.Checked == true)
            {
                Nombre = txt_Nombre.Text;
                Libreria = 1;
            }
            else
            {
                Nombre = txtNombreJuguete.Text;
                Libreria = 0;
            }
                

            Int32 Cantidad = Convert.ToInt32(txtCantidad.Text);
            Double Precio = fun.ToDouble(txtPrecio.Text);
            Double Descuento = 0;
            Double Efectivo = 0;
            Double Tarjeta = 0;
            if (txtEfectivo.Text != "")
                Efectivo = Convert.ToDouble(txtEfectivo.Text);
            if (txtTarjeta.Text != "")
                Tarjeta = Convert.ToDouble(txtTarjeta.Text);
            Double PorEfe = 0;
            Double PorTar = 0;

            if (txtPorEfe.Text != "")
                PorEfe = Convert.ToDouble(txtPorEfe.Text);

            if (txtPorTar.Text != "")
                PorTar = Convert.ToDouble(txtPorTar.Text);
            Indice = Indice + 1;
            Double SubTotal = Cantidad * Precio;
            string Val = Codigo + ";" + Nombre;
            Val = Val + ";" + Cantidad.ToString();
            Val = Val + ";" + Precio.ToString();
            Val = Val + ";" + Descuento.ToString();
            Val = Val + ";" + Efectivo.ToString().Replace(",", ".");
            Val = Val + ";" + Tarjeta.ToString().Replace(",", ".");
            Val = Val + ";" + SubTotal;
            Val = Val + ";" + Libreria;
            Val = Val + ";" + PorEfe;
            Val = Val + ";" + PorTar;
            Val = Val + ";" + Indice.ToString();
            tbCompra = fun.AgregarFilas(tbCompra, Val);
            Grilla.DataSource = tbCompra;
            CalcularTotal();
            LimpiarArticulo();
            fun.AnchoColumnas(Grilla, "0;40;10;10;0;10;10;10;0;5;5;0");
            txt_Codigo.Focus();
            if (tbCompra.Rows.Count > 1)
                Grilla.Sort(Grilla.Columns[11], ListSortDirection.Descending);
        }

        private void CalcularPrecioTarjetaEfectivo(Double Costo)
        {
            Double PorEfe = 0;
            Double PorTar = 0;
            Double Efectivo = 0;
            Double Tarjeta = 0;

            if (txtPorEfe.Text != "")
            {
                PorEfe = Convert.ToDouble(txtPorEfe.Text);
            }
            else
            {
                if (txtPorGlobalEfectivo.Text !="")
                {
                    PorEfe = Convert.ToDouble(txtPorGlobalEfectivo.Text);
                }
            }
              
            if (txtPorTar.Text != "")
            {
                PorTar  = Convert.ToDouble(txtPorTar.Text);
            }
            else
            {
                if (txtPorGlobalTarjeta.Text != "")
                {
                    PorTar = Convert.ToDouble(txtPorGlobalTarjeta.Text);
                }
            }
            Efectivo = Costo + Costo * PorEfe  / 100;
            Tarjeta  = Costo + Costo * PorTar  / 100;
            Efectivo = Math.Round(Efectivo, 0);
            Tarjeta = Math.Round(Tarjeta, 0);
            txtEfectivo.Text = Efectivo.ToString();
            txtTarjeta.Text = Tarjeta.ToString();

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
            if (fun.ValidarFecha (txtFecha.Text)==false)
            {
                Mensaje("Debe ingresar una fecha correcta para continuar");
                return;
            }

            SqlTransaction Transaccion;
            SqlConnection con = new SqlConnection(cConexion.GetConexion());
            con.Open();
            Transaccion = con.BeginTransaction();
            try
            {
                Int32 CodCompra = GrabarCompra(con, Transaccion);
                GrabarDetalleCompra(con, Transaccion, CodCompra);
                Transaccion.Commit();
                con.Close();
                Mensaje("Datos grabados Correctamente");
                LimpiarGrilla();
                
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
            DateTime Fecha = Convert.ToDateTime(txtFecha.Text);
            Int32? CodProveedor = null;
            if (cmbProveedor.SelectedIndex > 0)
                CodProveedor = Convert.ToInt32(cmbProveedor.SelectedValue);

            cCompra compra = new Clases.cCompra();
            Double Total = fun.ToDouble(txtTotal.Text);
            return compra.GrabarCompra(con, Transaccion, Fecha, Total, CodProveedor);
        }

        public void GrabarDetalleCompra(SqlConnection con, SqlTransaction Transaccion,Int32 CodCompra)
        {
            Int32 CodArticulo = 0;
            int Cantidad = 0;
            Double Costo = 0;
            Double Descueneto = 0;
            Double Subtotal = 0;
            int Libreria = 0;
            Double PorEfe = 0;
            Double PorTar = 0;

            cJuguete jug = new Clases.cJuguete();
            cArticulo objArt = new cArticulo();
            cDetalleCompra detalle = new cDetalleCompra();
            cDetalleCompraJuguete detalleJug = new cDetalleCompraJuguete();
            cArticulo art = new cArticulo();
            //string Col = "CodArticulo;Nombre;Cantidad;Precio;Descuento;Subtotal";
            for (int i=0;i< tbCompra.Rows.Count;i++)
            {
                Libreria = Convert.ToInt32(tbCompra.Rows[i]["Libreria"]);
                CodArticulo = Convert.ToInt32(tbCompra.Rows[i]["CodArticulo"].ToString());
                Cantidad = Convert.ToInt32(tbCompra.Rows[i]["Cantidad"].ToString());
                art.ActualizarStock(con, Transaccion, CodArticulo, Cantidad);
                Costo = fun.ToDouble(tbCompra.Rows[i]["Precio"].ToString());
                Descueneto = fun.ToDouble(tbCompra.Rows[i]["Descuento"].ToString());
                Subtotal = fun.ToDouble (tbCompra.Rows[i]["Subtotal"].ToString());
                if (tbCompra.Rows[i]["PorEfe"].ToString()!="0")
                {
                    PorEfe = Convert.ToDouble(tbCompra.Rows[i]["PorEfe"].ToString());
                }

                if (tbCompra.Rows[i]["PorTar"].ToString() != "0")
                {
                    PorTar = Convert.ToDouble(tbCompra.Rows[i]["PorTar"].ToString());
                }

                if (Libreria ==1)
                {
                    detalle.Insertar(con, Transaccion, CodCompra, CodArticulo, Cantidad, Costo, Descueneto, Subtotal);
                    art.ActualizarCosto(con, Transaccion, CodArticulo, Costo);
                    if (PorEfe > 0 || PorTar > 0)
                        art.ActualizarPorcentajes(con, Transaccion, CodArticulo, PorEfe, PorTar);
                }
                if (Libreria ==0)
                {
                    jug.ActualizarCosto(con, Transaccion, CodArticulo, Costo);
                    detalleJug.Insertar(con, Transaccion, CodCompra, CodArticulo, Cantidad, Costo, Descueneto, Subtotal);
                    if (PorEfe > 0 || PorTar > 0)
                        jug.ActualizarPorcentajes(con, Transaccion, CodArticulo, PorEfe, PorTar);
                }
                
            }
        }

        private void LimpiarArticulo()
        {
            txtCodigo.Text = "";
            txt_Codigo.Text = "";
            txt_CodigoBarra.Text = "";
            txt_Nombre.SelectedIndex = -1;
            txtCantidad.Text = "";
            txt_Stock.Text = "";
            txtPrecio.Text = "";
            txtEfectivo.Text = "";
            txtTarjeta.Text = "";
            txtPorEfe.Text = "";
            txtPorTar.Text = "";
        }

        private void LimpiarGrilla()
        {
            tbCompra.Clear();
            Grilla.DataSource = tbCompra;
            Indice = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarArticulo();
            LimpiarGrilla();
        }

        private void BuscarCompra(Int32 CodCompra)
        {
            cDetalleCompra det = new cDetalleCompra();
            DataTable trdo = det.GetDetallexId(CodCompra);
            string Val = "";
            // string Col = "CodArticulo;Nombre;Cantidad;Precio;Descuento;Subtotal";
           if (trdo.Rows.Count >0)
            {      

                string CodArt = trdo.Rows[0]["CodArticulo"].ToString();
                string Nombre = trdo.Rows[0]["Nombre"].ToString();
                string Cantidad = trdo.Rows[0]["Cantidad"].ToString();
                string Precio = trdo.Rows[0]["Costo"].ToString();
                string Descuento = trdo.Rows[0]["Descuento"].ToString();
                string Subtotal = trdo.Rows[0]["Subtotal"].ToString();

                Val = CodArt + ";" + Nombre;
                Val = Val + ";" + Cantidad.ToString();
                Val = Val + ";" + Precio.ToString();
                Val = Val + ";" + Descuento.ToString();
                Val = Val + ";" + Subtotal.ToString();
                tbCompra = fun.AgregarFilas(tbCompra, Val);
                Grilla.DataSource = tbCompra;
                CalcularTotal();
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {  /*
            if (PuedeAgregar == false)
            {
                PuedeAgregar = true;
                return;
            }
            */
            if (txtCantidad.Text =="")
            {
                return;
            }
          
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtPrecio.Text != "")
                {
                    Double Costo = Convert.ToDouble(txtPrecio.Text);
                    CalcularPrecioTarjetaEfectivo(Costo);
                }
                //Agregar();
                txtPrecio.Focus();
            }
                
        }

        private void LlenarComboArticulo()
        {
            cFunciones fun = new cFunciones();
            cArticulo art = new cArticulo();
            cJuguete jug = new cJuguete();
            DataTable trdo = art.GetTodosArticulos();
           
            txt_Nombre.DataSource = trdo;
            txt_Nombre.ValueMember = "CodArticulo";
            txt_Nombre.DisplayMember = "Nombre";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow r in trdo.Rows)
            {
                coleccion.Add(r["Nombre"].ToString());
            }
            txt_Nombre.AutoCompleteCustomSource = coleccion;
            txt_Nombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_Nombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt_Nombre.SelectedIndex = -1;

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtPrecio.Text != "")
                {
                    Double Costo = Convert.ToDouble(txtPrecio.Text);
                    CalcularPrecioTarjetaEfectivo(Costo);
                }
                //  Agregar();
                txtPorEfe.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txt_Nombre_RightToLeftChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_Nombre_SelectedValueChanged(object sender, EventArgs e)
        {
            int b = 0;
            if (txt_Nombre.SelectedIndex > 0)
            {
                Int32 CodArt = Convert.ToInt32(txt_Nombre.SelectedValue);
                cArticulo art = new Clases.cArticulo();
                DataTable trdo = art.GetArticuloxCodArt(CodArt);
                if (trdo.Rows.Count > 0)
                    if (trdo.Rows[0]["CodArticulo"].ToString() != "")
                    {
                        b = 1;
                        txtCodigo.Text = trdo.Rows[0]["CodArticulo"].ToString();
                        txt_Nombre.SelectedValue = txtCodigo.Text;
                        txt_CodigoBarra.Text = trdo.Rows[0]["CodigoBarra"].ToString();
                        txt_Codigo.Text = trdo.Rows[0]["Codigo"].ToString();
                        txt_Stock.Text = trdo.Rows[0]["Stock"].ToString();
                    }
                if (b == 1)
                {
                    PuedeAgregar = false;
                    txtCantidad.Text = "";
                    txtCantidad.Focus();
                }
            }
        }

        private void btnAbmJuguete_Click(object sender, EventArgs e)
        {
            if (chkLibreria.Checked==true)
            {
                FrmAbmArticulocs form = new FrmAbmArticulocs();
                form.FormClosing += new FormClosingEventHandler(form_FormClosing);
                form.ShowDialog();
            }
            else
            {
                FrmAbmJuguete  form = new FrmAbmJuguete();
                form.FormClosing += new FormClosingEventHandler(form_FormClosing);
                form.ShowDialog();
            }
            
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            LlenarComboArticulo();
            if (Principal.CampoIdSecundarioGenerado != "")
            {
                Clases.cFunciones fun = new Clases.cFunciones();
                switch (Principal.NombreTablaSecundario)
                {
                    case "Proveedor":
                        fun.LlenarCombo(cmbProveedor , "Proveedor", "Nombre", "CodProveedor");
                        cmbProveedor.SelectedValue = Principal.CampoIdSecundarioGenerado;
                        break;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txt_Nombre.SelectedIndex = -1;
        }

        private void chkLibreria_Click(object sender, EventArgs e)
        {
            if (chkLibreria.Checked==true)
            {
                txtNombreJuguete.Visible = false;
                txt_Nombre.Visible = true;
                CargarPorcentajesLibreria();
            }
            else
            {
                txtNombreJuguete.Visible = true ;
                txt_Nombre.Visible = false ;
                CargarPorcentajesJuguetes();
            }
        }

        private void BuscarCompraCompleta(Int32 CodCompra)
        {
            cDetalleCompra compra = new cDetalleCompra();
            DataTable trdo = compra.GetDetalleCompleto(CodCompra);
            trdo = fun.TablaaMiles(trdo, "SubTotal");
            trdo = fun.TablaaMiles(trdo, "Costo");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;55;15;15;15");
            double Total = fun.TotalizarColumna(trdo, "Subtotal");
            txtTotal.Text = Total.ToString();
            btnCancelar.Visible = false;
            btnGrabar.Visible = false;
        }

        private void btnNuevoProveedor_Click(object sender, EventArgs e)
        {
            Principal.CampoIdSecundario = "CodProveedor";
            Principal.CampoNombreSecundario = "Nombre";
            Principal.NombreTablaSecundario = "Proveedor";
            Principal.CampoIdSecundarioGenerado = "";
            FrmAltaBasica form = new FrmAltaBasica();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void Grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_Codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txt_CodigoBarra.Focus();
            }
        }

        private void txt_CodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txt_Nombre.Focus();
            }
            if (e.KeyChar == Convert.ToChar (Keys.Subtract))
            {
                txt_CodigoBarra.Text = "";
            }
        }

        private void txtPorEfe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPorTar.Focus();
                if (txtPrecio.Text != "")
                {
                    Double Costo = Convert.ToDouble(txtPrecio.Text);
                    CalcularPrecioTarjetaEfectivo(Costo);
                }
            }
        }

        private void txtPorTar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (txtPrecio.Text != "")
                {
                    Double Costo = Convert.ToDouble(txtPrecio.Text);
                    CalcularPrecioTarjetaEfectivo(Costo);
                }
                Agregar();
            }
        }

        private void txtPorGlobalEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPorGlobalTarjeta.Focus();
                if (txtPrecio.Text != "")
                {
                    Double Costo = Convert.ToDouble(txtPrecio.Text);
                    CalcularPrecioTarjetaEfectivo(Costo);
                }
            }
        }

        private void txtPorGlobalTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtCantidad.Focus();
                if (txtPrecio.Text != "")
                {
                    Double Costo = Convert.ToDouble(txtPrecio.Text);
                    Costo = Math.Round(Costo, 0);
                    CalcularPrecioTarjetaEfectivo(Costo);
                }
            }
        }
    }
}
