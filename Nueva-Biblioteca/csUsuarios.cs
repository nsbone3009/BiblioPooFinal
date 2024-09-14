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
        private csMensajesDCorreosYMensajitos mensajes = new csMensajesDCorreosYMensajitos();
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
        public void MostrarUsuarios(DataGridView tabla)
        {
            string consulta = "select IdUsuario,Nombres,Apellidos,Correo,Rol,U.Estado from USUARIO as U inner join ROL_USUARIO as R on U.IdTipoPersona=R.IdTipoPersona";
            tabla = new csLLenarDataGridView().Mostrar(tabla, consulta);
        }
        public bool AgregarUsuario()
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
                bool verificar01 = correoV.EsCorreoValido(correo);
                bool verificar = VerificarCorreoSQL(Correo, consulta);
                if (!verificar && verificar01 == true)
                {
                    string query02 = "insert into ROL_USUARIO(IdTipoPersona,Rol,Estado,FechaCreacion)values('" + Idrol + "','" + Rol + "','" + Estado + "','" + Fecha + "')";
                    Actualizar(query02);
                    string query = "insert into USUARIO(IdUsuario,Nombres,Apellidos,Correo,IdTipoPersona,Estado,FechaCreacion) values('" + IdUsuario + "','" + Nombre + "','" + Apellido + "','" + Correo + "','" + Idrol + "','" + Estado + "','" + Fecha + "')";
                    Actualizar(query);
                    Usuario = CreadorUser(); CifraClave = encriptar.EncriptarYDesencriptar(contra);
                    string query01 = "insert into CREDENCIAL(IdCredencial,IdUsuario,Usuario,Contraseña) values('" + IdCredencial + "','" + IdUsuario + "','" + Usuario + "','" + CifraClave + "')";
                    Actualizar(query01);
                    mensajes.EnvioDeCorreoUsuarioAgregar(Usuario, correo);
                    return true;
                }
                else
                {
                    mensajes.CorreoNoValidoORegistrado();
                    return false;
                }

            }
            else
            {
                mensajes.MensajeCamposIncompletos();
                return false;
            }
        }

        public bool EditarUsuario()
        {
            if (Nombre != string.Empty && Apellido != string.Empty && Correo != string.Empty && Estado != string.Empty && Rol != string.Empty)
            {
                Estado = VerificarEstado();
                string Id = "select IdTipoPersona from USUARIO where IdUsuario ='" + IdUsuario + "'";
                string _idRol = Extraer(Id, "IdTipoPersona");
                string query = "update USUARIO set Nombres='" + Nombre + "',Apellidos='" + Apellido + "',Correo='" + Correo + "',Estado='" + Estado + "' where IdUsuario='" + IdUsuario + "'";
                string query01 = "update ROL_USUARIO set Rol='" + Rol + "' where IdTipoPersona='" + _idRol + "'";
                Actualizar(query);
                Actualizar(query01);
                mensajes.EnvioCorreoUsuarioEditar(Nombre, Apellido, Correo, Rol);
                return true;
            }
            else
            {
                mensajes.MensajeCamposIncompletos();
                return false;
            }
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
        public void MostrarUsuarios(DataGridView tabla)
        {
            string consulta = "select IdUsuario,Nombres,Apellidos,Correo,Rol,U.Estado from USUARIO as U inner join ROL_USUARIO as R on U.IdTipoPersona=R.IdTipoPersona";
            tabla = new csLLenarDataGridView().Mostrar(tabla, consulta);
        }
    }
}