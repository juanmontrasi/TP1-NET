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
        private Usuario usuario;
        public FormMaterias(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }
        private void Materias_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            this.dgvMaterias.DataSource = null;
            this.dgvMaterias.AutoGenerateColumns = true;
            var materias = await MateriasApi.GetAllAsync();
            this.dgvMaterias.DataSource = materias;
            this.dgvMaterias.Refresh();

            if (this.dgvMaterias.Rows.Count > 0)
            {
                this.dgvMaterias.Rows[0].Selected = true;
                this.btnBorrar.Visible = true;
                this.btnEditar.Visible = true;
            }
            else
            {
                this.btnBorrar.Visible = false;
                this.btnEditar.Visible = false;
            }
            if (usuario.Rol.Equals("Alumno") || usuario.Rol.Equals("Docente"))
            {
                this.btnBorrar.Visible = false;
                this.btnEditar.Visible = false;
                this.btnNuevo.Visible = false;
            }
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar la materia?", "Eliminar materia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                int id = this.SelectedItem().idMateria;
                await MateriasApi.DeleteAsync(id);
                this.GetAllAndLoad();

                MessageBox.Show("Materia eliminada con éxito", "Materia Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        private dynamic SelectedItem()
        {
            return (dynamic)dgvMaterias.SelectedRows[0].DataBoundItem;
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            FormMateriaDetalle materiaDetalle = new FormMateriaDetalle();
            int id = this.SelectedItem().idMateria;
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

        private void FormMaterias_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }
    }
}
