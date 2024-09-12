
namespace Nueva_Biblioteca
{
    partial class frmConfiguracionGeneral
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ptbxLogoGeneral = new System.Windows.Forms.PictureBox();
            this.btnCambiarLogo = new System.Windows.Forms.Button();
            this.btnEliminarLogo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbxLogoGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(73)))), ((int)(((byte)(174)))));
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(42, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(8, 8, 808, 8);
            this.label2.Size = new System.Drawing.Size(936, 36);
            this.label2.TabIndex = 20;
            this.label2.Text = "Configuracion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(826, 50, 110, 400);
            this.label1.Size = new System.Drawing.Size(936, 463);
            this.label1.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(65, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(350, 0, 0, 400);
            this.label4.Size = new System.Drawing.Size(352, 415);
            this.label4.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Window;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(77, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 20);
            this.label8.TabIndex = 31;
            this.label8.Text = "Logo General\r\n";
            // 
            // ptbxLogoGeneral
            // 
            this.ptbxLogoGeneral.BackColor = System.Drawing.Color.Transparent;
            this.ptbxLogoGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbxLogoGeneral.Location = new System.Drawing.Point(97, 175);
            this.ptbxLogoGeneral.Name = "ptbxLogoGeneral";
            this.ptbxLogoGeneral.Size = new System.Drawing.Size(281, 292);
            this.ptbxLogoGeneral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbxLogoGeneral.TabIndex = 32;
            this.ptbxLogoGeneral.TabStop = false;
            // 
            // btnCambiarLogo
            // 
            this.btnCambiarLogo.BackColor = System.Drawing.Color.LimeGreen;
            this.btnCambiarLogo.FlatAppearance.BorderSize = 0;
            this.btnCambiarLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarLogo.ForeColor = System.Drawing.Color.White;
            this.btnCambiarLogo.Location = new System.Drawing.Point(245, 485);
            this.btnCambiarLogo.Name = "btnCambiarLogo";
            this.btnCambiarLogo.Size = new System.Drawing.Size(120, 40);
            this.btnCambiarLogo.TabIndex = 33;
            this.btnCambiarLogo.Text = "Cambiar";
            this.btnCambiarLogo.UseVisualStyleBackColor = false;
            this.btnCambiarLogo.Click += new System.EventHandler(this.btnCambiarLogo_Click);
            // 
            // btnEliminarLogo
            // 
            this.btnEliminarLogo.BackColor = System.Drawing.Color.Red;
            this.btnEliminarLogo.FlatAppearance.BorderSize = 0;
            this.btnEliminarLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarLogo.ForeColor = System.Drawing.Color.White;
            this.btnEliminarLogo.Location = new System.Drawing.Point(110, 485);
            this.btnEliminarLogo.Name = "btnEliminarLogo";
            this.btnEliminarLogo.Size = new System.Drawing.Size(120, 40);
            this.btnEliminarLogo.TabIndex = 34;
            this.btnEliminarLogo.Text = "Eliminar";
            this.btnEliminarLogo.UseVisualStyleBackColor = false;
            // 
            // frmConfiguracionGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 628);
            this.Controls.Add(this.btnEliminarLogo);
            this.Controls.Add(this.btnCambiarLogo);
            this.Controls.Add(this.ptbxLogoGeneral);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConfiguracionGeneral";
            this.Text = "frmConfiguracionGeneral";
            this.Load += new System.EventHandler(this.frmConfiguracionGeneral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbxLogoGeneral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox ptbxLogoGeneral;
        private System.Windows.Forms.Button btnCambiarLogo;
        private System.Windows.Forms.Button btnEliminarLogo;
    }
}