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

        public frmAgregarOEditarLector()
        {
            InitializeComponent();
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
                AgregaryEditar.AgregarLector();
                frm.validacion1 = false;

            }
            else if (frm.validacion2)
            {
                AgregaryEditar.EditarLector();
                frm.validacion2 = false;
            }
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            cbEstado.SelectedIndex = -1;
            frm.dgvLectores.Rows.Clear();
            claseLector.MostrarLectores(frm.dgvLectores);
            this.Close();
        }

        private void frmAgregarOEditarLector_Load(object sender, EventArgs e)
        {
            frmLectores frm = Owner as frmLectores;
            if (frm.validacion2) { btnGuardar.Enabled = false; }
        }
    }
}