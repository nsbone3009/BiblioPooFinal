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
        private void Calendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime Fecha = Calendario.SelectionStart;
            DateTime fecha = DateTime.Parse(Fecha.ToShortDateString());
            if (fecha>DateTime.Now)
            {
                txtFechaDevolucion.Text = fecha.ToString("yyyy-MM-dd");
                Calendario.Visible = false;
            }
            else
            {
                MessageBox.Show("Por favor seleccione una fecha valida no se puede realizar prestamos a fechas posteriores a la actual");
            }
            
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
                        MessageBox.Show("Porfavor ingrese todos los datos");
                    }
                }
                else 
                {
                    if (txtEstadoLibro.Text!=string.Empty)
                    {
                        try
                        {
                            string idprestamo = csReutilizacion.GenerarId("PRE");
                            string idlector = txtCodigo.Text;
                            prestamos.RegistrarPrestamo(idprestamo, idlector, idlibro, txtFechaDevolucion.Text, DateTime.Now.ToString("yyyy-MM-dd"),txtEstadoLibro.Text);
                            MessageBox.Show($"El libro {txtLibro.Text} se ha prestado a {txtNombre.Text} de forma correcta");
                            prestamos.enviarcorreo(txtNombre.Text, txtLibro.Text, txtFechaDevolucion.Text, correo);
                            btnRegistrar.Location = new Point(370, 373);
                            btnCancelar.Location = new Point(521, 373);
                            lblDeta.Visible = false;
                            txtEstadoLibro.Visible = false;
                            btnRegistrar.Text = "Continuar";
                            clear();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al registrar el prestamo : " +ex.Message);
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de error: "+ex);
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
    }
}
