using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Nueva_Biblioteca
{
    class csEditorial
    {
        private static string codigo, editorial, estado;
        private static csConexionDataBase dataBase = new csConexionDataBase();
        public string Codigo { set { codigo = value; } get { return codigo; } }
        public string Editorial { set { editorial = value; } get { return editorial; } }
        public string Estado { set { estado = value; } get { return estado; } }
        public void Mostrar(DataGridView data)
        {
            new csLLenarDataGridView().Mostrar(data, "Select IdEditorial, Editorial, Estado from EDITORIAL", 1);
        }
        public void GuardarEditorial(string codigo, string editorial, string estado, string fecha)
        {
            try
            {
                string consulta = $"INSERT INTO EDITORIAL(IdEditorial, Editorial, Estado, FechaCreacion) VALUES('{codigo}', '{editorial}', '{estado}', '{fecha}')";
                dataBase.Actualizar(consulta);
                MessageBox.Show("Editorial agregada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EditarEditorial(string Editoral, string estado, string id)
        {
            dataBase.Actualizar("Update EDITORIAL set Editorial = '" + Editoral + "', Estado = '" + estado + "' where IdEditorial = '" + id + "'");
        }
    }
}
