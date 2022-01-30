using AccesoDatos.ClassLibrary1;
using Logica.ClassLibrary1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usuarios.Formularios
{
    public partial class FmrMatricula : Form
    {
        public FmrMatricula()
        {
            InitializeComponent();
            loadProvincias();
            
        }
        private void loadProvincias()
        {
            try
            {
                List<Provincia> listaProvincias = new List<Provincia>();
                listaProvincias = Logica.ClassLibrary1.LogicaProvincia.getAllProvincias();
                if (listaProvincias != null && listaProvincias.Count > 0)
                {
                    listaProvincias.Insert(0, new Provincia
                    {
                        pro_id = 0,
                        pro_nombre = "Seleccione Provincia"
                    });

                    cmbProvincia.DataSource = listaProvincias;
                    cmbProvincia.DisplayMember = "pro_nombre";
                    cmbProvincia.ValueMember = "pro_id";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar las Provincias", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadCantones(int codigoProvincia)
        {
            try
            {
                if (codigoProvincia > 0)
                {
                    List<Canton> listaCanton = new List<Canton>();
                    listaCanton = Logica.ClassLibrary1.LogicaCanton.getAllCantonesXProvincia(codigoProvincia);
                    if (listaCanton != null && listaCanton.Count > 0)
                    {
                        listaCanton.Insert(0, new Canton
                        {
                            can_id = 0,
                            can_nombre = "Seleccione Cantón"
                        });

                        cmbCanton.DataSource = listaCanton;
                        cmbCanton.DisplayMember = "can_nombre";
                        cmbCanton.ValueMember = "can_id";
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar Cantones", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            searchPerson();
        }
        public void ejecutar(Persona persona)
        {
            lblPersona.Text = persona.per_nombres + " " + persona.per_apellidos;
        }      
        private void searchPerson()
        {
            string identificacion = txtCedula.Text.TrimEnd().TrimStart();
            if (!string.IsNullOrEmpty(identificacion))
            {
                Persona persona = new Persona();
                persona = Logica.ClassLibrary1.LogicaPersona.getPersonXIdentificacion(identificacion);
                if (persona != null)
                {
                    lblPersona.Text = persona.per_apellidos + " " + persona.per_nombres;
                    //Interpolation
                    lblPersona.Text = $"{persona.per_apellidos} {persona.per_nombres}";
                }
                else
                {
                    MessageBox.Show("Persona no existe", "Sistema Matriculacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Formularios.FmrPersona frmPersona = new FmrPersona();
                    FmrPersona frmP = new FmrPersona();
                    frmP.enviar += new FmrPersona.envDatos(ejecutar);
                    frmP.ShowDialog();

                }
            }
        }
        private void searchVehiculo()
        {
            string placa = txtID.Text.TrimEnd().TrimStart();
            if (!string.IsNullOrEmpty(placa))
            {
                Vehiculo vehiculo = new Vehiculo();
                vehiculo = Logica.ClassLibrary1.LogicaVehiculo.getVehiculoXPlaca(placa);
                if (vehiculo != null)
                {
                    lblID.Text = vehiculo.veh_id.ToString();
                    //Interpolation
                    lblIdVehi.Text = $"{vehiculo.Modelo.Marca.mar_descripcion} {vehiculo.Modelo.mod_descripcion}";
                }
                else
                {
                    MessageBox.Show("Vehiculo no existe", "Sistema Matriculacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Formularios.FrmVehiculo frmVehiculo = new FrmVehiculo();
                    frmVehiculo.Show();
                }
            }
        }
        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvincia.SelectedIndex > 0)
            {
                loadCantones(int.Parse(cmbProvincia.SelectedValue.ToString()));
            }
        }
        private void btnBuscarVehiculo_Click(object sender, EventArgs e)
        {
            searchVehiculo();
        }
        private void guardarMatricula()
        {
            try
            {
                Matricula matricula = new Matricula();
                matricula.mat_fechaemision = dateTimePicker1.Value;
                matricula.mat_fechacaducidad = dateTimePicker2.Value;
                matricula.mat_numeroespecie = txtNumEspecie.Text;
                matricula.mat_valormatricula = 150;
                matricula.can_id = Convert.ToInt32(cmbCanton.SelectedValue.ToString());
                matricula.per_id = txtCedula.Text;
                matricula.veh_id = int.Parse(lblID.Text);
                bool resSaveMatricula = Logica.ClassLibrary1.LogicaMatricula.saveMatricula(matricula);
                if (resSaveMatricula)
                {
                    MessageBox.Show("Matricula Generada Correctamente", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var persona = LogicaPersona.getPersonXIdentificacion(matricula.per_id);
                    string datosPersona = $"{persona.per_nombres} {persona.per_apellidos}";
                    string placa = txtID.Text.TrimEnd().TrimStart();
                    Vehiculo vehiculo = new Vehiculo();
                    vehiculo = Logica.ClassLibrary1.LogicaVehiculo.getVehiculoXPlaca(placa);
                    string datosVehiculo = $"{vehiculo.Modelo.Marca.mar_descripcion} {vehiculo.Modelo.mod_descripcion}";
                    bool resEmail = Logica.ClassLibrary1.LogicaMatricula.sendEmail(persona.per_correo, datosPersona, matricula.mat_fechaemision, matricula.mat_fechacaducidad, matricula.Canton.can_nombre, datosVehiculo);
                    if (resEmail)
                    {
                        MessageBox.Show("Correo enviado Correctamente", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al generar Matricula " + ex.Message);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarMatricula();
        }
    }
    }

