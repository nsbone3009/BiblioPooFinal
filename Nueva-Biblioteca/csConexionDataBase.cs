using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Nueva_Biblioteca
{
    class csConexionDataBase
    {
        public string cadenaConexion = @"Password=123;Persist Security Info=True;User ID=Jeremy01;Initial Catalog=BIBLIOTECA;Data Source=DESKTOP-2UJUKM2\JEREMY";
        //public string cadenaConexion = @"Password=1111;Persist Security Info=False;User ID=Administrador;Initial Catalog=BIBLIOTECA;Data Source=DESKTOP-T767FTN\KHRIZ";
        //public string cadenaConexion = @"Password=admin;Persist Security Info=False;User ID=admin;Initial Catalog=BIBLIOTECA;Data Source=NIURLETH";
        //public string cadenaConexion = @"Server= DESKTOP-RJ6RQ3J\SQLEXPRESS; DataBase = BIBLIOTECA; Integrated Security = True;";
        public SqlConnection conexion;
        public csConexionDataBase()
        {
            conexion = new SqlConnection(cadenaConexion);
        }
        public DataTable Registros(string consulta)
        {
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataAdapter datos = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public void Actualizar(string consulta)
        {
            try
            {
                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            } catch { conexion.Close(); }
        }
        public string Extraer(string consulta, string columna)
        {
            string resultado = "";
            conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader leer = comando.ExecuteReader();
            while (leer.Read()) { resultado = leer[columna].ToString(); }
            conexion.Close();
            return resultado;
        }
        public PictureBox ExtraerImagen(string consulta, string columna, PictureBox portada)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader leer = comando.ExecuteReader();
            try
            {
                if (leer.Read())
                {
                    MemoryStream memoria = new MemoryStream((byte[])leer[columna]);
                    Bitmap bitmap = new Bitmap(memoria);
                    portada.BackgroundImage = bitmap;
                }
            } catch { conexion.Close(); }
            conexion.Close();
            return portada;
        }
        public string ExtraerAutores(string consulta, string columna)
        {
            string resultado = "";
            conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader leer = comando.ExecuteReader();
            while (leer.Read())
            {
                if (resultado != "")
                    resultado += "," + leer[columna].ToString();
                else
                    resultado += leer[columna].ToString();
            }
            conexion.Close();
            return resultado;
        }
        public ComboBox LLenarLista(ComboBox lista, string consulta, string columna)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader leer = comando.ExecuteReader();
            while (leer.Read()) { lista.Items.Add(leer[columna].ToString()); }
            conexion.Close();
            return lista;
        }
        public string Contar(string consulta)
        {
            string numero = "";
            conexion.Open();
            SqlCommand comando = new SqlCommand(consulta, conexion);
            numero = comando.ExecuteScalar().ToString();
            conexion.Close();
            return numero;
        }
        public void CerrarConexion()
        {
            conexion.Close();
        }
        public void AbrirConexion()
        {
            conexion.Open();
        }
        public void GuardarImagen(PictureBox Imagen, string consulta)
        {
            MemoryStream espacio = new MemoryStream();
            Imagen.Image.Save(espacio, ImageFormat.Png);
            byte[] Convertir = espacio.ToArray();
            conexion.Open();
            SqlCommand Comando = new SqlCommand(consulta, conexion);
            Comando.Parameters.AddWithValue("imagen", Convertir);
            Comando.ExecuteNonQuery();
            conexion.Close();
        }
        public bool VerificarCorreoSQL(string correo, string consulta)
        {

            bool ExisteCorreo = false;
            conexion.Open();
            SqlCommand comands = new SqlCommand(consulta, conexion);
            int contador = (int)comands.ExecuteScalar();
            ExisteCorreo = contador > 0;
            conexion.Close();
            return ExisteCorreo;
        }

    }
}
