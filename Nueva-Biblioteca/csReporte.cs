using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;

namespace Nueva_Biblioteca
{
    class csReporte
    {
        public void GenerarReporte(ReportViewer reporte, string consulta, string informe, string nombreTabla)
        {
            reporte.LocalReport.DataSources.Clear();
            csConexionDataBase conexion = new csConexionDataBase();
            ReportDataSource DatosReporte = new ReportDataSource();
            DataTable tabla = conexion.Registros(consulta);
            reporte.LocalReport.ReportEmbeddedResource = "Nueva_Biblioteca." + informe;
            try { DatosReporte = new ReportDataSource(nombreTabla); }
            catch { }
            reporte.LocalReport.DataSources.Add(DatosReporte);
            DatosReporte.Value = tabla;
            reporte.LocalReport.Refresh();
        }
    }
}
