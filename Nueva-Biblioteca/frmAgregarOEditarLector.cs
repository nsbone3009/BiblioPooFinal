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
    public partial class frmAgregarOEditarLector : Form
    {
        private static csLectores claseLector = new csLectores();
        public string identificador = "";
        private static csMensajesDCorreosYMensajitos mensajes = new csMensajesDCorreosYMensajitos();

        public frmAgregarOEditarLector()
        {
            InitializeComponent();
            cbEstado.SelectedIndex = 0;
            btnEditar.Visible = false;
        }

        private void lbCerrar_Click(object sender, EventArgs e)
        {
            frmLectores frm = Owner as frmLectores;
            frm.validacion1 = false;
            frm.validacion2 = false;
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            txtApellido.Enabled = true;
            txtCorreo.Enabled = true;
            cbEstado.Enabled = true;
            btnGuardar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            frmLectores frm = Owner as frmLectores;

            csLectores AgregaryEditar = new csLectores(identificador, txtNombre.Text, txtApellido.Text, txtCorreo.Text, cbEstado.Text);

            if (frm.validacion1)
            {
                bool verificar = AgregaryEditar.AgregarLector();
                if (verificar)
                {
                    frm.validacion1 = false;
                    this.Close();
                }

            }
            else if (frm.validacion2)
            {
                bool verificar = AgregaryEditar.EditarLector();
                if (verificar)
                {
                    frm.validacion2 = false;
                    this.Close();
                }

            }
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            cbEstado.SelectedIndex = -1;
            frm.dgvLectores.Rows.Clear();
            claseLector.MostrarLectores(frm.dgvLectores);
        }

        private void frmAgregarOEditarLector_Load(object sender, EventArgs e)
        {
            frmLectores frm = Owner as frmLectores;
            if (frm.validacion2) { btnGuardar.Enabled = false; btnEditar.Visible = true; }
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