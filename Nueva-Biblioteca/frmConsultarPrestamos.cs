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
        static csGestionPrestamos gestionPrestamos = new csGestionPrestamos();
        static csConexionDataBase database = new csConexionDataBase();
        List<string> lectores = new List<string>();
        public static frmConsultarPrestamos Formulario()
        {
            if (instancia == null) { instancia = new frmConsultarPrestamos(); }
            return instancia;
        }
        public frmConsultarPrestamos()
        {
            InitializeComponent();
            lectores.Add("--Seleccionar Todos--");
            database.Lista(@"select distinct L.Nombres from PRESTAMO P join LECTOR L on P.IdLector = L.IdLector", lectores);
        }
        private void frmConsultarPrestamos_Load(object sender, EventArgs e)
        {
            cbLectores.DataSource = lectores;
            cbEstado.SelectedIndex = 0;
            Mostrar();
        }
        private void dgvPrestamos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPrestamos.Columns[dgvPrestamos.ColumnCount - 1].Index && e.RowIndex >= 0)
            {
                frmDevolverLibro frm = new frmDevolverLibro(); frm.rtxEstadoEntrega.Enabled = false; this.AddOwnedForm(frm); Limpiar();
                frm.rtxEstadoEntrega.Text = gestionPrestamos.ExtraerEstado(dgvPrestamos.Rows[e.RowIndex].Cells[0].Value.ToString().Trim(), "EstadoEntregado");
                if (dgvPrestamos.Rows[e.RowIndex].Cells[6].Value.ToString().Trim() == "Pendiente")
                {
                    frm.ID = dgvPrestamos.Rows[e.RowIndex].Cells[0].Value.ToString().Trim(); frm.ShowDialog();
                }
                else
                {
                    frm.rtxEstadoDevuelto.Text = gestionPrestamos.ExtraerEstado(dgvPrestamos.Rows[e.RowIndex].Cells[0].Value.ToString().Trim(), "EstadoRecibido");
                    frm.rtxEstadoDevuelto.Enabled = false; frm.btnGuardar.Enabled = false; frm.btnGuardar.Visible = false; frm.ShowDialog();
                }
            }
        }
        public void Mostrar()
        {
            string consulta = @"SELECT P.IdPrestamo, P.IdLector, L.Nombres, LI.Titulo, P.FechaDevolucion, P.FechaConfirmacionDevolucion, P.Estado 
                                FROM PRESTAMO P 
                                JOIN LECTOR L ON P.IdLector = L.IdLector 
                                JOIN LIBRO LI ON P.IdLibro = LI.IdLibro";
            new csLLenarDataGridView().Mostrar(dgvPrestamos,consulta, 3);
        }
        private void BusquedaCb()
        {
            string idLector = cbLectores.SelectedItem.ToString().TrimEnd();
            int estado = cbEstado.SelectedIndex;
            if (estado == 0 && idLector == "--Seleccionar Todos--")
                Mostrar();
            else
            {
                string consulta = gestionPrestamos.GenerarConsultaFiltro(estado, idLector);
                new csLLenarDataGridView().Mostrar(dgvPrestamos, consulta, 3);
            }
        }
        private void cbLectores_SelectedIndexChanged(object sender, EventArgs e)
        {
            BusquedaCb();
        }
        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            BusquedaCb();
        }
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            cbEstado.SelectedIndex = 0; cbLectores.SelectedIndex = 0;
            if (txtBusqueda.Text.Length >= 3)
                gestionPrestamos.BusquedaPorCaracter(dgvPrestamos, txtBusqueda.Text);
            else
                Mostrar();
        }
        private void Limpiar()
        {
            cbEstado.SelectedIndex = 0; cbLectores.SelectedIndex = 0; txtBusqueda.Clear();
        }
    }
}
