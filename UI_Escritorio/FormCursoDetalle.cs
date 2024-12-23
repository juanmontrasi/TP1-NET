﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Escritorio
{
    public partial class FormCursoDetalle : Form
    {
        public FormCursoDetalle()
        {
            InitializeComponent();
            cbComisiones.Enabled = false;
            cbComisiones.DataSource = null;
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
        }

        private async Task CargarMaterias()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:7111/materiasEnum";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var materias = await response.Content.ReadAsAsync<List<Materia>>();
                        cbMateria.DataSource = materias;
                        cbMateria.DisplayMember = "Nombre_Materia";
                        cbMateria.ValueMember = "IdMateria";

                        
                        if (this.EditMode && this.Curso != null)
                        {
                            cbMateria.SelectedValue = this.Curso.IdMateria;
                            
                            cbComisiones.SelectedValue = this.Curso.IdComision;
                        }
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

                    try
                    {
                        if (this.EditMode)
                        {
                            await CursosApi.UpdateAsync(this.Curso);
                            this.Close();
                        }
                        else
                        {
                            bool creada = await CursosApi.AddAsync(this.Curso);

                            if (creada)
                            {
                                MessageBox.Show("Curso creado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Ya existe un curso con el mismo nombre, materia, cupo, comision, y año calendario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                
                cbMateria.SelectedValue = this.Curso.IdMateria;
                cbComisiones.SelectedValue = this.Curso.IdComision;
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

        private void cbMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMateria.SelectedItem != null)
            {
                var materiaSeleccionada = (Materia)cbMateria.SelectedItem;
                if (materiaSeleccionada != null)
                {
                    int planId = materiaSeleccionada.IdPlan;
                    this.CargarComisiones(planId);
                }
            }
        }

        private async Task CargarComisiones(int idPlan)
        {
            cbComisiones.DataSource = null;
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:7111/comisionesEnum";

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var comisiones = await response.Content.ReadAsAsync<List<Comision>>();
                        var comisionesPlan = comisiones.Where(c => c.IdPlan == idPlan).ToList();
                        if (comisionesPlan.Any())
                        {
                            cbComisiones.Enabled = true;
                            cbComisiones.DataSource = comisionesPlan;
                            cbComisiones.DisplayMember = "Nombre_Comision";
                            cbComisiones.ValueMember = "IdComision";

                            // Seleccionar la comisión del curso si está en modo edición
                            if (this.EditMode && this.Curso != null)
                            {
                                cbComisiones.SelectedValue = this.Curso.IdComision;
                            }
                        }
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
    }
}
