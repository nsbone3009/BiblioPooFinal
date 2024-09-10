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
    public partial class frmAgregarOEditarUsuario : Form
    {
        public string identificador = "";
        public frmAgregarOEditarUsuario()
        {
            InitializeComponent();
        }

        private void lbCerrar_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = Owner as frmUsuarios;
            frm.validacion1 = false;
            frm.validacion2 = false;
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtContraseña.Enabled = false;
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtCorreo.Enabled = true;
            cbEstado.Enabled = true;
            cbTipo.Enabled = true;
            btnGuardar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {           
            frmUsuarios frm = Owner as frmUsuarios;
            csUsuarios agregar = new csUsuarios(identificador, txtNombre.Text, txtApellido.Text, cbEstado.Text, cbTipo.Text, txtCorreo.Text, txtContraseña.Text);
            if (frm.validacion1)
            {
                agregar.AgregarUsuario();
                frm.validacion1 = false;
            }
            else if (frm.validacion2)
            {
                agregar.EditarUsuario();
                frm.validacion2 = false;
            }           
            frm.dgvUsuarios.Rows.Clear();
            frm.Mostrar();
            this.Close();
        }

        private void frmAgregarOEditarUsuario_Load(object sender, EventArgs e)
        {
            frmUsuarios frm = Owner as frmUsuarios;
            if (frm.validacion2) { btnGuardar.Enabled = false ;  }
            
        }
    }
}
