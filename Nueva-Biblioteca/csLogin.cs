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
        private string usuario;
        private string contraseña;
        private string idUsuario;

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
        public csLogin() { }
        public csLogin(string usuario, string contraseña)
        {
            Usuario = usuario;
            Contraseña = contraseña;
        }

        public bool VerificacionLogin(string clave)
        {
            if (Usuario != string.Empty && contraseña != string.Empty)
            {
                conexion.Open();
                string query = "select * from CREDENCIAL where Usuario='" + Usuario + "' and Contraseña='" + clave + "'";
                SqlCommand comandos = new SqlCommand(query, conexion);
                SqlDataReader lector = comandos.ExecuteReader();
                if (lector.Read())
                {
                    IdUsuario = lector["IdUsuario"].ToString();
                    conexion.Close();
                    return true;
                }
            }
            conexion.Close();
            return false;
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

        public bool VerificarCorreoSQL(string correo,string consulta)
        {

            bool ExisteCorreo = false;
            conexion.Open();
            SqlCommand comands = new SqlCommand(consulta, conexion);
            int contador = (int)comands.ExecuteScalar();
            ExisteCorreo = contador > 0;
            conexion.Close();
            return ExisteCorreo;
        }

        public void ActualizarContraseña(string correo, string NuevaClave)
        {
            string consulta = " select IdUsuario from USUARIO where Correo='" + correo + "'";
            conexion.Open();
            SqlCommand comandos = new SqlCommand(consulta, conexion);
            SqlDataReader lector = comandos.ExecuteReader();
            if (lector.Read())
                idUsuario = lector["IdUsuario"].ToString().Trim();
            lector.Close();
            string consulta01 = "update CREDENCIAL set Contraseña='" + NuevaClave + "' where IdUsuario='" + idUsuario + "'";
            SqlCommand comandos01 = new SqlCommand(consulta01, conexion);
            comandos01.ExecuteReader();
            MessageBox.Show("🔒 Tu contraseña ha sido actualizada exitosamente. Puedes ahora acceder con tu nueva contraseña.", "Contraseña Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conexion.Close();
        }
    }
}