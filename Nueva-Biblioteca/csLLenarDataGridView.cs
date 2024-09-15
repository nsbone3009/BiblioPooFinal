using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace Nueva_Biblioteca
{
    class csLLenarDataGridView
    {
        public void Mostrar(DataGridView Tabla, string consulta, int opcion)
        {
            int f = 0, x = 0;
            Tabla.Columns[Tabla.ColumnCount - 1].Width = 50;
            csConexionDataBase dataBase = new csConexionDataBase();
            DataTable Contenedor = new DataTable(); 
            Contenedor = dataBase.Registros(consulta);
            if (Contenedor.Rows.Count >= 5) { x = 18; }
            foreach (DataRow row in Contenedor.Rows) 
            {
                Tabla.Rows.Add(row.ItemArray);
                if(opcion == 1)
                {
                    Tabla.Rows[f].Cells["Estado"].Value = Tabla.Rows[f].Cells["Estado"].Value.ToString() == "True" ? Tabla.Rows[f].Cells["Estado"].Value = "Activo" : Tabla.Rows[f].Cells["Estado"].Value = "Inactivo"; 
                    Tabla.Rows[f].Cells[Tabla.ColumnCount - 1].Value = Image.FromFile(@"C:\Users\Khriz\Downloads\editar.ico");
                }
                else
                {
                    Tabla.Rows[f].Cells[Tabla.ColumnCount - 1].Value = Image.FromFile(@"C:\Users\Khriz\Downloads\seleccionar.ico");
                }
                Tabla.Rows[f++].Height = 50;
            }
            for (int i = 0; i < Tabla.ColumnCount - 1; i++)
            {
                Tabla.Columns[i].Width = ((Tabla.Width - 50 - x) / (Tabla.ColumnCount - 1)) - 1;
                Tabla.Columns[i].Resizable = DataGridViewTriState.False;
            }
        }
    }
}
