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
    public partial class frmSeleccionAutor : Form
    {
        public frmSeleccionAutor()
        {
            InitializeComponent();
        }

        private void lbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSeleccionAutor_Load(object sender, EventArgs e)
        {
            new csLLenarDataGridView().Mostrar(dgvAutores, "Select IdAutor, Autor from AUTOR where Estado = 1", 2);
        }

        private void dgvAutores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvAutores.Columns[dgvAutores.ColumnCount - 1].Index && e.RowIndex >= 0)
            {
                frmAgregarOEditarLibro frm = Owner as frmAgregarOEditarLibro;
                if (frm.txtAutor.Text != "")
                    frm.txtAutor.Text += ", " + dgvAutores.Rows[e.RowIndex].Cells[1].Value.ToString();
                else
                    frm.txtAutor.Text += dgvAutores.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.Close();
            }
        }
    }
}
