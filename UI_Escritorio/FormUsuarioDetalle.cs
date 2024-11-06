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
            this.Usuario = new Usuario(); 
        }

        public bool EditMode { get; set; } = false;

        private async void FormUsuarioDetalle_Load(object sender, EventArgs e)
        {
            
            comboBoxRol.Items.AddRange(roles.ToArray());

            if(IdPersona.HasValue)
            {
                Persona personaCreada = await PersonaApi.GetAsync(IdPersona.Value);
                
                comboBoxPersonas.DataSource = new List<Persona> { personaCreada };
                comboBoxPersonas.DisplayMember = "Mail";
                comboBoxPersonas.ValueMember = "IdPersona";
                comboBoxPersonas.Enabled = false;
            }
            else if (IdPersona == null)
            {
                await CargaPersonas();
                comboBoxPersonas.Enabled = true;

            }

            if(EditMode)
            {
                 SetUsuario();
            }


            
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
                            this.Close();
                        }
                        else
                        {
                            bool creada = await UsuariosApi.AddAsync(this.Usuario);

                            if (creada)
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ya existe un usuario con el mismo nombre o ya existe un usuario para la misma persona y el mismo Rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                claveTextBox.Text = this.Usuario.Clave;
                comboBoxRol.SelectedItem = this.Usuario.Rol;
                comboBoxPersonas.SelectedValue = this.Usuario.IdPersona; 
                comboBoxPersonas.Enabled = false;
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
                errorProvider1.SetError(claveTextBox, "La Clave es Requerida"); 
            }
            if (this.comboBoxRol.SelectedItem == null)
            {
                isValid = false;
                errorProvider1.SetError(comboBoxRol, "El rol es Requerido"); 
            }
            if (this.comboBoxPersonas.SelectedItem == null)
            {
                isValid = false;
                errorProvider1.SetError(comboBoxPersonas, "La persona es Requerida"); 
            }

            return isValid;
        }

      

        private async Task CargaPersonas()
        {
            var personas = await PersonaApi.GetAllAsync();
            comboBoxPersonas.DataSource = personas;
            comboBoxPersonas.DisplayMember = "Mail";
            comboBoxPersonas.ValueMember = "IdPersona";
           
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

