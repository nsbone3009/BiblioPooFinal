using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Nueva_Biblioteca
{
    public partial class frmLibros : Form
    {
        private static csLibro claseLibro = new csLibro();
        public bool bandera = false;
        static csEditorial clase = new csEditorial();
        static private frmLibros instancia = null;
        static csLLenarDataGridView buscar = new csLLenarDataGridView();
        private csReutilizacion verificar = new csReutilizacion();

        public static frmLibros Formulario()
        {
            if (instancia == null) { instancia = new frmLibros(); }
            return instancia;
        }
        public frmLibros()
        {
            InitializeComponent();
        }
        private void btnCrear_Click(object sender, EventArgs e)
        {
            frmAgregarOEditarLibro frm = new frmAgregarOEditarLibro();
            this.AddOwnedForm(frm);
            bandera = true;
            claseLibro.MostrarListas(frm);
            frm.btnEditar.Visible = false;
            frm.cbEstado.SelectedItem = "Activo";
            frm.ShowDialog();
            claseLibro.LimpiarCampos(frm);
        }
        private void frmLibros_Load(object sender, EventArgs e)
        {
            claseLibro.MostrarLibros(dgvLibros);
        }
        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {   
            if (e.ColumnIndex == dgvLibros.Columns[dgvLibros.ColumnCount - 1].Index && e.RowIndex >= 0) //Boton Editar
            {
                frmAgregarOEditarLibro frm = new frmAgregarOEditarLibro();
                this.AddOwnedForm(frm);
                claseLibro.ObtenerDatosSeleccion(dgvLibros, e.RowIndex); 
                claseLibro.MostrarListas(frm);
                claseLibro.MostrarDatosSeleccion(frm);
                claseLibro.MostrarPortadaLibro(frm);
                claseLibro.HabilitarCampos(frm, false);
                frm.btnEditar.Visible = true;
                frm.ShowDialog();
                claseLibro.LimpiarCampos(frm);
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length >= 3)
            {
                string consulta = @"SELECT L.IdLibro, L.Titulo, STRING_AGG(A.Autor, ', ') AS Autores, G.Genero, E.Editorial, L.Ubicacion, L.Cantidad,
                           CASE WHEN  L.Estado = 1  THEN 'Activo' ELSE 'Inactivo' END AS Estado, L.FechaCreacion 
                           FROM LIBRO L 
                           JOIN GENERO G ON G.IdGenero = L.IdGenero 
                           JOIN EDITORIAL E ON E.IdEditorial = L.IdEditorial 
                           JOIN AUTOR_LIBRO AL ON AL.IdLibro = L.IdLibro 
                           JOIN AUTOR A ON  A.IdAutor = AL.IdAutor 
                           GROUP BY L.IdLibro, L.Titulo, G.Genero, E.Editorial, L.Ubicacion, L.Cantidad, L.Estado, L.FechaCreacion " +
                           $"HAVING STRING_AGG(A.Autor, ', ') LIKE '%{ txtBuscar.Text}%' OR L.Titulo LIKE '%{txtBuscar.Text}%' OR G.Genero LIKE '%{txtBuscar.Text}%' OR L.Ubicacion LIKE '%{txtBuscar.Text}%'";
                dgvLibros.Rows.Clear();
                buscar.Mostrar(dgvLibros, consulta, 1);
            }
            else
            {
                dgvLibros.Rows.Clear();
                claseLibro.MostrarLibros(dgvLibros);
            }
        }
    }
}
