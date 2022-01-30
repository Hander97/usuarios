﻿using AccesoDatos.ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary1.Utilidades
{
    public class EnviarCorreo
    {
        public static bool SendCorreo(Smtp dataConfiguration, string destinatario, string asunto, string mensaje)
        {

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.IsBodyHtml = true;

            msg.To.Add(destinatario);
            msg.Subject = asunto;

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mensaje, null, MediaTypeNames.Text.Html);

            LinkedResource imageHtmlBanner1 = new LinkedResource(@"C:\Plantilla\imagen1.jpg", MediaTypeNames.Text.Html);
            imageHtmlBanner1.ContentId = "idBanner1";

            LinkedResource imageHtmlBanner2 = new LinkedResource(@"C:\Plantilla\imagen2.png", MediaTypeNames.Text.Html);
            imageHtmlBanner2.ContentId = "idBanner2";

            htmlView.LinkedResources.Add(imageHtmlBanner1);
            htmlView.LinkedResources.Add(imageHtmlBanner2);

            msg.AlternateViews.Add(htmlView);

            msg.From = new MailAddress(dataConfiguration.smtp_username);

            SmtpClient cliente = new SmtpClient();
            cliente.Credentials = new System.Net.NetworkCredential(dataConfiguration.smtp_username, dataConfiguration.smtp_password);
            cliente.Port = int.Parse(dataConfiguration.smtp_puerto.ToString());
            cliente.EnableSsl = (bool)dataConfiguration.smtp_tls;

            cliente.Host = dataConfiguration.smtp_servidor;

            try
            {

                cliente.Send(msg);
                msg.Dispose();
                return true;

            }
            catch (Exception ex)
            {
                msg.Dispose();
                return false;

            }


        }
    }
}
