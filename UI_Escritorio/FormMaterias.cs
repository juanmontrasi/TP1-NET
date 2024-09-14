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
    public partial class FormMaterias : Form
    {
        public FormMaterias()
        {
            InitializeComponent();
        }
        private void Materias_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void  GetAllAndLoad()
        {
            this.dgvMaterias.DataSource = null;
            this.dgvMaterias.AutoGenerateColumns = true;
            var materias = await MateriasApi.GetAllAsync();
            this.dgvMaterias.DataSource = materias;
            this.dgvMaterias.Refresh();

            if (this.dgvMaterias.Rows.Count > 0)
            {
                this.dgvMaterias.Rows[0].Selected = true;
                this.btnBorrar.Enabled = true;
                this.btnEditar.Enabled = true;
            }
            else
            {
                this.btnBorrar.Enabled = false;
                this.btnEditar.Enabled = false;
            }
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = this.SelectedItem().IdMateria;
            await MateriasApi.DeleteAsync(id);
            this.GetAllAndLoad();
        }

        private Materia SelectedItem()
        {
            return (Materia)dgvMaterias.SelectedRows[0].DataBoundItem;
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            FormMateriaDetalle materiaDetalle = new FormMateriaDetalle();
            int id = this.SelectedItem().IdMateria;
            Materia materia = await MateriasApi.GetAsync(id);
            materiaDetalle.EditMode = true;
            materiaDetalle.Materia = materia;
            materiaDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormMateriaDetalle materiaDetalle = new FormMateriaDetalle();
            Materia materiaNuevo = new Materia();
            materiaDetalle.Materia = materiaNuevo;
            materiaDetalle.ShowDialog();
            this.GetAllAndLoad();
        }
    }
}
