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
        private static csReutilizacion claseCodigo = new csReutilizacion();
        static csAutores claseAutor = new csAutores();
        static csConexionDataBase dataBase = new csConexionDataBase();
        public frmAgregarOEditarAutor()
        {
            InitializeComponent();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            frmAutores frm = Owner as frmAutores;
            if (txtDescripcion.Text != "" & cbEstado.Text != "")
            {
                if (frm.bandera)
                {
                    try
                    {
                        string x = claseCodigo.GenerarCodigo("SELECT MAX(IdAutor) AS codigo FROM AUTOR", "codigo");
                        claseAutor.RegistrarAutor(x, txtDescripcion.Text, (cbEstado.SelectedItem == cbEstado.Items[0] ? 1 : 0).ToString(), DateTime.Now.ToString("dd-MM-yyyy"));
                        frm.bandera = false;
                        MessageBox.Show("El autor se ha agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch {
                        MessageBox.Show("Se produjo un error al intentar agregar el autor. Por favor, inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}
                }
                else 
                { 
                    claseAutor.ActualizarAutor(txtDescripcion.Text, (cbEstado.SelectedItem == cbEstado.Items[0] ? 1 : 0).ToString());
                    MessageBox.Show("El autor se ha actualizado correctamente.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                claseAutor.Mostrar(frm.dgvAutores);
            }
            else {
                MessageBox.Show("Todos los campos deben estar completos. Por favor, asegúrese de llenar todos los campos requeridos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
        }
        private void lbCerrar_Click(object sender, EventArgs e)
        {
            frmAutores frm = Owner as frmAutores;
            frm.bandera = false;
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
