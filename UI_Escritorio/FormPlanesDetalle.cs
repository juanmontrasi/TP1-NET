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
        public int? IdEspecialidad { get; set; } 
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

        public FormPlanesDetalle()
        {
            InitializeComponent();
        }

        public bool EditMode { get; set; } = false;

        private async void PlanesDetalle_Load(object sender, EventArgs e)
        {
            

            if (IdEspecialidad.HasValue)
            {
                Entidades.Especialidad especialidadCreada = await EspecialidadesApi.GetAsync(IdEspecialidad.Value);
                comboBoxEspecialidades.DataSource = new List<Entidades.Especialidad> { especialidadCreada };
                comboBoxEspecialidades.DisplayMember = "Nombre_Especialidad";
                comboBoxEspecialidades.ValueMember = "IdEspecialidad";
                comboBoxEspecialidades.Enabled = false;
            }
            else if (IdEspecialidad == null) { await CargaEspecialidades(); }
        }

        private async void aceptarButton_Click(object sender, EventArgs e)
        {
            if (this.ValidatePlan())
            {
                if (plan != null)
                {
                    this.Plan.Nombre_Plan = nombreTextBox.Text;
                    this.Plan.IdEspecialidad = (int)comboBoxEspecialidades.SelectedValue; 

                    try
                    {
                        bool creado;

                        if (this.EditMode)
                        {
                            await PlanesApi.UpdateAsync(this.Plan);
                            creado = true;
                        }
                        else
                        {
                            creado = await PlanesApi.AddAsync(this.Plan);
                        }

                        if (creado)
                        {
                            MessageBox.Show("Plan creado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close(); 
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un plan con ese nombre y especialidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("El Plan no está inicializado.");
                }
            }
        }



        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

       /* private async Task CargarEspecialidades()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:7111/especialidades";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var especialidades = await response.Content.ReadAsAsync<List<Especialidad>>();
                        comboBoxEspecialidades.DataSource = especialidades;
                        comboBoxEspecialidades.DisplayMember = "Nombre_Especialidad";
                        comboBoxEspecialidades.ValueMember = "IdEspecialidad";

                        if (IdEspecialidad.HasValue)
                        {
                            comboBoxEspecialidades.SelectedValue = IdEspecialidad.Value;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar especialidades: " + response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con el servidor: " + ex.Message);
                }
            }
        }*/

        private async Task CargaEspecialidades()
        {
            try
            {
                var especialidades = await EspecialidadesApi.GetAllAsync();
                comboBoxEspecialidades.DataSource = especialidades;
                comboBoxEspecialidades.DisplayMember = "Nombre_Especialidad";
                comboBoxEspecialidades.ValueMember = "IdEspecialidad";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar especialidades: " + ex.Message);
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

        
    }
}
