namespace Nueva_Biblioteca
{
    partial class frmPantallaPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPantallaPrincipal));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRepo = new System.Windows.Forms.Button();
            this.contenedorPrestamos = new System.Windows.Forms.ListBox();
            this.ptbxPrestamo = new System.Windows.Forms.PictureBox();
            this.btnPrestamo = new System.Windows.Forms.Button();
            this.contenedorPersonas = new System.Windows.Forms.ListBox();
            this.ptbxPersona = new System.Windows.Forms.PictureBox();
            this.btnPersona = new System.Windows.Forms.Button();
            this.ptbxBiblioteca = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBiblioteca = new System.Windows.Forms.Button();
            this.btnResumen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contenedorBiblioteca = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contenedorPerfil = new System.Windows.Forms.ListBox();
            this.ptbxPerfil = new System.Windows.Forms.PictureBox();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.ListaFlecha = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbxPrestamo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbxPersona)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbxBiblioteca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbxPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(73)))), ((int)(((byte)(174)))));
            this.panel1.Controls.Add(this.btnRepo);
            this.panel1.Controls.Add(this.contenedorPrestamos);
            this.panel1.Controls.Add(this.ptbxPrestamo);
            this.panel1.Controls.Add(this.btnPrestamo);
            this.panel1.Controls.Add(this.contenedorPersonas);
            this.panel1.Controls.Add(this.ptbxPersona);
            this.panel1.Controls.Add(this.btnPersona);
            this.panel1.Controls.Add(this.ptbxBiblioteca);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnBiblioteca);
            this.panel1.Controls.Add(this.btnResumen);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.contenedorBiblioteca);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 700);
            this.panel1.TabIndex = 3;
            // 
            // btnRepo
            // 
            this.btnRepo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRepo.FlatAppearance.BorderSize = 0;
            this.btnRepo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnRepo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnRepo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepo.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRepo.ForeColor = System.Drawing.Color.White;
            this.btnRepo.Location = new System.Drawing.Point(0, 415);
            this.btnRepo.Margin = new System.Windows.Forms.Padding(0);
            this.btnRepo.Name = "btnRepo";
            this.btnRepo.Size = new System.Drawing.Size(180, 40);
            this.btnRepo.TabIndex = 13;
            this.btnRepo.Text = "Reportes";
            this.btnRepo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRepo.UseVisualStyleBackColor = true;
            this.btnRepo.Click += new System.EventHandler(this.btnRepo_Click);
            // 
            // contenedorPrestamos
            // 
            this.contenedorPrestamos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contenedorPrestamos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.contenedorPrestamos.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenedorPrestamos.FormattingEnabled = true;
            this.contenedorPrestamos.ItemHeight = 19;
            this.contenedorPrestamos.Items.AddRange(new object[] {
            "Consulta",
            "Registro"});
            this.contenedorPrestamos.Location = new System.Drawing.Point(12, 518);
            this.contenedorPrestamos.Name = "contenedorPrestamos";
            this.contenedorPrestamos.Size = new System.Drawing.Size(154, 40);
            this.contenedorPrestamos.Sorted = true;
            this.contenedorPrestamos.TabIndex = 12;
            this.contenedorPrestamos.SelectedIndexChanged += new System.EventHandler(this.contenedorPrestamos_SelectedIndexChanged);
            // 
            // ptbxPrestamo
            // 
            this.ptbxPrestamo.BackColor = System.Drawing.Color.Transparent;
            this.ptbxPrestamo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbxPrestamo.Location = new System.Drawing.Point(150, 287);
            this.ptbxPrestamo.Name = "ptbxPrestamo";
            this.ptbxPrestamo.Size = new System.Drawing.Size(16, 16);
            this.ptbxPrestamo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbxPrestamo.TabIndex = 11;
            this.ptbxPrestamo.TabStop = false;
            // 
            // btnPrestamo
            // 
            this.btnPrestamo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrestamo.FlatAppearance.BorderSize = 0;
            this.btnPrestamo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrestamo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrestamo.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrestamo.ForeColor = System.Drawing.Color.White;
            this.btnPrestamo.Location = new System.Drawing.Point(0, 274);
            this.btnPrestamo.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrestamo.Name = "btnPrestamo";
            this.btnPrestamo.Size = new System.Drawing.Size(180, 40);
            this.btnPrestamo.TabIndex = 10;
            this.btnPrestamo.Text = "Prestamo";
            this.btnPrestamo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrestamo.UseVisualStyleBackColor = true;
            this.btnPrestamo.Click += new System.EventHandler(this.btnPrestamo_Click);
            // 
            // contenedorPersonas
            // 
            this.contenedorPersonas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contenedorPersonas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.contenedorPersonas.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenedorPersonas.FormattingEnabled = true;
            this.contenedorPersonas.ItemHeight = 19;
            this.contenedorPersonas.Items.AddRange(new object[] {
            " Lectores",
            " Usuarios"});
            this.contenedorPersonas.Location = new System.Drawing.Point(12, 564);
            this.contenedorPersonas.Name = "contenedorPersonas";
            this.contenedorPersonas.Size = new System.Drawing.Size(154, 40);
            this.contenedorPersonas.Sorted = true;
            this.contenedorPersonas.TabIndex = 9;
            this.contenedorPersonas.SelectedIndexChanged += new System.EventHandler(this.contenedorPersonas_SelectedIndexChanged);
            // 
            // ptbxPersona
            // 
            this.ptbxPersona.BackColor = System.Drawing.Color.Transparent;
            this.ptbxPersona.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbxPersona.Location = new System.Drawing.Point(150, 235);
            this.ptbxPersona.Name = "ptbxPersona";
            this.ptbxPersona.Size = new System.Drawing.Size(16, 16);
            this.ptbxPersona.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbxPersona.TabIndex = 8;
            this.ptbxPersona.TabStop = false;
            // 
            // btnPersona
            // 
            this.btnPersona.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPersona.FlatAppearance.BorderSize = 0;
            this.btnPersona.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPersona.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPersona.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPersona.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPersona.ForeColor = System.Drawing.Color.White;
            this.btnPersona.Location = new System.Drawing.Point(0, 222);
            this.btnPersona.Margin = new System.Windows.Forms.Padding(0);
            this.btnPersona.Name = "btnPersona";
            this.btnPersona.Size = new System.Drawing.Size(180, 40);
            this.btnPersona.TabIndex = 7;
            this.btnPersona.Text = "Persona";
            this.btnPersona.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersona.UseVisualStyleBackColor = true;
            this.btnPersona.Click += new System.EventHandler(this.btnPersona_Click);
            // 
            // ptbxBiblioteca
            // 
            this.ptbxBiblioteca.BackColor = System.Drawing.Color.Transparent;
            this.ptbxBiblioteca.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbxBiblioteca.Location = new System.Drawing.Point(150, 184);
            this.ptbxBiblioteca.Name = "ptbxBiblioteca";
            this.ptbxBiblioteca.Size = new System.Drawing.Size(16, 16);
            this.ptbxBiblioteca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbxBiblioteca.TabIndex = 2;
            this.ptbxBiblioteca.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiLight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gestion";
            // 
            // btnBiblioteca
            // 
            this.btnBiblioteca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBiblioteca.FlatAppearance.BorderSize = 0;
            this.btnBiblioteca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBiblioteca.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBiblioteca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBiblioteca.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBiblioteca.ForeColor = System.Drawing.Color.White;
            this.btnBiblioteca.Location = new System.Drawing.Point(0, 170);
            this.btnBiblioteca.Margin = new System.Windows.Forms.Padding(0);
            this.btnBiblioteca.Name = "btnBiblioteca";
            this.btnBiblioteca.Size = new System.Drawing.Size(180, 40);
            this.btnBiblioteca.TabIndex = 6;
            this.btnBiblioteca.Text = "Biblioteca";
            this.btnBiblioteca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBiblioteca.UseVisualStyleBackColor = true;
            this.btnBiblioteca.Click += new System.EventHandler(this.btnBiblioteca_Click);
            // 
            // btnResumen
            // 
            this.btnResumen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResumen.FlatAppearance.BorderSize = 0;
            this.btnResumen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnResumen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnResumen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResumen.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResumen.ForeColor = System.Drawing.Color.White;
            this.btnResumen.Location = new System.Drawing.Point(0, 90);
            this.btnResumen.Margin = new System.Windows.Forms.Padding(0);
            this.btnResumen.Name = "btnResumen";
            this.btnResumen.Size = new System.Drawing.Size(180, 40);
            this.btnResumen.TabIndex = 5;
            this.btnResumen.Text = "Resumen";
            this.btnResumen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResumen.UseVisualStyleBackColor = true;
            this.btnResumen.Click += new System.EventHandler(this.btnResumen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 60);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // contenedorBiblioteca
            // 
            this.contenedorBiblioteca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contenedorBiblioteca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.contenedorBiblioteca.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenedorBiblioteca.FormattingEnabled = true;
            this.contenedorBiblioteca.ItemHeight = 19;
            this.contenedorBiblioteca.Items.AddRange(new object[] {
            " Autor",
            " Editorial",
            " Genero",
            " Libro"});
            this.contenedorBiblioteca.Location = new System.Drawing.Point(12, 610);
            this.contenedorBiblioteca.Name = "contenedorBiblioteca";
            this.contenedorBiblioteca.Size = new System.Drawing.Size(154, 78);
            this.contenedorBiblioteca.Sorted = true;
            this.contenedorBiblioteca.TabIndex = 0;
            this.contenedorBiblioteca.SelectedIndexChanged += new System.EventHandler(this.contenedorBiblioteca_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.contenedorPerfil);
            this.panel2.Controls.Add(this.ptbxPerfil);
            this.panel2.Controls.Add(this.lbUsuario);
            this.panel2.Location = new System.Drawing.Point(180, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 60);
            this.panel2.TabIndex = 4;
            // 
            // contenedorPerfil
            // 
            this.contenedorPerfil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contenedorPerfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.contenedorPerfil.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contenedorPerfil.FormattingEnabled = true;
            this.contenedorPerfil.ItemHeight = 19;
            this.contenedorPerfil.Items.AddRange(new object[] {
            "Cambiar Clave",
            "Cerrar Sesion"});
            this.contenedorPerfil.Location = new System.Drawing.Point(721, 12);
            this.contenedorPerfil.Name = "contenedorPerfil";
            this.contenedorPerfil.Size = new System.Drawing.Size(125, 40);
            this.contenedorPerfil.Sorted = true;
            this.contenedorPerfil.TabIndex = 7;
            this.contenedorPerfil.SelectedIndexChanged += new System.EventHandler(this.contenedorPerfil_SelectedIndexChanged);
            // 
            // ptbxPerfil
            // 
            this.ptbxPerfil.BackColor = System.Drawing.Color.Transparent;
            this.ptbxPerfil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptbxPerfil.BackgroundImage")));
            this.ptbxPerfil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbxPerfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbxPerfil.Location = new System.Drawing.Point(964, 5);
            this.ptbxPerfil.Name = "ptbxPerfil";
            this.ptbxPerfil.Size = new System.Drawing.Size(50, 50);
            this.ptbxPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbxPerfil.TabIndex = 1;
            this.ptbxPerfil.TabStop = false;
            this.ptbxPerfil.Click += new System.EventHandler(this.ptbxPerfil_Click);
            // 
            // lbUsuario
            // 
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuario.Location = new System.Drawing.Point(852, 21);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(109, 19);
            this.lbUsuario.TabIndex = 0;
            this.lbUsuario.Text = "Khriz Coronel";
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Location = new System.Drawing.Point(180, 60);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1020, 640);
            this.pnlPrincipal.TabIndex = 5;
            // 
            // ListaFlecha
            // 
            this.ListaFlecha.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ListaFlecha.ImageStream")));
            this.ListaFlecha.TransparentColor = System.Drawing.Color.Transparent;
            this.ListaFlecha.Images.SetKeyName(0, "imgFlechaDerecha.png");
            this.ListaFlecha.Images.SetKeyName(1, "imgFlechaAbajo.png");
            // 
            // frmPantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPantallaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPantallaPrincipal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbxPrestamo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbxPersona)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbxBiblioteca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbxPerfil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnResumen;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.PictureBox ptbxPerfil;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.PictureBox ptbxBiblioteca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBiblioteca;
        private System.Windows.Forms.ImageList ListaFlecha;
        private System.Windows.Forms.ListBox contenedorBiblioteca;
        private System.Windows.Forms.ListBox contenedorPerfil;
        private System.Windows.Forms.PictureBox ptbxPersona;
        private System.Windows.Forms.Button btnPersona;
        private System.Windows.Forms.ListBox contenedorPersonas;
        private System.Windows.Forms.ListBox contenedorPrestamos;
        private System.Windows.Forms.PictureBox ptbxPrestamo;
        private System.Windows.Forms.Button btnPrestamo;
        private System.Windows.Forms.Button btnRepo;
    }
}

