using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion.WebForms.Administracion.Vehiculos
{
    public partial class WfmVehiculoNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int condigoVehiculo = int.Parse(Request["cod"].ToString());
                }

                //loadTipoVehiculo();
                //loadColorVehiculo();
            }
        }
    }
}