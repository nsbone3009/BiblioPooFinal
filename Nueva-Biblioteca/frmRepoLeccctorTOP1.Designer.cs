namespace Nueva_Biblioteca
{
    partial class frmRepoLeccctorTOP1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dSbiblioteca = new Nueva_Biblioteca.DSbiblioteca();
            this.lectorFrecuenteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lectorFrecuenteTableAdapter = new Nueva_Biblioteca.DSbibliotecaTableAdapters.LectorFrecuenteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dSbiblioteca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lectorFrecuenteBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.lectorFrecuenteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Nueva_Biblioteca.rpMejorLector.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dSbiblioteca
            // 
            this.dSbiblioteca.DataSetName = "DSbiblioteca";
            this.dSbiblioteca.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lectorFrecuenteBindingSource
            // 
            this.lectorFrecuenteBindingSource.DataMember = "LectorFrecuente";
            this.lectorFrecuenteBindingSource.DataSource = this.dSbiblioteca;
            // 
            // lectorFrecuenteTableAdapter
            // 
            this.lectorFrecuenteTableAdapter.ClearBeforeFill = true;
            // 
            // frmRepoLeccctorTOP1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRepoLeccctorTOP1";
            this.Text = "frmRepoLeccctorTOP1";
            this.Load += new System.EventHandler(this.frmRepoLeccctorTOP1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSbiblioteca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lectorFrecuenteBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DSbiblioteca dSbiblioteca;
        private System.Windows.Forms.BindingSource lectorFrecuenteBindingSource;
        private DSbibliotecaTableAdapters.LectorFrecuenteTableAdapter lectorFrecuenteTableAdapter;
    }
}