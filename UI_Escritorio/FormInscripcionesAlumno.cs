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
                this.btnBorrar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnNuevo.Enabled = false;
                this.btnListar.Enabled = true;
            }
            else
            {
                this.btnBorrar.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnNuevo.Enabled=false;
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
                this.btnBorrar.Enabled = true;
                this.btnEditar.Enabled = false; 
                this.btnNuevo.Enabled = true;

            }
            else
            {
                this.btnBorrar.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnNuevo.Enabled = true;
            }
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            AlumnoInscripcion alumnoInscripcionSelected = this.SelectedItem();
            if( alumnoInscripcionSelected != null )
            {
                int id = alumnoInscripcionSelected.IdAlumnoInscripcion;
                await AlumnoInscripcionesApi.DeleteAsync(id);
                this.GetAllAndLoadAlumno();
            }
            
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            
            FormAlumnoInscripcionesDetalle formAlumnoInscripcionesDetalle = new FormAlumnoInscripcionesDetalle(usuario);

            
            int id = this.SelectedItem().IdAlumnoInscripcion;
            AlumnoInscripcion alumnoInscripcion = await AlumnoInscripcionesApi.GetAsync(id);

            
            formAlumnoInscripcionesDetalle.EditMode = true;
            formAlumnoInscripcionesDetalle.AlumnoInscripcion = alumnoInscripcion;

            
            formAlumnoInscripcionesDetalle.ShowDialog();
            this.GetAllAndLoad();
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
                return (AlumnoInscripcion)dgvInscripcionesAlumno.SelectedRows[0].DataBoundItem;
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
