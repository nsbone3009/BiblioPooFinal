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
        static csReporte claseReporte = new csReporte();
        static private frmReportes instancia = null;
        public static frmReportes Formulario()
        {
            if (instancia == null) { instancia = new frmReportes(); }
            return instancia;
        }
        public frmReportes()
        {
            InitializeComponent();
        }
        private void OcultarBarraBusqueda()
        {
            lbBuscarLector.Visible = false;
            txtBuscarLector.Visible = false;
            btnBuscarLector.Visible = false;
        }
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
            }
        }
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            switch (cbReporte.SelectedIndex)
            {
                case 0:
                    string sentencia1 = "SELECT L.Nombres + ' ' + L.Apellidos AS Nombre, LB.Titulo, E.Editorial, G.Genero " +
                         "FROM PRESTAMO AS p INNER JOIN " +
                         "LECTOR AS L ON p.IdLector = L.IdLector INNER JOIN " +
                         "LIBRO AS LB ON p.IdLibro = LB.IdLibro INNER JOIN " +
                         "EDITORIAL AS E ON LB.IdEditorial = E.IdEditorial INNER JOIN " +
                         "GENERO AS G ON G.IdGenero = LB.IdGenero " +
                         $"WHERE(L.Nombres = '{txtBuscarLector.Text}')";
                    claseReporte.GenerarReporte(rptReporte, sentencia1, "informeLectores.rdlc", "dtsLectores");
                    this.rptReporte.RefreshReport();
                    break;
            }
        }
        private void btnBuscarLector_Click(object sender, EventArgs e)
        {
            frmSeleccionLectores frm = new frmSeleccionLectores();
            frm.repo = true;
            this.AddOwnedForm(frm);
            frm.ShowDialog();
        }
    }
}
