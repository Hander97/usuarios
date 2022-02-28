using Logica.ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.WebForms.Public
{
    public partial class WfmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            login();
        }
        private void login()
        {
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var user = LogicaUsuario.getUserXLogin(username, password);
                if (user != null)
                {
                    Session["Usuario"] = user;
                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Usuario o Clave Incorrecta');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Usuario o Clave Incorrecta');</script>");
            }
        }

        private void loginxapi()
        {

        }
    }
}