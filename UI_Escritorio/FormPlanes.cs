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
    public partial class FormPlanes : Form
    {
        public FormPlanes()
        {
            InitializeComponent();
        }
        private void Planes_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = this.SelectedItem().IdPlan;
            await PlanesApi.DeleteAsync(id);
            this.GetAllAndLoad();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            FormPlanesDetalle planDetalle = new FormPlanesDetalle();
            int id = this.SelectedItem().IdPlan;
            Plan plan = await PlanesApi.GetAsync(id);
            planDetalle.EditMode = true;
            planDetalle.Plan = plan;
            planDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormPlanesDetalle planesDetalle = new FormPlanesDetalle();
            Plan planNuevo = new Plan();
            planesDetalle.Plan = planNuevo;
            planesDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            this.dgvPlanes.DataSource = null;
            this.dgvPlanes.AutoGenerateColumns = true;
            var planes = await PlanesApi.GetAllAsync();
            this.dgvPlanes.DataSource = planes;
            this.dgvPlanes.Refresh();

            if (this.dgvPlanes.Rows.Count > 0)
            {
                this.dgvPlanes.Rows[0].Selected = true;
                this.btnBorrar.Enabled = true;
                this.btnEditar.Enabled = true;
            }
            else
            {
                this.btnBorrar.Enabled = false;
                this.btnEditar.Enabled = false;
            }
        }

        private Plan SelectedItem()
        {
            return (Plan)dgvPlanes.SelectedRows[0].DataBoundItem;
        }

    }
}
