using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nueva_Biblioteca
{
    internal class csLectores : csConexionDataBase
    {
        //Atributos
        private Random rnd = new Random(DateTime.Now.Millisecond);

        private string codigo, nombre, apellido, fecha, correo, estado;

        //Propiedades
        public string Codigo
        { get { return codigo; } set { codigo = value; } }

        public string Nombre
        { get { return nombre; } set { nombre = value; } }

        public string Apellido
        { get { return apellido; } set { apellido = value; } }

        public string Fecha
        { get { return fecha; } set { fecha = value; } }

        public string Correo
        { get { return correo; } set { correo = value; } }

        public string Estado
        { get { return estado; } set { estado = value; } }

        //Constructor
        public csLectores()
        { }

        //Metodos
        public csLectores(string codigo, string nombre, string apellido, string correo, string estado)
        {
            Codigo = codigo.Trim();
            Nombre = nombre.Trim();
            Apellido = apellido.Trim();
            Correo = correo.Trim();
            Estado = estado.Trim();
        }

        public void MostrarLectores(DataGridView tabla)
        {
            string consulta = "SELECT IdLector, Nombres, Apellidos, Correo, Estado FROM LECTOR";
            tabla = new csLLenarDataGridView().Mostrar(tabla, consulta);
        }

        public void AgregarLector()
        {

            if (Nombre != string.Empty && Apellido != string.Empty && Correo != string.Empty && Estado != string.Empty)
            {
                csLogin verifcarC = new csLogin();
                codigo = rnd.Next(1000, 99999).ToString();
                Estado = VerificarEstado();
                string consulta = $"Select COUNT(*) from LECTOR where Correo = '{Correo}'";
                bool verificar01 = EsCorreoValido(correo);
                bool verificar = verifcarC.VerificarCorreoSQL(Correo, consulta);
                if (!verificar&&verificar01==true)
                {
                    string query = $"Insert into LECTOR(IdLector, Nombres, Apellidos, Correo, Estado, FechaCreacion) " +
                        $"Values('{codigo}','{nombre}', '{apellido}', '{correo}', '{estado}','{DateTime.Now.ToString("yyyy-MM-dd")}')";
                    Actualizar(query);
                    MessageBox.Show("📝 ¡Nuevo lector agregado con éxito! 🎉 Tu registro ha sido completado y ahora formas parte de nuestra comunidad lectora. Prepárate para sumergirte en un mundo lleno de conocimiento y aventuras literarias. 📚", "Lector Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    csCorreoElectronico mensaje = new csCorreoElectronico();
                    mensaje.Receptor = Correo;
                    mensaje.Asunto = "¡Bienvenido a la Biblioteca Digital!";
                    mensaje.Cuerpo = "Estimado lector,\n\n" +
                                     "¡Nos complace darte la bienvenida a nuestra Biblioteca Digital! Tu cuenta ha sido creada exitosamente con los siguientes datos:\n\n" +
                                     "🆔 Nombre: " + Nombre + "\n" +
                                     "🆔 Apellido: " + Apellido + "\n" +
                                     "📧 Correo Electrónico: " + Correo + "\n\n" +
                                     "Te invitamos a explorar nuestra colección de libros y recursos. Si tienes alguna pregunta, no dudes en contactarnos.\n\n" +
                                     "¡Feliz lectura y bienvenida a tu nueva aventura literaria!\n\n" +
                                     "Saludos cordiales,\n" +
                                     "Equipo de la Biblioteca 📚";
                    if (mensaje.Enviar())
                    {
                        MessageBox.Show("🎉 ¡Lector agregado con éxito! Se ha enviado un correo de bienvenida con los datos proporcionados. Revisa tu bandeja de entrada y, si no lo encuentras, asegúrate de revisar también la carpeta de SPAM. ¡Nos alegra tenerte con nosotros! 📚", "Lector Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }


                    else

                        MessageBox.Show("⚠️ Hubo un problema al enviar el correo. Verifica que la dirección de correo electrónico sea válida e intenta nuevamente.", "Error de Envío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("⚠️ El correo electrónico ingresado no es válido o ya está registrado en nuestro sistema. Asegúrate de escribir una dirección de correo válida (por ejemplo, usuario@ejemplo.com) o intenta recuperar tu contraseña si ya tienes una cuenta registrada. ¡Gracias por tu comprensión! 📧", "Correo Inválido o Registrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
                MessageBox.Show("⚠️ ¡Atención! Algunos campos están incompletos. Por favor, llena toda la información requerida para registrar al lector. Cada detalle es importante para ofrecerte la mejor experiencia en nuestra biblioteca. 📖", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void EditarLector()
        {
            csLogin verifcarC = new csLogin();
            if (Nombre != string.Empty && Apellido != string.Empty && Correo != string.Empty && Estado != string.Empty)
            {
                Estado = VerificarEstado();
                string query = $"Update LECTOR set Nombres = '{Nombre}', Apellidos = '{Apellido}', Correo = '{Correo}', Estado = '{Estado}' where IdLector = '{Codigo}'";
                Actualizar(query);
                MessageBox.Show("✅ Los datos del lector han sido actualizados exitosamente. ¡Gracias por mantener la información al día! 📖", "Actualización Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                csCorreoElectronico mensaje = new csCorreoElectronico();
                mensaje.Receptor = Correo;
                mensaje.Asunto = "¡Actualización de tus datos en la Biblioteca Digital!";
                mensaje.Cuerpo = "Estimado lector,\n\nTus datos han sido actualizados correctamente en nuestra Biblioteca Digital. A continuación, te recordamos la información registrada:\n\n" +
                                 "🆔 Nombre: " + Nombre + "\n" +
                                 "🆔 Apellido: " + Apellido + "\n" +
                                 "📧 Correo Electrónico: " + Correo + "\n\n" +
                                 "Si necesitas realizar algún cambio adicional o tienes alguna pregunta, no dudes en contactarnos.\n\n" +
                                 "¡Gracias por ser parte de nuestra comunidad de lectores!\n\n" +
                                 "Saludos cordiales,\n" +
                                 "Equipo de la Biblioteca 📚";

                if (mensaje.Enviar())

                    MessageBox.Show("✅ ¡Datos del lector actualizados con éxito! Se ha enviado un correo con la información actualizada. Revisa tu bandeja de entrada y, si no lo encuentras, verifica en la carpeta de SPAM.", "Actualización Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else

                    MessageBox.Show("⚠️ Hubo un problema al enviar el correo. Verifica que la dirección de correo electrónico sea válida e intenta nuevamente.", "Error de Envío", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("⚠️ Por favor, completa todos los campos requeridos para actualizar la información del lector. Asegúrate de no dejar ningún dato en blanco para continuar con la edición. 📚", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private string VerificarEstado()
        {
            if (Estado == "Activo")
                return 1.ToString();
            else
                return 0.ToString();
        }
        public bool EsCorreoValido(string correo)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(correo, patron);
        }

    }
}