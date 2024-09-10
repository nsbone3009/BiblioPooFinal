using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nueva_Biblioteca
{
    internal class csPrestamos
    {
        private csConexionDataBase conexionSQL = new csConexionDataBase();
        csCorreoElectronico correo = new csCorreoElectronico();

        public csPrestamos()
        {
        }

        public bool RegistrarPrestamo(string idPrestamo, string idLector, string idLibro, string FechaDevolucion, string FechaCreacion, string estadoentregado)
        {
            try
            {
                string consulta = "INSERT INTO PRESTAMO (IdPrestamo, IdLector, IdLibro, FechaDevolucion, FechaCreacion, estadoentregado, Estado, Aviso, AvisoPrestamo) " +
                                  "VALUES (@IdPrestamo, @IdLector, @IdLibro, @FechaDevolucion, @FechaCreacion, @estadoentregado, " + 1+", "+0+", "+0+")";
                conexionSQL.AbrirConexion();
                SqlCommand comando = new SqlCommand(consulta, conexionSQL.conexion);
                comando.Parameters.AddWithValue("@IdPrestamo", idPrestamo);
                comando.Parameters.AddWithValue("@IdLector", idLector);
                comando.Parameters.AddWithValue("@IdLibro", idLibro);
                comando.Parameters.AddWithValue("@FechaDevolucion", FechaDevolucion);
                comando.Parameters.AddWithValue("@FechaCreacion", FechaCreacion);
                comando.Parameters.AddWithValue("@estadoentregado", estadoentregado);

                comando.ExecuteNonQuery();
                conexionSQL.CerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el préstamo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
   
        public bool enviarcorreo(string autor, string libro, string fechadevol, string email)
        {
          string cuerpoC = "Estimado(a) lector(a) "+autor+":\n\n" +
                 "Esperamos que estés disfrutando de la lectura de "+libro+". Te recordamos que este libro fue prestado de nuestra biblioteca y que la fecha de devolución es el "+fechadevol+". Por favor, asegúrate de devolverlo a tiempo para que otros usuarios también puedan acceder a él.\n\n" +
                 "Si necesitas más tiempo para finalizar tu lectura, no dudes en ponerte en contacto con nosotros para solicitar una extensión del préstamo.\n\n" +
                 "Gracias por utilizar nuestros servicios y ayudarnos a mantener los recursos disponibles para todos. ¡Que disfrutes el resto de tu lectura!";
            correo.Receptor = email;
            correo.Asunto = "HAZ REALIZADO UN PRESTAMO";
            correo.Cuerpo = cuerpoC;
            MessageBox.Show(correo.Enviar() ? "Correo enviado correctamente" : "Error al enviar el correo", "Envio de correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        public DataTable CargarPrestamosActivos()
        {
            string consulta = @"SELECT P.Estado AS Estado, 
                                P.IdLector AS IdLector, 
                                CONCAT(Le.Nombres, ' ', Le.Apellidos) AS NombreLector, 
                                Li.Titulo AS TituloLibro, 
                                P.FechaDevolucion AS FechaDevolucion
                                FROM Prestamo AS P
                                JOIN Lector AS Le ON P.IdLector = Le.IdLector
                                JOIN Libro AS Li ON P.IdLibro = Li.IdLibro
                                WHERE P.Estado = '1'";
            return conexionSQL.Registros(consulta); 
        }
    }
}
