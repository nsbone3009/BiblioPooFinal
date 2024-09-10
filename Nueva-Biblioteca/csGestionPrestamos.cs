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
        private string id;
        private string filtroP;
        private string consulta="";
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string FiltroP
        {
            get { return filtroP; }
            set { filtroP = value; }
        }
        public string Consulta
        {
            get { return consulta; }
            set { consulta = value; }
        }
        public csGestionPrestamos() { }
        public DataGridView Mostrar(DataGridView Tabla, string consulta)
        {
            DateTime fechaActual = DateTime.Now;
            int f = 0;
            csConexionDataBase dataBase = new csConexionDataBase();
            DataTable Contenedor = new DataTable();
            Contenedor = dataBase.Registros(consulta);
            Tabla.Rows.Clear();
            foreach (DataRow row in Contenedor.Rows)
            {
                Tabla.Rows.Add(row.ItemArray);
                Tabla.Rows[f].Cells["Estado"].Value = Tabla.Rows[f].Cells["Estado"].Value.ToString() == "True"
                    ? "Pendiente"
                    : "Devuelto";
                Tabla.Rows[f].Height = 50;
                string estadoPr = Tabla.Rows[f].Cells["Estado"].Value.ToString().Trim();
                DateTime fechaDevolucion = DateTime.Parse(Tabla.Rows[f].Cells["FechaDev"].Value.ToString().Trim());
                if ((fechaDevolucion < fechaActual) && estadoPr == "Pendiente")
                {
                    Tabla.Rows[f].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    Tabla.Rows[f].DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                }
                f++;
            }
            AjustarColumnas(Tabla);
            return Tabla;
        }
        private void AjustarColumnas(DataGridView Tabla)
        {
            int totalAncho = Tabla.Width;
            int anchoBoton = 50;
            int columnasDeTexto = Tabla.ColumnCount - 1;
            int anchoColumnaTexto = (totalAncho - anchoBoton) / columnasDeTexto;
            for (int i = 0; i < columnasDeTexto; i++)
            {
                Tabla.Columns[i].Width = anchoColumnaTexto;
                Tabla.Columns[i].Resizable = DataGridViewTriState.False;
            }
            Tabla.Columns[Tabla.ColumnCount - 1].Width = anchoBoton;
            Tabla.Columns[Tabla.ColumnCount - 1].Resizable = DataGridViewTriState.False;
        }
        public string GenerarConsultaFiltro(int estado, string idLector)
        {
            string consultaBase = @"SELECT P.IdPrestamo, P.IdLector, L.Nombres, LI.Titulo, P.FechaDevolucion, P.FechaConfirmacionDevolucion, P.Estado 
                                FROM PRESTAMO P
                                JOIN LECTOR L ON P.IdLector = L.IdLector
                                JOIN LIBRO LI ON P.IdLibro = LI.IdLibro";
            List<string> condiciones = new List<string>();
            if (!string.IsNullOrEmpty(idLector) && idLector != "--Seleccionar Todos--")
                condiciones.Add("P.IdLector = '" + idLector + "'");
            if (estado == 1)
                condiciones.Add("P.Estado = 1");
            else if (estado == 2)
                condiciones.Add("P.Estado = 0");
            if (condiciones.Count > 0)
            {
                consultaBase += " WHERE ";
                bool isFirst = true;
                foreach (string condicion in condiciones)
                {
                    if (!isFirst)
                        consultaBase += " AND ";
                    consultaBase += condicion;
                    isFirst = false;
                }
            }
            consulta = consultaBase;
            return consulta;
        }
        public List<string> comboBoxLector()
        {
            csConexionDataBase database = new csConexionDataBase();
            List<string> lectores = new List<string>();
            using (SqlConnection conexion1 = new SqlConnection(database.cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("select distinct IdLector from PRESTAMO", conexion1);
                try
                {
                    conexion1.Open();
                    SqlDataReader read = comando.ExecuteReader();
                    lectores.Add("--Seleccionar Todos--");
                    while (read.Read())
                        lectores.Add(read.GetString(0).Trim());
                    read.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return lectores;
        }


        public List<string> IdYLibro(string IdPrestamo)
        {
            csConexionDataBase database = new csConexionDataBase();
            List<string> datosLibro = new List<string>();
            using (SqlConnection conexion1 = new SqlConnection(database.cadenaConexion))
            {
                SqlCommand comando = new SqlCommand("select L.IdLibro, L.Cantidad from PRESTAMO P join LIBRO L on P.IdLibro = L.IdLibro where P.IdPrestamo = '"+IdPrestamo+"'", conexion1);
                try
                {
                    conexion1.Open();
                    SqlDataReader read = comando.ExecuteReader();
                    while (read.Read())
                    {
                        datosLibro.Add(read.GetString(0).Trim());
                        datosLibro.Add(read.GetInt32(1).ToString().Trim());
                    }
                    read.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return datosLibro;
        }


    }
}
