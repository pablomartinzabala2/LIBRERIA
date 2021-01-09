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
            this.chkIncluyeTodos = new System.Windows.Forms.CheckBox();
            this.txtPorTar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.txtPorEfe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.txtPorcentajeCosto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.txtPorcentajeCosto);
            this.Grupo.Controls.Add(this.label4);
            this.Grupo.Controls.Add(this.chkIncluyeTodos);
            this.Grupo.Controls.Add(this.txtPorTar);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.btnAplicar);
            this.Grupo.Controls.Add(this.txtPorEfe);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Controls.Add(this.txtArticulo);
            this.Grupo.Controls.Add(this.btnBuscar);
            this.Grupo.Controls.Add(this.lblFecha);
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.Grilla);
            this.Grupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Grupo.Location = new System.Drawing.Point(12, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(1046, 543);
            this.Grupo.TabIndex = 22;
            this.Grupo.TabStop = false;
            // 
            // chkIncluyeTodos
            // 
            this.chkIncluyeTodos.AutoSize = true;
            this.chkIncluyeTodos.Location = new System.Drawing.Point(340, 46);
            this.chkIncluyeTodos.Name = "chkIncluyeTodos";
            this.chkIncluyeTodos.Size = new System.Drawing.Size(95, 21);
            this.chkIncluyeTodos.TabIndex = 74;
            this.chkIncluyeTodos.Text = "checkBox1";
            this.chkIncluyeTodos.UseVisualStyleBackColor = true;
            // 
            // txtPorTar
            // 
            this.txtPorTar.Location = new System.Drawing.Point(264, 47);
            this.txtPorTar.Name = "txtPorTar";
            this.txtPorTar.Size = new System.Drawing.Size(70, 23);
            this.txtPorTar.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 72;
            this.label2.Text = "Porce Tarjeta";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(662, 13);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 71;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // txtPorEfe
            // 
            this.txtPorEfe.Location = new System.Drawing.Point(88, 45);
            this.txtPorEfe.Name = "txtPorEfe";
            this.txtPorEfe.Size = new System.Drawing.Size(70, 23);
            this.txtPorEfe.TabIndex = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 69;
            this.label1.Text = "Porc Efectivo";
            // 
            // txtArticulo
            // 
            this.txtArticulo.Location = new System.Drawing.Point(114, 11);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(242, 23);
            this.txtArticulo.TabIndex = 68;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(362, 8);
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
            this.label3.Location = new System.Drawing.Point(0, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1019, 25);
            this.label3.TabIndex = 59;
            this.label3.Text = "Listado de articulos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(0, 114);
            this.Grilla.Name = "Grilla";
            this.Grilla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.Grilla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(1019, 413);
            this.Grilla.TabIndex = 0;
            // 
            // txtPorcentajeCosto
            // 
            this.txtPorcentajeCosto.Location = new System.Drawing.Point(586, 11);
            this.txtPorcentajeCosto.Name = "txtPorcentajeCosto";
            this.txtPorcentajeCosto.Size = new System.Drawing.Size(70, 23);
            this.txtPorcentajeCosto.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 17);
            this.label4.TabIndex = 75;
            this.label4.Text = "Ingresar Porcentaje Costo";
            // 
            // FrmActualizarLibreria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 567);
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
        private System.Windows.Forms.TextBox txtPorEfe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPorTar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkIncluyeTodos;
        private System.Windows.Forms.TextBox txtPorcentajeCosto;
        private System.Windows.Forms.Label label4;
    }
}