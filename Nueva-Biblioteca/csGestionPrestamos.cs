using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace Nueva_Biblioteca
{
    class csGestionPrestamos
    {
        private csConexionDataBase dataBase = new csConexionDataBase();
        public void BusquedaPorCaracter(DataGridView dgvPrestamos, string busqueda)
        {
            try
            {
                string consulta = @"select P.IdPrestamo,P.IdLector, L.Nombres, LI.Titulo, P.FechaDevolucion, P.FechaConfirmacionDevolucion, P.Estado 
                                    from PRESTAMO P 
                                    join LECTOR L on P.IdLector = L.IdLector 
                                    join LIBRO LI on P.IdLibro = LI.IdLibro 
                                    where P.IdPrestamo like @busqueda or 
                                    L.IdLector like @busqueda or 
                                    L.Nombres like @busqueda or 
                                    LI.Titulo like @busqueda";
                consulta = consulta.Replace("@busqueda", "'%" + busqueda + "%'");
                new csLLenarDataGridView().Mostrar(dgvPrestamos, consulta, 3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string ExtraerEstado(string idPrestamo, string columna)
        {
            return dataBase.Extraer($"select {columna} from PRESTAMO where IdPrestamo = '{idPrestamo}'", columna).Trim();
        }
        public string GenerarConsultaFiltro(int estado, string idLector)
        {
            string consultaBase = @"SELECT P.IdPrestamo, P.IdLector, L.Nombres, LI.Titulo, P.FechaDevolucion, P.FechaConfirmacionDevolucion, P.Estado 
                                FROM PRESTAMO P
                                JOIN LECTOR L ON P.IdLector = L.IdLector
                                JOIN LIBRO LI ON P.IdLibro = LI.IdLibro";
            List<string> condiciones = new List<string>();
            if (!string.IsNullOrEmpty(idLector) && idLector != "--Seleccionar Todos--")
                condiciones.Add("L.Nombres = '" + idLector + "'");
            if (estado == 1)
                condiciones.Add("P.Estado = 1");
            else if (estado == 2)
                condiciones.Add("P.Estado = 0");
            if (condiciones.Count > 0)
                consultaBase += " WHERE " + string.Join(" AND ", condiciones);
            return consultaBase;
        }
    }
}
