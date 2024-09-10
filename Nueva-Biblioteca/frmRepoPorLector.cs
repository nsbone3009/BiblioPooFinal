using Microsoft.Reporting.WinForms;
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
    public partial class frmRepoPorLector : Form
    {
        public frmRepoPorLector()
        {
            InitializeComponent();
        }
        csConexionDataBase conexion = new csConexionDataBase();
        public void generarReporte(string nombre)
        {
            string consulta = $"SELECT L.Nombres + ' ' + L.Apellidos AS Nombre, LB.Titulo, E.Editorial, G.Genero\r\nFROM PRESTAMO AS p INNER JOIN\r\nLECTOR AS L ON p.IdLector = L.IdLector INNER JOIN\r\nLIBRO AS LB ON p.IdLibro = LB.IdLibro INNER JOIN\r\nEDITORIAL AS E ON LB.IdEditorial = E.IdEditorial INNER JOIN\r\nGENERO AS G ON G.IdGenero = LB.IdGenero\r\nWHERE        (L.Nombres = '{nombre}')";
            DataTable dt = conexion.Registros(consulta);
            ReportDataSource rds = new ReportDataSource("dsPrestamoPorLector", dt);
            EjecutarReporte(rds);
        }
        private void EjecutarReporte(ReportDataSource rds)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
        private void frmRepoPorLector_Load(object sender, EventArgs e)
        {
        }
    }
}
