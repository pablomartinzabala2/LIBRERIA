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
    public partial class FrmListadoPresupuesto : FormBase
    {
        cFunciones fun;
        public FrmListadoPresupuesto()
        {
            InitializeComponent();
        }

        private void FrmListadoPresupuesto_Load(object sender, EventArgs e)
        {
            fun = new cFunciones();
            DateTime Fecha = DateTime.Now;
            txtFechaHasta.Text = Fecha.ToShortDateString();
            Fecha = Fecha.AddMonths(-1);
            txtFechaDesde.Text = Fecha.ToShortDateString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            cPresupuesto prep = new cPresupuesto();
            DateTime FechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime FechaHasta = Convert.ToDateTime(txtFechaHasta.Text);
            DataTable trdo = prep.GetPresupuesto(FechaDesde, FechaHasta);
            trdo = fun.TablaaMiles(trdo, "Total");
            Grilla.DataSource = trdo;
            fun.AnchoColumnas(Grilla, "0;15;35;35;15");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Grilla.CurrentRow ==null)
            {
                Mensaje("Debe seleccionar un registro");
                return;
            }
            else
            {
                Principal.CodigodePresupuesto = Convert.ToInt32(Grilla.CurrentRow.Cells[0].Value.ToString());
                FrmVenta frm = new FrmVenta();
                frm.Show();
                this.Close();
            }
        }
    }
}
