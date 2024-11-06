using System;
using System.Windows.Forms;
using Entidades;

namespace UI_Escritorio
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (FormLogin loginForm = new FormLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {

                    Usuario usuario = loginForm.UsuarioAutenticado;

                    Application.Run(new FormMain(usuario));
                }
            }
        }
    }
}
