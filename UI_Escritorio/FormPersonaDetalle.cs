﻿using Entidades;
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


                    Persona creadaPersona = null;

                    if (this.EditMode)
                    {
                        await PersonaApi.UpdateAsync(this.Persona);
                        this.Close();
                    }
                    else
                    {
                        creadaPersona = await PersonaApi.AddAsync(this.Persona);

                        if (creadaPersona != null)
                        {
                            FormUsuarioDetalle formUsuarioDetalle = new FormUsuarioDetalle
                            {
                                Usuario = new Usuario(),
                                IdPersona = creadaPersona.IdPersona
                            };

                            var resultUsuario = formUsuarioDetalle.ShowDialog();

                            if (resultUsuario == DialogResult.OK)
                            {
                                this.Close();
                            }
                            else
                            {
                                await PersonaApi.DeleteAsync(creadaPersona.IdPersona);
                                MessageBox.Show("Debe Crear un Usuario para la Persona.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se pudo crear la persona.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Especialidad no está inicializada.");
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
            errorProvider.SetError(mailtb, string.Empty);
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




            // Validar Mail
            if (this.mailtb.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(mailtb, "El Mail es requerido");
            }


            // Validar Dirección
            if (this.direcciontb.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(direcciontb, "La Dirección es requerida");
            }

            return isValid;
        }
        
    }
}