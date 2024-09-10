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
    public partial class frmDevolverLibro : Form
    {

        csConexionDataBase database = new csConexionDataBase();
        csGestionPrestamos gestionPrestamos = new csGestionPrestamos();
        public string ID = "";
        private int cantidad = 0;
        public frmDevolverLibro()
        {
            InitializeComponent();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (rtxEstadoDevuelto.Text != "")
            {
                List<string> datos = gestionPrestamos.IdYLibro(ID);
                frmConsultarPrestamos frm = Owner as frmConsultarPrestamos; cantidad = int.Parse(datos[1].Trim()) + 1;
                database.Actualizar("update PRESTAMO set Estado = '" + 0 + "', EstadoRecibido = '" + rtxEstadoDevuelto.Text.TrimEnd().TrimStart() + "',FechaConfirmacionDevolucion = '"+ DateTime.Now.ToString("yyyy-MM-dd") + "' where IdPrestamo = '" + ID + "'");
                database.Actualizar("update LIBRO set cantidad = '"+cantidad+"' where IdLibro = '"+datos[0].Trim()+"'");
                frm.dgvPrestamos.Rows.Clear(); frm.Mostrar(); this.Close();
            }
            else
                MessageBox.Show("Faltan campos por llenar");
        }
        private void frmDevolverLibro_Load(object sender, EventArgs e)
        {
        }
        private void lbCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
