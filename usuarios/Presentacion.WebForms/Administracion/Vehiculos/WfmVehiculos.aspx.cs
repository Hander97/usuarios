using AccesoDatos.ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.WebForms.Administracion.Vehiculos
{
    public partial class WfmVehiculos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] != null)
                {
                    Usuario user = new Usuario();
                    user = (Usuario)Session["Usuario"];
                    if (user != null)
                    {
                        loadVehiculos();
                    }
                }
                else
                {
                    Response.Redirect("~/Public/wfmLogin.aspx");
                }
            }
        }
        private void loadVehiculos()
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();

            vehiculos = Logica.ClassLibrary1.LogicaVehiculo.getVehiculos();
            if (vehiculos.Count > 0 && vehiculos != null)
            {
                gdvVehiculos.DataSource = vehiculos.Select(data => new
                {
                    ID = data.veh_id,
                    PLACA = data.veh_placaActual,
                    MARCA = data.Modelo.Marca.mar_descripcion,
                    MODELO = data.Modelo.mod_descripcion,
                    MOTOR = data.veh_motor,
                    FECHA = data.veh_fechacompra.ToShortDateString(),
                    CILINDRAJE = data.veh_cilindraje
                });
                gdvVehiculos.DataBind();
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void lnkNuevo_Click(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void gdvVehiculos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string codigo = Convert.ToString(e.CommandArgument);

            if (e.CommandName == "Modificar")
            {
                Response.Redirect("WfmVehiculoNuevo.aspx?cod=" + codigo);
            }
            else if (e.CommandName == "Eliminar")
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo = Logica.ClassLibrary1.LogicaVehiculo.getVehiculoXId(int.Parse(codigo));
                if (vehiculo != null)
                {
                    if (Logica.ClassLibrary1.LogicaVehiculo.deleteVehiculo(vehiculo))
                    {
                        loadVehiculos();
                    }
                }

            }
        }
    }
    }
