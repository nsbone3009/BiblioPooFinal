using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Nueva_Biblioteca
{
    public partial class frmAgregarOEditarGenero : Form
    {
        public string identificador = "";

        public frmAgregarOEditarGenero()
        {
            InitializeComponent();
        }

        private void frmAgregarOEditarCategoria_Load(object sender, EventArgs e)
        {
            frmGenero frm = Owner as frmGenero;
            if (frm.validacion2) { btnGuardar.Enabled = false; }
            identificador = new csConexionDataBase().Extraer("Select * From GENERO where Genero = '" + txtDescripcion.Text.Trim() + "'", "IdGenero");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            cbEstado.Enabled = true;
            btnGuardar.Enabled = true;
        }

        private void lbCerrar_Click(object sender, EventArgs e)
        {
            frmGenero frm = Owner as frmGenero;
            frm.validacion1 = false;
            frm.validacion2 = false;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string bit = "";
            frmGenero frm = Owner as frmGenero;
            csGenero genero = new csGenero();
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
                    string idGenero = csReutilizacion.GenerarId(txtDescripcion.Text);
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd");
                    genero.GuardarGnero(idGenero, txtDescripcion.Text, bit, fecha);
                    frm.validacion1 = false;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Editar género existente
            else if (frm.validacion2)
            {
                genero.EditarGenero(txtDescripcion.Text, bit, identificador);
                frm.validacion2 = false;
            }

            // Limpiar campos y actualizar DataGridView
            txtDescripcion.Clear();
            cbEstado.SelectedIndex = -1;
            frm.dgvCategorias.Rows.Clear();
            genero.Mostrar(frm.dgvCategorias);
            this.Close();
        }
    }
}
