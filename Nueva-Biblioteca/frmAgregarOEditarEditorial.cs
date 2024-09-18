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
        static csReutilizacion clasecodigo = new csReutilizacion(); 
        public string identificador = "";

        public frmAgregarOEditarEditorial()
        {
            InitializeComponent();
        }

        private void lbCerrar_Click(object sender, EventArgs e)
        {
            frmEditorial frm = Owner as frmEditorial;
            frm.bandera = false;
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

            if (frm.bandera)
            {
                try
                {
                    string x = clasecodigo.GenerarCodigo("SELECT MAX(IdEditorial) AS codigo FROM EDITORIAL", "codigo");
                    editorial.GuardarEditorial(x, txtDescripcion.Text, bit, DateTime.Now.ToString("dd-MM-yyyy"));
                    frm.bandera = false;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                editorial.EditarEditorial(txtDescripcion.Text, bit, identificador);
            }

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
