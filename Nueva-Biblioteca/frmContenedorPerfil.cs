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
    public partial class frmContenedorPerfil : Form
    {
        public frmContenedorPerfil()
        {
            InitializeComponent();
        }

        private void contenedorPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(contenedorPerfil.SelectedIndex)
            {
                case 1:
                    {
                        frmPantallaPrincipal frm = frmPantallaPrincipal.Formulario();
                        frm.Hide();
                        this.Hide();
                        frmLogin login = frmLogin.Formulario();
                        login.Show();
                        break;
                    }
            }
        }
    }
}
