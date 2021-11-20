using AccesoDatos.ClassLibrary1;
using Logica.ClassLibrary1;
using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace usuarios
{
    public partial class FrmLogin : Form
    {
     
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            login();
        }
        public class Encrypt
        {
            public static string GetSHA1(string str)
            {
                SHA1 sha1 = SHA1Managed.Create();
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] stream = null;
                StringBuilder sb = new StringBuilder();
                stream = sha1.ComputeHash(encoding.GetBytes(str));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            }
        }
        private void login()
        {
            try
            {
                string correo = txtUser.Text.TrimStart().TrimEnd();
                string clave = txtPassword.Text;
                string cadenaEncriptada = Encrypt.GetSHA1(clave);
               

                if (!string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(cadenaEncriptada))
                {
                    Usuario usuario = new Usuario();
                    usuario = LogicaUsuario.getUserXLogin(correo, cadenaEncriptada);
                    if (usuario != null)
                    {
                        var dataUser = usuario.usu_nombres + " " + usuario.usu_apellidos;
                        var dataUser2 = $"{ usuario.usu_nombres}  { usuario.usu_apellidos}";

                        MessageBox.Show("Bienvenido al sistema\n" + usuario.Rol.rol_descripcion
                        + "\n" + dataUser2, "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error en usuario o clave", "Sistema de Matriculación Vehicular",
                                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }   
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
