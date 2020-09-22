namespace CodesGenerator2
{
    partial class FrmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.proyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProyectoNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmListado = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProyectoParametrizacion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.tscProyectos = new System.Windows.Forms.ToolStripComboBox();
            this.tsmConfiguracion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmConfiguracionConexionBD = new System.Windows.Forms.ToolStripMenuItem();
            this.tsConfiguracionTablas = new System.Windows.Forms.ToolStripMenuItem();
            this.tstMensaje = new System.Windows.Forms.ToolStripTextBox();
            this.generarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGenerarPersistencia = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGenerarServicio = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgrupacionDeTablas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proyectoToolStripMenuItem,
            this.tscProyectos,
            this.tsmConfiguracion,
            this.tstMensaje,
            this.generarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(933, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // proyectoToolStripMenuItem
            // 
            this.proyectoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmProyectoNuevo,
            this.tsmListado,
            this.tsmProyectoParametrizacion,
            this.tsmSalir});
            this.proyectoToolStripMenuItem.Name = "proyectoToolStripMenuItem";
            this.proyectoToolStripMenuItem.Size = new System.Drawing.Size(66, 23);
            this.proyectoToolStripMenuItem.Text = "Proyecto";
            // 
            // tsmProyectoNuevo
            // 
            this.tsmProyectoNuevo.Name = "tsmProyectoNuevo";
            this.tsmProyectoNuevo.Size = new System.Drawing.Size(159, 22);
            this.tsmProyectoNuevo.Text = "Nuevo";
            this.tsmProyectoNuevo.Click += new System.EventHandler(this.tsmProyectoNuevo_Click);
            // 
            // tsmListado
            // 
            this.tsmListado.Name = "tsmListado";
            this.tsmListado.Size = new System.Drawing.Size(159, 22);
            this.tsmListado.Text = "Listado";
            // 
            // tsmProyectoParametrizacion
            // 
            this.tsmProyectoParametrizacion.Name = "tsmProyectoParametrizacion";
            this.tsmProyectoParametrizacion.Size = new System.Drawing.Size(159, 22);
            this.tsmProyectoParametrizacion.Text = "Parametrizacion";
            this.tsmProyectoParametrizacion.Click += new System.EventHandler(this.tsmProyectoParametrizacion_Click);
            // 
            // tsmSalir
            // 
            this.tsmSalir.Name = "tsmSalir";
            this.tsmSalir.Size = new System.Drawing.Size(159, 22);
            this.tsmSalir.Text = "Salir";
            // 
            // tscProyectos
            // 
            this.tscProyectos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscProyectos.Name = "tscProyectos";
            this.tscProyectos.Size = new System.Drawing.Size(121, 23);
            this.tscProyectos.SelectedIndexChanged += new System.EventHandler(this.tscProyectos_SelectedIndexChanged);
            this.tscProyectos.Click += new System.EventHandler(this.tscProyectos_Click);
            // 
            // tsmConfiguracion
            // 
            this.tsmConfiguracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmConfiguracionConexionBD,
            this.tsConfiguracionTablas,
            this.tsmAgrupacionDeTablas});
            this.tsmConfiguracion.Enabled = false;
            this.tsmConfiguracion.Name = "tsmConfiguracion";
            this.tsmConfiguracion.Size = new System.Drawing.Size(95, 23);
            this.tsmConfiguracion.Text = "Configuración";
            // 
            // tsmConfiguracionConexionBD
            // 
            this.tsmConfiguracionConexionBD.Name = "tsmConfiguracionConexionBD";
            this.tsmConfiguracionConexionBD.Size = new System.Drawing.Size(187, 22);
            this.tsmConfiguracionConexionBD.Text = "Conexion BD";
            this.tsmConfiguracionConexionBD.Click += new System.EventHandler(this.tsmConfiguracionConexionBD_Click);
            // 
            // tsConfiguracionTablas
            // 
            this.tsConfiguracionTablas.Name = "tsConfiguracionTablas";
            this.tsConfiguracionTablas.Size = new System.Drawing.Size(187, 22);
            this.tsConfiguracionTablas.Text = "Tablas";
            this.tsConfiguracionTablas.Click += new System.EventHandler(this.tsConfiguracionTablas_Click);
            // 
            // tstMensaje
            // 
            this.tstMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tstMensaje.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tstMensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.tstMensaje.Name = "tstMensaje";
            this.tstMensaje.ReadOnly = true;
            this.tstMensaje.Size = new System.Drawing.Size(200, 23);
            // 
            // generarToolStripMenuItem
            // 
            this.generarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGenerarPersistencia,
            this.tsmGenerarServicio});
            this.generarToolStripMenuItem.Name = "generarToolStripMenuItem";
            this.generarToolStripMenuItem.Size = new System.Drawing.Size(60, 23);
            this.generarToolStripMenuItem.Text = "Generar";
            // 
            // tsmGenerarPersistencia
            // 
            this.tsmGenerarPersistencia.Name = "tsmGenerarPersistencia";
            this.tsmGenerarPersistencia.Size = new System.Drawing.Size(180, 22);
            this.tsmGenerarPersistencia.Text = "Persistencia";
            // 
            // tsmGenerarServicio
            // 
            this.tsmGenerarServicio.Name = "tsmGenerarServicio";
            this.tsmGenerarServicio.Size = new System.Drawing.Size(180, 22);
            this.tsmGenerarServicio.Text = "Servicio";
            // 
            // tsmAgrupacionDeTablas
            // 
            this.tsmAgrupacionDeTablas.Name = "tsmAgrupacionDeTablas";
            this.tsmAgrupacionDeTablas.Size = new System.Drawing.Size(187, 22);
            this.tsmAgrupacionDeTablas.Text = "Agrupación de Tablas";
            this.tsmAgrupacionDeTablas.Click += new System.EventHandler(this.tsmAgrupacionDeTablas_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "Code Generator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem proyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmProyectoNuevo;
        private System.Windows.Forms.ToolStripMenuItem tsmListado;
        private System.Windows.Forms.ToolStripComboBox tscProyectos;
        private System.Windows.Forms.ToolStripMenuItem tsmProyectoParametrizacion;
        private System.Windows.Forms.ToolStripMenuItem tsmSalir;
        private System.Windows.Forms.ToolStripMenuItem tsmConfiguracion;
        private System.Windows.Forms.ToolStripMenuItem tsmConfiguracionConexionBD;
        private System.Windows.Forms.ToolStripTextBox tstMensaje;
        private System.Windows.Forms.ToolStripMenuItem tsConfiguracionTablas;
        private System.Windows.Forms.ToolStripMenuItem generarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmGenerarPersistencia;
        private System.Windows.Forms.ToolStripMenuItem tsmGenerarServicio;
        private System.Windows.Forms.ToolStripMenuItem tsmAgrupacionDeTablas;
    }
}