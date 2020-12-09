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
    public partial class FrmActualizarPrecioJuguete : FormBase 
    {
        public FrmActualizarPrecioJuguete()
        {
            InitializeComponent();
        }

        private void FrmActualizarPrecioJuguete_Load(object sender, EventArgs e)
        {   
            cMarca marca = new Clases.cMarca();
            DataTable tb = marca.GetAll();
            this.Lista.DataSource = tb;
            this.Lista.DisplayMember = "Nombre";
            this.Lista.ValueMember = "CodMarca";

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            for (int i=0;i< Lista.Items.Count;i++)
            {
                Lista.SetItemChecked(i,true);
            }
        }

        private void btnNinguno_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Lista.Items.Count; i++)
            {
                Lista.SetItemChecked(i, false);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        { /*
            for (int i = 0; i < Lista.Items.Count; i++)
            {
                Boolean op = Lista.GetSelected(i);
                if (op == true)
                {
                    string msj = Lista.Items[i].ToString(); 
                    
                }
            }
            */
            if (txtPorcentaje.Text =="")
            {
                Mensaje("Debe ingresar un porcentaje");
                return;
            }
            int b = 0;
            int Por = Convert.ToInt32(txtPorcentaje.Text);
            Int32 CodMarca = 0;
            cJuguete jug = new cJuguete();
            foreach (var item in Lista.CheckedItems)
            {
                DataRowView dataRowView = item as DataRowView; //Suponiendo que estás utilizando un DataTable haces un cast pues item es de tipo object
                string id = Convert.ToString(dataRowView["CodMarca"]);
                CodMarca = Convert.ToInt32(id);
                jug.ActualizarPrecioxMarca(CodMarca, Por);
                b = 1;
                //estados += id;
            }
            if (b == 1)
                Mensaje("Datos grabados correctamente");
            else
                Mensaje("Debe seleccionar algun registro para continuar");

           // Verificar();
        }

        private void Verificar()
        {  
            if (Lista.CheckedItems.Count != 0)
            {
                string ficherosSeleccionados = "";
                //recorremos todos los elementos activados
                //CheckedItems sólo devuelve los elementos activados/chequeados
                for (int i = 0; i <= Lista.CheckedItems.Count - 1; i++)
                {
                    if (ficherosSeleccionados != "")
                    {
                        ficherosSeleccionados =
                             ficherosSeleccionados +
                             Environment.NewLine +
                            // Lista.CheckedItems[i].ToString();
                            Lista.Items[i].ToString();
                    }
                    else
                    {
                        ficherosSeleccionados =
                             Lista.CheckedItems[i].ToString();
                    }
                }
                Mensaje(ficherosSeleccionados);
            }
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            cFunciones fun = new Clases.cFunciones();
            fun.SoloNumerosEnteros(e);
        }
    }
}
