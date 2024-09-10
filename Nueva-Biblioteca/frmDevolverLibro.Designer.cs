
namespace Nueva_Biblioteca
{
    partial class frmDevolverLibro
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
            this.wvno = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lbCerrar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtxEstadoDevuelto = new System.Windows.Forms.RichTextBox();
            this.rtxEstadoEntrega = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // wvno
            // 
            this.wvno.AutoSize = true;
            this.wvno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wvno.Location = new System.Drawing.Point(24, 55);
            this.wvno.Name = "wvno";
            this.wvno.Size = new System.Drawing.Size(199, 20);
            this.wvno.TabIndex = 46;
            this.wvno.Text = "Estado del libro entregado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Estado del libro devuelto:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(73)))), ((int)(((byte)(174)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(344, 249);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(106, 32);
            this.btnGuardar.TabIndex = 39;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lbCerrar
            // 
            this.lbCerrar.AutoSize = true;
            this.lbCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(73)))), ((int)(((byte)(174)))));
            this.lbCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCerrar.Location = new System.Drawing.Point(453, 9);
            this.lbCerrar.Name = "lbCerrar";
            this.lbCerrar.Size = new System.Drawing.Size(15, 15);
            this.lbCerrar.TabIndex = 35;
            this.lbCerrar.Text = "X";
            this.lbCerrar.Click += new System.EventHandler(this.lbCerrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(73)))), ((int)(((byte)(174)))));
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(8, 8, 349, 8);
            this.label2.Size = new System.Drawing.Size(480, 36);
            this.label2.TabIndex = 36;
            this.label2.Text = "Devolver Libro";
            // 
            // rtxEstadoDevuelto
            // 
            this.rtxEstadoDevuelto.BackColor = System.Drawing.Color.White;
            this.rtxEstadoDevuelto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxEstadoDevuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxEstadoDevuelto.Location = new System.Drawing.Point(27, 172);
            this.rtxEstadoDevuelto.MaxLength = 100;
            this.rtxEstadoDevuelto.Name = "rtxEstadoDevuelto";
            this.rtxEstadoDevuelto.Size = new System.Drawing.Size(423, 60);
            this.rtxEstadoDevuelto.TabIndex = 47;
            this.rtxEstadoDevuelto.Text = "";
            // 
            // rtxEstadoEntrega
            // 
            this.rtxEstadoEntrega.BackColor = System.Drawing.Color.White;
            this.rtxEstadoEntrega.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxEstadoEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxEstadoEntrega.Location = new System.Drawing.Point(27, 81);
            this.rtxEstadoEntrega.MaxLength = 100;
            this.rtxEstadoEntrega.Name = "rtxEstadoEntrega";
            this.rtxEstadoEntrega.ReadOnly = true;
            this.rtxEstadoEntrega.Size = new System.Drawing.Size(423, 60);
            this.rtxEstadoEntrega.TabIndex = 48;
            this.rtxEstadoEntrega.Text = "";
            // 
            // frmDevolverLibro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 293);
            this.Controls.Add(this.rtxEstadoEntrega);
            this.Controls.Add(this.rtxEstadoDevuelto);
            this.Controls.Add(this.wvno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lbCerrar);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDevolverLibro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDevolverLibro";
            this.Load += new System.EventHandler(this.frmDevolverLibro_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label wvno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCerrar;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RichTextBox rtxEstadoDevuelto;
        public System.Windows.Forms.RichTextBox rtxEstadoEntrega;
        public System.Windows.Forms.Button btnGuardar;
    }
}