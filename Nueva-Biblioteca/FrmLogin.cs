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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            csLogin login = new csLogin(txtUsuario.Text, txtContraseña.Text);
            string EncriptarClave = login.EncriptarYDesencriptar(txtContraseña.Text);
            login.VerificacionLogin(EncriptarClave);



        }

        private void btnOcultarContraseña_Click(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = false; btnMostrarContraseña.Visible = true; btnOcultarContraseña.Visible = false;
        }

        private void btnMostrarContraseña_Click(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = true; btnMostrarContraseña.Visible = false; btnOcultarContraseña.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lbOlvidoContraseña_Click(object sender, EventArgs e)
        {

           
            new FrmRecuperacionDContrasña().ShowDialog();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
