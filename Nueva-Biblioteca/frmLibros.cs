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
            dgvLibros = claseLibro.MostrarLibros(dgvLibros);
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
                string aux = txtBuscar.Text;
                aux = verificar.VerificarEstado(aux);
                string consulta = "select L.IdLibro, L.Titulo, A.Autor, G.Genero, E.Editorial, L.Ubicacion, L.Cantidad, L.Estado from LIBRO L join AUTOR_LIBRO AL on L.IdLibro = AL.IdLibro join AUTOR A on A.IdAutor = AL.IdAutor join GENERO G on L.IdGenero = G.IdGenero join EDITORIAL E on L.IdEditorial = E.IdEditorial where L.IdLibro like '%" + txtBuscar.Text + "%'"+ 
                    "or L.Titulo like '%" + aux + "%' " +
                    "or A.Autor like '%" + aux + "%'" + 
                    "or G.Genero like '%" + aux + "%'" +  
                    "or E.Editorial like '%"+ aux + "%'" +
                    "or L.Estado like '%" + aux + "%'" +
                    "or L.Ubicacion like '%" + aux + "%'";
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
