using CodesGenerator2.Comunes;
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

namespace CodesGenerator2.Ventanas
{
    public partial class FrmParametrizacion : Form
    {
        public FrmParametrizacion()
        {
            InitializeComponent();
        }

        private void btnDialogPathProyectos_Click(object sender, EventArgs e)
        {
            try
            {
                fbdPathProyectos.ShowDialog();

                if(fbdPathProyectos.SelectedPath.Length > 0)
                {
                    txtPathProyectos.Text = fbdPathProyectos.SelectedPath;
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

        private void FrmParametrizacion_Load(object sender, EventArgs e)
        {
            try
            {
                if(!CargarDatosParametrizacion())
                {
                    MessageBox.Show("No se pudieron cargar los datos de parametrización");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CargarDatosParametrizacion()
        {
            bool booOk = false;

            try
            {
                string strDirectorio = System.AppDomain.CurrentDomain.BaseDirectory;

                if (ManejadorIO.Existe(strDirectorio, "Parametrizacion.json"))
                {
                    string strPathParametrizacion = strDirectorio + "/" + "Parametrizacion.json";
                    using (StreamReader jsonStream = File.OpenText(strPathParametrizacion))
                    {
                        var json = jsonStream.ReadToEnd();
                        Parametrizacion oParametrizacion = JsonConvert.DeserializeObject<Parametrizacion>(json);

                        if (oParametrizacion != null)
                        {
                            if (oParametrizacion.PathProyectos.Length > 0)
                            {
                                txtPathProyectos.Text = oParametrizacion.PathProyectos;
                                txtDirectorioLog.Text = oParametrizacion.DirectorioLog;
                                txtArchivoLog.Text = oParametrizacion.ArchivoLog;

                                booOk = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return booOk;
        }

        private void btnGuadar_Click(object sender, EventArgs e)
        {
            try
            {
                if(GuardarDatosParametrizacion())
                {
                    MessageBox.Show("Los datos se guardaron correctamente");
                }
                else
                {
                    MessageBox.Show("Los datos no se pudieron guardar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool GuardarDatosParametrizacion()
        {
            bool booOk = false;

            try
            {
                if (txtPathProyectos.Text.Trim().Length > 0)
                {
                    Parametrizacion oParametrizacion = new Parametrizacion();
                    oParametrizacion.PathProyectos = txtPathProyectos.Text.Trim();
                    string cadenaJson = JsonConvert.SerializeObject(oParametrizacion);

                    string strDirectorio = System.AppDomain.CurrentDomain.BaseDirectory;
                    string strPathParametrizacion = strDirectorio + "/" + "Parametrizacion.json";

                    System.IO.File.WriteAllText(strPathParametrizacion, cadenaJson);

                    booOk = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return booOk;
        }
    }
}
