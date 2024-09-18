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
                            MessageBox.Show("LIBRO AGREGADO CORRECTAMENTE.");
                            frm.bandera = false;
                            this.Close();
                        }
                        else { MessageBox.Show("OCURRIÓ UN ERROR AL AGREGAR EL LIBRO."); }
                    }
                    else
                    {
                        if (claseLibro.ActualizarLibro(txtTitulo.Text, txtAutor.Text, cbCategoria.SelectedItem.ToString(), cbEditorial.SelectedItem.ToString(), txtUbicacion.Text, txtStock.Text, cbEstado.SelectedItem.ToString(), ImgLibro))
                        {
                            MessageBox.Show("LIBRO ACTUALIZADO CORRECTAMENTE.");
                            this.Close();
                        }
                        else { MessageBox.Show("OCURRIÓ UN ERROR AL ACTUALIZAR EL LIBRO."); }
                    }
                    claseLibro.MostrarLibros(frm.dgvLibros);
                }
                else { MessageBox.Show("EL STOCK A AGREGAR DEBE SER DE AL MENOS 1."); }
            }
            else { MessageBox.Show("CAMPOS INVALIDOS, TODO LOS CAMPOS DEBEN ESTAR LLENOS."); }
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
