using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace Nueva_Biblioteca
{
    class csEnvioDeAvisoDevolucion
    {
        csConexionDataBase database = new csConexionDataBase();
        public void Comparar()
        {
            using (SqlConnection conexion = new SqlConnection(database.cadenaConexion))
            {
                string consulta = @"SELECT P.IdPrestamo, L.Nombres, L.Correo, LI.Titulo
                                    FROM PRESTAMO P
                                    JOIN LECTOR L ON P.IdLector = L.IdLector
                                    JOIN LIBRO LI ON P.IdLibro = LI.IdLibro
                                    WHERE P.Estado = 1
                                    AND P.Aviso = 0";
                conexion.Open();
                SqlCommand comando = new SqlCommand(consulta, conexion);
                SqlDataReader leer = comando.ExecuteReader();
                while (leer.Read())
                {
                    string idPrestamo = leer.GetString(0).Trim();
                    string nombreLector = leer.GetString(1).TrimEnd().TrimStart();
                    string correoLector = leer.GetString(2).Trim();
                    string tituloLibro = leer.GetString(3).TrimEnd().TrimStart();
                    database.Actualizar("update PRESTAMO set Aviso = 1 where IdPrestamo = '"+idPrestamo+"'");
                    EnviarCorreo(correoLector, nombreLector, tituloLibro);
                }
            }
        }
        private void EnviarCorreo(string correo, string nombre, string titulo)
        {
            csCorreoElectronico email = new csCorreoElectronico();
            email.Asunto = "Recordatorio de Entrega de Libro - Quedan 24 horas";
            email.Cuerpo = @"Estimado/a " + nombre + ": " +
                "\n\nEsperamos que se encuentre bien. " +
                "\n\nLe recordamos que el libro [" + titulo + "] que tiene en préstamo se encuentra próximo a su fecha de vencimiento. " +
                "\n\nLe resta menos de 24 horas para devolver el ejemplar a nuestra biblioteca. " +
                "\n\nPara evitar recargos y permitir que otros usuarios disfruten del mismo, le solicitamos que realice la devolución dentro del plazo establecido. " +
                "\n\nSi necesita extender el préstamo o tiene alguna consulta, por favor, no dude en contactarnos. Estamos aquí para ayudarle. " +
                "\n\nAgradecemos su atención y comprensión." +
                "\n\nAtentamente la Biblioteca UTEQ";
            email.Receptor = correo;
            email.Con_Copia = "sanchezvera243@gmail.com";
            email.Enviar();
        }

    }
}
