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
    public partial class frmRecuperacionDeContrasña : Form
    {
        private static long codigo = 0; private static string correo = "";
        private csMensajesDCorreosYMensajitos mensajes = new csMensajesDCorreosYMensajitos();

        public frmRecuperacionDeContrasña()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            csLogin verificar = new csLogin();
            string consulta = "select COUNT(*) from USUARIO where Correo='" + txtCorreo.Text.Trim() + "'";
            bool Verificador = verificar.VerificarCorreoSQL(txtCorreo.Text.Trim(), consulta);

            if (Verificador == true && txtCorreo.Text.Contains("@"))
            {
                codigo = new Random().Next(10000000, 99999999);
                mensajes.EnvioDeCorreoRecuperacionDCuenta(txtCorreo.Text, codigo);
                btnEnviar.Visible = false;
                btnVerificar.Visible = true;
                txtCodigo.Enabled = true;
                txtCorreo.Enabled = false;
                correo = txtCorreo.Text;
            }
            else
                MessageBox.Show("❌ El correo electrónico ingresado no se encuentra en el sistema. Por favor, verifica la dirección o regístrate si aún no lo has hecho.", "Correo No Registrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                if (long.Parse(txtCodigo.Text) == codigo)
                {
                    frmActualizacionDContraseña frm = new frmActualizacionDContraseña();
                    frm.txtCorreo.Text = correo;
                    frm.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("⚠️ El código ingresado es incorrecto. Por favor, verifica el código y vuelve a intentarlo.", "Código Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("❗ Debes ingresar un código para continuar. Por favor, completa el campo y vuelve a intentarlo.", "Código Requerido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void FrmRecuperacionDContrasña_Load(object sender, EventArgs e)
        {
            btnVerificar.Visible = false;
        }

        private void lbCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}