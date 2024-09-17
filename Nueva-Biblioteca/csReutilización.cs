using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nueva_Biblioteca
{
    internal class csReutilizacion
    {
        static csConexionDataBase conexion = new csConexionDataBase();
        public static string GenerarId(string nombre)
        {
            if (nombre.Length < 3)
            {
                throw new ArgumentException("El nombre debe tener al menos 3 caracteres.");
            }
            string letras = nombre.Substring(0, 3).ToUpper();
            Random random = new Random();
            string numeros = random.Next(10000, 100000).ToString();  // Siempre genera un número de 5 dígitos
            string id = letras + numeros;

            return id;
        }
        public string VerificarEstado(string Estado)
        {
            Estado = Estado.ToLower();
            if (Estado == "activo")
                return "1";
            else if (Estado == "inactivo")
                return "0";
            return Estado;
        }
        public string GenerarCodigo(string consulta, string columna)
        {
            string defecto = conexion.Extraer(consulta, columna);
            if(defecto != "")
            {
                string aux = "";
                defecto = (int.Parse(defecto) + 1).ToString();
                while ((defecto.Length + aux.Length) != 6) { aux += "0"; }
                return aux + defecto;
            }
            return "000001";
        }
    }
}
