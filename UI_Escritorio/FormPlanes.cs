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
        private Usuario usuario;
        public FormPlanes(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
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
            
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el plan?", "Eliminar plan", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                Plan planSelected = this.SelectedItem();
                if (planSelected != null)
                {
                    int id = planSelected.IdPlan;
                    await PlanesApi.DeleteAsync(id);
                    this.GetAllAndLoad();
                }

                MessageBox.Show("Plan eliminado con éxito", "Plan Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            Plan planSelected = this.SelectedItem();
            if (planSelected != null)
            {
                FormPlanesDetalle planDetalle = new FormPlanesDetalle();
                int id = planSelected.IdPlan;
                Plan plan = await PlanesApi.GetAsync(id);
                planDetalle.EditMode = true;
                planDetalle.Plan = plan;
                planDetalle.ShowDialog();
                this.GetAllAndLoad();
            }
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

            this.dgvPlanes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            if (this.dgvPlanes.Rows.Count > 0)
            {
                this.dgvPlanes.Rows[0].Selected = true;
                this.btnBorrar.Visible = true;
                this.btnEditar.Visible = true;
            }
            else
            {
                this.btnBorrar.Visible = false;
                this.btnEditar.Visible = false;
            }

            if(usuario.Rol.Equals("Alumno") || usuario.Rol.Equals("Docente"))
            {
                this.btnNuevo.Visible = false;
                this.btnEditar.Visible = false;
                this.btnBorrar.Visible = false;
            }
        }

        private Plan SelectedItem()
        {

            if (dgvPlanes.SelectedRows.Count > 0)
            {
                Plan plan = (Plan)dgvPlanes.SelectedRows[0].DataBoundItem;
                if (plan != null)
                {
                    return plan;
                }
            }

            MessageBox.Show("Debes listar y seleccionar un plan", "Planes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

    }
}
