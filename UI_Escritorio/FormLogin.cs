using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Escritorio
{
    public partial class FormLogin : Form
    {
        public Usuario UsuarioAutenticado { get; private set; }
        public FormLogin()
        {
            InitializeComponent();

        }
        private async void BtnIngresar_Click(object sender, EventArgs e)
        {
            // La propiedad Text de los TextBox contiene el texto escrito en ellos

            string nombreUsuario = txtUsuario.Text;
            string clave = txtPass.Text;

            var usuario = await UsuariosApi.AuthenticateAsync(nombreUsuario, clave);

            if (usuario != null)
            {
                // Credenciales correctas, almacenar el usuario autenticado y cerrar el formulario
                UsuarioAutenticado = usuario;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        
        private void LnkOlvidaPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
