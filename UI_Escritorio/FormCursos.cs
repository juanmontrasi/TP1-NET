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
        private Usuario usuario;
        public FormCursos(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
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
            if (usuario.Rol.Equals("Alumno") || usuario.Rol.Equals("Docente"))
            {
                this.btnBorrar.Visible = false;
                this.btnEditar.Visible = false;
                this.btnNuevo.Visible = false;
            }
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el curso?", "Eliminar curso", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                Curso cursoSelected = this.SelectedItem();
                if (cursoSelected != null)
                {
                    int id = cursoSelected.IdCurso;
                    await CursosApi.DeleteAsync(id);
                    this.GetAllAndLoad();

                    MessageBox.Show("Curso eliminado con éxito", "Curso Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }


        private async void btnEditar_Click(object sender, EventArgs e)
        {
            FormCursoDetalle cursoDetalle = new FormCursoDetalle();
            Curso cursoSelected = this.SelectedItem();
            if (cursoSelected != null)
            {
                int id = cursoSelected.IdCurso;
                Curso curso = await CursosApi.GetAsync(id);
                cursoDetalle.EditMode = true;
                cursoDetalle.Curso = curso;
                cursoDetalle.ShowDialog();
                this.GetAllAndLoad();
            }
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
            if (dgvCursos.SelectedRows.Count > 0)
            {
                dynamic selectedDynamic = dgvCursos.SelectedRows[0].DataBoundItem;
                var jObject = (Newtonsoft.Json.Linq.JObject)selectedDynamic;

                
                var curso = new Curso
                {
                    IdCurso = jObject["idCurso"]?.ToObject<int>() ?? 0,
                    Nombre = jObject["nombre"]?.ToObject<string>() ?? string.Empty,
                    IdComision = jObject["idComision"]?.ToObject<int>() ?? 0,
                    IdMateria = jObject["idMateria"]?.ToObject<int>() ?? 0,
                    Cupo = jObject["cupo"]?.ToObject<int>() ?? 0,
                    Anio_Calendario = jObject["anioCalendario"]?.ToObject<int>() ?? 0,
                    Materia = new Materia
                    {
                        IdMateria = jObject["idMateria"]?.ToObject<int>() ?? 0,
                        Nombre_Materia = jObject["nombre_Materia"]?.ToObject<string>() ?? string.Empty
                    },
                    Comision = new Comision
                    {
                        IdComision = jObject["idComision"]?.ToObject<int>() ?? 0,
                        Nombre_Comision = jObject["nombre_Comision"]?.ToObject<string>() ?? string.Empty
                    }
                };

                
                return curso;
            }
            return null;
        }


        private void FormCursos_load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }
    }
}
