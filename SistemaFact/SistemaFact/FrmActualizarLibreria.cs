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
    public partial class FrmActualizarLibreria : FormBase 
    {
        cFunciones fun;
        public FrmActualizarLibreria()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            if (txtArticulo.Text == "")
            {
                Mensaje("Debe ingresar un art{iculo");
                return;
            }
            string Nombre = txtArticulo.Text;
            cArticulo art = new Clases.cArticulo();
            DataTable trdo = art.GetArticuloxNombre(Nombre);
            trdo = fun.TablaaMiles(trdo, "PorEfe");
            trdo = fun.TablaaMiles(trdo, "PorTar");
            trdo = fun.TablaaMiles(trdo, "Costo");
            trdo = fun.TablaaMiles(trdo, "PrecioEfectivo");
            trdo = fun.TablaaMiles(trdo, "PrecioTarjeta");
            Grilla.DataSource = trdo;
            string Ancho = "0;0;0;40;10;10;10;10;10;10";
            fun.AnchoColumnas(Grilla, Ancho);
        }

        private void FrmActualizarLibreria_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            CargarPorcentajes();
            string texto = "Aplicar a todos el " + txtPorEfe.Text;
            texto = texto + " y " + txtPorTar.Text;
            chkIncluyeTodos.Text = texto;
        }

        public void CargarPorcentajes()
        {   
            cPorcentaje obj = new Clases.cPorcentaje();
            DataTable trdo = obj.GetPorcentaje();
            if (trdo.Rows.Count > 0)
            {
                txtPorEfe.Text = trdo.Rows[0]["PorEfeLibreria"].ToString();
                if (txtPorEfe.Text != "")
                {
                    Double Efectivo = Convert.ToDouble(txtPorEfe.Text.Replace(".", ","));
                    txtPorEfe.Text = Math.Round(Efectivo, 0).ToString();
                }
                txtPorTar.Text = trdo.Rows[0]["PorTarLibreria"].ToString();
                if (txtPorTar.Text != "")
                {
                    Double Efectivo = Convert.ToDouble(txtPorTar.Text.Replace(".", ","));
                    txtPorTar.Text = Math.Round(Efectivo, 0).ToString();
                }
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (txtPorcentajeCosto.Text =="")
            {
                Mensaje("Debe ingresar un porcentaje de costo");
                return;
            }
            if (txtPorEfe.Text.Trim () =="")
            {
                Mensaje("Debe ingresar un porcentaje");
                return;
            }
            if (Grilla.Rows.Count <2)
            {
                Mensaje("Debe buscar articulos");
                return;
            }
            int Can = Grilla.Rows.Count - 1;
            string msj = "Confirma aplicar el  " + txtPorEfe.Text;
            msj = msj + " a los siguientes " + Can.ToString() + " Articulos ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }
            int IncluyeTodos = 0;
            if (chkIncluyeTodos.Checked == true)
                IncluyeTodos = 1;

            Double PorCosto = 0;
            Double PorEfe = 0;
            Double PorTar = 0;
            Double Costo = 0;
            Double PrecioEfectivo = 0;
            Double PrecioTarjeta = 0;

            PorEfe = Convert.ToDouble(txtPorEfe.Text);
            PorTar = Convert.ToDouble(txtPorTar.Text);
            PorCosto = Convert.ToDouble(txtPorcentajeCosto.Text);
            Double PorEfeGrilla = 0;
            Double PorTarGrilla = 0;
            Int32 CodArticulo = 0;
            cArticulo art = new cArticulo();
            for (int i=0;i< Grilla.Rows.Count -1;i++)
            {
                CodArticulo = Convert.ToInt32(Grilla.Rows[i].Cells[0].Value.ToString());
                Costo = Convert.ToDouble(Grilla.Rows[i].Cells[5].Value.ToString());
                if (Grilla.Rows[i].Cells[8].Value.ToString ()!="")
                {
                    PorEfeGrilla = Convert.ToDouble(Grilla.Rows[i].Cells[8].Value.ToString());
                }
                else
                {
                    PorEfeGrilla = 0;
                }
                 
                if (Grilla.Rows[i].Cells[9].Value.ToString() != "")
                {
                    PorTarGrilla = Convert.ToDouble(Grilla.Rows[i].Cells[9].Value.ToString());
                }
                else
                {
                    PorTarGrilla = 0;
                }
                Costo = Costo + Costo * PorCosto / 100;
                PrecioEfectivo = Costo + Costo * PorEfe / 100;
                PrecioTarjeta = Costo + Costo * PorTar / 100;
                if (IncluyeTodos ==0)
                {
                    if (PorEfeGrilla > 0)
                    {
                        PrecioEfectivo = Costo + Costo * PorEfeGrilla / 100;
                    }
                }
                if (IncluyeTodos ==0)
                {
                    if (PorTarGrilla > 0)
                    {
                        PrecioTarjeta = Costo + Costo * PorTarGrilla / 100;
                    }
                }
                art.ActualizarMontosArticulos(CodArticulo, Costo, PrecioEfectivo, PrecioTarjeta);
               
            }
            Mensaje("Datos grabados correctamente");
            Buscar();
        }
    }
}
