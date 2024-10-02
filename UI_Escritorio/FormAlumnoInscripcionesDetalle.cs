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

            cbAlumnos.DataSource = new List<Usuario>{usuario};
            cbAlumnos.DisplayMember = "Nombre_Usuario";
            cbAlumnos.ValueMember = "IdPersona";
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
                cbCursos.Enabled = false;
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

        private void SetAlumnoInscripcion()
        {

            cbCondicion.SelectedItem = alumnoInscripcion.Condicion;
            cbAlumnos.SelectedValue = alumnoInscripcion.IdPersona;
            cbCursos.SelectedValue = alumnoInscripcion.IdCurso;


           
            if (EditMode)
            {
                tbNota.Text = alumnoInscripcion.Nota.ToString();
                tbNota.Enabled = usuario.Rol.Equals("Administrador"); // Solo el administrador puede editar la nota
                cbCondicion.Enabled = usuario.Rol.Equals("Administrador");
                cbAlumnos.Enabled = false;
                cbCursos.Enabled = false;
            }
            else
            {   tbNota.Text = string.Empty;
                tbNota.Enabled = false;
                cbCondicion.SelectedItem = "Inscripto";
                cbCondicion.Enabled = false;
                cbAlumnos.Enabled = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.validateAlumno())
            {
                if (alumnoInscripcion != null)
                {
                    this.AlumnoInscripcion.IdPersona = (int)cbAlumnos.SelectedValue;
                    this.AlumnoInscripcion.IdCurso = (int)cbCursos.SelectedValue;
                    this.AlumnoInscripcion.Condicion = cbCondicion.SelectedItem.ToString();



                    if (EditMode && usuario.Rol.Equals("Administrador"))
                    {
                        if (int.TryParse(tbNota.Text, out int nota))
                        {
                            this.AlumnoInscripcion.Nota = nota;
                        }
                        else
                        {
                            MessageBox.Show("La nota debe ser un número entero válido.");
                        }
                    }
                    else if (!EditMode)
                    {
                        alumnoInscripcion.Condicion = "Inscripto";
                    }
                }
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

            if (string.IsNullOrWhiteSpace(cbAlumnos.Text))
            {
                isValid = false;
                errorProvider.SetError(cbAlumnos, "El alumno es requerido.");
            }

            if (string.IsNullOrWhiteSpace(cbCursos.Text))
            {
                isValid = false;
                errorProvider.SetError(cbCursos, "El curso es requerido.");
            }

            return isValid;
        }

        private async Task cargarCursos()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:7111/cursos";
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var cursos = await response.Content.ReadAsAsync<List<Curso>>();
                        cbCursos.DataSource = cursos;
                        cbCursos.DisplayMember = "Nombre";
                        cbCursos.ValueMember = "IdCurso"; 

                        if(IdCurso.HasValue)
                        {
                            cbCursos.SelectedItem = IdCurso.Value;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al conectar con el servidor");
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("Error al conectar con el servidor" + ex.Message);
                }
            }
            
        }
    }
}
