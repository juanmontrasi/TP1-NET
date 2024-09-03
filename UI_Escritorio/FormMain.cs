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
    }
}


        
       /* Lo Comento porque es la forma para poner una ventana dentro de otra en forma modal
        private void MainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMain appMain = new FormMain();
            appMain.MdiParent = this;
            appMain.Show();
        }*/
