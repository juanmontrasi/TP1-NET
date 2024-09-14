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
    public partial class FormCursos : Form
    {
        public FormCursos()
        {
            InitializeComponent();
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            this.dgvCursos.DataSource = null;
            this.dgvCursos.AutoGenerateColumns = true;
            var comisiones = await CursosApi.GetAllAsync();
            this.dgvCursos.DataSource = comisiones;
            this.dgvCursos.Refresh();

            if (this.dgvCursos.Rows.Count > 0)
            {
                this.dgvCursos.Rows[0].Selected = true;
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
            int id = this.SelectedItem().IdCurso;
            await CursosApi.DeleteAsync(id);
            this.GetAllAndLoad();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            FormCursoDetalle cursoDetalle = new FormCursoDetalle();
            int id = this.SelectedItem().IdCurso;
            Curso curso = await CursosApi.GetAsync(id);
            cursoDetalle.EditMode = true;
            cursoDetalle.Curso = curso;
            cursoDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormCursoDetalle cursoDetalle = new FormCursoDetalle();
            Curso cursoNuevo = new Curso();
            cursoDetalle.Curso = cursoNuevo;
            cursoDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private Curso SelectedItem()
        {
            return (Curso)dgvCursos.SelectedRows[0].DataBoundItem;
        }
    }
}
