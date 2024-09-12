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
    public partial class frmConfiguracionGeneral : Form
    {
        static csConexionDataBase conexion = new csConexionDataBase();
        static frmConfiguracionGeneral instancia = null;
        public static frmConfiguracionGeneral Formulario()
        {
            if(instancia == null) { instancia = new frmConfiguracionGeneral(); }
            return instancia;
        }

        public frmConfiguracionGeneral()
        {
            InitializeComponent();
        }

        private void btnCambiarLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog Imagen = new OpenFileDialog();
            Imagen.Filter = "archivos de imagen (*png;)|*png;";
            if (Imagen.ShowDialog() == DialogResult.OK)
            {
                ptbxLogoGeneral.BackgroundImage = null;
                ptbxLogoGeneral.Image = Image.FromFile(Imagen.FileName);
                conexion.GuardarImagen(ptbxLogoGeneral, "Insert into CONFIGURACION(Imagen) Values(@imagen)");
            }
        }

        private void frmConfiguracionGeneral_Load(object sender, EventArgs e)
        {
            string consulta = "Select * from CONFIGURACION where IdConfiguracion = (Select max(IdConfiguracion) from CONFIGURACION)";
            ptbxLogoGeneral = conexion.ExtraerImagen(consulta, "Imagen", ptbxLogoGeneral);
        }
    }
}
