using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nueva_Biblioteca
{
    internal class csLogin : csConexionDataBase
    {
        private csMensajesDCorreosYMensajitos mensajes = new csMensajesDCorreosYMensajitos();
        private string usuario;
        private string contraseña;
        private string idUsuario;
        private Timer TresSegundos;
        public string IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }

        public csLogin()
        { }

        public csLogin(string usuario, string contraseña)
        {
            Usuario = usuario;
            Contraseña = contraseña;
            TresSegundos = new Timer();
            TresSegundos.Interval = 3000;
            TresSegundos.Tick += TresSegundos_Tick;
        }

        public bool VerificacionLogin(string clave)
        {

            if (Usuario != string.Empty && contraseña != string.Empty)
            {
                string query = "select IdCredencial,Usuario,Contraseña from CREDENCIAL where Usuario='" + Usuario + "' and Contraseña='" + clave + "'";
                IdUsuario = Extraer(query, "IdCredencial");
                if (idUsuario != string.Empty)
                {
                    TresSegundos.Start();
                    MessageBox.Show("📚 ¡Acceso concedido! Has ingresado correctamente al sistema de administración de la Biblioteca. Ahora puedes gestionar usuarios, libros y más. ¡Gracias por mantener la biblioteca en orden! 🗂️", "Inicio de Sesión Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("❌ Usuario o contraseña incorrectos. Revisa tus credenciales y vuelve a intentarlo. ¡No te quedes sin descubrir tu próxima lectura!", "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            else
            {
                mensajes.MensajeCamposIncompletos();
                return false;
            }
        }
        public void ActualizarContraseña(string correo, string NuevaClave)
        {
            string consulta = " select IdUsuario from USUARIO where Correo='" + correo + "'";
            idUsuario = Extraer(consulta, "IdUsuario");
            string consulta01 = "update CREDENCIAL set Contraseña='" + NuevaClave + "' where IdUsuario='" + idUsuario + "'";
            Actualizar(consulta01);
            MessageBox.Show("🔒 Tu contraseña ha sido actualizada exitosamente. Puedes ahora acceder con tu nueva contraseña.", "Contraseña Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public string EncriptarYDesencriptar(string clave)
        {
            string frase = "hola";
            byte[] data = UTF8Encoding.UTF8.GetBytes(clave);
            MD5 md5 = MD5.Create();
            TripleDES tripldes = TripleDES.Create();
            tripldes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(frase));
            tripldes.Mode = CipherMode.ECB;
            ICryptoTransform transform = tripldes.CreateEncryptor();
            byte[] result = transform.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(result);

        }
        private void TresSegundos_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
            TresSegundos.Stop();
        }
    }
}