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
    public partial class FormPersonaDetalle : Form
    {
        private Persona persona;

        public Persona Persona
        {
            get { return persona; }
            set {
                persona = value;
                    if (persona != null)
                    this.SetPersona();
                } 
        }
        public bool EditMode { get; internal set; } = false;
        public FormPersonaDetalle()
        {
            InitializeComponent();
        }
        private async void FormPersonaDetalle_Load(object sender, EventArgs e) 
        {
            await CargarPlanes();
            comboBoxTipoPersona.DataSource = Enum.GetValues(typeof(TipoPersona));
         
        }

        private void SetPersona()
        {
            if (this.Persona != null)
            {
                nombreTextBox.Text = this.Persona.Nombre;
                apellidotb.Text = this.Persona.Apellido;
                legajotb.Text = this.Persona.Legajo.ToString();
                mailtb.Text = this.Persona.Mail;
                direcciontb.Text = this.Persona.Direccion;
                comboBoxTipoPersona.SelectedItem = (TipoPersona)this.Persona.Tipo_Persona;


                if (!string.IsNullOrEmpty(this.Persona.FechaNacimiento))
                {
                    fechaNacdtp.Value = DateTime.Parse(this.Persona.FechaNacimiento);
                }
            }
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidatePersona())
            {
                if (persona != null)
                {
                    if (comboBoxPlanes.SelectedValue != null && int.TryParse(comboBoxPlanes.SelectedValue.ToString(), out int idPlan))
                    {
                        this.Persona.IdPlan = idPlan;
                    }
                    else
                    {
                        MessageBox.Show("El Plan seleccionado no es válido.");
                        return;
                    }

                    TipoPersona tipoPersonaSeleccionado = (TipoPersona)comboBoxTipoPersona.SelectedItem;
                    this.Persona.Tipo_Persona = (int)tipoPersonaSeleccionado;

                    this.Persona.Nombre = nombreTextBox.Text;
                    this.Persona.Apellido = apellidotb.Text;
                    this.Persona.Legajo = int.Parse(legajotb.Text);
                    this.Persona.Mail = mailtb.Text;
                    this.Persona.Direccion = direcciontb.Text;
                    this.Persona.FechaNacimiento = fechaNacdtp.Value.ToString("yyyy-MM-dd");
                    


                    if (this.EditMode)
                    {
                        await PersonaApi.UpdateAsync(this.Persona);
                        this.Close();
                    }
                    else
                    {
                       await PersonaApi.AddAsync(this.Persona);
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Persona no está inicializada.");
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

            // Limpiar errores previos
            errorProvider.SetError(nombreTextBox, string.Empty);
            errorProvider.SetError(apellidotb, string.Empty);
            errorProvider.SetError(legajotb, string.Empty);
            errorProvider.SetError(comboBoxTipoPersona, string.Empty);
            errorProvider.SetError(mailtb, string.Empty);
            errorProvider.SetError(comboBoxPlanes, string.Empty);
            errorProvider.SetError(direcciontb, string.Empty);

            // Validar Nombre
            if (this.nombreTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(nombreTextBox, "El Nombre es requerido");
            }

            // Validar Apellido
            if (this.apellidotb.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(apellidotb, "El Apellido es requerido");
            }

            // Validar Legajo
            if (this.legajotb.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(legajotb, "El Legajo es requerido");
            }
            else
            {
                // Validar que Legajo sea un número
                if (!int.TryParse(legajotb.Text, out _))
                {
                    isValid = false;
                    errorProvider.SetError(legajotb, "El Legajo debe ser un número");
                }
            }

            // Validar Tipo de Persona
            if (comboBoxTipoPersona.SelectedItem == null)
            {
                isValid = false;
                errorProvider.SetError(comboBoxTipoPersona, "El Tipo de Persona es requerido");
            }

            // Validar Mail
            if (this.mailtb.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(mailtb, "El Mail es requerido");
            }

            // Validar Plan
            if (comboBoxPlanes.SelectedItem == null)
            {
                isValid = false;
                errorProvider.SetError(comboBoxPlanes, "El Plan es requerido");
            }

            // Validar Dirección
            if (this.direcciontb.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(direcciontb, "La Dirección es requerida");
            }

            return isValid;
        }

        private async Task CargarPlanes()
        {
            using (HttpClient client = new HttpClient())
            {

                string apiUrl = "https://localhost:7111/planes";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var planes = await response.Content.ReadAsAsync<List<Plan>>();
                        comboBoxPlanes.DataSource = planes;
                        comboBoxPlanes.DisplayMember = "Nombre_Plan";
                        comboBoxPlanes.ValueMember = "IdPlan";
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar Materias: " + response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con el servidor: " + ex.Message);
                }
            }
        }

    }
}
