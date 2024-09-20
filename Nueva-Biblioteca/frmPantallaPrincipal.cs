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
        public string IdEmpleado = "";

        static private frmPantallaPrincipal instancia = null;
        public static frmPantallaPrincipal Formulario()
        {
            if (instancia == null) { instancia = new frmPantallaPrincipal(); }
            return instancia;
        }
        public frmPantallaPrincipal()
        {
            InitializeComponent();
            Reloj.Start();
        }
        private void MostrarLogo()
        {
            string consulta = "Select * from CONFIGURACION where IdConfiguracion = (Select max(IdConfiguracion) from CONFIGURACION)";
            ptbxLogoMenu = conexion.ExtraerImagen(consulta, "Imagen", ptbxLogoMenu);
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
        }

        private void btnBiblioteca_Click(object sender, EventArgs e)
        {
            if (!biblioteca) 
            {
                if (persona) { btnPersona.PerformClick(); }
                if (prestamo) { btnPrestamo.PerformClick(); }
                if (reporte) { btnReportes.PerformClick(); }
                if (configuracion) { btnConfiguracion.PerformClick(); }
                ptbxBiblioteca.BackgroundImage = ListaFlecha.Images[1];
                contenedorBiblioteca.Visible = true;
                contenedorBiblioteca.Location = new Point(12, 213);
                btnPersona.Location = new Point(0, 291);
                btnPrestamo.Location = new Point(0, 340);
                btnReportes.Location = new Point(0, 390);
                btnConfiguracion.Location = new Point(0, 440);

                ptbxPersona.Location = new Point(150, 303);
                ptbxPrestamo.Location = new Point(150, 352);
                ptbxReporte.Location = new Point(150, 402);
                ptbxConfiguracion.Location = new Point(150, 452);
                biblioteca = true; 
            }
            else 
            { 
                ptbxBiblioteca.BackgroundImage = ListaFlecha.Images[0];
                contenedorBiblioteca.Visible = false;
                btnPersona.Location = new Point(0, 222);
                btnPrestamo.Location = new Point(0, 274);
                btnReportes.Location = new Point(0, 331);
                btnConfiguracion.Location = new Point(0, 384);

                ptbxPersona.Location = new Point(150, 235);
                ptbxPrestamo.Location = new Point(150, 287);
                ptbxReporte.Location = new Point(150, 345);
                ptbxConfiguracion.Location = new Point(150, 397);
                biblioteca = false;
                contenedorBiblioteca.SelectedIndex = -1;
            }
        }
        private void btnPersona_Click(object sender, EventArgs e)
        {
            if (!persona)
            {
                if (biblioteca) { btnBiblioteca.PerformClick(); }
                if (prestamo) { btnPrestamo.PerformClick(); }
                if (reporte) { btnReportes.PerformClick(); }
                if (configuracion) { btnConfiguracion.PerformClick(); }
                ptbxPersona.BackgroundImage = ListaFlecha.Images[1];
                contenedorPersonas.Visible = true;
                contenedorPersonas.Location = new Point(12, 267);
                btnPrestamo.Location = new Point(0, 307);
                btnReportes.Location = new Point(0, 357);
                btnConfiguracion.Location = new Point(0, 407);

                ptbxPrestamo.Location = new Point(150, 320);
                ptbxReporte.Location = new Point(150, 370);
                ptbxConfiguracion.Location = new Point(150, 420);
                persona = true;
            }
            else
            {
                ptbxPersona.BackgroundImage = ListaFlecha.Images[0];
                btnPrestamo.Location = new Point(0, 274);
                btnReportes.Location = new Point(0, 331);
                btnConfiguracion.Location = new Point(0, 384);

                ptbxPrestamo.Location = new Point(150, 287);
                ptbxReporte.Location = new Point(150, 345);
                ptbxConfiguracion.Location = new Point(150, 397);
                contenedorPersonas.Visible = false;
                persona = false;
                contenedorPersonas.SelectedIndex = -1;
            }
        }
        private void btnReportes_Click(object sender, EventArgs e)
        {
            if (!reporte)
            {
                if(biblioteca) { btnBiblioteca.PerformClick(); }
                if(persona) { btnPersona.PerformClick(); }
                if(prestamo) { btnPrestamo.PerformClick(); }
                if(configuracion) { btnConfiguracion.PerformClick(); }
                ptbxReporte.BackgroundImage = ListaFlecha.Images[1];
                contenedorReportes.Visible = true;
                contenedorReportes.Location = new Point(12, 374);
                btnConfiguracion.Location = new Point(0, 395);

                ptbxConfiguracion.Location = new Point(150, 408);
                reporte = true;
            }
            else
            {
                ptbxReporte.BackgroundImage = ListaFlecha.Images[0];
                contenedorReportes.Visible = false;
                btnConfiguracion.Location = new Point(0, 384);

                ptbxConfiguracion.Location = new Point(150, 397);
                reporte = false;
                contenedorReportes.SelectedIndex = -1;
            }
        }
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            if (!configuracion)
            {
                if (biblioteca) { btnBiblioteca.PerformClick(); }
                if (persona) { btnPersona.PerformClick(); }
                if (prestamo) { btnPrestamo.PerformClick(); }
                if (reporte) { btnReportes.PerformClick(); }
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
                contenedorConfiguracion.SelectedIndex = -1;
            }
        }
        private void btnPrestamo_Click(object sender, EventArgs e)
        {
            if (!prestamo)
            {
                if (biblioteca) { btnBiblioteca.PerformClick(); }
                if (persona) { btnPersona.PerformClick(); }
                if (reporte) { btnReportes.PerformClick(); }
                if (configuracion) { btnConfiguracion.PerformClick(); }
                ptbxPrestamo.BackgroundImage = ListaFlecha.Images[1];
                contenedorPrestamos.Visible = true;
                contenedorPrestamos.Location = new Point(12, 316);
                btnReportes.Location = new Point(0, 357);
                btnConfiguracion.Location = new Point(0, 407);

                ptbxReporte.Location = new Point(150, 370);
                ptbxConfiguracion.Location = new Point(150, 420);
                prestamo = true;
            }
            else
            {
                ptbxPrestamo.BackgroundImage = ListaFlecha.Images[0];
                btnReportes.Location = new Point(0, 331);
                btnConfiguracion.Location = new Point(0, 384);

                ptbxReporte.Location = new Point(150, 345);
                ptbxConfiguracion.Location = new Point(150, 397);
                contenedorPrestamos.Visible = false;
                prestamo = false;
                contenedorPrestamos.SelectedIndex = -1;
            }
        }
        private void btnResumen_Click(object sender, EventArgs e)
        {
            pnlPrincipal.Controls.Clear();
            frmResumen frm = frmResumen.Formulario();
            frm.TopLevel = false;
            pnlPrincipal.Controls.Add(frm);
            frm.Show();
        }

        private void LlamarFormulario(Form formulario)
        {
            pnlPrincipal.Controls.Clear();
            formulario.TopLevel = false;
            pnlPrincipal.Controls.Add(formulario);
            formulario.Show();
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

        private void Reloj_Tick(object sender, EventArgs e)
        {
            MostrarLogo();
        }

        private void contenedorPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(contenedorPerfil.SelectedIndex)
            {
                case 0:
                    frmCambioDeContraseña frmCambio = new frmCambioDeContraseña();
                    frmCambio.ShowDialog();
                    break;
                case 1:
                    frmLogin frmlog = frmLogin.Formulario();
                    frmlog.Show();
                    this.Hide();
                    contenedorPerfil.Visible = false;
                    perfil = false;
                    break;
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
    }
}