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
    public partial class frmGenero : Form
    {
        public bool validacion1 = false, validacion2 = false;
        private csLLenarDataGridView buscar = new csLLenarDataGridView();
        private csReutilizacion verificar = new csReutilizacion();
        static private frmGenero instancia = null;
        static csGenero clase = new csGenero();

        public static frmGenero Formulario()
        {
            if (instancia == null) { instancia = new frmGenero(); }
            return instancia;
        }

        public frmGenero()
        {
            InitializeComponent();
        }

        private void frmCategoria_Load(object sender, EventArgs e)  
        {
            clase.Mostrar(dgvCategorias);
        }

       

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAgregarOEditarGenero frm = new frmAgregarOEditarGenero();
            this.AddOwnedForm(frm);

            if (e.ColumnIndex == dgvCategorias.Columns[dgvCategorias.ColumnCount - 1].Index && e.RowIndex >= 0)
            {
                validacion2 = true;
                frm.identificador = dgvCategorias.Rows[e.RowIndex].Cells[0].Value.ToString();
                frm.txtDescripcion.Text = dgvCategorias.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvCategorias.Rows[e.RowIndex].Cells[2].Value.ToString() == "Activo") { frm.cbEstado.SelectedItem = frm.cbEstado.Items[0]; }
                else { frm.cbEstado.SelectedItem = frm.cbEstado.Items[1]; }
                frm.txtDescripcion.Enabled = false;
                frm.cbEstado.Enabled = false;
                frm.ShowDialog();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 0)
            {
                string estadoTraducido = verificar.VerificarEstado(txtBuscar.Text);
                string consulta = "SELECT IdGenero, Genero, Estado " +
                                  "FROM GENERO " +
                                  "WHERE IdGenero LIKE '%" + txtBuscar.Text + "%' " +
                                  "OR Genero LIKE '%" + txtBuscar.Text + "%' " +
                                  "OR Estado LIKE '%" + estadoTraducido + "%'";

                dgvCategorias.Rows.Clear();
                buscar.Mostrar(dgvCategorias, consulta);
            }
            else if (txtBuscar.Text.Length == 0)
            {
                dgvCategorias.Rows.Clear();
                clase.Mostrar(dgvCategorias);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            validacion1 = true;
            frmAgregarOEditarGenero frm = new frmAgregarOEditarGenero();
            this.AddOwnedForm(frm);
            frm.btnEditar.Visible = false;
            frm.ShowDialog();
        }
    }
}
