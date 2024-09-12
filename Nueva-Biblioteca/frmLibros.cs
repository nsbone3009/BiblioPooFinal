using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nueva_Biblioteca
{
    public partial class frmLibros : Form
    {
        private static csLibro claseLibro = new csLibro();
        public bool bandera = false;
        static private frmLibros instancia = null;

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

    }
}
