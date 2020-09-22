using CodesGenerator2.Comunes;
using CodesGenerator2.Proyectos;
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

namespace CodesGenerator2.Ventanas
{
    public partial class FrmProyectoNuevo : Form
    {
        public FrmProyectoNuevo()
        {
            InitializeComponent();
        }

        private void FrmProyectoNuevo_Load(object sender, EventArgs e)
        {
            CargarComboTecnologias();
        }

        private void CargarComboTecnologias()
        {
            try
            {
                ManagerTecnologia mgrTecnologia = new ManagerTecnologia();
                ComboItem oItem = new ComboItem(ManagerTecnologia._ID_NET_CSHARP_ESCRITORIO, mgrTecnologia.ListaTecnologias[ManagerTecnologia._ID_NET_CSHARP_ESCRITORIO].Nombre);
                cmbTecnologia.Items.Add(oItem);
                oItem = new ComboItem(ManagerTecnologia._ID_NET_CSHARP_WEB, mgrTecnologia.ListaTecnologias[ManagerTecnologia._ID_NET_CSHARP_WEB].Nombre);
                cmbTecnologia.Items.Add(oItem);
                oItem = new ComboItem(ManagerTecnologia._ID_PHP, mgrTecnologia.ListaTecnologias[ManagerTecnologia._ID_PHP].Nombre);
                cmbTecnologia.Items.Add(oItem);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtNombre.Text.Trim().Length > 0 &&
                    txtDescripcion.Text.Trim().Length > 0 &&
                    cmbTecnologia.SelectedIndex >= 0)
                {
                    Guid gId = Guid.NewGuid();
                    ManejadorProyectos mgrProyectos = new ManejadorProyectos();
                    ManejadorProyectos.PathProyectos = FrmPrincipal.PathProyectos;

                    Guid gTecnologiaId = ((ComboItem)cmbTecnologia.SelectedItem).Id;

                    if(mgrProyectos.Guardar(gId, txtNombre.Text.Trim(), txtDescripcion.Text.Trim(), gTecnologiaId))
                    {
                        FrmPrincipal frmDueno = (FrmPrincipal)Owner;

                        frmDueno.CargarComboProyectos(gId);

                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo crear correctamente el proyecto");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese todos los datos necesarios");
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
    }
}
