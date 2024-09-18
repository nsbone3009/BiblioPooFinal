using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nueva_Biblioteca
{
    public partial class frmAgregarOEditarLibro : Form
    {
        private static csLibro claseLibro = new csLibro();

        public frmAgregarOEditarLibro()
        {
            InitializeComponent();
        }

        private void lbCerrar_Click(object sender, EventArgs e)
        {
            frmLibros frm = frmLibros.Formulario();
            frm.bandera = false;
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            claseLibro.HabilitarCampos(this, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtTitulo.Text != "" & txtAutor.Text != "" & cbCategoria.Text != "" & cbEditorial.Text != "" & txtUbicacion.Text != "" & txtStock.Text != "" & cbEstado.Text != "")
            {
                if (int.Parse(txtStock.Text) > 0)
                {
                    frmLibros frm = frmLibros.Formulario();
                    if (frm.bandera)
                    {
                        if (claseLibro.RegistrarLibro(txtTitulo.Text, txtAutor.Text, cbCategoria.SelectedItem.ToString(), cbEditorial.SelectedItem.ToString(), txtUbicacion.Text, txtStock.Text, cbEstado.SelectedItem.ToString(), ImgLibro))
                        {
                            MessageBox.Show("El libro ha sido agregado exitosamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frm.bandera = false;
                            this.Close();
                        }
                        else {MessageBox.Show("Ocurrió un error al intentar agregar el libro. Por favor, inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}
                    }
                    else
                    {
                        if (claseLibro.ActualizarLibro(txtTitulo.Text, txtAutor.Text, cbCategoria.SelectedItem.ToString(), cbEditorial.SelectedItem.ToString(), txtUbicacion.Text, txtStock.Text, cbEstado.SelectedItem.ToString(), ImgLibro))
                        {
                            MessageBox.Show("El libro se ha actualizado correctamente.", "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else {
                            MessageBox.Show("Se produjo un error al intentar actualizar el libro. Por favor, verifique los datos e inténtelo nuevamente.", "Error de actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);}
                    }
                    claseLibro.MostrarLibros(frm.dgvLibros);
                }
                else {
                    MessageBox.Show("El stock que desea agregar debe ser al menos 1. Por favor, ingrese un valor válido.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
            }
            else {
                MessageBox.Show("Por favor, complete todos los campos. No se permiten campos vacíos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
        }

        private void btnAutor_Click(object sender, EventArgs e)
        {
            frmSeleccionAutor frm = new  frmSeleccionAutor();
            this.AddOwnedForm(frm);
            frm.ShowDialog();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Imagen = new OpenFileDialog();
            Imagen.Filter = "archivos de imagen (*png;)|*png;";
            if (Imagen.ShowDialog() == DialogResult.OK)
            {
                ImgLibro.BackgroundImage = null;
                ImgLibro.Image = Image.FromFile(Imagen.FileName);
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnLimpiarAutores_Click(object sender, EventArgs e)
        {
            txtAutor.Clear();
        }
    }
}
