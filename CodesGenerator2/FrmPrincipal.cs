using CodesGenerator2.Comunes;
using CodesGenerator2.Proyectos;
using CodesGenerator2.Ventanas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace CodesGenerator2
{
    public partial class FrmPrincipal : Form
    {
        public static string PathProyectos = "";
        public static string DirectorioLog = "";
        public static string ArchivoLog = "";

        public static Guid ProyectoActivoId = Guid.Empty;
        public static int indexProyectoActivo = -1;
        public static bool HayProyectoCargado = false;
        public static string ProyectoActivoNombre = "";
        public static Guid ProyectoActivoTipoId = Guid.Empty;

        public static ConexionBD oConexion = new ConexionBD();

        public static List<string> ListaTablasGuardadas = new List<string>();

        public FrmPrincipal()
        {
            InitializeComponent();

            PathProyectos = string.Empty;
        }

        private void tsmProyectoParametrizacion_Click(object sender, EventArgs e)
        {
            FrmParametrizacion ventana = new FrmParametrizacion();
            ventana.ShowDialog();
        }

        private void tsmProyectoNuevo_Click(object sender, EventArgs e)
        {
            FrmProyectoNuevo ventana = new FrmProyectoNuevo();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                ManagerParametrizacion mgrParametrizacion = new ManagerParametrizacion();
                ManagerParametrizacion.PathAplicacion = System.AppDomain.CurrentDomain.BaseDirectory;
                Parametrizacion oParametrizacion = mgrParametrizacion.GetParametrizacion();

                if(oParametrizacion != null)
                {
                    PathProyectos = oParametrizacion.PathProyectos;
                    DirectorioLog = oParametrizacion.DirectorioLog;
                    ArchivoLog = oParametrizacion.ArchivoLog;

                    Logger.LogDirectory = DirectorioLog;
                    Logger.LogFile = ArchivoLog;

                    CargarComboProyectos(Guid.Empty);
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar los datos de parametrización");
                    Application.Exit();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public bool CargarComboProyectos(Guid gIdSeleccionado)
        {
            bool booOk = false;

            try
            {
                tscProyectos.Items.Clear();

                ManejadorProyectos.PathProyectos = PathProyectos;
                ManejadorProyectos mgrProyectos = new ManejadorProyectos();
                List<Proyecto> ListaProyectos = mgrProyectos.GetProyectos();

                if(ListaProyectos.Count > 0)
                {
                    int iPos = 0;

                    foreach(Proyecto oProyecto in ListaProyectos)
                    {
                        Guid gId = new Guid(oProyecto.ProyectoId);
                        ComboItem oItem = new ComboItem(gId, oProyecto.Nombre);
                        tscProyectos.Items.Add(oItem);

                        if(gIdSeleccionado != null && gIdSeleccionado!= Guid.Empty && gIdSeleccionado == gId)
                        {
                            ProyectoActivoId = gId;
                            indexProyectoActivo = iPos;
                            HayProyectoCargado = true;
                            ProyectoActivoNombre = oProyecto.Nombre;
                            ProyectoActivoTipoId = new Guid(oProyecto.TecnologiaId);

                            ManagerTecnologia mgrTecnologia = new ManagerTecnologia();
                            tstMensaje.Text = ProyectoActivoNombre + "(" + mgrTecnologia.ListaTecnologias[ProyectoActivoTipoId].Nombre + ")";
                        }

                        iPos++;
                    }

                    if(indexProyectoActivo >= 0)
                    {
                        tscProyectos.SelectedIndex = indexProyectoActivo;
                        tsmConfiguracion.Enabled = true;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return booOk;
        }

        private void tscProyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LimpiarDatos();

                if (tscProyectos.SelectedIndex >= 0)
                {
                    indexProyectoActivo = tscProyectos.SelectedIndex;
                    ProyectoActivoId = ((ComboItem)tscProyectos.SelectedItem).Id;
                    HayProyectoCargado = true;

                    ManejadorProyectos mgrProyectos = new ManejadorProyectos();
                    Proyecto oProyecto = mgrProyectos.Get(ProyectoActivoId);

                    if (oProyecto != null)
                    {
                        ProyectoActivoNombre = oProyecto.Nombre;
                        ProyectoActivoTipoId = new Guid(oProyecto.TecnologiaId);

                        ManagerTecnologia mgrTecnologia = new ManagerTecnologia();
                        tstMensaje.Text = ProyectoActivoNombre + " (" + mgrTecnologia.ListaTecnologias[ProyectoActivoTipoId].Nombre + ")";

                        if(CargarDatosConexionBD())
                        {
                            CargarTablasGuardadas();
                        }

                        tsmConfiguracion.Enabled = true;

                    }
                }
                else
                {
                    indexProyectoActivo = tscProyectos.SelectedIndex;
                    ProyectoActivoId = Guid.Empty;
                    HayProyectoCargado = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void tscProyectos_Click(object sender, EventArgs e)
        {

        }

        private void tsmConfiguracionConexionBD_Click(object sender, EventArgs e)
        {
            FrmConfConexionBD ventana = new FrmConfConexionBD();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void LimpiarDatos()
        {
            try
            {
                ProyectoActivoId = Guid.Empty;
                indexProyectoActivo = -1;
                HayProyectoCargado = false;
                ProyectoActivoNombre = "";
                ProyectoActivoTipoId = Guid.Empty;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CargarDatosConexionBD()
        {
            bool booOk = false;

            try
            {
                if(PathProyectos != string.Empty && ProyectoActivoId != Guid.Empty)
                {
                    ManejadorConfiguracionConexionBD mgrConfiguracionBD = new ManejadorConfiguracionConexionBD();
                    mgrConfiguracionBD.PathProyectos = PathProyectos;
                    mgrConfiguracionBD.ProyectoId = ProyectoActivoId;

                    ConfiguracionConexionBD oConfConexion = mgrConfiguracionBD.Get();

                    if(oConfConexion != null)
                    {
                        oConexion.Servidor = oConfConexion.Instancia;
                        oConexion.Usuario = oConfConexion.Usuario;
                        oConexion.Clave = oConfConexion.Contrasena;
                        oConexion.BaseDatos = oConfConexion.BaseDatos;

                        booOk = true;
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

            return booOk;
        }

        private void tsConfiguracionTablas_Click(object sender, EventArgs e)
        {
            FrmTablas ventana = new FrmTablas();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        public bool CargarTablasGuardadas()
        {
            bool booOk = false;

            try
            {
                if (PathProyectos.Length > 0 && ProyectoActivoId != Guid.Empty)
                {

                    ManejadorConfiguracionTablas mgrConfiguracion = new ManejadorConfiguracionTablas();
                    mgrConfiguracion.PathProyectos = PathProyectos;
                    mgrConfiguracion.ProyectoId = ProyectoActivoId;

                    ConfiguracionTablas oConf = mgrConfiguracion.Get();

                    if (oConf != null && oConf.Tablas.Count > 0)
                    {
                        ListaTablasGuardadas = oConf.Tablas;
                    }

                    booOk = true;
                }
                else
                {
                    MessageBox.Show("No hay pathproyectos ni proyectoActivoId");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema al cargar las tablas guardadas - " + ex.Message);
            }

            return booOk;
        }

        private void tsmAgrupacionDeTablas_Click(object sender, EventArgs e)
        {
            FrmAgrupacionTablas ventana = new FrmAgrupacionTablas();
            ventana.Owner = this;
            ventana.ShowDialog();
        }
    }
}
