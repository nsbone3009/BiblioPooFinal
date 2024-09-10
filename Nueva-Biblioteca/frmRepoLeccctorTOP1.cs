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
    public partial class frmRepoLeccctorTOP1 : Form
    {
        public frmRepoLeccctorTOP1()
        {
            InitializeComponent();
        }
        csConexionDataBase conexion = new csConexionDataBase();
        private void frmRepoLeccctorTOP1_Load(object sender, EventArgs e)
        {
            string consulta = "SELECT TOP (1) COUNT(p.IdLector) AS cantidad, L.Nombres + ' ' + L.Apellidos AS Lector\r\nFROM PRESTAMO AS p INNER JOIN\r\nLECTOR AS L ON p.IdLector = L.IdLector\r\nGROUP BY L.Nombres, L.Apellidos\r\nORDER BY cantidad DESC";
            DataTable dt = conexion.Registros(consulta);
            ReportDataSource rds = new ReportDataSource("dsLectorFrecuente", dt);
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
