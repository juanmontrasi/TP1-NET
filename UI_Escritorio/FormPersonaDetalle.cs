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
using System.Net.Http;

namespace UI_Escritorio
{
    public partial class FormPersonaDetalle : Form
    {
        public Persona persona;

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

        private async void FormPersonaDetalle_Load(object sender, EventArgs e)
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
                    
                    this.Persona.Nombre = nombreTextBox.Text;
                    this.Persona.Apellido = apellidotb.Text;
                    this.Persona.Mail = mailtb.Text;
                    this.Persona.Direccion = direcciontb.Text;
                    this.Persona.FechaNacimiento = fechaNacdtp.Value.ToString("yyyy-MM-dd");

                    try
                    {
                        bool creada;

                        if (this.EditMode)
                        {
                            await PersonaApi.UpdateAsync(this.Persona);
                            creada = true; 
                        }
                        else
                        {
                            creada = await PersonaApi.AddAsync(this.Persona); 
                        }

                        if (creada)
                        {
                            
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
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

           
            if (this.nombreTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(nombreTextBox, "El Nombre es requerido");
            }

           
            if (this.apellidotb.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(apellidotb, "El Apellido es requerido");
            }




           
            if (this.mailtb.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(mailtb, "El Mail es requerido");
            }


           
            if (this.direcciontb.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(direcciontb, "La Dirección es requerida");
            }

            return isValid;
        }
        
    }
}