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
    public partial class frmCambioDeContraseña : Form
    {
        static csLogin login = new csLogin();
        static csConexionDataBase conexion = new csConexionDataBase();
        public frmCambioDeContraseña()
        {
            InitializeComponent();
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            frmPantallaPrincipal frm = frmPantallaPrincipal.Formulario();

            string ContraVieja = conexion.Extraer($"Select * from CREDENCIAL where IdUsuario = '{frm.IdEmpleado}' ", "Contraseña").Trim();
            string ContraViejaIngresada = login.EncriptarYDesencriptar(txtContraseñaActual.Text.Trim());
            
            if (ContraViejaIngresada == ContraVieja)
            {
                if(txtNuevaContraseña.Text == txtConfNuevaContraseña.Text)
                {
                    string NuevaClaveEncriptada = login.EncriptarYDesencriptar(txtNuevaContraseña.Text);
                    conexion.Actualizar($"Update CREDENCIAL set Contraseña = '{NuevaClaveEncriptada}' where IdUsuario = '{frm.IdEmpleado}'");
                    txtConfNuevaContraseña.Clear();
                    txtContraseñaActual.Clear();
                    txtNuevaContraseña.Clear();
                    MessageBox.Show("LA CONTRASEÑA SE CAMBIO CORRECTAMENTE.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("LA NUEVA CONTRASEÑA Y SU CONFIRMACION NO COINCIDE, VERIFIQUE.");
                }
            }
            else
            {
                MessageBox.Show("CONTRASEÑA INCORRECTA, VERIFIQUE ANTES DE CONTINUAR.");
            }
        }

        private void lbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
