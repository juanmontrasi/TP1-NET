using MySqlX.XDevAPI;
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
    public partial class FormEspecialidades : Form
    {
        public FormEspecialidades()
        {
            InitializeComponent();
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = this.SelectedItem().IdEspecialidad;
            await EspecialidadesApi.DeleteAsync(id);
            this.GetAllAndLoad();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            FormEspecialidadDetalle especialidadDetalle = new FormEspecialidadDetalle();
            int id = this.SelectedItem().IdEspecialidad;
            Especialidad especialidad = await EspecialidadesApi.GetAsync(id);
            especialidadDetalle.EditMode = true;
            especialidadDetalle.Especialidad = especialidad;
            especialidadDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormEspecialidadDetalle especialidadDetalle = new FormEspecialidadDetalle();
            Especialidad especialidadNuevo = new Especialidad();
            especialidadDetalle.Especialidad = especialidadNuevo;
            especialidadDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            this.dgvEspecialidades.DataSource = null;
            this.dgvEspecialidades.AutoGenerateColumns = true;
            var especialidades = await EspecialidadesApi.GetAllAsync();
            this.dgvEspecialidades.DataSource = especialidades;
            this.dgvEspecialidades.Refresh();

            if (this.dgvEspecialidades.Rows.Count > 0)
            {
                this.dgvEspecialidades.Rows[0].Selected = true;
                this.btnBorrar.Enabled = true;
                this.btnEditar.Enabled = true;
            }
            else
            {
                this.btnBorrar.Enabled = false;
                this.btnEditar.Enabled = false;
            }
        }

        private Especialidad SelectedItem()
        {
            return (Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem;
        }
    }
}
