using Entidades;
using System;
using System.Windows.Forms;

namespace UI_Escritorio
{
    public partial class FormMain : Form
    {
        private Usuario usuarioAutenticado;

        public IEnumerable<string> roles = new List<string> { "Alumno", "Administrador", "Docente" };
        public FormMain(Usuario usuario)
        {
            InitializeComponent();
            this.usuarioAutenticado = usuario;
        }



        private void FormMain_Shown(object sender, EventArgs e)
        {
            if (usuarioAutenticado.Rol == "Alumno")
            {
                personasToolStripMenuItem.Visible = false;
                cursosDocenteToolStripMenuItem.Visible = false;
                cursosToolStripMenuItem.Visible = true;
                especialidadesToolStripMenuItem.Visible = true;
                planesToolStripMenuItem.Visible = true;
                usuarioToolStripMenuItem.Visible = false;

            }
            if (usuarioAutenticado.Rol == "Docente")
            {
                personasToolStripMenuItem.Visible = false;
                cursosToolStripMenuItem.Visible = true;
                especialidadesToolStripMenuItem.Visible = true;
                planesToolStripMenuItem.Visible = true;
                usuarioToolStripMenuItem.Visible = false;
                inscripcionesToolStripMenuItem.Visible = false;
            }
        }

        

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        

        private void esToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMaterias formMaterias = new FormMaterias(usuarioAutenticado);
            formMaterias.FormBorderStyle = FormBorderStyle.None;
            formMaterias.WindowState = FormWindowState.Maximized;
            formMaterias.MdiParent = this;
            formMaterias.Show();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCursos formCursos = new FormCursos(usuarioAutenticado);
            formCursos.FormBorderStyle = FormBorderStyle.None;
            formCursos.WindowState = FormWindowState.Maximized;
            formCursos.MdiParent = this;
            formCursos.Show();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormComisiones formComisiones = new FormComisiones(usuarioAutenticado);
            formComisiones.FormBorderStyle = FormBorderStyle.None;
            formComisiones.WindowState = FormWindowState.Maximized;
            formComisiones.MdiParent = this;
            formComisiones.Show();
        }

        private void inscripcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInscripcionesAlumno formInscripcionesAlumno = new FormInscripcionesAlumno(usuarioAutenticado);
            formInscripcionesAlumno.FormBorderStyle = FormBorderStyle.None;
            formInscripcionesAlumno.WindowState = FormWindowState.Maximized;
            formInscripcionesAlumno.MdiParent = this;
            formInscripcionesAlumno.Show();
        }

        private void cursosDocenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDocenteCurso formCursDoc = new FormDocenteCurso(usuarioAutenticado);
            formCursDoc.FormBorderStyle = FormBorderStyle.None;
            formCursDoc.WindowState = FormWindowState.Maximized;
            formCursDoc.MdiParent = this;
            formCursDoc.Show();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEspecialidades formEsp = new FormEspecialidades(usuarioAutenticado);
            formEsp.FormBorderStyle = FormBorderStyle.None;
            formEsp.WindowState = FormWindowState.Maximized;
            formEsp.MdiParent = this;
            formEsp.Show();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPlanes formPlanes = new FormPlanes(usuarioAutenticado);
            formPlanes.FormBorderStyle = FormBorderStyle.None;
            formPlanes.WindowState = FormWindowState.Maximized;
            formPlanes.MdiParent = this;
            formPlanes.Show();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonas formPersonas = new FormPersonas();
            formPersonas.FormBorderStyle = FormBorderStyle.None;
            formPersonas.WindowState = FormWindowState.Maximized;
            formPersonas.MdiParent = this;
            formPersonas.Show();

        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuario formUsuario = new FormUsuario();
            formUsuario.FormBorderStyle = FormBorderStyle.None;
            formUsuario.WindowState = FormWindowState.Maximized;
            formUsuario.MdiParent = this;
            formUsuario.Show();
        }
    }
}
