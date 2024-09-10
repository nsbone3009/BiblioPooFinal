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
    public partial class frmRepoTOP5 : Form
    {
        
        public frmRepoTOP5()
        {
            InitializeComponent();
        }
        csConexionDataBase conexion = new csConexionDataBase();
        private void frmRepoTOP5_Load(object sender, EventArgs e)
        {
            string consulta = "SELECT TOP (5) COUNT(IdLibro) AS cant, Titulo\r\nFROM (SELECT P.IdPrestamo, P.IdLibro, L.Titulo\r\nFROM PRESTAMO AS P INNER JOIN\r\nLIBRO AS L ON P.IdLibro = L.IdLibro) AS x\r\nGROUP BY Titulo\r\nORDER BY cant DESC";
            DataTable dt = conexion.Registros(consulta);
            ReportDataSource rds = new ReportDataSource("dsTop5", dt);
            EjecutarReporte(rds);
        }
        private void EjecutarReporte(ReportDataSource rds)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }
    }
}
