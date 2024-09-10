using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nueva_Biblioteca
{
    public partial class frmAgregarOEditarEditorial : Form
    {
        public string identificador = "";

        public frmAgregarOEditarEditorial()
        {
            InitializeComponent();
        }

        private void lbCerrar_Click(object sender, EventArgs e)
        {
            frmEditorial frm = Owner as frmEditorial;
            frm.validacion1 = false;
            frm.validacion2 = false;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string bit = "";
            frmEditorial frm = Owner as frmEditorial;
            csEditorial editorial = new csEditorial();
            csConexionDataBase dataBase = new csConexionDataBase();

            if (string.IsNullOrEmpty(txtDescripcion.Text) || cbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios. Por favor, complete los campos vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (cbEstado.SelectedItem == cbEstado.Items[0]) { bit = "1"; } else { bit = "0"; }

            if (frm.validacion1)
            {
                try
                {
                    string idEditorial = csReutilizacion.GenerarId(txtDescripcion.Text);
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd");
                    editorial.GuardarEditorial(idEditorial, txtDescripcion.Text, bit, fecha);
                    frm.validacion1 = false;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (frm.validacion2)
            {
                editorial.EditarEditorial(txtDescripcion.Text, bit, identificador);
                frm.validacion2 = false;
            }

            // Limpiar campos y actualizar DataGridView
            txtDescripcion.Clear();
            cbEstado.SelectedIndex = -1;
            frm.dgvEditorial.Rows.Clear();
            editorial.Mostrar(frm.dgvEditorial);
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            cbEstado.Enabled = true;
            btnGuardar.Enabled = true;
        }

        private void frmAgregarOEditarEditorial_Load(object sender, EventArgs e)
        {
            frmEditorial frm = Owner as frmEditorial;
            if (frm.validacion2) { btnGuardar.Enabled = false; }
            identificador = new csConexionDataBase().Extraer("Select * From EDITORIAL where Editorial = '" + txtDescripcion.Text.Trim() + "'", "IdEditorial");
        }
    }
}
