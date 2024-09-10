using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nueva_Biblioteca
{
    class csAutores
    {
        private static string codigo, autor, estado;
        private static csConexionDataBase dataBase = new csConexionDataBase();
        public string Codigo { set { codigo = value; } get { return codigo; } }
        public string Autor { set { autor = value; } get { return autor; } }
        public string Estado { set { estado = value; } get { return estado; } }
        public void Mostrar(DataGridView data)
        {
            data = new csLLenarDataGridView().Mostrar(data, "Select IdAutor, Autor, Estado from AUTOR");
        }
        public void GuardarAutor(string codigo, string autor, string estado, string fecha)
        {
            try
            {
                string consulta = $"INSERT INTO AUTOR(IdAutor, Autor, Estado, FechaCreacion) VALUES('{codigo}', '{autor}', '{estado}', '{fecha}')";
                dataBase.Actualizar(consulta);
                MessageBox.Show("Autor agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EditarAutor( string autor, string estado ,string id)
        {
            dataBase.Actualizar("Update AUTOR set Autor = '" + autor + "', Estado = '" + estado + "' where IdAutor = '" + id + "'");
        }
    }
}
