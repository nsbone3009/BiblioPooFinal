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
        static csConexionDataBase conexion = new csConexionDataBase();
        static private frmLogin instancia = null;
        public static frmLogin Formulario()
        {
            if (instancia == null) { instancia = new frmLogin(); }
            return instancia;
        }
    
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            //csLogin login = new csLogin(txtUsuario.Text, txtContraseña.Text);
            //string EncriptarClave = login.EncriptarYDesencriptar(txtContraseña.Text);

            //if (login.VerificacionLogin(EncriptarClave))
            //{
                frmPantallaPrincipal frmPrincipal = frmPantallaPrincipal.Formulario();
                frmResumen frm = frmResumen.LlamarFormulario();
                frmPrincipal.pnlPrincipal.Controls.Clear();
                frm.TopLevel = false;
                frmPrincipal.pnlPrincipal.Controls.Add(frm);
                frmPrincipal.Show();
                frm.Show(); 
                this.Hide();
            //}
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
            new frmRecuperacionDeContrasña().ShowDialog();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string consulta = "Select * from CONFIGURACION where IdConfiguracion = (Select max(IdConfiguracion) from CONFIGURACION)";
            ptbxLogoLogin = conexion.ExtraerImagen(consulta, "Imagen", ptbxLogoLogin);
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                txtContraseña.Focus();
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIniciarSesion.PerformClick();
            }
        }
    }
}
