namespace CodesGenerator2.Ventanas
{
    partial class FrmAgrupacionTablas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lsbTablas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvTablas = new System.Windows.Forms.DataGridView();
            this.Agrupacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tablas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablas)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.lsbTablas);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 199);
            this.panel1.TabIndex = 0;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(314, 88);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(278, 57);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lsbTablas
            // 
            this.lsbTablas.FormattingEnabled = true;
            this.lsbTablas.Location = new System.Drawing.Point(3, 3);
            this.lsbTablas.Name = "lsbTablas";
            this.lsbTablas.Size = new System.Drawing.Size(302, 186);
            this.lsbTablas.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(311, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre Agrupación";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(314, 49);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(278, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvTablas);
            this.panel2.Location = new System.Drawing.Point(12, 217);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(609, 221);
            this.panel2.TabIndex = 1;
            // 
            // dgvTablas
            // 
            this.dgvTablas.AllowUserToAddRows = false;
            this.dgvTablas.AllowUserToDeleteRows = false;
            this.dgvTablas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTablas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Agrupacion,
            this.Tablas});
            this.dgvTablas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTablas.Location = new System.Drawing.Point(0, 0);
            this.dgvTablas.Name = "dgvTablas";
            this.dgvTablas.ReadOnly = true;
            this.dgvTablas.Size = new System.Drawing.Size(607, 219);
            this.dgvTablas.TabIndex = 0;
            // 
            // Agrupacion
            // 
            this.Agrupacion.HeaderText = "Agrupacion";
            this.Agrupacion.Name = "Agrupacion";
            this.Agrupacion.ReadOnly = true;
            this.Agrupacion.Width = 150;
            // 
            // Tablas
            // 
            this.Tablas.HeaderText = "Tablas";
            this.Tablas.Name = "Tablas";
            this.Tablas.ReadOnly = true;
            this.Tablas.Width = 400;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnCerrar);
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Location = new System.Drawing.Point(627, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(161, 426);
            this.panel3.TabIndex = 2;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(3, 88);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(153, 79);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(3, 3);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(153, 79);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // FrmAgrupacionTablas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAgrupacionTablas";
            this.Text = "Agrupación de Tablas";
            this.Load += new System.EventHandler(this.FrmAgrupacionTablas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTablas)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ListBox lsbTablas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dgvTablas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Agrupacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tablas;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnGuardar;
    }
}