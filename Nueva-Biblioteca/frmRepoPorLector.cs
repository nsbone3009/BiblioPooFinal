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
    public partial class frmRepoPorLector : Form
    {
        public frmRepoPorLector()
        {
            InitializeComponent();
        }
        public void generarReporte(string nombre)
        {
            this.prestamoPorLectorTableAdapter.Fill(this.dSbiblioteca.PrestamoPorLector, nombre);

            // Actualiza el ReportViewer después de llenar los datos
            this.reportViewer1.RefreshReport();
        }

        private void frmRepoPorLector_Load(object sender, EventArgs e)
        {
        }
    }
}
