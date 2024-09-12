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
            try
            {
                // Validar si algún campo está vacío o nulo
                if (string.IsNullOrEmpty(txtTitulo.Text) || string.IsNullOrEmpty(txtAutor.Text) || cbCategoria.SelectedItem == null || cbEditorial.SelectedItem == null || string.IsNullOrEmpty(txtUbicacion.Text) || string.IsNullOrEmpty(txtStock.Text) || cbEstado.SelectedItem == null || ImgLibro == null)
                {
                    throw new Exception("Todos los campos son obligatorios y no pueden estar vacíos.");
                }
                frmLibros frm = frmLibros.Formulario();
                // Agregar
                if (frm.bandera & int.Parse(txtStock.Text) > 0)
                {
                    if (claseLibro.RegistrarLibro(txtTitulo.Text, txtAutor.Text, cbCategoria.SelectedItem.ToString(),
                                                  cbEditorial.SelectedItem.ToString(), txtUbicacion.Text,
                                                  txtStock.Text, cbEstado.SelectedItem.ToString(), ImgLibro))
                    {
                        claseLibro.MostrarLibros(frm.dgvLibros);
                        MessageBox.Show("LIBRO AGREGADO CORRECTAMENTE.");
                    }
                    else
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL AGREGAR EL LIBRO.");
                    }
                    frm.bandera = false;
                    this.Close();
                }
                // Modificar
                else if(!frm.bandera & int.Parse(txtStock.Text) > 0)
                {
                    if (claseLibro.ActualizarLibro(txtTitulo.Text, txtAutor.Text, cbCategoria.SelectedItem.ToString(),
                                                   cbEditorial.SelectedItem.ToString(), txtUbicacion.Text,
                                                   txtStock.Text, cbEstado.SelectedItem.ToString(), ImgLibro))
                    {
                        claseLibro.MostrarLibros(frm.dgvLibros);
                        MessageBox.Show("LIBRO ACTUALIZADO CORRECTAMENTE.");
                    }
                    else
                    {
                        MessageBox.Show("OCURRIÓ UN ERROR AL ACTUALIZAR EL LIBRO.");
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("EL STOCK A AGREGAR DEBE SER MAYOR A 0");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
