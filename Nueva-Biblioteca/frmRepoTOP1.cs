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
    public partial class frmRepoTOP1 : Form
    {
        public frmRepoTOP1()
        {
            InitializeComponent();
        }

        private void frmRepoTOP1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSbiblioteca.Top1' Puede moverla o quitarla según sea necesario.
            this.top1TableAdapter.Fill(this.dSbiblioteca.Top1);

            this.reportViewer1.RefreshReport();
        }
    }
}
