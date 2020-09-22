namespace CodesGenerator2.Ventanas
{
    partial class FrmParametrizacion
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
            this.btnDialogPathProyectos = new System.Windows.Forms.Button();
            this.txtPathProyectos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuadar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.fbdPathProyectos = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDirectorioLog = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArchivoLog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtArchivoLog);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDirectorioLog);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnDialogPathProyectos);
            this.panel1.Controls.Add(this.txtPathProyectos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 138);
            this.panel1.TabIndex = 0;
            // 
            // btnDialogPathProyectos
            // 
            this.btnDialogPathProyectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDialogPathProyectos.Location = new System.Drawing.Point(451, 10);
            this.btnDialogPathProyectos.Name = "btnDialogPathProyectos";
            this.btnDialogPathProyectos.Size = new System.Drawing.Size(75, 26);
            this.btnDialogPathProyectos.TabIndex = 2;
            this.btnDialogPathProyectos.Text = ". . .";
            this.btnDialogPathProyectos.UseVisualStyleBackColor = true;
            this.btnDialogPathProyectos.Click += new System.EventHandler(this.btnDialogPathProyectos_Click);
            // 
            // txtPathProyectos
            // 
            this.txtPathProyectos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathProyectos.Location = new System.Drawing.Point(155, 10);
            this.txtPathProyectos.Name = "txtPathProyectos";
            this.txtPathProyectos.Size = new System.Drawing.Size(298, 26);
            this.txtPathProyectos.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path Proyectos";
            // 
            // btnGuadar
            // 
            this.btnGuadar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuadar.Location = new System.Drawing.Point(3, 3);
            this.btnGuadar.Name = "btnGuadar";
            this.btnGuadar.Size = new System.Drawing.Size(533, 51);
            this.btnGuadar.TabIndex = 1;
            this.btnGuadar.Text = "Guardar";
            this.btnGuadar.UseVisualStyleBackColor = true;
            this.btnGuadar.Click += new System.EventHandler(this.btnGuadar_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Controls.Add(this.btnGuadar);
            this.panel2.Location = new System.Drawing.Point(12, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(541, 118);
            this.panel2.TabIndex = 2;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(3, 60);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(533, 51);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // txtDirectorioLog
            // 
            this.txtDirectorioLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirectorioLog.Location = new System.Drawing.Point(155, 53);
            this.txtDirectorioLog.Name = "txtDirectorioLog";
            this.txtDirectorioLog.Size = new System.Drawing.Size(371, 26);
            this.txtDirectorioLog.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Directorio Log";
            // 
            // txtArchivoLog
            // 
            this.txtArchivoLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArchivoLog.Location = new System.Drawing.Point(155, 97);
            this.txtArchivoLog.Name = "txtArchivoLog";
            this.txtArchivoLog.Size = new System.Drawing.Size(371, 26);
            this.txtArchivoLog.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Archivo Log";
            // 
            // FrmParametrizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 283);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmParametrizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametrizacion";
            this.Load += new System.EventHandler(this.FrmParametrizacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDialogPathProyectos;
        private System.Windows.Forms.TextBox txtPathProyectos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuadar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.FolderBrowserDialog fbdPathProyectos;
        private System.Windows.Forms.TextBox txtArchivoLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDirectorioLog;
        private System.Windows.Forms.Label label2;
    }
}