using AccesoDatos.ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary1
{
    public class LogicaPersona
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static Persona getPersonXIdentificacion(string identificacion)
        {
            try
            {
                var person = dc.Persona.FirstOrDefault(data => data.per_estatus == 'A'
                                                       && data.per_identificacion.Equals(identificacion));

                return person;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }
    }
}
