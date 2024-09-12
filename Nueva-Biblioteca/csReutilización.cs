using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nueva_Biblioteca
{
    internal class csReutilizacion
    {
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
    }
}
