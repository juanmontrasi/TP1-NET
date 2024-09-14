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
    public partial class FormComisionDetalle : Form
    {
        public FormComisionDetalle()
        {
            InitializeComponent();
        }
        public Comision comision;
        public Comision Comision
        {
            get { return comision; }
            set
            {
                comision = value;
                if (comision != null)
                {
                    this.SetComisiones();
                }
            }
        }
        public bool EditMode { get; internal set; } = false;
        private void FormComisionDetalle_Load(object sender, EventArgs e)
        {
            this.CargarPlanes();
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

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.ValidateComisiones())
            {
                if (comision != null)
                {
                    this.Comision.Nombre_Comision = nombreTextBox.Text;
                    this.Comision.Anio_Especialidad = int.Parse(anioTextBox.Text);
                    this.Comision.IdPlan = (int)cbPlanes.SelectedValue;


                    if (this.EditMode)
                    {
                        await ComisionesApi.UpdateAsync(this.Comision);
                    }
                    else
                    {
                        await ComisionesApi.AddAsync(this.Comision);
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Comision no está inicializada.");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetComisiones()
        {
            if (this.Comision != null)
            {
                nombreTextBox.Text = this.Comision.Nombre_Comision;
                anioTextBox.Text = this.Comision.Anio_Especialidad.ToString();
            }
        }

        private bool ValidateComisiones()
        {
            bool isValid = true;
            errorProvider1.SetError(nombreTextBox, string.Empty);
            errorProvider1.SetError(anioTextBox, string.Empty);
            if (this.nombreTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider1.SetError(nombreTextBox, "El Nombre es Requerido");
            }
            if (this.anioTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider1.SetError(anioTextBox, "El Año es Requerido");
            }
            return isValid;
        }
    }
}
