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

        private csMensajesDCorreosYMensajitos mensajes = new csMensajesDCorreosYMensajitos();
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

        public bool AgregarLector()
        {
            if (Nombre != string.Empty && Apellido != string.Empty && Correo != string.Empty && Estado != string.Empty)
            {
                csLogin verifcarC = new csLogin();
                codigo = rnd.Next(1000, 99999).ToString();
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
                Estado = VerificarEstado();
                string query = $"Update LECTOR set Nombres = '{Nombre}', Apellidos = '{Apellido}', Correo = '{Correo}', Estado = '{Estado}' where IdLector = '{Codigo}'";
                Actualizar(query);
                mensajes.EnvioCorreoLectorEditar(nombre, apellido, correo);
                return true;
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