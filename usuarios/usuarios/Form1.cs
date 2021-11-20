﻿using AccesoDatos.ClassLibrary1;
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

        private void login()
        {
            try
            {
                string correo = txtUser.Text.TrimStart().TrimEnd();
                string clave = txtPassword.Text;

                //string ecriptar = logica.encriptar(clave);

                if (!string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(clave))
                {
                    Usuario usuario = new Usuario();
                    usuario = LogicaUsuario.getUserXLogin(correo, clave);
                    if (usuario != null)
                    {
                        var dataUser = usuario.usu_nombres + " " + usuario.usu_apellidos;
                        //Interpolation
                        var dataUser2 = $"{ usuario.usu_nombres}  { usuario.usu_apellidos}";

                        MessageBox.Show("Bienvenido al sistema\n Rol:" + usuario.Rol.rol_descripcion
                        + "\nUsuario: " + dataUser2, "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                else
                {
                    MessageBox.Show("Error en usuario o clave", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
