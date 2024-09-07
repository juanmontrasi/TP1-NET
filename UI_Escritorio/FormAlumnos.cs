using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyecto_academia;
using Entidades;
namespace UI_Escritorio
{
    public partial class FormAlumnos : Form
    {
        public FormAlumnos()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {


        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
           /* FormAlumnoDetalle formAlumnoDetalle = new FormAlumnoDetalle();
            Persona persona = new Persona();
            formAlumnoDetalle.Persona = persona;*/

        }

        private async void GetAllAndLoad()
        {
            AlumnoApi alumno = new AlumnoApi();
            this.dgvAlumnos.DataSource = null;
            this.dgvAlumnos.DataSource = await AlumnoApi.GetAllAsync();
            if (this.dgvAlumnos.Rows.Count > 0)
            {
                this.dgvAlumnos.Rows[0].Selected = true;
                this.btnBorrar.Enabled = true;
                this.btnEditar.Enabled = true;
            }
            else
            {
                this.btnBorrar.Enabled = false;
                this.btnEditar.Enabled = false;
            }
        }
    }
}
