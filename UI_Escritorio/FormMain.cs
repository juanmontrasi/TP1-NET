using System;
using System.Windows.Forms;

namespace UI_Escritorio
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }



        private void FormMain_Shown(object sender, EventArgs e)
        {
            // Código que se ejecutará cuando el formulario principal se muestre.

        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAlumnos formAlumnos = new FormAlumnos();
            formAlumnos.FormBorderStyle = FormBorderStyle.None; // Quita los bordes y los botones de control
            formAlumnos.WindowState = FormWindowState.Maximized;
            formAlumnos.MdiParent = this; // Para que se muestre dentro del FormMain si es MDI
            formAlumnos.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void docentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDocentes formDoc = new FormDocentes();
            formDoc.FormBorderStyle = FormBorderStyle.None;
            formDoc.WindowState = FormWindowState.Maximized;
            formDoc.MdiParent = this;
            formDoc.Show();
        }

        private void esToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMaterias formMaterias = new FormMaterias();
            formMaterias.FormBorderStyle = FormBorderStyle.None;
            formMaterias.WindowState = FormWindowState.Maximized;
            formMaterias.MdiParent = this;
            formMaterias.Show();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCursos formCursos = new FormCursos();
            formCursos.FormBorderStyle = FormBorderStyle.None;
            formCursos.WindowState = FormWindowState.Maximized;
            formCursos.MdiParent = this;
            formCursos.Show();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormComisiones formComisiones = new FormComisiones();
            formComisiones.FormBorderStyle = FormBorderStyle.None;
            formComisiones.WindowState = FormWindowState.Maximized;
            formComisiones.MdiParent = this;
            formComisiones.Show();
        }

        private void inscripcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInscripcionesAlumno formInscripcionesAlumno = new FormInscripcionesAlumno();
            formInscripcionesAlumno.FormBorderStyle = FormBorderStyle.None;
            formInscripcionesAlumno.WindowState = FormWindowState.Maximized;
            formInscripcionesAlumno.MdiParent = this;
            formInscripcionesAlumno.Show();
        }

        private void cursosDocenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCursosDocente formCursDoc = new FormCursosDocente();
            formCursDoc.FormBorderStyle = FormBorderStyle.None;
            formCursDoc.WindowState = FormWindowState.Maximized;
            formCursDoc.MdiParent = this;
            formCursDoc.Show();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEspecialidades formEsp = new FormEspecialidades();
            formEsp.FormBorderStyle = FormBorderStyle.None;
            formEsp.WindowState = FormWindowState.Maximized;
            formEsp.MdiParent = this;
            formEsp.Show();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPlanes formPlanes = new FormPlanes();
            formPlanes.FormBorderStyle = FormBorderStyle.None;
            formPlanes.WindowState = FormWindowState.Maximized;
            formPlanes.MdiParent = this;
            formPlanes.Show();
        }
    }
}
