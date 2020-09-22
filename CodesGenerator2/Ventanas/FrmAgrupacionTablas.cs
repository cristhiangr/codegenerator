using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace CodesGenerator2.Ventanas
{
    public partial class FrmAgrupacionTablas : Form
    {
        public FrmAgrupacionTablas()
        {
            InitializeComponent();
        }

        private void FrmAgrupacionTablas_Load(object sender, EventArgs e)
        {
            CargarListaTablas();
        }

        private bool CargarListaTablas()
        {
            bool booOk = false;

            try
            {
                if (FrmPrincipal.HayProyectoCargado && FrmPrincipal.ProyectoActivoId != Guid.Empty &&
                    FrmPrincipal.PathProyectos != string.Empty && FrmPrincipal.oConexion != null)
                {
                    string strSql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";

                    Respuesta oRespuesta = FrmPrincipal.oConexion._EjecutarSelect(strSql);

                    if (oRespuesta.Success)
                    {
                        if (FrmPrincipal.oConexion.Reader.HasRows)
                        {
                            while (FrmPrincipal.oConexion.Reader.Read())
                            {
                                string strTablaNombre = FrmPrincipal.oConexion.Reader["TABLE_NAME"].ToString();

                                bool booGuardada = false;

                                if (FrmPrincipal.ListaTablasGuardadas.Contains(strTablaNombre))
                                {
                                    booGuardada = true;

                                    lsbTablas.Items.Add(strTablaNombre);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al consultar tablas - " + oRespuesta.Message);
                    }

                    FrmPrincipal.oConexion.CerrarConexion();
                }
                else
                {
                    MessageBox.Show("No se ha inicializado correctamente el proyecto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return booOk;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtNombre.Text)
                {

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
