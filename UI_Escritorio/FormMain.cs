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

        private void UsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Aqu� puedes agregar el c�digo que deseas ejecutar cuando se hace clic en "Usuario".
            
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            // C�digo que se ejecutar� cuando el formulario principal se muestre.
            
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
