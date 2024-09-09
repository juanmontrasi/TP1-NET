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
    public partial class FormPlanesDetalle : Form
    {
        private Plan plan;

        public Plan Plan
        {
            get { return plan; }
            set
            {
                plan = value;
                if (plan != null)
                {
                    this.SetPlan();
                }
            }
        }

        public async void PlanesDetalle_Load(object sender, EventArgs e)
        {

        }
        public FormPlanesDetalle()
        {
            InitializeComponent();
        }
        public bool EditMode { get; set; } = false;

         private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidatePlan())
            {
                if (plan != null)
                {
                    this.Plan.Nombre_Plan = nombreTextBox.Text;

                    if (this.EditMode)
                    {
                        await PlanesApi.UpdateAsync(this.Plan);
                    }
                    else
                    {
                        await PlanesApi.AddAsync(this.Plan);
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("El Plan no está inicializado.");
                }
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetPlan()
        {
            if (this.Plan != null)
            {
                nombreTextBox.Text = this.Plan.Nombre_Plan;
            }
        }

        private bool ValidatePlan()
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
