﻿using Entidades;
using Org.BouncyCastle.Pqc.Crypto.Falcon;
using proyecto_academia.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_Escritorio
{
    public partial class FormAlumnoInscripcionesDetalle : Form
    {
        private AlumnoInscripcion alumnoInscripcion;
        public int? IdCurso { get; set; }
        
        public bool EditMode { get; internal set; } = false;
        private Usuario usuario;
        public IEnumerable<string> condiciones = new List<string>
            {
                "Inscripto",
                "Regular",
                "Aprobada",
                "Libre"
            };

        public FormAlumnoInscripcionesDetalle(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            cbCondicion.DataSource = condiciones.ToList();
            cbCondicion.SelectedItem = "Inscripto";


            if (usuario.Rol.Equals("Alumno"))
            {
                cbAlumnos.DataSource = new List<Usuario> { usuario };
                cbAlumnos.DisplayMember = "Nombre_Usuario";
                cbAlumnos.ValueMember = "IdPersona";
                cbAlumnos.Enabled = false;
                tbNota.Enabled = false;
                cbCondicion.Enabled = false;
            }

            if (!usuario.Rol.Equals("Alumno") && !usuario.Rol.Equals("Administrador"))
            {
                MessageBox.Show("Solo los usuarios con rol de Alumno o Administrador pueden acceder a esta sección.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void FormAlumnoInscripcionesDetalle_Load(object sender, EventArgs e)
        {
            await cargarCursos();

            if (IdCurso.HasValue)
            {
                cbCursos.SelectedValue = IdCurso.Value;
                cbCursos.Visible = false;
            }
            if(alumnoInscripcion != null)
            {
                UsuarioService usuarioService = new UsuarioService();
                Usuario user = usuarioService.GetAlumnoInscripcion(alumnoInscripcion.IdPersona);
                cbAlumnos.DataSource = new List<Usuario> { user };
                cbAlumnos.DisplayMember = "Nombre_Usuario";
                cbAlumnos.ValueMember = "IdPersona";
                cbAlumnos.Enabled = false;

            }
            else if (alumnoInscripcion == null)
            {
                UsuarioService usuarioService = new UsuarioService();
                Usuario user = usuarioService.GetAlumnoInscripcion(usuario.IdPersona);
                cbAlumnos.DataSource = new List<Usuario> { user };
                cbAlumnos.DisplayMember = "Nombre_Usuario";
                cbAlumnos.ValueMember = "IdPersona";
                cbAlumnos.Enabled = false;
            }
            
        }

        public AlumnoInscripcion AlumnoInscripcion
        {
            get { return alumnoInscripcion; }
            set
            {
                alumnoInscripcion = value;
                if (alumnoInscripcion != null)
                {
                    this.SetAlumnoInscripcion();
                }
            }
        }

        private async void SetAlumnoInscripcion()
        {
            cbCondicion.SelectedItem = alumnoInscripcion.Condicion;

            if (EditMode)
            {
                cbAlumnos.DisplayMember = "Nombre_Usuario";
                cbAlumnos.ValueMember = "IdPersona";
                cbAlumnos.SelectedValue = alumnoInscripcion.IdPersona;

                tbNota.Text = alumnoInscripcion.Nota.ToString();
                tbNota.Visible = true;
                cbCondicion.Visible = true;
                cbAlumnos.Enabled = false;
                cbCursos.Visible = false;
            }
            else
            {
                cbAlumnos.DataSource = new List<Usuario> { usuario };
                cbAlumnos.DisplayMember = "Nombre_Usuario";
                cbAlumnos.ValueMember = "IdPersona";
                cbAlumnos.Visible = false;

                tbNota.Text = string.Empty;
                cbCondicion.SelectedItem = "Inscripto";
                cbCondicion.Visible = false;
                tbNota.Visible = false;
                cursolb.Visible = false;
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validateAlumno())
                {
                    if (alumnoInscripcion == null)
                    {
                        alumnoInscripcion = new AlumnoInscripcion();
                    }

                    if (!EditMode)
                    {
                        alumnoInscripcion.IdPersona = (int)cbAlumnos.SelectedValue;
                    }

                    alumnoInscripcion.IdCurso = Convert.ToInt32(cbCursos.SelectedValue);
                    alumnoInscripcion.Condicion = cbCondicion.SelectedItem.ToString();

                    if (EditMode && usuario.Rol.Equals("Administrador"))
                    {
                        if (int.TryParse(tbNota.Text, out int nota))
                        {
                            alumnoInscripcion.Nota = nota;

                            if (nota < 1 || nota > 10)
                            {
                                MessageBox.Show("La nota debe estar entre 1 y 10.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbNota.Focus();
                                return;
                            }

                            bool result = await AlumnoInscripcionesApi.UpdateAsync(alumnoInscripcion);
                            if (!result)
                            {
                                MessageBox.Show("Error al actualizar la inscripción. Asegúrate de que la Nota sea válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("La nota debe ser un número entero válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbNota.Focus();
                            return;
                        }
                    }
                    else if (!EditMode)
                    {
                        alumnoInscripcion.Condicion = "Inscripto";
                        bool result = await AlumnoInscripcionesApi.AddAsync(alumnoInscripcion);
                        if (!result)
                        {
                            MessageBox.Show("Error al agregar la inscripción. El alumno puede que ya esté inscrito en este curso o que no haya cupo del curso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validateAlumno()
        {
            bool isValid = true;

            errorProvider.SetError(cbCondicion, string.Empty);
            errorProvider.SetError(cbAlumnos, string.Empty);
            errorProvider.SetError(tbNota, string.Empty);
            errorProvider.SetError(cbCursos, string.Empty);

            if (string.IsNullOrWhiteSpace(cbCondicion.Text))
            {
                isValid = false;
                errorProvider.SetError(cbCondicion, "La condición es requerida.");
            }

            if (cbAlumnos.SelectedValue == null || !int.TryParse(cbAlumnos.SelectedValue.ToString(), out int alumnoId) || alumnoId == 0)
            {
                isValid = false;
                errorProvider.SetError(cbAlumnos, "El alumno es requerido.");
            }

            if (cbCursos.SelectedValue == null || !int.TryParse(cbCursos.SelectedValue.ToString(), out int cursoId) || cursoId == 0)
            {
                isValid = false;
                errorProvider.SetError(cbCursos, "El curso es requerido.");
            }

            return isValid;
        }

        
        private async Task cargarCursos()
        { 
                        var cursos = await CursosApi.GetAllAsync();
                        cbCursos.DataSource = cursos;
                        cbCursos.DisplayMember = "Nombre";
                        cbCursos.ValueMember = "IdCurso";

                        if (IdCurso.HasValue)
                        {
                            cbCursos.SelectedValue = IdCurso.Value;
                        }
            
        }
    }
}
