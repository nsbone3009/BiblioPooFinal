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
        public string CorreoIgual = "";
        public string identificador = "";
        private static csMensajesDCorreosYMensajitos mensajes = new csMensajesDCorreosYMensajitos();
        public frmAgregarOEditarUsuario()
        {
            InitializeComponent();
            cbEstado.SelectedIndex = 0;
            btnEditar.Visible= false;
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
            CorreoIgual= txtCorreo.Text;
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
            csUsuarios agregar = new csUsuarios(identificador, txtNombre.Text, txtApellido.Text, cbEstado.Text, cbTipo.Text, txtCorreo.Text, txtContraseña.Text,CorreoIgual);
            if (frm.validacion1)
            {
                bool verificar = agregar.AgregarUsuario();
                if (verificar)
                {
                    frm.validacion1 = false;
                    this.Close();
                }

            }
            else if (frm.validacion2)
            {
                bool verificar = agregar.EditarUsuario();
                if (verificar)
                {
                    frm.validacion2 = false;
                    this.Close();
                }

            }
            frm.dgvUsuarios.Rows.Clear();
            agregar.MostrarUsuarios(frm.dgvUsuarios);
        }

        private void frmAgregarOEditarUsuario_Load(object sender, EventArgs e)
        {
            frmUsuarios frm = Owner as frmUsuarios;
            if (frm.validacion2) { btnGuardar.Enabled = false ;btnEditar.Visible = true;  }

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            mensajes.NoNumero(sender, e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            mensajes.NoNumero(sender, e);
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            mensajes.NoEspacio(sender, e);
        }
    }
}
