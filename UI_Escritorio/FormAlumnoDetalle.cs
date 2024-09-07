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
    public partial class FormAlumnoDetalle : Form
    {
        private Persona alumno;

        public Persona Persona { get { return alumno; }
         /*   set { alumno = value;
                this.SetAlumno();
            }*/
        }
        
        public FormAlumnoDetalle()
        {
            InitializeComponent();
        }

       /* private void SetAlumno()
        {
            this.nombre.Text = this.alumno.Nombre;
        } */
    }
}
