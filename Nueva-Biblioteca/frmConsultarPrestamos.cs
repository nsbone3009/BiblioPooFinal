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
    public partial class frmConsultarPrestamos : Form
    {
        static private frmConsultarPrestamos instancia = null;
        csConexionDataBase database = new csConexionDataBase();
        string consulta;
        public static frmConsultarPrestamos Formulario()
        {
            if (instancia == null) { instancia = new frmConsultarPrestamos(); }
            return instancia;
        }
        public frmConsultarPrestamos()
        {
            InitializeComponent();
        }
        private void frmConsultarPrestamos_Load(object sender, EventArgs e)
        {
            csGestionPrestamos gestionPrestamos = new csGestionPrestamos();
            List<string> lectores = gestionPrestamos.comboBoxLector();
            cbLectores.DataSource = lectores;
            cbEstado.SelectedIndex = 0;
            Mostrar();
        }
        private void dgvPrestamos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPrestamos.Columns[e.ColumnIndex].Name == "btnEntregarLibro")
            {
                frmDevolverLibro frm = new frmDevolverLibro();
                this.AddOwnedForm(frm);
                frm.rtxEstadoEntrega.Text = database.Extraer("select EstadoEntregado from PRESTAMO where IdPrestamo = '" + dgvPrestamos.Rows[e.RowIndex].Cells[0].Value.ToString().Trim() + "'", "EstadoEntregado").Trim();
                frm.rtxEstadoEntrega.Enabled = false;
                if (dgvPrestamos.Rows[e.RowIndex].Cells[6].Value.ToString().Trim() == "Pendiente")
                {
                    frm.ID = dgvPrestamos.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                    frm.ShowDialog();
                }
                else
                {
                    frm.rtxEstadoDevuelto.Text = database.Extraer("select EstadoRecibido from PRESTAMO where IdPrestamo = '" + dgvPrestamos.Rows[e.RowIndex].Cells[0].Value.ToString().Trim() + "'", "EstadoRecibido").Trim();
                    frm.rtxEstadoDevuelto.Enabled = false;
                    frm.btnGuardar.Enabled = false;
                    frm.btnGuardar.Visible = false;
                    frm.ShowDialog();
                }
            }
        }
        public void Mostrar()
        {
            string consulta0 = @"select P.IdPrestamo,P.IdLector, L.Nombres, LI.Titulo, P.FechaDevolucion, P.FechaConfirmacionDevolucion, P.Estado from PRESTAMO P 
                                join LECTOR L on P.IdLector = L.IdLector 
                                join LIBRO LI on P.IdLibro = LI.IdLibro";
            dgvPrestamos = new csGestionPrestamos().Mostrar(dgvPrestamos, consulta0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string idLector = cbLectores.SelectedItem.ToString().TrimEnd();
            int estado = cbEstado.SelectedIndex;
            if (estado == 0 && idLector == "--Seleccionar Todos--")
                Mostrar();
            else
            {
                consulta = new csGestionPrestamos().GenerarConsultaFiltro(estado, idLector);
                dgvPrestamos.Rows.Clear();
                dgvPrestamos = new csGestionPrestamos().Mostrar(dgvPrestamos, consulta);
            }
        }
    }
}
