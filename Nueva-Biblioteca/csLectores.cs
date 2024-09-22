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
        private static csReutilizacion claseCodigo = new csReutilizacion();
        private csMensajesDCorreosYMensajitos mensajes = new csMensajesDCorreosYMensajitos();
        private string codigo, nombre, apellido, fecha, correo, estado, correoIgual;

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

        public string CorreoIgual { get => correoIgual; set => correoIgual = value; }

        //Constructor
        public csLectores()
        { }

        //Metodos
        public csLectores(string codigo, string nombre, string apellido, string correo, string estado,string igual)
        {
            Codigo = codigo.Trim();
            Nombre = nombre.Trim();
            Apellido = apellido.Trim();
            Correo = correo.Trim();
            Estado = estado.Trim();
            CorreoIgual=igual.Trim();
        }

        public void MostrarLectores(DataGridView tabla)
        {
            string consulta = @"SELECT L.IdLector, L.Nombres, L.Apellidos, L.Correo,
                    CASE WHEN  L.Estado = 1  THEN 'Activo' ELSE 'Inactivo' END AS Estado
                    FROM LECTOR L";
            new csLLenarDataGridView().Mostrar(tabla, consulta, 1);
        }

        public bool AgregarLector()
        {
            if (Nombre != string.Empty && Apellido != string.Empty && Correo != string.Empty && Estado != string.Empty)
            {
                csLogin verifcarC = new csLogin();
                codigo = claseCodigo.GenerarCodigo("SELECT MAX(IdLector) AS codigo FROM LECTOR", "codigo");
                Estado = VerificarEstado();
                string consulta = $"Select COUNT(*) from LECTOR where Correo = '{Correo}'";
                bool verificar01 = EsCorreoValido(correo);
                bool verificar = VerificarCorreoSQL(Correo, consulta);
                if (!verificar && verificar01 == true)
                {
                    string query = $"Insert into LECTOR(IdLector, Nombres, Apellidos, Correo, Estado, FechaCreacion) " +
                        $"Values('{codigo}','{nombre}', '{apellido}', '{correo}', '{estado}','{DateTime.Now.ToString("yyyy-MM-dd")}')";
                    Actualizar(query);
                    mensajes.EnvioDeCorreoLectoresAgregar(nombre, apellido, correo);
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

        public bool EditarLector()
        {
            csLogin verifcarC = new csLogin();
            if (Nombre != string.Empty && Apellido != string.Empty && Correo != string.Empty && Estado != string.Empty)
            {
                string consulta = $"Select COUNT(*) from LECTOR where Correo = '{Correo}'";
                bool verificar01 = EsCorreoValido(correo);
                Estado = VerificarEstado();
                if (verificar01)
                {
                    if (Correo == CorreoIgual)
                    {
                        string query = $"Update LECTOR set Nombres = '{Nombre}', Apellidos = '{Apellido}', Correo = '{Correo}', Estado = '{Estado}' where IdLector = '{Codigo}'";
                        Actualizar(query);
                        mensajes.EnvioCorreoLectorEditar(nombre, apellido, correo);
                        return true;
                    }
                    else
                    {
                        bool verificar = VerificarCorreoSQL(Correo, consulta);
                        if (!verificar)
                        {
                            string query = $"Update LECTOR set Nombres = '{Nombre}', Apellidos = '{Apellido}', Correo = '{Correo}', Estado = '{Estado}' where IdLector = '{Codigo}'";
                            Actualizar(query);
                            mensajes.EnvioCorreoLectorEditar(nombre, apellido, correo);
                            return true;
                        }
                        else
                        {
                            mensajes.CorreoNoValidoORegistrado();
                            return false;
                        }
                    }

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

        private string VerificarEstado()
        {
            if (Estado == "Activo")
                return 1.ToString();
            else
                return 0.ToString();
        }

        public bool EsCorreoValido(string correo)
        {
            string patron = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(correo, patron);
        }
    }
}