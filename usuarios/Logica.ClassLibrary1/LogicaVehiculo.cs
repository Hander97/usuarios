using AccesoDatos.ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary1
{
    public class LogicaVehiculo
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static Vehiculo getVehiculoXPlaca(string placa)
        {
            try
            {
                var vehiculo = dc.Vehiculo.FirstOrDefault(data => data.veh_status == 'A'
                                                       && data.veh_placaActual.Equals(placa));

                return vehiculo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }

    }
}
