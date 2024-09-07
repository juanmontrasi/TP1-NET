using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace UI_Escritorio
{
    public partial class FormEspecialidadDetalle : Form
    {
        private Especialidad especialidad;

        public Especialidad Especialidad
        {
            get { return especialidad; }
            set
            {
                especialidad = value;
                if (especialidad != null)
                {
                    this.SetEspecialidad();
                }
            }
        }

        public bool EditMode { get; set; } = false;

        public FormEspecialidadDetalle()
        {
            InitializeComponent();
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateEspecialidad())
            {
                if (especialidad != null)
                {
                    this.Especialidad.Nombre_Especialidad = nombreTextBox.Text;

                    if (this.EditMode)
                    {
                        await EspecialidadesApi.UpdateAsync(this.Especialidad);
                    }
                    else
                    {
                        await EspecialidadesApi.AddAsync(this.Especialidad);
                    }

                    this.Close();
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

        private void SetEspecialidad()
        {
            if (this.Especialidad != null)
            {
                nombreTextBox.Text = this.Especialidad.Nombre_Especialidad;
            }
        }

        private bool ValidateEspecialidad()
        {
            bool isValid = true;
            errorProvider.SetError(nombreTextBox, string.Empty);

            if (this.nombreTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(nombreTextBox, "El Nombre es Requerido");
            }

            return isValid;
        }
    }
}
