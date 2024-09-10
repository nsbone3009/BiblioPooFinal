using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nueva_Biblioteca
{
    class csGenero
    {
        private static string codigo, genero, estado;
        private static csConexionDataBase dataBase = new csConexionDataBase();
        public string Codigo { set { codigo = value; } get { return codigo; } }
        public string Genero { set { genero = value; } get { return genero; } }
        public string Estado { set { estado = value; } get { return estado; } }
        public void Mostrar(DataGridView data)
        {
            data = new csLLenarDataGridView().Mostrar(data, "Select IdGenero, Genero, Estado from GENERO");
        }
        public void GuardarGnero(string codigo, string genero, string estado, string fecha)
        {
            try
            {
              
                string consulta = $"INSERT INTO GENERO(IdGenero, Genero, Estado, FechaCreacion) VALUES('{codigo}', '{genero}', '{estado}', '{fecha}')";
                dataBase.Actualizar(consulta);
             
                MessageBox.Show("Genero agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EditarGenero(string genero, string estado, string id)
        {
            dataBase.Actualizar("Update GENERO set Genero = '" + genero + "', Estado = '" + estado + "' where IdGenero = '" + id + "'");
        }
    }
}
