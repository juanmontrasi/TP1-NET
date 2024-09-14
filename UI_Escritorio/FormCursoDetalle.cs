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
    public partial class FormCursoDetalle : Form
    {
        public FormCursoDetalle()
        {
            InitializeComponent();
        }
        public Curso curso;
        public Curso Curso
        {
            get { return curso; }
            set
            {
                curso = value;
                if (curso != null)
                {
                    this.SetCursos();
                }
            }
        }
        public bool EditMode { get; internal set; } = false;

        private void FormCursoDetalle_Load(object sender, EventArgs e)
        {
            this.CargarMaterias();
            this.CargarComisiones();
        }
        private async Task CargarMaterias()
        {
            using (HttpClient client = new HttpClient())
            {

                string apiUrl = "https://localhost:7111/materias";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var materias = await response.Content.ReadAsAsync<List<Materia>>();
                        cbMateria.DataSource = materias;
                        cbMateria.DisplayMember = "Nombre_Materia";
                        cbMateria.ValueMember = "IdMateria";
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

        private async Task CargarComisiones()
        {
            using (HttpClient client = new HttpClient())
            {

                string apiUrl = "https://localhost:7111/comisiones";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var comisiones = await response.Content.ReadAsAsync<List<Comision>>();
                        cbComisiones.DataSource = comisiones;
                        cbComisiones.DisplayMember = "Nombre_Comision";
                        cbComisiones.ValueMember = "IdComision";
                    }
                    else
                    {
                        MessageBox.Show("Error al cargar Comisiones: " + response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con el servidor: " + ex.Message);
                }
            }
        }

        private async void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (this.ValidateCursos())
            {
                if (curso != null)
                {
                    this.Curso.Nombre = nombreTextBox.Text;
                    this.Curso.Anio_Calendario = int.Parse(anioTextBox.Text);
                    this.Curso.Cupo = int.Parse(cupoTextBox.Text);
                    this.Curso.IdMateria = (int)cbMateria.SelectedValue;
                    this.Curso.IdComision = (int)cbComisiones.SelectedValue;


                    if (this.EditMode)
                    {
                        await CursosApi.UpdateAsync(this.Curso);
                    }
                    else
                    {
                        await CursosApi.AddAsync(this.Curso);
                    }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Curso no está inicializada.");
                }
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetCursos()
        {
            if (this.Curso != null)
            {
                nombreTextBox.Text = this.Curso.Nombre;
                cupoTextBox.Text = this.Curso.Cupo.ToString();
                anioTextBox.Text = this.Curso.Anio_Calendario.ToString();
            }
        }

        private bool ValidateCursos()
        {
            bool isValid = true;
            errorProvider1.SetError(nombreTextBox, string.Empty);
            errorProvider1.SetError(cupoTextBox, string.Empty);
            errorProvider1.SetError(anioTextBox, string.Empty);


            if (this.nombreTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider1.SetError(nombreTextBox, "El Nombre es Requerido");
            }
            if (this.cupoTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider1.SetError(cupoTextBox, "El Cupo es Requerido");
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
