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
        }
        private void lbCerrar_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = Owner as frmUsuarios;
            frm.bandera = false;
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
            csUsuarios claseUsuario = new csUsuarios(identificador, txtNombre.Text, txtApellido.Text, cbEstado.Text, cbTipo.Text, txtCorreo.Text, txtContraseña.Text,CorreoIgual);
            if (frm.bandera)
            {
                if (claseUsuario.AgregarUsuario())
                {
                    frm.bandera = false;
                    this.Close();
                }
            }
            else { if (claseUsuario.EditarUsuario()) { this.Close(); } }
            claseUsuario.MostrarUsuarios(frm.dgvUsuarios);
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
