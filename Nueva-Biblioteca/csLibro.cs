using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing;
using System.Web;

namespace Nueva_Biblioteca
{
    class csLibro
    {
        private static csReutilizacion claseCodigo = new csReutilizacion();
        private static string codigo, titulo, autor, categoria, editorial, ubicacion, estado, fechaCreacion;
        private static csConexionDataBase dataBase = new csConexionDataBase();
        private static int cantidad;
        public string Codigo { set { codigo = value; } get { return codigo; } }
        public string Titulo { set { titulo = value; } get { return titulo; } }
        public string Autor { set { autor = value; } get { return autor; } }
        public string Categoria { set { categoria = value; } get { return categoria; } }
        public string Editorial { set { editorial = value; } get { return editorial; } }
        public string Ubicacion { set { ubicacion = value; } get { return ubicacion; } }
        public int Cantidad { set { cantidad = value; } get { return cantidad; } }
        public string Estado { set { estado = value; } get { return estado; } }
        public string FechaCreacion { set { fechaCreacion = value; } get { return fechaCreacion; } }
        public csLibro() { }
        public void MostrarLibros(DataGridView Tabla)
        {
            string consulta = @"SELECT L.IdLibro, L.Titulo, STRING_AGG(A.Autor, ', ') AS Autores, G.Genero, E.Editorial, L.Ubicacion, L.Cantidad,
                           CASE WHEN  L.Estado = 1  THEN 'Activo' ELSE 'Inactivo' END AS Estado, L.FechaCreacion 
                           FROM LIBRO L 
                           JOIN GENERO G ON G.IdGenero = L.IdGenero 
                           JOIN EDITORIAL E ON E.IdEditorial = L.IdEditorial 
                           JOIN AUTOR_LIBRO AL ON AL.IdLibro = L.IdLibro 
                           JOIN AUTOR A ON  A.IdAutor = AL.IdAutor 
                           GROUP BY L.IdLibro, L.Titulo, G.Genero, E.Editorial, L.Ubicacion, L.Cantidad, L.Estado, L.FechaCreacion";
            new csLLenarDataGridView().Mostrar(Tabla, consulta, 1);
        }
        public void MostrarPortadaLibro(frmAgregarOEditarLibro formulario)
        {
            string consulta = $"Select * from LIBRO where IdLibro = '{codigo}'";
            formulario.ImgLibro = dataBase.ExtraerImagen(consulta, "Foto", formulario.ImgLibro);
        }
        public void ObtenerDatosSeleccion(DataGridView Tabla, int fila)
        {
            codigo = Tabla.Rows[fila].Cells[0].Value.ToString();
            titulo = Tabla.Rows[fila].Cells[1].Value.ToString();
            autor = Tabla.Rows[fila].Cells[2].Value.ToString();
            categoria = Tabla.Rows[fila].Cells[3].Value.ToString();
            editorial = Tabla.Rows[fila].Cells[4].Value.ToString();
            ubicacion = Tabla.Rows[fila].Cells[5].Value.ToString();
            cantidad = int.Parse(Tabla.Rows[fila].Cells[6].Value.ToString());
            estado = Tabla.Rows[fila].Cells[7].Value.ToString();
        }
        public void MostrarDatosSeleccion(frmAgregarOEditarLibro formulario)
        {
            formulario.txtTitulo.Text = titulo;
            formulario.txtAutor.Text = autor;
            formulario.cbCategoria.SelectedItem = categoria;
            formulario.cbEditorial.SelectedItem = editorial;
            formulario.txtUbicacion.Text = ubicacion;
            formulario.txtStock.Text = cantidad.ToString();
            formulario.cbEstado.SelectedItem = estado;
        }
        public void HabilitarCampos(frmAgregarOEditarLibro formulario, bool valor)
        {
            formulario.txtStock.Enabled = valor;
            formulario.txtTitulo.Enabled = valor;
            formulario.txtUbicacion.Enabled = valor;
            formulario.btnSeleccionar.Enabled = valor;
            formulario.btnGuardar.Enabled = valor;
            formulario.btnAgregarAutor.Enabled = valor;
            formulario.btnLimpiarAutores.Enabled = valor;
            formulario.cbCategoria.Enabled = valor;
            formulario.cbEditorial.Enabled = valor;
            formulario.cbEstado.Enabled = valor;
        }
        public void MostrarListas(frmAgregarOEditarLibro formulario)
        {
            formulario.cbCategoria = dataBase.LLenarLista(formulario.cbCategoria, "Select Genero from GENERO where Estado = 1", "Genero");
            formulario.cbEditorial = dataBase.LLenarLista(formulario.cbEditorial, "Select Editorial from EDITORIAL where Estado = 1", "Editorial");
        }
        public bool RegistrarLibro(string titulo, string autor, string genero, string editorial, string ubicacion, string cantidad, string estado, PictureBox portada)
        {
            try
            {
                codigo = claseCodigo.GenerarCodigo("SELECT MAX(IdLibro) AS codigo FROM LIBRO", "codigo");
                genero = dataBase.Extraer("Select IdGenero From GENERO Where Genero = '" + genero + "'", "IdGenero");
                editorial = dataBase.Extraer("Select IdEditorial From EDITORIAL Where Editorial = '" + editorial + "'", "IdEditorial");
                
                string consulta = "Insert into LIBRO(IdLibro, Titulo, IdGenero, IdEditorial, Ubicacion, Cantidad, Estado, FechaCreacion)" +
                $"Values('{codigo}', '{titulo}', '{genero}', '{editorial}', '{ubicacion}', '{cantidad}', '{(estado == "Activo" ? 1 : 0)}', '{DateTime.Now.ToString("dd-MM-yyyy")}')";
                dataBase.Actualizar(consulta);

                if (autor.Contains(','))
                {
                    string[] autores = autor.Split(',');
                    foreach (string nombre in autores)
                    {
                        string ID = dataBase.Extraer($"Select * From AUTOR Where Autor = '{nombre.Trim()}'", "IdAutor");
                        string x = claseCodigo.GenerarCodigo("SELECT MAX(IdAutor_libro) AS codigo FROM AUTOR_LIBRO", "codigo");
                        string sentencia = $"Insert into AUTOR_LIBRO(IdAutor_Libro, IdLibro, IdAutor) Values('{x}', '{codigo}', '{ID}')";
                        dataBase.Actualizar(sentencia);
                    }
                }
                else
                {
                    string ID = dataBase.Extraer($"Select * From AUTOR Where Autor = '{autor.Trim()}'", "IdAutor");
                    string x = claseCodigo.GenerarCodigo("SELECT MAX(IdAutor_libro) AS codigo FROM AUTOR_LIBRO", "codigo");
                    string sentencia = $"Insert into AUTOR_LIBRO(IdAutor_Libro, IdLibro, IdAutor) Values('{x}', '{codigo}', '{ID}')";
                    dataBase.Actualizar(sentencia);
                }

                if (portada.Image != null)
                {
                    string sentencia = $"Update LIBRO set Foto = @imagen where IdLibro = '{codigo}'";
                    dataBase.GuardarImagen(portada, sentencia);
                }
            }
            catch (Exception) { return false; }
            return true;
        }
        public bool ActualizarLibro(string titulo, string autor, string genero, string editorial, string ubicacion, string cantidad, string estado, PictureBox portada)
        {
            try
            {
                genero = dataBase.Extraer("Select IdGenero From GENERO Where Genero = '" + genero + "'", "IdGenero");
                editorial = dataBase.Extraer("Select IdEditorial From EDITORIAL Where Editorial = '" + editorial + "'", "IdEditorial");

                string consulta = $"Update LIBRO set Titulo = '{titulo}', IdGenero = '{genero}', IdEditorial = '{editorial}', Ubicacion = '{ubicacion}', " +
                $"Cantidad = '{cantidad}', Estado = '{(estado == "Activo" ? 1 : 0)}' Where IdLibro = '{codigo}'";
                dataBase.Actualizar(consulta);

                string consulta1 = $"Delete AUTOR_LIBRO where IdLibro = '{codigo}'";
                dataBase.Actualizar(consulta1);

                if (autor.Contains(','))
                {
                    string[] autores = autor.Split(',');
                    foreach (string nombre in autores)
                    {
                        string ID = dataBase.Extraer($"Select * From AUTOR Where Autor = '{nombre.Trim()}'", "IdAutor");
                        string x = claseCodigo.GenerarCodigo("SELECT MAX(IdAutor_libro) AS codigo FROM AUTOR_LIBRO", "codigo");
                        string sentencia = $"Insert into AUTOR_LIBRO(IdAutor_Libro, IdLibro, IdAutor) Values('{x}', '{codigo}', '{ID}')";
                        dataBase.Actualizar(sentencia);
                    }
                }
                else
                {
                    string ID = dataBase.Extraer($"Select * From AUTOR Where Autor = '{autor.Trim()}'", "IdAutor");
                    string x = claseCodigo.GenerarCodigo("SELECT MAX(IdAutor_libro) AS codigo FROM AUTOR_LIBRO", "codigo");
                    string sentencia = $"Insert into AUTOR_LIBRO(IdAutor_Libro, IdLibro, IdAutor) Values('{x}', '{codigo}', '{ID}')";
                    dataBase.Actualizar(sentencia);
                }

                if (portada.Image != null)
                {
                    string sentencia = $"Update LIBRO set Foto = @imagen where IdLibro = '{codigo}'";
                    dataBase.GuardarImagen(portada, sentencia);
                }
            }
            catch { return false; }
            return true;
        }
        public void LimpiarCampos(frmAgregarOEditarLibro formulario)
        {
            formulario.txtTitulo.Clear();
            formulario.txtAutor.Clear();
            formulario.txtUbicacion.Clear();
            formulario.txtStock.Clear();
            formulario.cbCategoria.Controls.Clear();
            formulario.cbEditorial.Controls.Clear();
            formulario.cbEstado.Controls.Clear();
            formulario.ImgLibro.BackgroundImage = null;
        }
    }
}
