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
        static csReutilizacion claseCodigo = new csReutilizacion();
        static csGenero claseGenero = new csGenero();
        public frmAgregarOEditarGenero()
        {
            InitializeComponent();
        }
        private void frmAgregarOEditarCategoria_Load(object sender, EventArgs e)
        {
            
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
            frm.bandera = false;
            this.Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string bit = "";
            frmGenero frm = Owner as frmGenero;
            csConexionDataBase dataBase = new csConexionDataBase();
            if (string.IsNullOrEmpty(txtDescripcion.Text) || cbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios. Por favor, complete los campos vacíos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbEstado.SelectedItem == cbEstado.Items[0]) { bit = "1"; } else { bit = "0"; }
            if (frm.bandera)
            {
                try
                {
                    string x = claseCodigo.GenerarCodigo("SELECT MAX(IdGenero) AS codigo FROM GENERO", "codigo");
                    claseGenero.GuardarGnero(x, txtDescripcion.Text, bit, DateTime.Now.ToString("dd-MM-yyyy"));
                    frm.bandera = false;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                claseGenero.EditarGenero(txtDescripcion.Text, bit);
            }

            txtDescripcion.Clear();
            cbEstado.SelectedIndex = -1;
            frm.dgvCategorias.Rows.Clear();
            claseGenero.Mostrar(frm.dgvCategorias);
            this.Close();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) 
            {
                e.Handled = true;
            }
        }
    }
}
