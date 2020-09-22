using CodesGenerator2.Proyectos;
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
    public partial class FrmTablas : Form
    {

        public FrmTablas()
        {
            InitializeComponent();
        }

        private void FrmTablas_Load(object sender, EventArgs e)
        {
            try
            {
                
                FrmPrincipal vPadre = (FrmPrincipal)this.Owner;
                vPadre.CargarTablasGuardadas();
                
                CargarTablas();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool CargarTablas()
        {
            bool booOk = false;

            try
            {
                if(FrmPrincipal.HayProyectoCargado && FrmPrincipal.ProyectoActivoId != Guid.Empty && 
                    FrmPrincipal.PathProyectos != string.Empty && FrmPrincipal.oConexion != null)
                {
                    string strSql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";

                    Respuesta oRespuesta = FrmPrincipal.oConexion._EjecutarSelect(strSql);

                    if (oRespuesta.Success)
                    {
                        if(FrmPrincipal.oConexion.Reader.HasRows)
                        {
                            while(FrmPrincipal.oConexion.Reader.Read())
                            {
                                string strTablaNombre = FrmPrincipal.oConexion.Reader["TABLE_NAME"].ToString();

                                bool booGuardada = false;

                                if(FrmPrincipal.ListaTablasGuardadas.Contains(strTablaNombre))
                                {
                                    booGuardada = true;
                                }

                                dgvTablas.Rows.Add(strTablaNombre, booGuardada);
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
                FrmPrincipal.oConexion.CerrarConexion();
                MessageBox.Show(ex.Message);
            }

            return booOk;
        }

        

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvTablas.Rows.Count > 0)
                {
                    List<string> ListaTablas = new List<string>();
                    foreach(DataGridViewRow fila in dgvTablas.Rows)
                    {
                        if((bool)fila.Cells["Agregar"].Value)
                        {
                            ListaTablas.Add(fila.Cells["Nombre"].Value.ToString());
                        }
                    }

                    if(ListaTablas.Count > 0)
                    {
                        ManejadorConfiguracionTablas mgrConfTablas = new ManejadorConfiguracionTablas();
                        mgrConfTablas.PathProyectos = FrmPrincipal.PathProyectos;
                        mgrConfTablas.ProyectoId = FrmPrincipal.ProyectoActivoId;

                        if(mgrConfTablas.Guardar(ListaTablas))
                        {
                            MessageBox.Show("Se guardó la configuración correctamente");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar las tablas - " + mgrConfTablas.MensajeError);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ninguna tabla");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}