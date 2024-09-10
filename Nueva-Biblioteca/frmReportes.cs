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
    public partial class frmReportes : Form
    {
        private Form activeForm = null;
        frmRepoPorLector lec = new frmRepoPorLector();
        static private frmReportes instancia = null;
        public static frmReportes Formulario()
        {
            if (instancia == null) { instancia = new frmReportes(); }
            return instancia;
        }
        public frmReportes()
        {
            InitializeComponent();
            txtBuscarLector.TextChanged += txtBuscarLector_TextChanged;


        }
        private void MostrarFormularioHijo(object hijo)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            if (this.pnlReportes.Controls.Count > 0)
            {
                this.pnlReportes.Controls.RemoveAt(0);
            }
            Form fh = hijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pnlReportes.Controls.Add(fh);
            this.pnlReportes.Tag = fh;
            fh.Show();
        }
        private void frmReportes_Load(object sender, EventArgs e)
        {
        }
        private void ocultar()
        {
            lbBuscarLector.Visible = false;
            txtBuscarLector.Visible = false;
            btnBuscarLector.Visible = false;
        }

        csConexionDataBase con =new csConexionDataBase();


        private void cbReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbReporte.SelectedItem.ToString())
            {
                case "Prestamos por lector":
                    btnGenerar.Enabled = true;
                    lbBuscarLector.Visible = true;
                    txtBuscarLector.Visible = true;
                    btnBuscarLector.Visible = true;
                    btnGenerar.Enabled = true;
                    btnLimpiarRepo.Enabled = true;
                    break;
                case "Libro con mayor numero de prestamos":
                    btnGenerar.Enabled= true;
                    btnLimpiarRepo.Enabled = true;
                    ocultar();
                    break;
                case "Lector mas frecuente":
                    btnGenerar.Enabled = true;
                    btnLimpiarRepo.Enabled = true;
                    ocultar();
                    break;
                case "Top 5 Libros mas prestados":
                    btnGenerar.Enabled = true;
                    btnLimpiarRepo.Enabled = true;
                    ocultar();
                    break;
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbReporte.Text!=string.Empty)
                {
                    pnlReportes.Visible=true;
                    if (cbReporte.SelectedItem.ToString()== "Libro con mayor numero de prestamos")
                    {
                        MostrarFormularioHijo(new frmRepoTOP1());
                    }
                    else if (cbReporte.SelectedItem.ToString() == "Prestamos por lector")
                    {
                        if (!string.IsNullOrEmpty(txtBuscarLector.Text))
                        {
                            frmRepoPorLector reporteForm = new frmRepoPorLector();
                            reporteForm.generarReporte(txtBuscarLector.Text);
                            MostrarFormularioHijo(reporteForm);
                        }
                        else
                        {
                            MessageBox.Show("Por favor, ingrese el nombre del lector.");
                        }
                    }
                    else if (cbReporte.SelectedItem.ToString() == "Top 5 Libros mas prestados")
                    {
                        MostrarFormularioHijo(new frmRepoTOP5());
                    }
                    else if (cbReporte.SelectedItem.ToString() == "Lector mas frecuente" )
                    {
                        MostrarFormularioHijo(new frmRepoLeccctorTOP1());
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccion el tipo de reporte que desea generar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: "+ ex);
            }
        }
        public void clear()
        {
            cbReporte.Text=string.Empty;
            txtBuscarLector.Text=string.Empty;
            ocultar();
            pnlReportes.Visible= false;
            btnGenerar.Enabled = false;
            btnLimpiarRepo.Enabled = false;
        }

        private void btnLimpiarRepo_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnBuscarLector_Click(object sender, EventArgs e)
        {
            frmSeleccionLectores frm = new frmSeleccionLectores();
            frm.repo = true;
            this.AddOwnedForm(frm);
            frm.ShowDialog();
        }

        private void txtBuscarLector_TextChanged(object sender, EventArgs e)
        {
        }

    }
}
