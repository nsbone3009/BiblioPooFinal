using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Nueva_Biblioteca
{
    internal class csEmail
    {
        string servidor, usuario, clave, emisor, emisor_nombre, receptor, con_copia, asunto, cuerpo, adjunto;
        public MailMessage mensaje;
        int puerto;
        bool ssl;
        public string Emisor
        {
            get { return emisor; }
            set { emisor = value; mensaje.From = new MailAddress(emisor, emisor_nombre); }
        }
        public string Emisor_Nombre
        {
            get { return emisor_nombre; }
            set { emisor_nombre = value; mensaje.From = new MailAddress(emisor, emisor_nombre); }
        }
        public string Receptor
        {
            get { return receptor; }
            set { receptor = value; mensaje.To.Add(new MailAddress(receptor)); }
        }
        public string Con_Copia
        {
            get { return con_copia; }
            set
            {
                con_copia = value;
                MailAddress mail = new MailAddress(con_copia);
                mensaje.CC.Add(mail);
            }
        }
        public string Asunto
        {
            get { return asunto; }
            set { asunto = value; mensaje.Subject = asunto; }
        }
        public string Cuerpo
        {
            get { return cuerpo; }
            set { cuerpo = value; mensaje.Body = cuerpo; }
        }
        public string Adjunto
        {
            get { return adjunto; }
            set
            {
                adjunto = value;
                Attachment attachment = new Attachment(adjunto);
                mensaje.Attachments.Add(attachment);
            }
        }
        public string Servidor
        {
            get { return servidor; }
            set { servidor = value; }
        }
        public int Puerto
        {
            get { return puerto; }
            set { puerto = value; }
        }
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }
        public bool Ssl
        {
            get { return ssl; }
            set { ssl = value; }
        }
        public csEmail()
        {
            //mensaje = new MailMessage();
            //emisor = "test.programador.2024@gmail.com";
            //emisor_nombre = "BIBLIOTECA OMAIGA";
            //servidor = "smtp.gmail.com";
            //puerto = 587;
            //ssl = true;
            //usuario = "test.programador.2024@gmail.com";
            //clave = "zyrv goee svln pjpw";
            mensaje = new MailMessage();
            emisor = "pruebaspoo24@gmail.com";
            emisor_nombre = "BIBLIOTECA UTEQ";
            servidor = "smtp.gmail.com";
            puerto = 587;
            ssl = true;
            usuario = "pruebaspoo24@gmail.com";
            clave = "nzknyvycobsgsrju";
        }
        public Boolean Enviar()
        {
            mensaje.From = new MailAddress(emisor, emisor_nombre);
            SmtpClient clienteSMTP = new SmtpClient(servidor);
            clienteSMTP.Port = puerto;
            clienteSMTP.EnableSsl = ssl;
            clienteSMTP.Credentials = new NetworkCredential(usuario, clave);
            try { clienteSMTP.Send(mensaje); }
            catch { mensaje.Dispose(); return false; }
            mensaje.Dispose();
            return true;
        }
    }
}

