namespace SistemaFact
{
    partial class FrmListadoArticulo
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
            this.Grupo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Grilla = new System.Windows.Forms.DataGridView();
            this.Grupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).BeginInit();
            this.SuspendLayout();
            // 
            // Grupo
            // 
            this.Grupo.Controls.Add(this.label3);
            this.Grupo.Controls.Add(this.textBox1);
            this.Grupo.Controls.Add(this.label2);
            this.Grupo.Controls.Add(this.txtDescripcion);
            this.Grupo.Controls.Add(this.label1);
            this.Grupo.Controls.Add(this.Grilla);
            this.Grupo.Location = new System.Drawing.Point(12, 12);
            this.Grupo.Name = "Grupo";
            this.Grupo.Size = new System.Drawing.Size(838, 464);
            this.Grupo.TabIndex = 20;
            this.Grupo.TabStop = false;
            this.Grupo.Enter += new System.EventHandler(this.Grupo_Enter);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.MediumPurple;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(826, 25);
            this.label3.TabIndex = 59;
            this.label3.Text = "Listado de Artículos";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(335, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Codigo Barra";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(80, 19);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(175, 20);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descripción";
            // 
            // Grilla
            // 
            this.Grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grilla.Location = new System.Drawing.Point(6, 70);
            this.Grilla.Name = "Grilla";
            this.Grilla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.Grilla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.Grilla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Grilla.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.Grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grilla.Size = new System.Drawing.Size(826, 360);
            this.Grilla.TabIndex = 0;
            this.Grilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grilla_CellContentClick);
            // 
            // FrmListadoArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 488);
            this.Controls.Add(this.Grupo);
            this.Name = "FrmListadoArticulo";
            this.Text = "Listado de artículos";
            this.Load += new System.EventHandler(this.FrmListadoArticulo_Load);
            this.Grupo.ResumeLayout(false);
            this.Grupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grupo;
        private System.Windows.Forms.DataGridView Grilla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label3;
    }
}