using System;
using System.Windows.Forms;
using Entidades;

namespace UI_Escritorio
{
    public partial class FormInscripcionesAlumno : Form
    {
        private Usuario usuario;
        public FormInscripcionesAlumno(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            if (!usuario.Rol.Equals("Alumno") && !usuario.Rol.Equals("Administrador"))
            {
                MessageBox.Show("Solo los alumnos o administradores pueden acceder a este formulario.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (usuario.Rol.Equals("Administrador"))
            {
                this.GetAllAndLoad();
            }
            else if (usuario.Rol.Equals("Alumno"))
            {
                this.GetAllAndLoadAlumno();
            }
        }

        private async void GetAllAndLoad()
        {
            this.dgvInscripcionesAlumno.DataSource = null;
            this.dgvInscripcionesAlumno.AutoGenerateColumns = true;
            var alumnoInscripciones = await AlumnoInscripcionesApi.GetAllAsync();
            this.dgvInscripcionesAlumno.DataSource = alumnoInscripciones;
            this.dgvInscripcionesAlumno.Refresh();

            if (this.dgvInscripcionesAlumno.Rows.Count > 0)
            {
                this.dgvInscripcionesAlumno.Rows[0].Selected = true;
                this.btnBorrar.Visible = false;
                this.btnEditar.Visible = true;
                this.btnNuevo.Visible = false;
                this.btnListar.Visible = true;
            }
            else
            {
                this.btnBorrar.Visible = false;
                this.btnEditar.Visible = false;
                this.btnNuevo.Visible = false;
            }
        }


        private async void GetAllAndLoadAlumno()
        {
            this.dgvInscripcionesAlumno.DataSource = null;
            this.dgvInscripcionesAlumno.AutoGenerateColumns = true;
            var alumnoInscripciones = await AlumnoInscripcionesApi.GetByAlumnoIdAsync(usuario.IdPersona);
            this.dgvInscripcionesAlumno.DataSource = alumnoInscripciones;
            this.dgvInscripcionesAlumno.Refresh();

            if (this.dgvInscripcionesAlumno.Rows.Count > 0)
            {
                this.dgvInscripcionesAlumno.Rows[0].Selected = true;
                this.btnBorrar.Visible = true;
                this.btnEditar.Visible = false; 
                this.btnNuevo.Visible = true;

            }
            else
            {
                this.btnBorrar.Visible = false;
                this.btnEditar.Visible = false;
                this.btnNuevo.Visible = true;
            }
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar la inscripcion del alumno?", "Eliminar inscripcion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                AlumnoInscripcion alumnoInscripcionSelected = this.SelectedItem();
                if (alumnoInscripcionSelected != null)
                {
                    int id = alumnoInscripcionSelected.IdAlumnoInscripcion;
                    await AlumnoInscripcionesApi.DeleteAsync(id);
                    this.GetAllAndLoadAlumno();
                }

                MessageBox.Show("Inscripcion eliminada con éxito", "Inscripcion Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            else if (result == DialogResult.Cancel)
            {
                return;
            }

        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            FormAlumnoInscripcionesDetalle formAlumnoInscripcionesDetalle = new FormAlumnoInscripcionesDetalle(usuario);

            AlumnoInscripcion selectedInscripcion = this.SelectedItem();
            if (selectedInscripcion != null)
            {
                int id = selectedInscripcion.IdAlumnoInscripcion;
                AlumnoInscripcion alumnoInscripcion = await AlumnoInscripcionesApi.GetAsync(id);

                formAlumnoInscripcionesDetalle.EditMode = true;
                formAlumnoInscripcionesDetalle.AlumnoInscripcion = alumnoInscripcion;

                formAlumnoInscripcionesDetalle.ShowDialog();
                this.GetAllAndLoad();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna inscripción.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            FormAlumnoInscripcionesDetalle formAlumnoInscripcionesDetalle = new FormAlumnoInscripcionesDetalle(usuario);
            AlumnoInscripcion alumnoInscripcionNuevo = new AlumnoInscripcion();
            formAlumnoInscripcionesDetalle.EditMode = false;
            formAlumnoInscripcionesDetalle.AlumnoInscripcion = alumnoInscripcionNuevo; 

            formAlumnoInscripcionesDetalle.ShowDialog();
            this.GetAllAndLoadAlumno();
        }

        private AlumnoInscripcion SelectedItem()
        {
            if (dgvInscripcionesAlumno.SelectedRows.Count > 0)
            {
                dynamic selectedDynamic = dgvInscripcionesAlumno.SelectedRows[0].DataBoundItem;
                var jObject = (Newtonsoft.Json.Linq.JObject)selectedDynamic;

                
                var alumnoInscripcion = new AlumnoInscripcion
                {
                    IdAlumnoInscripcion = jObject["idAlumnoInscripcion"]?.ToObject<int>() ?? 0,
                    IdPersona = jObject["idPersona"]?.ToObject<int>() ?? 0,
                    IdCurso = jObject["idCurso"]?.ToObject<int>() ?? 0,
                    Nota = jObject["nota"]?.ToObject<int>() ?? 0,
                    Condicion = jObject["condicion"]?.ToObject<string>() ?? string.Empty,
                    Persona = new Persona
                    {
                        IdPersona = jObject["idPersona"]?.ToObject<int>() ?? 0,
                        Nombre = jObject["personaNombre"]?.ToObject<string>() ?? string.Empty,
                        Apellido = jObject["personaApellido"]?.ToObject<string>() ?? string.Empty
                    },
                    Curso = new Curso
                    {
                        IdCurso = jObject["idCurso"]?.ToObject<int>() ?? 0,
                        Nombre = jObject["cursoNombre"]?.ToObject<string>() ?? string.Empty
                    }
                };

                
                return alumnoInscripcion;
            }
            return null;
        }





        private void FormInscripcionesAlumno_Load(object sender, EventArgs e)
        {
            if (usuario.Rol.Equals("Administrador"))
            {
                this.GetAllAndLoad();
            }
            else if (usuario.Rol.Equals("Alumno"))
            {
                this.GetAllAndLoadAlumno();
            }
        }
    }
}
