using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Nueva_Biblioteca
{
    class csLLenarDataGridView
    {
        public DataGridView Mostrar(DataGridView Tabla, string consulta)
        {
            int f = 0; 
            csConexionDataBase dataBase = new csConexionDataBase();
            DataTable Contenedor = new DataTable(); 
            Contenedor = dataBase.Registros(consulta); 

            foreach(DataRow row in Contenedor.Rows) 
            {
                Tabla.Rows.Add(row.ItemArray);
                Tabla.Rows[f].Cells["Estado"].Value = Tabla.Rows[f].Cells["Estado"].Value.ToString() == "True" ? Tabla.Rows[f].Cells["Estado"].Value = "Activo" : Tabla.Rows[f].Cells["Estado"].Value = "Inactivo"; //Si estado es True sera igual a Activo y viceversa.
                Tabla.Rows[f++].Height = 50;
                Tabla.Columns[Tabla.ColumnCount - 1].Width = 50;
            }
            for(int i = 0; i < Tabla.ColumnCount - 1; i++)
            {
                Tabla.Columns[i].Width = ((Tabla.Width - 50) / (Tabla.ColumnCount - 1)) - 1;
                Tabla.Columns[i].Resizable = DataGridViewTriState.False;
            }
            return Tabla;
        }
        public DataGridView MostrarSeleccion(DataGridView Tabla, string consulta)
        {
            int f = 0; //Contador.
            csConexionDataBase dataBase = new csConexionDataBase(); 
            DataTable Contenedor = new DataTable(); 
            Contenedor = dataBase.Registros(consulta); 
            foreach (DataRow row in Contenedor.Rows) 
            {
                Tabla.Rows.Add(row.ItemArray); 
                Tabla.Rows[f++].Height = 50; 
                Tabla.Columns[Tabla.ColumnCount - 1].Width = 50;
            }
            for (int i = 0; i < Tabla.ColumnCount - 1; i++)
            {
                Tabla.Columns[i].Width = ((Tabla.Width - 50) / (Tabla.ColumnCount - 1)) - 1;
                Tabla.Columns[i].Resizable = DataGridViewTriState.False;
            }
            return Tabla;
        }
    }
}
