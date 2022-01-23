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
    public partial class FmrPersona : Form
    {
        public FmrPersona()
        {
            InitializeComponent();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            savePersona();
        }
        private void savePersona()
        {
            try
            {
                Persona persona = new Persona();
                char ti = char.Parse(cmbTipoId.SelectedItem.ToString());
                persona.per_tipoidentificacion = ti;
                persona.per_identificacion = txtId.Text.ToUpper();
                persona.per_apellidos = txtApellidos.Text.ToUpper();
                persona.per_nombres = txtNombres.Text.ToUpper();
                persona.per_fechanacimiento = dtpFechaN.Value;
                persona.per_direccion = txtDireccion.Text;
                persona.per_telefono = txtTelefono.Text;
                persona.per_celular = txtTelefono.Text;
                persona.per_tiposangre = cmbTipoSangre.SelectedItem.ToString();
                persona.per_correo = txtCorreo.Text;
                persona.per_genero = char.Parse(cmbGenero.SelectedItem.ToString());
                if (Logica.ClassLibrary1.LogicaPersona.savePersona(persona))
                {
                    MessageBox.Show("Guardado Correcto");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Error al guardar Persona", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNums(e);
        }
        private void txtId_Leave(object sender, EventArgs e)
        {
            if (txtId.Text.Length < 10)
            {
                MessageBox.Show("Faltan Digitos");
            }
            else
            {
                var length = txtId.Text.Length;
                string str = txtId.Text;
                char[] charArray = str.ToCharArray();
                if (Validar.VerificaCedula(charArray))
                {
                    MessageBox.Show("Cedula Correcta");
                }
                else
                {
                    MessageBox.Show("Cedula Incorrecta");
                }
            }
        }
        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }
        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNums(e);
        }
        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNums(e);
        }
        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (Validar.email_bien_escrito(txtCorreo.Text))
            {
            }
            else
            {
                MessageBox.Show("Correo Inválido");
            }
        }
    }
}
