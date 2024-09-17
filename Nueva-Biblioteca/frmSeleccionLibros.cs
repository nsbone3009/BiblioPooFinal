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
    public partial class frmSeleccionLibros : Form
    {
        csConexionDataBase dataBase = new csConexionDataBase();
        DataTable Contenedor = new DataTable();
        public frmSeleccionLibros()
        {
            InitializeComponent();
        }

        private void lbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSeleccionLibros_Load(object sender, EventArgs e)
        {

        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvLibros.Columns[dgvLibros.ColumnCount - 1].Index && e.RowIndex >= 0)
            {
                frmPrestamoRegistrar frm = Owner as frmPrestamoRegistrar;
                frm.idlibro = dgvLibros.Rows[e.RowIndex].Cells[0].Value.ToString();
                frm.txtLibro.Text = dgvLibros.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.Close();
            }
        }
    }
}
