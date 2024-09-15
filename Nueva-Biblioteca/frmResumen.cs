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
    public partial class frmResumen : Form
    {
        static private frmResumen instancia = null;

        public static frmResumen Formulario()
        {
            if (instancia == null) { instancia = new frmResumen(); }
            return instancia;
        }

        public frmResumen()
        {
            InitializeComponent();
        }

        private void frmResumen_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
        public void Mostrar()
        {
            charGraficoDatos.Series[0].Points.Clear();
            lbTotalEditoriales.Text = new csConexionDataBase().Contar("Select count(IdEditorial) from EDITORIAL ");
            lbTotalAutores.Text = new csConexionDataBase().Contar("Select count(IdAutor) from AUTOR ");
            lbTotalCategorias.Text = new csConexionDataBase().Contar("Select count(IdGenero) from GENERO");
            lbTotalLibros.Text = new csConexionDataBase().Contar("Select count(IdLibro) from LIBRO");
            lbTotalLectores.Text = new csConexionDataBase().Contar("select count(IdLector)from LECTOR");
            lbTotalUsuarios.Text = new csConexionDataBase().Contar("select count(IdUsuario)from USUARIO");
            lbPrestamosRegistrados.Text = new csConexionDataBase().Contar("select count(IdPrestamo) from PRESTAMO");
            lbPrestamosPendientes.Text = new csConexionDataBase().Contar("select count(IdPrestamo) FROM PRESTAMO WHERE EstadoRecibido  is NULL");
            charGraficoDatos.Series[0].Points.AddXY("Libros", lbTotalLibros.Text);
            charGraficoDatos.Series[0].Points.AddXY("Autores", lbTotalAutores.Text);
            charGraficoDatos.Series[0].Points.AddXY("Editoriales", lbTotalEditoriales.Text);
            charGraficoDatos.Series[0].Points.AddXY("Categorias", lbTotalCategorias.Text);
            charGraficoDatos.Series[0].Points.AddXY("Lectores", lbTotalLectores.Text);
            charGraficoDatos.Series[0].Points.AddXY("Prestamos Registrados", lbPrestamosRegistrados.Text);
            charGraficoDatos.Series[0].Points.AddXY("Prestamos Pendientes", lbPrestamosPendientes.Text);
            charGraficoDatos.Series[0].Points.AddXY("Usuarios", lbTotalUsuarios.Text);
        }
    }
}
