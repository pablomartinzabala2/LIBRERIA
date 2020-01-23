using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFact
{
    public partial class Principal : Form
    {
        private int childFormNumber = 0;
        //nombre del campo id
        public static string CampoIdSecundario;
        //nombre del campo descripcion
        public static string CampoNombreSecundario;
        //nombre de la tabla donde se realiza el grabado
        public static string NombreTablaSecundario;
        public static string NombreLabelSecundario;
        //valor del id que genera al insertar
        public static string CampoIdSecundarioGenerado;
        public static Int32 CodUsuarioLogueado;
        public static string NombreUsuarioLogueado;
        public static string CodigoPrincipalAbm;
        public static string CodigoSenia;
        
        public static string OpcionesdeBusqueda;
        public static string TablaPrincipal;
        public static string OpcionesColumnasGrilla;
        public static string ColumnasVisibles;
        public static string ColumnasAncho;
        public static string Comodin;
        public Principal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            FrmAbmArticulocs childForm = new FrmAbmArticulocs();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            FrmAbmTipoPrenda childForm = new FrmAbmTipoPrenda();
            childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfigurarImpresora childForm = new FrmConfigurarImpresora();
            childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void printSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmColor  childForm = new FrmColor();
            childForm.MdiParent = this;
            //childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            FrmListadoArticulo frm = new FrmListadoArticulo();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
