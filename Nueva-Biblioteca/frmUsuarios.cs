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
    public partial class frmUsuarios : Form
    {
        public bool validacion1 = false, validacion2 = false;

        static private frmUsuarios instancia = null;

        public static frmUsuarios Formulario()
        {
            if (instancia == null) { instancia = new frmUsuarios(); }
            return instancia;
        }

        public frmUsuarios()
        {
            InitializeComponent();
        }
        public void Mostrar()
        {
            string consulta = "select IdUsuario,Nombres,Apellidos,Correo,Rol,U.Estado from USUARIO as U inner join ROL_USUARIO as R on U.IdTipoPersona=R.IdTipoPersona";
            dgvUsuarios = new csLLenarDataGridView().Mostrar(dgvUsuarios, consulta);
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            validacion1 = true;
            frmAgregarOEditarUsuario frm = new frmAgregarOEditarUsuario();
            this.AddOwnedForm(frm);
            
            frm.ShowDialog();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAgregarOEditarUsuario frm = new frmAgregarOEditarUsuario();
            this.AddOwnedForm(frm);
            if (e.ColumnIndex == dgvUsuarios.Columns[6].Index && e.RowIndex >= 0)
            {
                validacion2 = true;
                frm.identificador= dgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString();
                frm.txtNombre.Text = dgvUsuarios.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.txtApellido.Text = dgvUsuarios.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.txtCorreo.Text = dgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (dgvUsuarios.Rows[e.RowIndex].Cells[4].Value.ToString() == "Empleado") { frm.cbTipo.SelectedItem = frm.cbTipo.Items[0]; }
                else { frm.cbTipo.SelectedItem = frm.cbTipo.Items[1]; }
                if (dgvUsuarios.Rows[e.RowIndex].Cells[5].Value.ToString() == "Activo") { frm.cbEstado.SelectedItem = frm.cbEstado.Items[0]; }
                else { frm.cbEstado.SelectedItem = frm.cbEstado.Items[1]; }
                frm.txtContraseña.Enabled = false;
                frm.txtNombre.Enabled = false;
                frm.txtApellido.Enabled = false;
                frm.txtCorreo.Enabled = false;
                frm.cbTipo.Enabled = false;
                frm.cbEstado.Enabled = false;
                frm.ShowDialog();
            }          
        }
    }
}
