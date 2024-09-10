using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nueva_Biblioteca
{
    internal class csUsuarios : csConexionDataBase
    {
        private Random random = new Random(DateTime.Now.Millisecond);
       private string idUsuarip, nombre, apellido, fecha, rol, idrol, estado, usuario, contra, correo, cifraClave, idCredencial;
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Idrol { get => idrol; set => idrol = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contra { get => contra; set => contra = value; }
        public string Correo { get => correo; set => correo = value; }
        public string CifraClave { get => cifraClave; set => cifraClave = value; }
        public string IdUsuario { get => idUsuarip; set => idUsuarip = value; }
        public string IdCredencial { get => idCredencial; set => idCredencial = value; }
        public string Rol { get => rol; set => rol = value; }

        public csUsuarios()
        { }

        public csUsuarios(string IdU, string nombre, string apellido, string estado, string rol, string correo, string contra)
        {
            Nombre = nombre.Trim(); Apellido = apellido.Trim(); Estado = estado.Trim();
            Contra = contra.Trim(); Correo = correo.Trim(); Rol = rol.Trim(); IdUsuario = IdU.Trim();
        }

        public void AgregarUsuario()
        {
            csLectores correoV = new csLectores();
            csLogin encriptar = new csLogin();
            Fecha = DateTime.Now.ToString("yyyy-MM-dd");
            IdUsuario = random.Next(1000, 99999).ToString();
            IdCredencial = random.Next(1000, 99999).ToString();
            Idrol = random.Next(1000, 99999).ToString();
            if (Nombre != string.Empty && Apellido != string.Empty && Correo != string.Empty && Estado != string.Empty && Rol != string.Empty && Contra != string.Empty)
            {

                Estado = VerificarEstado();
                string consulta = $"Select COUNT(*) from USUARIO where Correo = '{Correo}'";
                bool verificar01= correoV.EsCorreoValido(correo);
                bool verificar = encriptar.VerificarCorreoSQL(Correo, consulta);
                if (!verificar&& verificar01==true)
                {
                    string query02 = "insert into ROL_USUARIO(IdTipoPersona,Rol,Estado,FechaCreacion)values('" + Idrol + "','" + Rol + "','" + Estado + "','" + Fecha + "')";
                    Actualizar(query02);
                    string query = "insert into USUARIO(IdUsuario,Nombres,Apellidos,Correo,IdTipoPersona,Estado,FechaCreacion) values('" + IdUsuario + "','" + Nombre + "','" + Apellido + "','" + Correo + "','" + Idrol + "','" + Estado + "','" + Fecha + "')";
                    Actualizar(query);
                    Usuario = CreadorUser(); CifraClave = encriptar.EncriptarYDesencriptar(contra);
                    string query01 = "insert into CREDENCIAL(IdCredencial,IdUsuario,Usuario,Contraseña) values('" + IdCredencial + "','" + IdUsuario + "','" + Usuario + "','" + CifraClave + "')";
                    Actualizar(query01);
                    MessageBox.Show("🎉 ¡Felicidades! El usuario se ha agregado exitosamente a la Biblioteca. ¡Bienvenido al mundo del conocimiento! 📚✨", "Usuario Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    csCorreoElectronico mensaje = new csCorreoElectronico();
                    mensaje.Receptor = Correo.Trim();
                    mensaje.Asunto = "¡Bienvenido a la Biblioteca Digital!";
                    mensaje.Cuerpo = "Estimado lector,\n\n¡Nos complace darte la bienvenida a nuestra Biblioteca Digital! Tu cuenta ha sido creada exitosamente.\n\n🆔 Tu nombre de usuario es: " + Usuario + "\n\nTe invitamos a explorar nuestra colección de libros y recursos. Si tienes alguna pregunta, no dudes en contactarnos.\n\n¡Feliz lectura!\n\nSaludos cordiales,\nEquipo de la Biblioteca 📚";

                    if (mensaje.Enviar())
                        MessageBox.Show("🎉 ¡Usuario agregado con éxito! Se ha enviado un correo con tu nombre de usuario para que puedas acceder a nuestra biblioteca digital. Revisa tu bandeja de entrada y, si no lo encuentras, asegúrate de revisar también la carpeta de SPAM. ¡Bienvenido a tu nueva aventura literaria! 📚", "Usuario Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("⚠️ Hubo un problema al enviar el correo. Verifica que la dirección de correo electrónico sea válida e intenta nuevamente.", "Error de Envío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("🔒 El correo electrónico ingresado no es válido o ya está registrado en nuestro sistema. Asegúrate de introducir una dirección de correo válida (como usuario@ejemplo.com) o utiliza otra dirección si el correo ya existe en nuestros registros. Si olvidaste tu contraseña, intenta recuperarla. ¡Gracias por tu comprensión! 📚", "Correo Inválido o Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("⚠️ Todos los campos son necesarios para registrar un nuevo usuario en la Biblioteca. Asegúrate de completar la información requerida para continuar. ¡Tu próxima aventura literaria te espera! 📚", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void EditarUsuario()
        {
            if (Nombre != string.Empty && Apellido != string.Empty && Correo != string.Empty && Estado != string.Empty && Rol != string.Empty)
            {
                Estado = VerificarEstado();
                MessageBox.Show(IdUsuario);
                MessageBox.Show(Estado);
                string Id = "select IdTipoPersona from USUARIO where IdUsuario ='" + IdUsuario + "'";
                string _idRol = Extraer(Id, "IdTipoPersona");
                string query = "update USUARIO set Nombres='" + Nombre + "',Apellidos='" + Apellido + "',Correo='" + Correo + "',Estado='" + Estado + "' where IdUsuario='" + IdUsuario + "'";
                string query01 = "update ROL_USUARIO set Rol='" + Rol + "' where IdTipoPersona='" + _idRol + "'";
                Actualizar(query);
                Actualizar(query01);
                MessageBox.Show("✅ Los datos del usuario han sido modificados exitosamente. ¡Gracias por mantener la información actualizada! 📚", "Modificación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                csCorreoElectronico mensaje = new csCorreoElectronico();
                mensaje.Receptor = Correo;
                mensaje.Asunto = "Actualización de Datos en la Biblioteca Digital";
                mensaje.Cuerpo = "Estimado usuario,\n\n" +
                                 "Queremos informarte que los datos de tu cuenta en nuestra Biblioteca Digital han sido actualizados correctamente. Aquí están los detalles de tu información modificada:\n\n" +
                                 "📝 Nombre: " + Nombre + "\n" +
                                 "📝 Apellido: " + Apellido + "\n" +
                                 "📧 Correo Electrónico: " + Correo + "\n" +
                                 "🔖 Rol: " + Rol + "\n\n" +
                                 "Si no solicitaste esta actualización o tienes alguna duda, por favor contáctanos de inmediato.\n\n" +
                                 "Gracias por ser parte de nuestra comunidad lectora. ¡Sigue disfrutando de nuestra colección de libros y recursos!\n\n" +
                                 "Saludos cordiales,\n" +
                                 "Equipo de la Biblioteca 📚";
                if (mensaje.Enviar())
                {
                    MessageBox.Show("✅ Los datos del usuario han sido modificados exitosamente y se ha enviado un correo con la información actualizada. Revisa tu bandeja de entrada y, si no lo encuentras, verifica también la carpeta de SPAM. ¡Gracias por mantener tu información al día! 📚",
                                    "Modificación y Envío Exitoso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("⚠️ Los datos del usuario se han actualizado correctamente, pero hubo un problema al enviar el correo. Verifica que la dirección de correo electrónico sea válida e intenta nuevamente.",
                                    "Actualización Completa, Error de Envío",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            else
                MessageBox.Show("⚠️ Todos los campos son necesarios para actualizar un usuario en la Biblioteca. Asegúrate de completar la información requerida para continuar. ¡Tu próxima aventura literaria te espera! 📚", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public string VerificarEstado()
        {
            if (Estado == "Activo")
                return 1.ToString();
            else
                return 0.ToString();
        }

        public string CreadorUser()
        {
            string user = Nombre[0].ToString().ToLower();
            user = user + Apellido.ToLower();
            return user;
        }
    }
}