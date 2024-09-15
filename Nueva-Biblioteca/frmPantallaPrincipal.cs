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
    public partial class frmPantallaPrincipal : Form
    {
        static csConexionDataBase conexion = new csConexionDataBase();
        static bool biblioteca = false, persona = false, prestamo = false, perfil = false, reporte = false, configuracion = false;
        private Timer timer;

        static private frmPantallaPrincipal instancia = null;
        public static frmPantallaPrincipal Formulario()
        {
            if (instancia == null) { instancia = new frmPantallaPrincipal(); }
            return instancia;
        }

        public frmPantallaPrincipal()
        {
            InitializeComponent();
            Confi();
        }

        private void Confi()
        {
            timer = new Timer();
            timer.Interval = 60000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            new csEnvioDeAvisoDevolucion().Comparar();
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            frmResumen frm = frmResumen.Formulario();
            frm.TopLevel = false;
            pnlPrincipal.Controls.Add(frm);
            frm.Mostrar();
            frm.Show();
        }

        private void frmPantallaPrincipal_Load(object sender, EventArgs e)
        {
            contenedorBiblioteca.Visible = false;
            contenedorPersonas.Visible = false;
            contenedorPrestamos.Visible = false;
            contenedorReportes.Visible = false;
            contenedorConfiguracion.Visible = false;
            contenedorPerfil.Visible = false;
            ptbxBiblioteca.BackgroundImage = ListaFlecha.Images[0];
            ptbxPersona.BackgroundImage = ListaFlecha.Images[0];
            ptbxPrestamo.BackgroundImage = ListaFlecha.Images[0];
            ptbxReporte.BackgroundImage = ListaFlecha.Images[0];
            ptbxConfiguracion.BackgroundImage = ListaFlecha.Images[0];
            string consulta = "Select * from CONFIGURACION where IdConfiguracion = (Select max(IdConfiguracion) from CONFIGURACION)";
            ptbxLogoMenu = conexion.ExtraerImagen(consulta, "Imagen", ptbxLogoMenu);
        }

        private void btnBiblioteca_Click(object sender, EventArgs e)
        {
            if (!biblioteca) 
            {
                if (persona) { btnPersona.PerformClick(); }
                if (prestamo) { btnPrestamo.PerformClick(); }
                ptbxBiblioteca.BackgroundImage = ListaFlecha.Images[1];
                contenedorBiblioteca.Visible = true;
                contenedorBiblioteca.Location = new Point(12, 213);
                btnPersona.Location = new Point(0, 291);
                btnPrestamo.Location = new Point(0, 340);
                ptbxPersona.Location = new Point(150, 303);
                ptbxPrestamo.Location = new Point(150, 352);
                biblioteca = true; 
            }
            else 
            { 
                ptbxBiblioteca.BackgroundImage = ListaFlecha.Images[0];
                contenedorBiblioteca.Visible = false;
                btnPersona.Location = new Point(0, 222);
                ptbxPersona.Location = new Point(150, 235);
                ptbxPrestamo.Location = new Point(150, 287);
                btnPrestamo.Location = new Point(0, 274);
                biblioteca = false; 
            }
        }

        private void LlamarFormulario(Form formulario)
        {
            pnlPrincipal.Controls.Clear();
            formulario.TopLevel = false;
            pnlPrincipal.Controls.Add(formulario);
            formulario.Show();
        }

        private void btnPersona_Click(object sender, EventArgs e)
        {
            if (!persona)
            {
                if (biblioteca) { btnBiblioteca.PerformClick(); }
                if (prestamo) { btnPrestamo.PerformClick(); }
                ptbxPersona.BackgroundImage = ListaFlecha.Images[1];
                contenedorPersonas.Visible = true;
                contenedorPersonas.Location = new Point(12, 267);
                btnPrestamo.Location = new Point(0, 307);
                ptbxPrestamo.Location = new Point(150, 320);
                persona = true;
            }
            else
            {
                ptbxPersona.BackgroundImage = ListaFlecha.Images[0];
                btnPrestamo.Location = new Point(0, 274);
                ptbxPrestamo.Location = new Point(150, 287);
                contenedorPersonas.Visible = false;
                persona = false;
            }
        }

        private void contenedorPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (contenedorPersonas.SelectedIndex)
            {
                case 0:
                    {
                        frmLectores frm = frmLectores.Formulario();
                        LlamarFormulario(frm);
                        break;
                    }
                case 1:
                    {
                        frmUsuarios frm = frmUsuarios.Formulario();
                        LlamarFormulario(frm);
                        break;
                    }
            }
        }

        private void contenedorBiblioteca_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (contenedorBiblioteca.SelectedIndex) 
            {
                case 0:
                    {
                        frmAutores frm = frmAutores.Formulario();
                        LlamarFormulario(frm);
                        break;
                    }
                case 1:
                    {
                        frmEditorial frm = frmEditorial.Formulario();
                        LlamarFormulario(frm);
                        break;
                    }
                case 2:
                    {
                        frmGenero frm = frmGenero.Formulario();
                        LlamarFormulario(frm);
                        break;
                    }
                case 3:
                    {
                        frmLibros frm = frmLibros.Formulario();
                        LlamarFormulario(frm);
                        break;
                    }
            }
        }

        private void ptbxPerfil_Click(object sender, EventArgs e)
        {
            if(!perfil) { contenedorPerfil.Visible = true;  perfil = true; }
            else { contenedorPerfil.Visible = false; perfil = false; contenedorPerfil.SelectedIndex = -1; }
        }

        private void ptbxPersona_Click(object sender, EventArgs e)
        {
            btnPersona.PerformClick();
        }

        private void ptbxBiblioteca_Click(object sender, EventArgs e)
        {
            btnBiblioteca.PerformClick();
        }

        private void ptbxPrestamo_Click(object sender, EventArgs e)
        {
            btnPrestamo.PerformClick();
        }

        private void contenedorConfiguracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(contenedorConfiguracion.SelectedIndex)
            {
                case 0:
                    frmConfiguracionGeneral frm = frmConfiguracionGeneral.Formulario();
                    LlamarFormulario(frm);
                    break;
            }
        }

        private void contenedorPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(contenedorPerfil.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    frmLogin frm = frmLogin.Formulario();
                    frm.Show();
                    this.Hide();
                    contenedorPerfil.Visible = false;
                    perfil = false;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!configuracion)
            {
                contenedorConfiguracion.Visible = true;
                contenedorConfiguracion.Location = new Point(12, 425);
                ptbxConfiguracion.BackgroundImage = ListaFlecha.Images[1];
                configuracion = true;
            }
            else
            {
                contenedorConfiguracion.Visible = false;
                ptbxConfiguracion.BackgroundImage = ListaFlecha.Images[0];
                configuracion = false;
            }
        }

        private void contenedorReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(contenedorReportes.SelectedIndex)
            {
                case 0:
                    frmReportes frm = frmReportes.Formulario();
                    LlamarFormulario(frm);
                    break;
            }  
        }

        private void btnRepo_Click(object sender, EventArgs e)
        {
            if (!reporte)
            {
                ptbxReporte.BackgroundImage = ListaFlecha.Images[1];
                contenedorReportes.Visible = true;
                contenedorReportes.Location = new Point(12, 372);
                reporte = true;
            }
            else
            {
                ptbxReporte.BackgroundImage = ListaFlecha.Images[0];
                contenedorReportes.Visible = false;
                reporte = false;
            }
        }

        private void contenedorPrestamos_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (contenedorPrestamos.SelectedIndex)
            {
                case 0:
                    {
                        frmConsultarPrestamos frm = new frmConsultarPrestamos();
                        LlamarFormulario(frm);
                        break;
                    }
                case 1:
                    {
                        frmPrestamoRegistrar frm = new frmPrestamoRegistrar();
                        LlamarFormulario(frm);
                        break;
                    }
            }
        }

        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            if (!prestamo)
            {
                if (biblioteca) { btnBiblioteca.PerformClick(); }
                if (persona) { btnPersona.PerformClick(); }
                ptbxPrestamo.BackgroundImage = ListaFlecha.Images[1];
                contenedorPrestamos.Visible = true;
                contenedorPrestamos.Location = new Point(12, 316);
                btnReportes.Location = new Point(0, 360);
                ptbxReporte.Location = new Point(150, 372);
                prestamo = true;
            }
            else
            {
                ptbxPrestamo.BackgroundImage = ListaFlecha.Images[0];
                btnReportes.Location = new Point(0, 331);
                ptbxReporte.Location = new Point(150, 347);
                contenedorPrestamos.Visible = false;
                prestamo = false;
            }
        }
    }
}
