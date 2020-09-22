using CodesGenerator2.Comunes;
using CodesGenerator2.Proyectos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodesGenerator2.Ventanas
{
    public partial class FrmConfConexionBD : Form
    {
        public FrmConfConexionBD()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if(!ConectarCargarComboBasesDatos())
                {
                    MessageBox.Show("No se logro conectar a la instancia");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ConectarCargarComboBasesDatos()
        {
            bool booOk = false;

            try
            {
                if (txtUsuario.Text.Trim().Length > 0 &&
                txtInstancia.Text.Trim().Length > 0 &&
                txtContrasena.Text.Trim().Length > 0)
                {
                    lstBasesDatos.Items.Clear();
                    /*FrmPrincipal.oConexion.Usuario = txtUsuario.Text.Trim();
                    FrmPrincipal.oConexion.Clave = txtContrasena.Text.Trim();
                    FrmPrincipal.oConexion.Servidor = txtInstancia.Text.Trim();*/

                    string strSql = "SELECT name FROM sys.databases;";
                    string strCadenaConexion = "Data Source=" + txtInstancia.Text.Trim() + ";User ID=" + txtUsuario.Text.Trim() + ";Password=" + txtContrasena.Text.Trim() + ";Initial Catalog=master";
                    SqlConnection sqlConexion = new SqlConnection(strCadenaConexion);

                    sqlConexion.Open();
                    SqlCommand Comando = new SqlCommand(strSql, sqlConexion);
                    SqlDataReader Reader = Comando.ExecuteReader();

                    if (Reader.HasRows)
                    {
                        while (Reader.Read())
                        {
                            lstBasesDatos.Items.Add(Reader["name"].ToString());
                        }
                    }

                    booOk = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return booOk;
        }

        private void FrmConfConexionBD_Load(object sender, EventArgs e)
        {
            try
            {
                if(FrmPrincipal.PathProyectos.Length > 0 && FrmPrincipal.ProyectoActivoId != Guid.Empty)
                {
                    
                    ManejadorConfiguracionConexionBD mgrConfiguracionBD = new ManejadorConfiguracionConexionBD();
                    mgrConfiguracionBD.PathProyectos = FrmPrincipal.PathProyectos;
                    mgrConfiguracionBD.ProyectoId = FrmPrincipal.ProyectoActivoId;

                    ConfiguracionConexionBD oConfConexion = mgrConfiguracionBD.Get();

                    if (oConfConexion != null)
                    {
                        txtInstancia.Text = oConfConexion.Instancia;
                        txtUsuario.Text = oConfConexion.Usuario;
                        txtContrasena.Text = oConfConexion.Contrasena;
                        txtBaseDatos.Text = oConfConexion.BaseDatos;
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

        private void lstBasesDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstBasesDatos.SelectedIndex >= 0)
            {
                txtBaseDatos.Text = lstBasesDatos.SelectedItem.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInstancia.Text.Trim().Length > 0 &&
                    txtUsuario.Text.Trim().Length > 0 &&
                    txtContrasena.Text.Trim().Length > 0 &&
                    txtBaseDatos.Text.Trim().Length > 0)
                {
                    ManejadorConfiguracionConexionBD mgrConfigConexion = new ManejadorConfiguracionConexionBD();
                    mgrConfigConexion.PathProyectos = FrmPrincipal.PathProyectos;
                    mgrConfigConexion.ProyectoId = FrmPrincipal.ProyectoActivoId;

                    if(mgrConfigConexion.Guardar(txtInstancia.Text.Trim(), txtUsuario.Text.Trim(), txtContrasena.Text.Trim(), txtBaseDatos.Text))
                    {
                        MessageBox.Show("Los datos de configuración se guardaron correctamente");
                    }
                    else
                    {
                        MessageBox.Show("No se pudieron guardar los datos - " + mgrConfigConexion.MensajeError);
                    }
                }
                else
                {
                    MessageBox.Show("Debe llenar todos los datos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
