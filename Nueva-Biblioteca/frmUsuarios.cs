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
        private csUsuarios usuarios = new csUsuarios();
        private csLLenarDataGridView buscar = new csLLenarDataGridView();
        static private frmUsuarios instancia = null;
        private csReutilizacion verificar = new csReutilizacion();


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
            new csLLenarDataGridView().Mostrar(dgvUsuarios, consulta, 1);
        }
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            usuarios.MostrarUsuarios(dgvUsuarios);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            validacion1 = true;
            frmAgregarOEditarUsuario frm = new frmAgregarOEditarUsuario();
            this.AddOwnedForm(frm);

            frm.ShowDialog();
        }

        private void lblBuscar_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           
            if (txtBuscar.Text.Length > 1)
            {
                string estadoTraducido = verificar.VerificarEstado(txtBuscar.Text);
                string consulta = "SELECT U.IdUsuario, U.Nombres, U.Apellidos, U.Correo, R.Rol, U.Estado FROM USUARIO AS U INNER JOIN ROL_USUARIO AS R ON U.IdTipoPersona = R.IdTipoPersona WHERE U.IdUsuario LIKE '%" + txtBuscar.Text + "%' OR U.Nombres LIKE '%" + txtBuscar.Text + "%' OR U.Apellidos LIKE '%" + txtBuscar.Text + "%' OR U.Correo LIKE '%" + txtBuscar.Text + "%' OR U.Estado LIKE '%" + estadoTraducido + "%'";
                dgvUsuarios.Rows.Clear();
                buscar.Mostrar(dgvUsuarios, consulta, 1);
            }
            if (txtBuscar.Text.Length == 0)
            {
                dgvUsuarios.Rows.Clear();
                usuarios.MostrarUsuarios(dgvUsuarios);
            }
        }


        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            frmAgregarOEditarUsuario frm = new frmAgregarOEditarUsuario();
            this.AddOwnedForm(frm);
            if (e.ColumnIndex == dgvUsuarios.Columns[dgvUsuarios.ColumnCount - 1].Index && e.RowIndex >= 0)
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
