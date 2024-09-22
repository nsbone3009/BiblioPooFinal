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
