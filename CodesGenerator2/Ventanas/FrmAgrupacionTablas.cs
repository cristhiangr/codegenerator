using CodesGenerator2.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace CodesGenerator2.Ventanas
{
    public partial class FrmAgrupacionTablas : Form
    {

        private List<string> ListaTablasYaCargadas = new List<string>();

        public FrmAgrupacionTablas()
        {
            InitializeComponent();
        }

        private void FrmAgrupacionTablas_Load(object sender, EventArgs e)
        {
            CargarAgrupacionesTablas();
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

                                    if(!ListaTablasYaCargadas.Contains(strTablaNombre))
                                    {
                                        lsbTablas.Items.Add(strTablaNombre);
                                    }
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

        private void CargarAgrupacionesTablas()
        {
            try
            {
                if (FrmPrincipal.PathProyectos.Length > 0 && FrmPrincipal.ProyectoActivoId != Guid.Empty)
                {

                    ManejadorAgrupacionTablas mgrAgrupacionesTablas = new ManejadorAgrupacionTablas();
                    mgrAgrupacionesTablas.PathProyectos = FrmPrincipal.PathProyectos;
                    mgrAgrupacionesTablas.ProyectoId = FrmPrincipal.ProyectoActivoId;

                    ListaAgrupacionesTablas oListaAgrupaciones = mgrAgrupacionesTablas.Get();

                    if (oListaAgrupaciones != null)
                    {
                        if(oListaAgrupaciones.AgrupacionesTablas.Count > 0)
                        {
                            foreach(AgrupacionTablas oAgrupacion in oListaAgrupaciones.AgrupacionesTablas)
                            {

                                if(oAgrupacion.Tablas.Count > 0)
                                {
                                    string strTablas = "";
                                    bool booPrimero = true;

                                    foreach(string strTabla in oAgrupacion.Tablas)
                                    {

                                        if(!booPrimero)
                                        {
                                            strTablas += ",";
                                        }

                                        strTablas += strTabla;

                                        ListaTablasYaCargadas.Add(strTabla);
                                    }

                                    dgvTablas.Rows.Add(oAgrupacion.NombreGrupo, strTablas);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No hay pathproyectos ni proyectoActivoId");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtNombre.Text.Trim().Length > 0 && lsbTablas.SelectedItems.Count > 0)
                {
                    string strNombreGrupo = txtNombre.Text.Trim();
                    string strCadenaTablas = "";
                    List<object> ListaSeleccionados = new List<object>();

                    bool booPrimero = true;

                    foreach(var itemSeleccionado in lsbTablas.SelectedItems)
                    {
                        if(!booPrimero)
                        {
                            strCadenaTablas += ",";
                        }
                        strCadenaTablas += itemSeleccionado.ToString();
                        ListaSeleccionados.Add(itemSeleccionado);
                        booPrimero = false;
                    }

                    dgvTablas.Rows.Add(strNombreGrupo, strCadenaTablas);

                    foreach (object objSeleccionado in ListaSeleccionados)
                    {
                        lsbTablas.Items.Remove(objSeleccionado);
                    }

                    txtNombre.Text = "";
                }
                else
                {
                    MessageBox.Show("Ingrese todos los datos");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GuardarAgrupaciones();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool GuardarAgrupaciones()
        {
            bool booOk = false;

            try
            {
                if (dgvTablas.Rows.Count > 0)
                {
                    //ListaAgrupacionesTablas listaAgrupaciones = new ListaAgrupacionesTablas();
                    List<AgrupacionTablas> ListaAgrupacionTablas = new List<AgrupacionTablas>();

                    foreach(DataGridViewRow fila in dgvTablas.Rows)
                    {
                        string strNombreGrupo = fila.Cells["Agrupacion"].Value.ToString();
                        string strTablas = fila.Cells["Tablas"].Value.ToString();
                        string[] arrTablas = strTablas.Split(',');

                        AgrupacionTablas oAgrupacionTablas = new AgrupacionTablas();
                        oAgrupacionTablas.NombreGrupo = strNombreGrupo;

                        foreach(string strTabla in arrTablas)
                        {
                            oAgrupacionTablas.Tablas.Add(strTabla);
                        }

                        //listaAgrupaciones.AgrupacionesTablas.Add(oAgrupacionTablas);
                        ListaAgrupacionTablas.Add(oAgrupacionTablas);
                    }

                    ManejadorAgrupacionTablas mgrAgrupacionTablas = new ManejadorAgrupacionTablas();
                    mgrAgrupacionTablas.PathProyectos = FrmPrincipal.PathProyectos;
                    mgrAgrupacionTablas.ProyectoId = FrmPrincipal.ProyectoActivoId;

                    if (mgrAgrupacionTablas.Guardar(ListaAgrupacionTablas))
                    {
                        MessageBox.Show("Los datos de configuración se guardaron correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron guardar los datos - " + mgrAgrupacionTablas.MensajeError);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return booOk;
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvTablas.SelectedRows.Count > 0)
                {
                    List<DataGridViewRow> ListaSeleccionados = new List<DataGridViewRow>();

                    foreach (DataGridViewRow fila in dgvTablas.SelectedRows)
                    {
                        string strTablas = fila.Cells["Tablas"].Value.ToString();
                        string[] arrTablas = strTablas.Split(',');

                        foreach(string strTabla in arrTablas)
                        {
                            lsbTablas.Items.Add(strTabla);
                        }

                        ListaSeleccionados.Add(fila);
                    }

                    foreach(DataGridViewRow filaSeleccionada in ListaSeleccionados)
                    {
                        dgvTablas.Rows.Remove(filaSeleccionada);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}