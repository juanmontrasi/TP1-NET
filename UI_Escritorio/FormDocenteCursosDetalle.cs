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
    public partial class FormDocenteCursosDetalle : Form
    {

        private DocenteCurso docenteCurso;
        public int? IdCurso { get; set; }
        public bool EditMode { get; internal set; } = false;
        private Usuario usuario;
        public List<int> cargos = new List<int>
            {
                1,
                2
            };


        public FormDocenteCursosDetalle(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            cbCargo.DataSource = cargos.ToList();

            if (!usuario.Rol.Equals("Docente") && !usuario.Rol.Equals("Administrador"))
            {
                MessageBox.Show("Solo los usuarios con rol de Docente o Administrador pueden acceder a esta sección.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void FormDocenteCursosDetalle_Load(object sender, EventArgs e)
        {
            await cargarCursos();
            await cargarDocentes();
        }
        private async Task cargarCursos()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:7111/cursos";
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var cursos = await response.Content.ReadAsAsync<List<Curso>>();
                        cbCurso.DataSource = cursos;
                        cbCurso.DisplayMember = "Nombre";
                        cbCurso.ValueMember = "IdCurso";

                        if (IdCurso.HasValue)
                        {
                            cbCurso.SelectedValue = IdCurso.Value;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al conectar con el servidor.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con el servidor: " + ex.Message);
                }
            }
        }

        private async Task cargarDocentes()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://localhost:7111/usuarios";
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var usuarios = await response.Content.ReadAsAsync<List<Usuario>>();
                        List<Usuario> docentes = usuarios.Where(a => a.Rol == "Docente").ToList();
                        
                        cbDocente.DataSource = docentes;

                        cbDocente.DisplayMember = "Nombre_Usuario";
                        cbDocente.ValueMember = "IdPersona";

                        if (IdCurso.HasValue)
                        {
                            cbDocente.SelectedValue = IdCurso.Value;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al conectar con el servidor.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con el servidor: " + ex.Message);
                }
            }
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validateDocente())
                {
                    if (docenteCurso != null)
                    {

                        docenteCurso.IdPersona = (int)cbDocente.SelectedValue;

                        docenteCurso.IdCurso = (int)cbCurso.SelectedValue;

                        docenteCurso.Cargo = (int)cbCargo.SelectedItem;

                            if (this.EditMode)
                            {
                                await DocenteCursosApi.UpdateAsync(this.docenteCurso);
                                this.Close();
                            }
                            else
                            {
                                bool creada = await DocenteCursosApi.AddAsync(this.docenteCurso);

                                if (creada)
                                {
                                    MessageBox.Show("Asignacion creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {

                                    MessageBox.Show("Ya existe esta asignacion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                        
                    }
                    else
                    {
                        MessageBox.Show("Curso no está inicializada.");
                    }

                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DocenteCurso DocenteCurso
        {
            get { return docenteCurso; }
            set
            {
                docenteCurso = value;
                if (docenteCurso != null)
                {
                    this.SetDocenteCursos();
                }
            }
        }

        private async void SetDocenteCursos()
        {
            cbCargo.SelectedItem = docenteCurso.Cargo;
            cbDocente.SelectedItem = docenteCurso.IdPersona;
            cbCurso.SelectedItem = docenteCurso.IdCurso;
        }

        private bool validateDocente()
        {
            bool isValid = true;

            errorProvider1.SetError(cbCargo, string.Empty);
            errorProvider1.SetError(cbDocente, string.Empty);
            errorProvider1.SetError(cbCurso, string.Empty);

            if (string.IsNullOrWhiteSpace(cbCargo.Text))
            {
                isValid = false;
                errorProvider1.SetError(cbCargo, "El cargo es requerido.");
            }

            if (cbDocente.SelectedValue == null || (int)cbDocente.SelectedValue == 0)
            {
                isValid = false;
                errorProvider1.SetError(cbDocente, "El docente es requerido.");
            }

            if (cbCurso.SelectedValue == null || (int)cbCurso.SelectedValue == 0)
            {
                isValid = false;
                errorProvider1.SetError(cbCurso, "El curso es requerido.");
            }

            return isValid;
        }

        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
