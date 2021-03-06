using AccesoDatos.ClassLibrary1;
using Logica.ClassLibrary1;
using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Data;

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
            public static string GetSha1(string str)
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
                string cadenaEncriptada = Encrypt.GetSha1(clave);
              
                if (!string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(clave))
                {
                   
                    Usuario usuario = new Usuario();
                    usuario = LogicaUsuario.getUserXLogin(correo, clave);
                    if (usuario != null)
                    {
                        var dataUser = usuario.usu_nombres + " " + usuario.usu_apellidos;
                        var dataUser2 = $"{ usuario.usu_nombres}  { usuario.usu_apellidos}";

                        MessageBox.Show("Bienvenido al sistema\n" + usuario.Rol.rol_descripcion
                        + "\n" + dataUser2, "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2 form2 = new Form2();
                        form2.Show();
                        this.Hide();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
