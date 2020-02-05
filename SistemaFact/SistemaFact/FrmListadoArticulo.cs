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
    public partial class FrmListadoArticulo : FormBase
    {
        public FrmListadoArticulo()
        {
            InitializeComponent();
        }

        private void FrmListadoArticulo_Load(object sender, EventArgs e)
        {
            CargarGrilla("", "", "");
        }

        private void CargarGrilla(string Nombre,string CodigoBarra,string Codigo)
        {
            cArticulo art = new Clases.cArticulo();
            DataTable trdo = art.GetDetalleArticulo(Nombre,CodigoBarra,Codigo );
            Grilla.DataSource = trdo;
            Grilla.Columns[0].Visible = false;
            Grilla.Columns[3].Width = 310;
            Grilla.Columns[6].HeaderText = "Tarjeta";
            Grilla.Columns[8].HeaderText = "Efectivo/Deb";
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            string nombre = txtDescripcion.Text;
            CargarGrilla(nombre, "", "");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Grupo_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Codigo = textBox1.Text;
            if (Codigo.Length >4)
            {
                CargarGrilla("", Codigo, "");
            } 
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            CargarGrilla("", "", txtCodigo.Text);
        }
    }
}
