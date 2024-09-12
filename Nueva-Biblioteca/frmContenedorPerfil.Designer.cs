
namespace Nueva_Biblioteca
{
    partial class frmContenedorPerfil
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
            this.contenedorPerfil = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // contenedorPerfil
            // 
            this.contenedorPerfil.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contenedorPerfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.contenedorPerfil.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenedorPerfil.FormattingEnabled = true;
            this.contenedorPerfil.ItemHeight = 19;
            this.contenedorPerfil.Items.AddRange(new object[] {
            "Cambiar Clave",
            "Cerrar Sesion"});
            this.contenedorPerfil.Location = new System.Drawing.Point(0, 0);
            this.contenedorPerfil.Name = "contenedorPerfil";
            this.contenedorPerfil.Size = new System.Drawing.Size(136, 38);
            this.contenedorPerfil.Sorted = true;
            this.contenedorPerfil.TabIndex = 8;
            this.contenedorPerfil.SelectedIndexChanged += new System.EventHandler(this.contenedorPerfil_SelectedIndexChanged);
            // 
            // frmContenedorPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 40);
            this.Controls.Add(this.contenedorPerfil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmContenedorPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox contenedorPerfil;
    }
}