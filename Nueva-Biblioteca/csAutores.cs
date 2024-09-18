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
        private static csConexionDataBase conexion = new csConexionDataBase();
        public string Codigo { set { codigo = value; } get { return codigo; } }
        public string Autor { set { autor = value; } get { return autor; } }
        public string Estado { set { estado = value; } get { return estado; } }
        public void Mostrar(DataGridView tabla)
        {
            string consulta = "SELECT A.IdAutor, A.Autor, CASE WHEN  A.Estado = 1  THEN 'Activo' ELSE 'Inactivo' END AS Estado FROM AUTOR A";
            new csLLenarDataGridView().Mostrar(tabla, consulta, 1);
        }
        public void RegistrarAutor(string codigo, string autor, string estado, string fecha)
        {
            string consulta = $"INSERT INTO AUTOR(IdAutor, Autor, Estado, FechaCreacion) VALUES('{codigo}', '{autor}', '{estado}', '{fecha}')";
            conexion.Actualizar(consulta);
        }
        public void ActualizarAutor(string autor, string estado)
        {
            string consulta = $"Update AUTOR set Autor = '{autor}', Estado = '{estado}' where IdAutor = '{codigo}'";
            conexion.Actualizar(consulta);
        }
        public void LimpiarCampos(frmAgregarOEditarAutor formulario)
        {
            formulario.txtDescripcion.Clear();
            formulario.cbEstado.SelectedIndex = -1;
        }
    }
}
