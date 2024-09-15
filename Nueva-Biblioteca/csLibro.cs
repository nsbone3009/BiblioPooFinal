using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing;

namespace Nueva_Biblioteca
{
    class csLibro
    {
        //Atributos Libros
        private static string codigo, titulo, autor, categoria, editorial, ubicacion, estado, fechaCreacion;
        private static csConexionDataBase dataBase = new csConexionDataBase();
        private static int cantidad;
        //Propiedades Atributos 
        public string Codigo { set { codigo = value; } get { return codigo; } }
        public string Titulo { set { titulo = value; } get { return titulo; } }
        public string Autor { set { autor = value; } get { return autor; } }
        public string Categoria { set { categoria = value; } get { return categoria; } }
        public string Editorial { set { editorial = value; } get { return editorial; } }
        public string Ubicacion { set { ubicacion = value; } get { return ubicacion; } }
        public int Cantidad { set { cantidad = value; } get { return cantidad; } }
        public string Estado { set { estado = value; } get { return estado; } }
        public string FechaCreacion { set { fechaCreacion = value; } get { return fechaCreacion; } }
        //Constructor
        public csLibro() { }
        //Metodos Libros
        public DataGridView MostrarLibros(DataGridView Tabla)
        {
            if (Tabla.RowCount >= 0) { Tabla.Rows.Clear(); }
            int f = 0, z = 0;
            Tabla.Columns[Tabla.ColumnCount - 1].Width = 50;
            Tabla.Columns[Tabla.ColumnCount - 1].CellTemplate.Style.Padding = new Padding(1);
            string consulta = "Select L.IdLibro, L.Titulo, G.Genero, E.Editorial, L.Ubicacion, L.Cantidad, L.Estado from LIBRO L " +
            "Join GENERO G on G.IdGenero = L.IdGenero Join EDITORIAL E on E.IdEditorial = L.IdEditorial";
            DataTable TablaTemporal = dataBase.Registros(consulta);
            if (TablaTemporal.Rows.Count >= 5) { z = 12; }
            foreach (DataRow row in TablaTemporal.Rows)
            {
                int x = 0;
                Tabla.Rows.Add(); 
                Tabla.Rows[f].Height = 50;
                Tabla.Columns[Tabla.ColumnCount - 1].Width = 50;
                object[] vector = row.ItemArray;
                for (int c = 0; c < Tabla.ColumnCount - 1; c++)
                {
                    if (c != 2)
                        Tabla.Rows[f].Cells[c].Value = vector[x++].ToString();
                    else
                    {
                        string nombre = "";
                        codigo = Tabla.Rows[f].Cells["Codigo"].Value.ToString();
                        string[] autores = dataBase.ExtraerAutores("Select * from AUTOR_LIBRO where IdLibro = '" + codigo + "'", "IdAutor").Split(',');
                        foreach (string autor in autores)
                        {
                            if (nombre != "") { nombre += ", " + dataBase.Extraer("Select * from AUTOR where IdAutor = '" + autor + "'", "Autor"); }
                            else { nombre += dataBase.Extraer("Select * from AUTOR where IdAutor = '" + autor + "'", "Autor"); }
                        }
                        Tabla.Rows[f].Cells[2].Value = nombre;
                    }
                }
                Tabla.Rows[f].Cells["Estado"].Value = Tabla.Rows[f].Cells["Estado"].Value.ToString() == "True" ? Tabla.Rows[f].Cells["Estado"].Value = "Activo" : Tabla.Rows[f].Cells["Estado"].Value = "Inactivo";
                Tabla.Rows[f].Cells[Tabla.ColumnCount - 1].Value = Image.FromFile(@"C:\Users\Khriz\Downloads\editar.ico");
                f++;
            }
            for (int i = 0; i < Tabla.ColumnCount - 1; i++)
            {
                Tabla.Columns[i].Width = ((Tabla.Width - 50 - z) / (Tabla.ColumnCount - 1))-1;
                Tabla.Columns[i].Resizable = DataGridViewTriState.False;
            }
            return Tabla;
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
            formulario.txtAutor.Enabled = valor;
            formulario.btnSeleccionar.Enabled = valor;
            formulario.btnGuardar.Enabled = valor;
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
                codigo = titulo.Substring(0, 2).ToUpper() + new Random().Next(10000, 99999);
                if (estado == "Activo") { estado = "1"; } else { estado = "0"; }
                genero = dataBase.Extraer("Select IdGenero From GENERO Where Genero = '" + genero + "'", "IdGenero");
                editorial = dataBase.Extraer("Select IdEditorial From EDITORIAL Where Editorial = '" + editorial + "'", "IdEditorial");
                string consulta = "Insert into LIBRO(IdLibro, Titulo, IdGenero, IdEditorial, Ubicacion, Cantidad, Estado, FechaCreacion)" +
                $"Values('{codigo}', '{titulo}', '{genero}', '{editorial}', '{ubicacion}', '{cantidad}', '{estado}', '{DateTime.Now.ToString("dd-MM-yyyy")}')";
                dataBase.Actualizar(consulta);
                if (autor.Contains(','))
                {
                    string[] autores = autor.Split(',');
                    foreach (string item in autores)
                    {
                        string ID = dataBase.Extraer($"Select * From AUTOR Where Autor = '{item.Trim()}'", "IdAutor");
                        string sentencia = "Insert into AUTOR_LIBRO(IdAutor_Libro, IdLibro, IdAutor)" +
                        $" Values('{titulo.Substring(0, 2).ToUpper() + new Random().Next(10000, 99999)}', '{codigo}', '{ID}')";
                        dataBase.Actualizar(sentencia);
                    }
                }
                else
                {
                    string ID = dataBase.Extraer($"Select * From AUTOR Where Autor = '{autor.Trim()}'", "IdAutor");
                    string sentencia = "Insert into AUTOR_LIBRO(IdAutor_Libro, IdLibro, IdAutor)" +
                    $" Values('{titulo.Substring(0, 2).ToUpper() + new Random().Next(10000, 99999)}', '{codigo}', '{ID}')";
                    dataBase.Actualizar(sentencia);
                }
                if (portada.Image != null)
                {
                    string sentencia = $"Update LIBRO set Foto = @imagen where IdLibro = '{codigo}'";
                    dataBase.GuardarImagen(portada, sentencia);
                }
            } catch(Exception) { return false; }
            return true;
        }
        public bool ActualizarLibro(string titulo, string autor, string genero, string editorial, string ubicacion, string cantidad, string estado, PictureBox portada)
        {
            try
            {
                if (estado == "Activo") { estado = "1"; } else { estado = "0"; }
                genero = dataBase.Extraer("Select IdGenero From GENERO Where Genero = '" + genero + "'", "IdGenero");
                editorial = dataBase.Extraer("Select IdEditorial From EDITORIAL Where Editorial = '" + editorial + "'", "IdEditorial");
                string consulta = "Update LIBRO set Titulo = '" + titulo + "', IdGenero = '" + genero + "', IdEditorial = '" + editorial + "', Ubicacion = '" + ubicacion + "', " +
                "Cantidad = '" + cantidad + "', Estado = '" + estado + "' Where IdLibro = '" + codigo + "'";
                dataBase.Actualizar(consulta);
                if (portada.Image != null)
                {
                    string sentencia = $"Update LIBRO set Foto = @imagen where IdLibro = '{codigo}'";
                    dataBase.GuardarImagen(portada, sentencia);
                }
            }
            catch (Exception) { return false; }
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
