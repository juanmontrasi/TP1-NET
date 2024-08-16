namespace UI_Escritorio
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            FormLogin appLogin = new FormLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void MainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMain appMain = new FormMain();
            appMain.MdiParent = this;
            appMain.Show();
        }
    }
}
