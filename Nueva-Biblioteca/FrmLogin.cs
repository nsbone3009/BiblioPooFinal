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
        public string NombreEmpleado = "";
        static private frmLogin instancia = null;
        public static frmLogin Formulario()
        {
            if (instancia == null) { instancia = new frmLogin(); }
            return instancia;
        }
        public frmLogin()
        {
            InitializeComponent();
            AccesoDefault();
            Reloj.Start();
        }
        private void AccesoDefault()
        {
            string consulta = "IF EXISTS (SELECT 1 FROM CREDENCIAL WHERE (SELECT COUNT(IdCredencial) FROM CREDENCIAL) > 0) SELECT CAST(1 AS BIT) AS RESULTADO ELSE SELECT CAST(0 AS BIT) AS RESULTADO";
            if (conexion.Extraer(consulta, "RESULTADO") == "False")
            {
                string sentencia1 = "Insert into ROL_USUARIO(IdTipoPersona, Rol, Estado, FechaCreacion) Values('000001', 'Administrador', 1, GETDATE())";
                string sentencia2 = "Insert into USUARIO(IdUsuario, Nombres, Apellidos, Correo, IdTipoPersona, Estado, FechaCreacion) Values('000001', 'Acceso Default', 'Default Acceso', 'Default@gmail.com', '000001', 1, GETDATE())";
                string sentencia3 = "Insert into CREDENCIAL(IdCredencial, IdUsuario, Usuario, Contraseña) Values('000001', '000001', 'admin', 'pQ2Zygl/Go8=')";

                conexion.Actualizar(sentencia1);
                conexion.Actualizar(sentencia2);
                conexion.Actualizar(sentencia3);
            }
        }
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            csLogin login = new csLogin(txtUsuario.Text, txtContraseña.Text);
            string EncriptarClave = login.EncriptarYDesencriptar(txtContraseña.Text);

            if (login.VerificacionLogin(EncriptarClave))
            {
                try
                {
                    string aux = conexion.Extraer($"Select * from USUARIO where IdUsuario = '{login.IdUsuario}'", "Nombres");
                    NombreEmpleado = aux.Substring(0, aux.IndexOf(' '));
                    aux = conexion.Extraer($"Select * from USUARIO where IdUsuario = '{login.IdUsuario}'", "Apellidos");
                    NombreEmpleado += " " + aux.Substring(0, aux.IndexOf(' '));
                }
                catch { }

                frmPantallaPrincipal frmPrincipal = frmPantallaPrincipal.Formulario();
                frmResumen frm = frmResumen.Formulario();
                frmPrincipal.pnlPrincipal.Controls.Clear();
                frm.TopLevel = false;
                frmPrincipal.pnlPrincipal.Controls.Add(frm);
                frmPrincipal.Show();

                frmPrincipal.lbEmpleado.Text = NombreEmpleado;
                frmPrincipal.IdEmpleado = login.IdUsuario;

                frm.Show();
                this.Hide();
            }
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
        private void MostrarLogo()
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
        private void Reloj_Tick(object sender, EventArgs e)
        {
            MostrarLogo();
        }
    }
}
