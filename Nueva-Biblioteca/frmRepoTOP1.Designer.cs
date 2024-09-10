namespace Nueva_Biblioteca
{
    partial class frmRepoTOP1
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
            this.dSbibliotecaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.top1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.top1TableAdapter = new Nueva_Biblioteca.DSbibliotecaTableAdapters.Top1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dSbiblioteca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSbibliotecaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.top1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.top1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Nueva_Biblioteca.LibroMasPrestado.rdlc";
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
            // dSbibliotecaBindingSource
            // 
            this.dSbibliotecaBindingSource.DataSource = this.dSbiblioteca;
            this.dSbibliotecaBindingSource.Position = 0;
            // 
            // top1BindingSource
            // 
            this.top1BindingSource.DataMember = "Top1";
            this.top1BindingSource.DataSource = this.dSbiblioteca;
            // 
            // top1TableAdapter
            // 
            this.top1TableAdapter.ClearBeforeFill = true;
            // 
            // frmRepoTOP1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRepoTOP1";
            this.Text = "frmRepoTOP1";
            this.Load += new System.EventHandler(this.frmRepoTOP1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSbiblioteca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSbibliotecaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.top1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DSbiblioteca dSbiblioteca;
        private System.Windows.Forms.BindingSource dSbibliotecaBindingSource;
        private System.Windows.Forms.BindingSource top1BindingSource;
        private DSbibliotecaTableAdapters.Top1TableAdapter top1TableAdapter;
    }
}