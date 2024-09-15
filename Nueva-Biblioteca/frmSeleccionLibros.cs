using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nueva_Biblioteca
{
    public partial class frmSeleccionLibros : Form
    {
        csConexionDataBase dataBase = new csConexionDataBase();
        DataTable Contenedor = new DataTable();
        public frmSeleccionLibros()
        {
            InitializeComponent();
        }

        private void lbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSeleccionLibros_Load(object sender, EventArgs e)
        {
            string consulta = "Select L.IdLibro, L.Titulo, G.Genero, E.Editorial from LIBRO L " +
            "Join GENERO G on G.IdGenero = L.IdGenero Join EDITORIAL E on E.IdEditorial = L.IdEditorial";
            int f = 0, z = 0;
            dgvLibros.Columns[dgvLibros.ColumnCount - 1].Width = 50;
            dgvLibros.Columns[dgvLibros.ColumnCount - 1].CellTemplate.Style.Padding = new Padding(1);
            DataTable TablaTemporal = dataBase.Registros(consulta);
            if (TablaTemporal.Rows.Count >= 5) { z = 18; }
            foreach (DataRow row in TablaTemporal.Rows)
            {
                int x = 0;
                dgvLibros.Rows.Add();
                dgvLibros.Rows[f].Height = 50;
                dgvLibros.Columns[dgvLibros.ColumnCount - 1].Width = 50;
                object[] vector = row.ItemArray;
                for (int c = 0; c < dgvLibros.ColumnCount - 1; c++)
                {
                    if (c != 2)
                        dgvLibros.Rows[f].Cells[c].Value = vector[x++].ToString();
                    else
                    {
                        string nombre = "";
                        string codigo = dgvLibros.Rows[f].Cells["Codigo"].Value.ToString();
                        string[] autores = dataBase.ExtraerAutores("Select * from AUTOR_LIBRO where IdLibro = '" + codigo + "'", "IdAutor").Split(',');
                        foreach (string autor in autores)
                        {
                            if (nombre != "") { nombre += ", " + dataBase.Extraer("Select * from AUTOR where IdAutor = '" + autor + "'", "Autor"); }
                            else { nombre += dataBase.Extraer("Select * from AUTOR where IdAutor = '" + autor + "'", "Autor"); }
                        }
                        dgvLibros.Rows[f].Cells[2].Value = nombre;
                    }
                }
                dgvLibros.Rows[f].Cells[dgvLibros.ColumnCount - 1].Value = Image.FromFile(@"C:\Users\Khriz\Downloads\seleccionar.ico");
                f++;
            }
            for (int i = 0; i < dgvLibros.ColumnCount - 1; i++)
            {
                dgvLibros.Columns[i].Width = ((dgvLibros.Width - 50 - z) / (dgvLibros.ColumnCount - 1)) - 1;
                dgvLibros.Columns[i].Resizable = DataGridViewTriState.False;
            }
        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvLibros.Columns[dgvLibros.ColumnCount - 1].Index && e.RowIndex >= 0)
            {
                frmPrestamoRegistrar frm = Owner as frmPrestamoRegistrar;
                frm.idlibro = dgvLibros.Rows[e.RowIndex].Cells[0].Value.ToString();
                frm.txtLibro.Text = dgvLibros.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.Close();
            }
        }
    }
}
