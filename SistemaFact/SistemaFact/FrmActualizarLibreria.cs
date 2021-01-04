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
            DataTable trdo = art.GetArticulo(Nombre, "", "");
            Grilla.DataSource = trdo;
            string Ancho = "0;0;0;40;15;15;15;15";
            fun.AnchoColumnas(Grilla, Ancho);
        }

        private void FrmActualizarLibreria_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (txtPorcentaje.Text.Trim () =="")
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
            string msj = "Confirma aplicar el  " + txtPorcentaje.Text;
            msj = msj + " a los siguientes " + Can.ToString() + " Articulos ";
            var result = MessageBox.Show(msj, "Información",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                return;
            }
            Double Por = Convert.ToDouble(txtPorcentaje.Text);
            Int32 CodArticulo = 0;
            cArticulo art = new cArticulo();
            for (int i=0;i< Grilla.Rows.Count -1;i++)
            {
                CodArticulo = Convert.ToInt32(Grilla.Rows[i].Cells[0].Value.ToString());
                art.ActualizarPrecio(CodArticulo, Por);
            }
            Mensaje("Datos grabados correctamente");
            Buscar();
        }
    }
}
