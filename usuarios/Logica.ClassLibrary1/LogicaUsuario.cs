using AccesoDatos.ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.ClassLibrary1
{
    public class LogicaUsuario
    {
        private static DcMantenimientoDataContext dc = new DcMantenimientoDataContext();

        public static List<Usuario> getAllaUsers()
        {
            try
            {
                var lista = dc.Usuario.Where(Data => Data.usu_status == 'A');
                return lista.ToList();
            }
            catch (Exception ex )
            {

                throw new ArgumentException("Error al  Obtener Usuario" + ex.Message);
            }
        }
        public static Usuario getUserXLogin(string email, string clave)
        {
            try
            {
                var Usuario = dc.Usuario.Where(data => data.usu_status == 'A'
                                               && data.usu_correo.Equals(email)
                                               && data.usu_password.Equals(clave)
                                               ).FirstOrDefault();

                return Usuario;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al obtener Usuario " + ex.Message);
            }
        }
        public static bool saveUser(Usuario dataUsuario) 
        {
            try
            {
                bool result = false;
                dc.Usuario.InsertOnSubmit(dataUsuario);
                dc.SubmitChanges();
                dataUsuario.usu_add = DateTime.Now;
                dataUsuario.usu_status = 'A';

                result = true;
                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al  Guardar Usuario" + ex.Message);
            }
        }
        public static bool updateUser(Usuario dataUsuario)
        {
            try
            {
                bool result = false;
                
                dc.SubmitChanges();

                result = true;
                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al Modificar Usuario" + ex.Message);
            }
        }
        public static bool deleteUser(Usuario dataUsuario)
        {
            try
            {
                bool result = false;
                //dc.ExecuteCommand("DELETE");
                dataUsuario.usu_status = 'I';
                dc.SubmitChanges();

                result = true;
                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al Eliminar Usuario" + ex.Message);
            }
        }
    }
}
