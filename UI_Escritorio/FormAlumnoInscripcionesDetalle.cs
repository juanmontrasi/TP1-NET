using Entidades;
using System;
using System.Windows.Forms;

namespace UI_Escritorio
{
    public partial class FormAlumnoInscripcionesDetalle : Form
    {
        private AlumnoInscripcion alumnoInscripcion;
        public bool EditMode { get; internal set; } = false;
        private Usuario usuario; 


        public FormAlumnoInscripcionesDetalle(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

   
            if (!usuario.Rol.Equals("Alumno"))
            {
                MessageBox.Show("Solo los usuarios con rol de Alumno pueden acceder a esta sección.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); 
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetAlumnoInscripcion()
        {
           
        }
    }
}
