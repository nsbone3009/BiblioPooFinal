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
        private static csConexionDataBase conexion = new csConexionDataBase();
        private static DataTable registros = new DataTable();
        public void Mostrar(DataGridView Tabla, string consulta, int opcion)
        {
            int f = 0, x = 0;
            if(Tabla.RowCount >= 0) { Tabla.Rows.Clear(); }
            Tabla.Columns[Tabla.ColumnCount - 1].Width = 50;
            registros = conexion.Registros(consulta);

            if (registros.Rows.Count >= 5) { x = 18; }

            foreach (DataRow row in registros.Rows) 
            {
                Tabla.Rows.Add(row.ItemArray);
                switch(opcion)
                {
                    case 1:
                        Tabla.Rows[f].Cells[Tabla.ColumnCount - 1].Value = Image.FromFile(Environment.CurrentDirectory + @"\\Iconos\editar.ico");
                        break;
                    case 2:
                        Tabla.Rows[f].Cells[Tabla.ColumnCount - 1].Value = Image.FromFile(Environment.CurrentDirectory + @"\\Iconos\seleccionar.ico");
                        break;
                    case 3:
                        Tabla.Rows[f].Cells[Tabla.ColumnCount - 1].Value = Image.FromFile(Environment.CurrentDirectory + @"\\Iconos\devolver.ico");
                        if ((DateTime.Parse(Tabla.Rows[f].Cells["FechaDev"].Value.ToString().Trim()) < DateTime.Now) && Tabla.Rows[f].Cells["Estado"].Value.ToString().Trim() == "Pendiente")
                        {
                            Tabla.Rows[f].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                            Tabla.Rows[f].DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                        }
                        break;
                }
                Tabla.Rows[f].Resizable = DataGridViewTriState.False;
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
