namespace SistemaFact
{
    partial class FrmActualizarLibreria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmActualizarLibreria));
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPorcentaje = new System.Windows.Forms.TextBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.btnAplicar);
            this.Grupo.Controls.Add(this.txtPorcentaje);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Controls.Add(this.txtArticulo);
            this.Grupo.Controls.Add(this.btnBuscar);
            this.Grupo.Controls.Add(this.lblFecha);
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.Grilla);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(12, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(858, 543);
            this.Grupo.TabIndex = 22;
            this.Grupo.TabStop = false;
            // 
            // txtArticulo
            // 
            this.txtArticulo.Location = new System.Drawing.Point(114, 11);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(299, 23);
            this.txtArticulo.TabIndex = 68;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(419, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(40, 28);
            this.btnBuscar.TabIndex = 67;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(-3, 16);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(111, 17);
            this.lblFecha.TabIndex = 65;
            this.lblFecha.Text = "Ingresar Articulo";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.MediumPurple;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(842, 25);
            this.label3.TabIndex = 59;
            this.label3.Text = "Listado de articulos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(0, 67);
            this.Grilla.Name = "Grilla";
            this.Grilla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.Grilla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(842, 456);
            this.Grilla.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(465, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 17);
            this.label1.TabIndex = 69;
            this.label1.Text = "Incrementar Porcentaje";
            // 
            // txtPorcentaje
            // 
            this.txtPorcentaje.Location = new System.Drawing.Point(626, 10);
            this.txtPorcentaje.Name = "txtPorcentaje";
            this.txtPorcentaje.Size = new System.Drawing.Size(70, 23);
            this.txtPorcentaje.TabIndex = 70;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(702, 8);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 71;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // FrmActualizarLibreria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 519);
            this.Controls.Add(this.Grupo);
            this.Name = "FrmActualizarLibreria";
            this.Text = "FrmActualizarLibreria";
            this.Load += new System.EventHandler(this.FrmActualizarLibreria_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.TextBox txtPorcentaje;
        private System.Windows.Forms.Label label1;
    }
}