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
            int f = 0; //Contador.
            csConexionDataBase dataBase = new csConexionDataBase(); //Intancia un Objeto.
            DataTable Contenedor = new DataTable(); //Crea una tabla en memoria.
            Contenedor = dataBase.Registros(consulta); //Asigna los Datos al contenedor.

            foreach(DataRow row in Contenedor.Rows) //Recorrera fila por fila del contenedor.
            {
                Tabla.Rows.Add(row.ItemArray); //ItemArray obtiene todos los valores de las celdas en forma de un Array, luego se añade una fila con estos valores.
                Tabla.Rows[f].Cells["Estado"].Value = Tabla.Rows[f].Cells["Estado"].Value.ToString() == "True" ? Tabla.Rows[f].Cells["Estado"].Value = "Activo" : Tabla.Rows[f].Cells["Estado"].Value = "Inactivo"; //Si estado es True sera igual a Activo y viceversa.
                Tabla.Rows[f++].Height = 50; //Establece el alto de fila.
                Tabla.Columns[Tabla.ColumnCount - 2].Width = 50; //Estable el ancho de la antepenultima celda
                Tabla.Columns[Tabla.ColumnCount - 1].Width = 50; //Estable el ancho de la ultima celda
            }
            for (int i = 0; i < Tabla.ColumnCount - 2; i++)
            {
                Tabla.Columns[i].Width = ((Tabla.Width - 100) / (Tabla.ColumnCount - 2)) - 1;
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
