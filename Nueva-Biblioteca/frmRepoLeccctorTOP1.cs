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
    public partial class frmRepoLeccctorTOP1 : Form
    {
        public frmRepoLeccctorTOP1()
        {
            InitializeComponent();
        }

        private void frmRepoLeccctorTOP1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSbiblioteca.LectorFrecuente' Puede moverla o quitarla según sea necesario.
            this.lectorFrecuenteTableAdapter.Fill(this.dSbiblioteca.LectorFrecuente);

            this.reportViewer1.RefreshReport();
        }
    }
}
