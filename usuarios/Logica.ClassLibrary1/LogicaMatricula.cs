using AccesoDatos.ClassLibrary1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary1
{
    public class LogicaMatricula
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static bool saveMatricula(Matricula dataMatricula)
        {
            try
            {
                bool result = false;
                dataMatricula.mat_add = DateTime.Now;
                dataMatricula.mat_status = 'A';

                dc.Matricula.InsertOnSubmit(dataMatricula);
                //Commit a la base
                dc.SubmitChanges();

                result = true;
                return result;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al guardar Matricula " + ex.Message);
            }
        }


        private static string convertHtmlToString(string cliente, DateTime fecha, DateTime fechaC, string ciudad, string vehiculo)
        {
            string body = string.Empty;

            using (StreamReader reader = new StreamReader(@"C:\Plantilla\plantilla.html"))
            {
                body = reader.ReadToEnd();
                body = body.Replace("@Cliente", cliente);
                body = body.Replace("@Fecha", fecha.ToLongDateString());
                body = body.Replace("@FechaC", fechaC.ToLongDateString());
                body = body.Replace("@Vehiculo", vehiculo);
                body = body.Replace("@Ciudad", fecha.ToLongDateString());
            }

            return body;
        }

        public static bool sendEmail(string correo, string persona, DateTime fecha, DateTime fechaC, string ciudad, string vehiculo)
        {
            try
            {
                var serverConfig = LogicaEmail.getConfigEmailServer();
                string asunto = "Matriculacion Vehicular";
                bool res = Utilidades.EnviarCorreo.SendCorreo(serverConfig, correo, asunto, convertHtmlToString(persona, fecha, fechaC, ciudad, vehiculo));

                return res;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al enviar Correo " + ex.Message); ;
            }
        }

    }
}
