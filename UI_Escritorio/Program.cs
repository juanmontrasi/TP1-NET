namespace UI_Escritorio
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
         static void Main()
        {
            using (FormLogin loginForm = new FormLogin())
            {
                if(loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new FormMain());
                }
            }
        }
    }
}