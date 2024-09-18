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
    public partial class FormUsuarioDetalle : Form
    {
        public Usuario usuario;

        public IEnumerable<string> roles = new List<string> { "Alumno", "Administrador", "Docente" };
        public int? IdPersona { get; set; }
        public Usuario Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                if (usuario != null)
                    this.SetUsuario();
            }
        }

        public FormUsuarioDetalle()
        {
            InitializeComponent();
            
        }
        public bool EditMode { get; set; } = false;
        private async void FormUsuarioDetalle_Load(object sender, EventArgs e)
        {
            await CargarPersonas();

            if (IdPersona.HasValue)
            {
                comboBoxPersonas.SelectedValue = IdPersona.Value;
                comboBoxPersonas.Enabled = false;
            }
            comboBoxRol.Items.AddRange(roles.ToArray());
        }


        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.ValidateUsuario())
            {
                if (usuario != null)
                {
                    this.Usuario.Nombre_Usuario = nombreTextBox.Text;
                    this.Usuario.Clave = claveTextBox.Text;
                    this.Usuario.Rol = (string)comboBoxRol.SelectedItem;
                    this.Usuario.IdPersona = (int)comboBoxPersonas.SelectedValue;
                    this.Usuario.Habilitado = 1;

                    try
                    {
                        if (this.EditMode)
                        {
                            await UsuariosApi.UpdateAsync(this.Usuario);
                        }
                        else
                        {
                            await UsuariosApi.AddAsync(this.Usuario);
                        }

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no está inicializado.");
                }
            }
        }


        private void SetUsuario()
        {
            if (this.Usuario != null)
            {
                nombreTextBox.Text = this.Usuario.Nombre_Usuario;
            }
            if (this.Usuario != null)
            {
                claveTextBox.Text = this.Usuario.Clave;
            }
            if (this.Usuario != null)
            {
                comboBoxRol.SelectedItem = this.Usuario.Rol;
            }
        }

        private bool ValidateUsuario()
        {
            bool isValid = true;
            errorProvider1.SetError(nombreTextBox, string.Empty);
            errorProvider1.SetError(claveTextBox, string.Empty);
            errorProvider1.SetError(comboBoxRol, string.Empty);
            errorProvider1.SetError(comboBoxPersonas, string.Empty);

            if (this.nombreTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider1.SetError(nombreTextBox, "El Nombre es Requerido");
            }
            if (this.claveTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider1.SetError(nombreTextBox, "La Clave es Requerida");
            }
            if (this.comboBoxRol.SelectedItem == null)
            {
                isValid = false;
                errorProvider1.SetError(nombreTextBox, "El rol es Requerido");
            }
            if (this.comboBoxPersonas.SelectedItem == null)
            {
                isValid = false;
                errorProvider1.SetError(nombreTextBox, "El rol es Requerido");
            }

            return isValid;
        }

        private async Task CargarPersonas()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:7111/personas";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var personas = await response.Content.ReadAsAsync<List<Persona>>();
                        comboBoxPersonas.DataSource = personas;
                        comboBoxPersonas.DisplayMember = "Legajo";
                        comboBoxPersonas.ValueMember = "IdPersona";

                        if (IdPersona.HasValue)
                        {
                            comboBoxPersonas.SelectedValue = IdPersona.Value;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar personas: " + response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con el servidor: " + ex.Message);
                }
            }
        }



        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }


        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}

