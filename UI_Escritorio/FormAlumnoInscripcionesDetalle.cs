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
        public bool EditMode { get; internal set; } = false;
        public FormAlumnoInscripcionesDetalle()
        {
            InitializeComponent();
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
