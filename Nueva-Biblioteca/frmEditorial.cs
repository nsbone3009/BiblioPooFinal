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
    public partial class frmEditorial : Form
    {
        public bool validacion1 = false, validacion2 = false;
        static private frmEditorial instancia = null;
        static csEditorial clase = new csEditorial();
        private csLLenarDataGridView buscar = new csLLenarDataGridView();
        private csReutilizacion verificar = new csReutilizacion();

        public static frmEditorial Formulario()
        {
            if (instancia == null) { instancia = new frmEditorial(); }
            return instancia;
        }

        public frmEditorial()
        {
            InitializeComponent();
        }

        private void frmEditorial_Load(object sender, EventArgs e)
        {
           clase.Mostrar(dgvEditorial);
        }

        

        private void dgvEditorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAgregarOEditarEditorial frm = new frmAgregarOEditarEditorial();
            this.AddOwnedForm(frm);
            if (e.ColumnIndex == dgvEditorial.Columns[dgvEditorial.ColumnCount - 1].Index && e.RowIndex >= 0)
            {
                validacion2 = true;
                frm.identificador = dgvEditorial.Rows[e.RowIndex].Cells[0].Value.ToString();
                frm.txtDescripcion.Text = dgvEditorial.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgvEditorial.Rows[e.RowIndex].Cells[2].Value.ToString() == "Activo") { frm.cbEstado.SelectedItem = frm.cbEstado.Items[0]; }
                else { frm.cbEstado.SelectedItem = frm.cbEstado.Items[1]; }
                frm.txtDescripcion.Enabled = false;
                frm.cbEstado.Enabled = false;
                frm.ShowDialog();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length > 1)
            {
                string estadoTraducido = verificar.VerificarEstado(txtBuscar.Text);
                string consulta = "SELECT IdEditorial, Editorial, Estado " +
                                  "FROM EDITORIAL " +
                                  "WHERE IdEditorial LIKE '%" + txtBuscar.Text + "%' " +
                                  "OR Editorial LIKE '%" + txtBuscar.Text + "%' " +
                                  "OR Estado LIKE '%" + estadoTraducido + "%'";

                dgvEditorial.Rows.Clear();
                buscar.Mostrar(dgvEditorial, consulta);
            }
            else if (txtBuscar.Text.Length == 0)
            {
                dgvEditorial.Rows.Clear();
                clase.Mostrar(dgvEditorial);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            validacion1 = true;
            frmAgregarOEditarEditorial frm = new frmAgregarOEditarEditorial();
            this.AddOwnedForm(frm);
            frm.btnEditar.Visible = false;
            frm.ShowDialog();
        }
    }
}
