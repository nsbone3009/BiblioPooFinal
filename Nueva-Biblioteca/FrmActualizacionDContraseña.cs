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
    public partial class frmActualizacionDContraseña : Form
    {
        public frmActualizacionDContraseña()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtNuevaClave.Text != string.Empty & txtConfirmarCLave.Text != string.Empty)
            {
                csLogin ingreso = new csLogin();
                if (txtNuevaClave.Text == txtConfirmarCLave.Text)
                {
                    string ClaveEncriptada = ingreso.EncriptarYDesencriptar(txtConfirmarCLave.Text);
                    ingreso.ActualizarContraseña(txtCorreo.Text.Trim(), ClaveEncriptada);
                    this.Hide();
                }
                else
                    MessageBox.Show("🔒 Las contraseñas ingresadas no coinciden. Por favor, verifica y vuelve a intentarlo.", "Error de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("✍️ Por favor, completa todos los campos requeridos para actualizar tu contraseña.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
