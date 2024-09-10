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
    //public partial class frmActualizarContraseña : Form
    //{
    //    public frmActualizarContraseña()
    //    {
    //        InitializeComponent();
    //    }

    //    private void btnEnviar_Click(object sender, EventArgs e)
    //    {

    //    }

    //    private void bntnuevacontra_Click(object sender, EventArgs e)
    //    {

    //    }

    //    private void bntocultaNueva_Click(object sender, EventArgs e)
    //    {

    //    }

    //    private void txtNuevaClave_TextChanged(object sender, EventArgs e)
    //    {
    //        txtConfirmarCLave.UseSystemPasswordChar = true;
    //        btnMostrarContraseña.Visible = true;
    //        btnOcultarContraseña.Visible = false;
    //    }

    //    private void frmActualizarContraseña_Load(object sender, EventArgs e)
    //    {
    //       btnOcultarContraseña.Visible = false;
    //        bntocultaNueva.Visible = false;
    //    }

    //    private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
    //    {
    //         if (e.KeyChar == (char)Keys.Space)
    //        {
    //            MessageBox.Show("No se permiten espacios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    //            txtCorreo.Text = string.Empty;
    //        }
    //    }

    //    private void label2_Click(object sender, EventArgs e)
    //    {

    //    }

    //    private void btnEnviar_Click_1(object sender, EventArgs e)
    //    {
    //        if (txtNuevaClave.Text != string.Empty & txtConfirmarCLave.Text != string.Empty)
    //        {
    //            csLogin ingreso = new csLogin();
    //            if (txtNuevaClave.Text == txtConfirmarCLave.Text)
    //            {
    //                string ClaveEncriptada = ingreso.EncriptarYDesencriptar(txtConfirmarCLave.Text);
    //                ingreso.ActualizarContraseña(txtCorreo.Text, ClaveEncriptada);
    //                this.Hide();
    //            }
    //            else
    //                MessageBox.Show("🔒 Las contraseñas ingresadas no coinciden. Por favor, verifica y vuelve a intentarlo.", "Error de Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    //        }
    //        else
    //            MessageBox.Show("✍️ Por favor, completa todos los campos requeridos para actualizar tu contraseña.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    //    }

    //    private void button1_Click(object sender, EventArgs e)
    //    {
    //        this.Hide();
    //    }

    //    private void btnNueva_Click(object sender, EventArgs e)
    //    {
    //        txtNuevaClave.UseSystemPasswordChar = true; btnNueva.Visible = false; bntocultaNueva.Visible = true;
    //    }

    //    private void btnOcultarContraseña_Click(object sender, EventArgs e)
    //    {
    //        txtConfirmarCLave.UseSystemPasswordChar = false; btnMostrarContraseña.Visible = true; btnOcultarContraseña.Visible = false;
    //    }

    //    private void btnMostrarContraseña_Click(object sender, EventArgs e)
    //    {
    //        txtConfirmarCLave.UseSystemPasswordChar = true; btnMostrarContraseña.Visible = false; btnOcultarContraseña.Visible = true;
    //    }

    //    private void bntocultaNueva_Click_1(object sender, EventArgs e)
    //    {
    //         txtNuevaClave.UseSystemPasswordChar = false; btnNueva.Visible = true; bntocultaNueva.Visible = false;
    //    }
    //}
}
