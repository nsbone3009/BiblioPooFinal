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
                conexionSQL.AbrirConexion();
                // --Aclaracion: Se hace una verificacion de si el libro ya lo tiene este usuario.
                string consultaVerificacion = "SELECT COUNT(*) FROM PRESTAMO WHERE IdLibro = @IdLibro AND IdLector = @IdLector AND Estado = 1";
                using (SqlCommand comandoVerificacion = new SqlCommand(consultaVerificacion, conexionSQL.conexion))
                {
                    comandoVerificacion.Parameters.AddWithValue("@IdLibro", idLibro);
                    comandoVerificacion.Parameters.AddWithValue("@IdLector", idLector);

                    int count = (int)comandoVerificacion.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Este libro ya está prestado a este usuario. Debe devolverlo antes de poder pedirlo prestado nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                // --Aclaracion: Se inicia la transacción
                SqlTransaction transaccion = conexionSQL.conexion.BeginTransaction();
                try
                {
                    // --Aclaracion: Consulta para agregar el prestamo
                    string consulta = "INSERT INTO PRESTAMO (IdPrestamo, IdLector, IdLibro, FechaDevolucion, FechaCreacion, estadoentregado, Estado, Aviso, AvisoPrestamo) " +
                                      "VALUES (@IdPrestamo, @IdLector, @IdLibro, @FechaDevolucion, @FechaCreacion, @estadoentregado, " + 1 + ", " + 0 + ", " + 0 + ")";
                    SqlCommand comando = new SqlCommand(consulta, conexionSQL.conexion, transaccion);
                    comando.Parameters.AddWithValue("@IdPrestamo", idPrestamo);
                    comando.Parameters.AddWithValue("@IdLector", idLector);
                    comando.Parameters.AddWithValue("@IdLibro", idLibro);
                    comando.Parameters.AddWithValue("@FechaDevolucion", FechaDevolucion);
                    comando.Parameters.AddWithValue("@FechaCreacion", FechaCreacion);
                    comando.Parameters.AddWithValue("@estadoentregado", estadoentregado);

                    comando.ExecuteNonQuery();

                    // --Aclaracion: Actualizar el stock del libro
                    string consultaStock = "UPDATE LIBRO SET Cantidad = Cantidad - 1 WHERE IdLibro = @IdLibro";
                    SqlCommand comandoStock = new SqlCommand(consultaStock, conexionSQL.conexion, transaccion);
                    comandoStock.Parameters.AddWithValue("@IdLibro", idLibro);
                    comandoStock.ExecuteNonQuery();
                    transaccion.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Encontre esto chevere que se llama Rollback para revertir la transacción si hay algún error
                    transaccion.Rollback();
                    MessageBox.Show("Error al registrar el préstamo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                conexionSQL.CerrarConexion();
            }
        }

        public bool enviarcorreo(string autor, string libro, string fechadevol, string email)
        {
            string cuerpoC = $"Estimado(a) {autor}:\n\n" +
         $"Te informamos que has realizado el préstamo del libro \"{libro}\" en nuestra biblioteca. La fecha límite para la devolución es el {fechadevol}. Te recordamos que es importante devolverlo a tiempo para que otros usuarios también puedan disfrutar de este recurso.\n\n" +
         "Si necesitas más tiempo para terminar tu lectura, por favor, ponte en contacto con nosotros para solicitar una extensión del préstamo.\n\n" +
         "Gracias por confiar en nuestros servicios. ¡Te deseamos una excelente lectura!\n\n" +
         "Atentamente,\n Biblioteca";
            correo.Receptor = email;
            correo.Asunto = "HAZ REALIZADO UN PRESTAMO";
            correo.Cuerpo = cuerpoC;
            MessageBox.Show(correo.Enviar() ? "Correo enviado correctamente" : "Error al enviar el correo", "Envio de correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
    }
}
