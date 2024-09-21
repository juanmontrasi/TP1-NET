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
    public partial class FormInscripcionesAlumno : Form
    {
        private Usuario usuario;
        public FormInscripcionesAlumno(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            if (usuario.Rol != "Alumno")
            {
                MessageBox.Show("Solo los alumnos pueden acceder a este formulario.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
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
                this.btnBorrar.Enabled = true;
                this.btnEditar.Enabled = true;
            }
            else
            {
                this.btnBorrar.Enabled=false;
                this.btnEditar.Enabled=false;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = this.SelectedItem().IdAlumnoInscripcion;
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
            FormAlumnoInscripcionesDetalle alumnoInscripcionesDetalle = new FormAlumnoInscripcionesDetalle(usuario);
            AlumnoInscripcion alumnoInscripcionNuevo = new AlumnoInscripcion();
            alumnoInscripcionesDetalle.ShowDialog();
            this.GetAllAndLoad();

        }

        private AlumnoInscripcion SelectedItem()
        {
            return (AlumnoInscripcion)dgvInscripcionesAlumno.Rows[0].DataBoundItem;
        }
    }
}
