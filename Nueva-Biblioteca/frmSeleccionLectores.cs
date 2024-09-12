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
    public partial class frmSeleccionLectores : Form
    {
        csConexionDataBase cs = new csConexionDataBase();
        public frmSeleccionLectores()
        {
            InitializeComponent();
        }

        private void lbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSeleccionLectores_Load(object sender, EventArgs e)
        {
            dgvLectores = new csLLenarDataGridView().MostrarSeleccion(dgvLectores, "Select IdLector, Nombres, Apellidos, Correo From LECTOR");
        }
        public bool repo = false;
        private void dgvLectores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Boton Seleccionar
            if (e.ColumnIndex == dgvLectores.Columns[dgvLectores.ColumnCount- 1].Index && e.RowIndex >= 0)
            {
                if (repo==true)
                {
                    frmReportes frmR = Owner as frmReportes;
                    frmR.txtBuscarLector.Text = dgvLectores.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.Close();
                }
                else
                {
                    frmPrestamoRegistrar frm = Owner as frmPrestamoRegistrar;

                    frm.txtCodigo.Text = dgvLectores.Rows[e.RowIndex].Cells[0].Value.ToString();
                    frm.txtNombre.Text = dgvLectores.Rows[e.RowIndex].Cells[1].Value.ToString() + " " + dgvLectores.Rows[e.RowIndex].Cells[2].Value.ToString();
                    frm.correo = dgvLectores.Rows[e.RowIndex].Cells[3].Value.ToString();
                    this.Close();
                }
                
            }
        }
        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
           
        }
    }
}
