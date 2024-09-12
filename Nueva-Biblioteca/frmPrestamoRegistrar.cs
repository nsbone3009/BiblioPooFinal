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
    public partial class frmPrestamoRegistrar : Form
    {
        csPrestamos prestamos=new csPrestamos();
        public string idlibro;
        public string correo="sanchezvera243@gmail.com";
        public frmPrestamoRegistrar()
        {
            InitializeComponent();
        }
        private void btnBuscarLector_Click(object sender, EventArgs e)
        {
            frmSeleccionLectores frm = new frmSeleccionLectores();
            this.AddOwnedForm(frm);
            frm.ShowDialog();
        }
        private void btnBuscarPrestamo_Click(object sender, EventArgs e)
        {
            frmSeleccionLibros frm = new frmSeleccionLibros();
            this.AddOwnedForm(frm);
            frm.ShowDialog();
        }
        private void frmPrestamoRegistrar_Load(object sender, EventArgs e)
        {
            Calendario.Visible = false;
        }
        private void btnCalendario_Click(object sender, EventArgs e)
        {
            Calendario.Visible = true;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado=MessageBox.Show("¿Esta seguro que desea cancelar?","Cancelar prestamo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                clear();
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRegistrar.Text == "Continuar")
                {
                    if (txtCodigo.Text != string.Empty && txtFechaDevolucion.Text != string.Empty && txtLibro.Text != string.Empty && txtNombre.Text != string.Empty)
                    {
                        btnRegistrar.Location = new Point(370, 505);
                        btnCancelar.Location = new Point(521, 505);
                        lblDeta.Visible = true;
                        txtEstadoLibro.Visible = true;
                        btnRegistrar.Text = "Registrar";
                    }
                    else
                    {
                        MessageBox.Show("Por favor, ingrese todos los datos requeridos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (txtEstadoLibro.Text != string.Empty)
                    {
                        try
                        {
                            string idprestamo = csReutilizacion.GenerarId("PRE");
                            string idlector = txtCodigo.Text;

                            // Intentar registrar el préstamo
                            bool exito = prestamos.RegistrarPrestamo(idprestamo, idlector, idlibro, txtFechaDevolucion.Text, DateTime.Now.ToString("yyyy-MM-dd"), txtEstadoLibro.Text);

                            // Mostrar el mensaje de éxito solo si el préstamo se registró correctamente
                            if (exito)
                            {
                                MessageBox.Show($"El libro \"{txtLibro.Text}\" ha sido prestado correctamente a {txtNombre.Text}.", "Préstamo exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                prestamos.enviarcorreo(txtNombre.Text, txtLibro.Text, txtFechaDevolucion.Text, correo);

                                // Restablecer el formulario
                                btnRegistrar.Location = new Point(370, 373);
                                btnCancelar.Location = new Point(521, 373);
                                lblDeta.Visible = false;
                                txtEstadoLibro.Visible = false;
                                btnRegistrar.Text = "Continuar";
                                clear();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al registrar el préstamo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mensaje de error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clear()
        {
            txtCodigo.Text ="";
            txtEstadoLibro.Text = "";
            txtFechaDevolucion.Text = "";
            txtLibro.Text = "";
            txtNombre.Text = "";
        }
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            btnCancelar.Enabled= !string.IsNullOrWhiteSpace(txtCodigo.Text);
            btnRegistrar.Enabled= !string.IsNullOrWhiteSpace(txtCodigo.Text);
        }
        private void txtLibro_TextChanged(object sender, EventArgs e)
        {
            btnCancelar.Enabled = !string.IsNullOrWhiteSpace(txtLibro.Text);
            btnRegistrar.Enabled = !string.IsNullOrWhiteSpace(txtLibro.Text);
        }

        private void Calendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = Calendario.SelectionStart;

            if (fechaSeleccionada < DateTime.Now)
            {
                MessageBox.Show("La fecha seleccionada no puede ser anterior a la fecha actual.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Calendario.SetSelectionRange(DateTime.Now, DateTime.Now); // Resaltar la fecha actual
            }
            else if (fechaSeleccionada > DateTime.Now.AddDays(7))
            {
                MessageBox.Show("La fecha seleccionada no puede ser posterior a 7 días a partir de hoy.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Calendario.SetSelectionRange(DateTime.Now, DateTime.Now); // Resaltar la fecha actual
            }
            else
            {
                txtFechaDevolucion.Text = fechaSeleccionada.ToString("yyyy-MM-dd");
            }
        }
    }
}
