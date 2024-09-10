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
    public partial class frmAgregarOEditarAutor : Form
    {
        public string identificador = "";

        public frmAgregarOEditarAutor()
        {
            InitializeComponent();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            csAutores autor = new csAutores();
            string bit = "";
            frmAutores frm = Owner as frmAutores;
            csConexionDataBase dataBase = new csConexionDataBase();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(txtDescripcion.Text) || cbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios. Por favor, complete los campos vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir si algún campo está vacío
            }
            if (cbEstado.SelectedItem == cbEstado.Items[0]) { bit = "1"; } else { bit = "0"; }
            if (frm.validacion1)
            {
                try
                {
                    string idAutor = csReutilizacion.GenerarId(txtDescripcion.Text);
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd");
                    autor.GuardarAutor(idAutor, txtDescripcion.Text, bit, fecha);
                    frm.validacion1 = false;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Editar autor existente
            else if (frm.validacion2)
            {
                autor.EditarAutor(txtDescripcion.Text, bit, identificador);
                frm.validacion2 = false;
            }

            // Limpiar campos y actualizar DataGridView
            txtDescripcion.Clear();
            cbEstado.SelectedIndex = -1;
            frm.dgvAutores.Rows.Clear();
            autor.Mostrar(frm.dgvAutores);
            this.Close();
        }

        private void lbCerrar_Click(object sender, EventArgs e)
        {
            frmAutores frm = Owner as frmAutores;
            frm.validacion1 = false;
            frm.validacion2 = false;
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            cbEstado.Enabled = true;
            btnGuardar.Enabled = true;
        }

        private void frmAgregarOEditarAutor_Load(object sender, EventArgs e)
        {
            frmAutores frm = Owner as frmAutores;
            if (frm.validacion2) { btnGuardar.Enabled = false; }
            identificador = new csConexionDataBase().Extraer("Select * From AUTOR where Autor = '" + txtDescripcion.Text.Trim() + "'", "IdAutor");
        }
    }
}
