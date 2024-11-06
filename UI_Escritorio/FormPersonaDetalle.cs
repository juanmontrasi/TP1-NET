using Entidades;
using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;

namespace UI_Escritorio
{
    public partial class FormPersonaDetalle : Form
    {
        public Persona persona;

        public int idPersonaCreada { get; set; }
        public Persona Persona
        {
            get { return persona; }
            set
            {
                persona = value;
                if (persona != null)
                    SetPersona();
            }
        }

        public bool EditMode { get; set; } = false;

        public FormPersonaDetalle()
        {
            InitializeComponent();
        }

        private void FormPersonaDetalle_Load(object sender, EventArgs e)
        {
            
        }

        private void SetPersona()
        {
            if (this.Persona != null)
            {
                nombreTextBox.Text = this.Persona.Nombre;
                apellidotb.Text = this.Persona.Apellido;
                mailtb.Text = this.Persona.Mail;
                direcciontb.Text = this.Persona.Direccion;

                if (DateTime.TryParse(this.Persona.FechaNacimiento, out DateTime fechaNacimiento))
                {
                    fechaNacdtp.Value = fechaNacimiento;
                }
            }
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidatePersona())
            {
                if (persona != null)
                {
                    
                    this.Persona.Nombre = nombreTextBox.Text;
                    this.Persona.Apellido = apellidotb.Text;
                    this.Persona.Mail = mailtb.Text;
                    this.Persona.Direccion = direcciontb.Text;
                    this.Persona.FechaNacimiento = fechaNacdtp.Value.ToString("yyyy-MM-dd");

                    try
                    {
                        bool creada = false;
                        

                        if (this.EditMode)
                        {
                            await PersonaApi.UpdateAsync(this.Persona);
                            MessageBox.Show("Persona actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            creada = await PersonaApi.AddAsync(this.Persona);
                            
                        }

                        if (creada)
                        {
                            Persona personaCreada = await PersonaApi.GetPersonaCreated(Persona.Nombre, Persona.Apellido, Persona.FechaNacimiento);
                            idPersonaCreada = personaCreada.IdPersona;
                            FormUsuarioDetalle formUsuarioDetalle = new FormUsuarioDetalle
                            {
                                IdPersona = idPersonaCreada
                            };


                            var result = formUsuarioDetalle.ShowDialog();

                            if (result == DialogResult.OK)
                            {
                                MessageBox.Show("Usuario creado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {

                                await PersonaApi.DeleteAsync(idPersonaCreada);
                                MessageBox.Show("Se produjo un error al crear el usuario. La persona ha sido eliminada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (!creada)
                        {
                            MessageBox.Show("Ya existe una persona con el mismo Nombre, Apellido y Fecha de Nacimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La persona no está inicializada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidatePersona()
        {
            bool isValid = true;

            errorProvider.SetError(nombreTextBox, string.Empty);
            errorProvider.SetError(apellidotb, string.Empty);
            errorProvider.SetError(mailtb, string.Empty);
            errorProvider.SetError(direcciontb, string.Empty);

            
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                isValid = false;
                errorProvider.SetError(nombreTextBox, "El Nombre es requerido");
            }

            if (string.IsNullOrWhiteSpace(apellidotb.Text))
            {
                isValid = false;
                errorProvider.SetError(apellidotb, "El Apellido es requerido");
            }

            if (string.IsNullOrWhiteSpace(mailtb.Text))
            {
                isValid = false;
                errorProvider.SetError(mailtb, "El Mail es requerido");
            }

            if (string.IsNullOrWhiteSpace(direcciontb.Text))
            {
                isValid = false;
                errorProvider.SetError(direcciontb, "La Dirección es requerida");
            }

            return isValid;
        }
    }
}
