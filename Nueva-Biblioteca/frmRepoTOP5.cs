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
    public partial class frmRepoTOP5 : Form
    {
        
        public frmRepoTOP5()
        {
            InitializeComponent();
        }

        private void frmRepoTOP5_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSbiblioteca.Top5' Puede moverla o quitarla según sea necesario.
            this.top5TableAdapter.Fill(this.dSbiblioteca.Top5);

            this.reportViewer1.RefreshReport();
        }
    }
}
