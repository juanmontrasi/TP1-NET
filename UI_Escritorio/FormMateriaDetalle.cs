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
using Google.Protobuf.WellKnownTypes;

namespace UI_Escritorio
{
    public partial class FormMateriaDetalle : Form
    {
        private Materia materia;
        public Materia Materia
        {
            get { return materia; }
            set
            {
                materia = value;
                if (materia != null)
                {
                    this.SetMateria();
                }
            }
        }

        public bool EditMode { get; internal set; } = false;

        private async void FormMateriaDetalle_Load(object sender, EventArgs e)
        {
            await CargarPlanes();
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
                        cbPlanes.DataSource = planes;
                        cbPlanes.DisplayMember = "Nombre_Plan";
                        cbPlanes.ValueMember = "IdPlan";
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

        public FormMateriaDetalle()
        {
            InitializeComponent();
        }
        private void SetMateria()
        {
            if (this.Materia != null)
            {
                nombreTextBox.Text = this.Materia.Nombre_Materia;
                hsemTextBox.Text = this.Materia.Hs_Semanales.ToString();
                htotTextBox.Text = this.Materia.Hs_Totales.ToString();
            }
        }

        private bool ValidateMateria()
        {
            bool isValid = true;
            errorProvider1.SetError(nombreTextBox, string.Empty);
            errorProvider1.SetError(hsemTextBox, string.Empty);
            errorProvider1.SetError(htotTextBox, string.Empty);

            if (this.nombreTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider1.SetError(nombreTextBox, "El Nombre es Requerido");
            }
            if (this.hsemTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider1.SetError(hsemTextBox, "Las horas Semanales son requeridas");
            }
            if (this.htotTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider1.SetError(htotTextBox, "Las horas Totales son requeridas");
            }
            return isValid;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.ValidateMateria())
            {
                if (materia != null)
                {
                    this.Materia.Nombre_Materia = nombreTextBox.Text;
                    this.Materia.Hs_Semanales = int.Parse(hsemTextBox.Text);
                    this.Materia.Hs_Totales = int.Parse(htotTextBox.Text);
                    this.Materia.IdPlan = (int)cbPlanes.SelectedValue;
                    try
                    {
                        if (this.EditMode)
                        {
                            await MateriasApi.UpdateAsync(this.Materia);
                        }
                        else
                        {
                            bool creada = await MateriasApi.AddAsync(this.Materia);

                            if (creada)
                            {
                                MessageBox.Show("Materia creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {

                                MessageBox.Show("Ya existe una materia con el mismo nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Materia no está inicializada.");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
