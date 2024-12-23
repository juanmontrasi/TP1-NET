﻿using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;


namespace UI_Escritorio
{
    public partial class FormDocenteCurso : Form
    {
        private Usuario usuario;
        public FormDocenteCurso(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            if (!usuario.Rol.Equals("Docente") && !usuario.Rol.Equals("Administrador"))
            {
                MessageBox.Show("Solo los docentes o administradores pueden acceder a este formulario.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void FormDocenteCurso_Load(object sender, EventArgs e)
        {
            if (usuario.Rol.Equals("Administrador"))
            {
                this.GetAllAndLoad();
            }
            else if (usuario.Rol.Equals("Docente"))
            {
                this.GetAllAndLoadDocente();
            }
        }

        private void btnListar_Click_1(object sender, EventArgs e)
        {
            if (usuario.Rol.Equals("Administrador"))
            {
                this.GetAllAndLoad();
            }
            else if (usuario.Rol.Equals("Docente"))
            {
                this.GetAllAndLoadDocente();
            }
        }

        private async void GetAllAndLoadDocente()
        {

            this.dgvDocenteCursos.AutoGenerateColumns = true;
            var docenteCursos = await DocenteCursosApi.GetDocenteCursoByIdAsync(usuario.IdPersona);
            this.dgvDocenteCursos.DataSource = docenteCursos;
            this.dgvDocenteCursos.Refresh();

            if (this.dgvDocenteCursos.Rows.Count > 0)
            {
                this.dgvDocenteCursos.Rows[0].Selected = true;
                this.btnBorrar.Visible = false;
                this.btnEditar.Visible = false;
                this.btnNuevo.Visible = false;
                this.btnListar.Visible = true;
            }
            else
            {
                this.btnBorrar.Visible = false;
                this.btnEditar.Visible = false;
                this.btnNuevo.Visible = false;
            }
        }

        private async void GetAllAndLoad()
        {
            this.dgvDocenteCursos.AutoGenerateColumns = true;
            var docenteCursos = await DocenteCursosApi.GetAllAsync();
            this.dgvDocenteCursos.DataSource = docenteCursos;
            this.dgvDocenteCursos.Refresh();

            if (this.dgvDocenteCursos.Rows.Count > 0)
            {
                this.dgvDocenteCursos.Rows[0].Selected = true;
                this.btnBorrar.Visible = true;
                this.btnEditar.Visible = false;
                this.btnNuevo.Visible = true;
                this.btnListar.Visible = true;
            }
            else
            {
                this.btnBorrar.Visible = false;
                this.btnEditar.Visible = false;
                this.btnNuevo.Visible = true;
            }
        }

        private async void btnBorrar_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar la asignación del docente?", "Eliminar Asignación", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                DocenteCurso docenteCursoSelected = this.SelectedItem();
                if (docenteCursoSelected != null)
                {
                    int id = docenteCursoSelected.IdDocenteCurso;
                    await DocenteCursosApi.DeleteAsync(id);
                    this.GetAllAndLoad();
                }

                MessageBox.Show("Asignación eliminada con éxito", "Asignación Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }


        private DocenteCurso SelectedItem()
        {
            if (dgvDocenteCursos.SelectedRows.Count > 0)
            {
                dynamic selectedDynamic = dgvDocenteCursos.SelectedRows[0].DataBoundItem;
                var jObject = (Newtonsoft.Json.Linq.JObject)selectedDynamic;

                
                var docenteCurso = new DocenteCurso
                {
                    IdDocenteCurso = jObject["idDocenteCurso"]?.ToObject<int>() ?? 0,
                    IdPersona = jObject["idPersona"]?.ToObject<int>() ?? 0,
                    IdCurso = jObject["idCurso"]?.ToObject<int>() ?? 0,
                    Cargo = jObject["cargo"]?.ToObject<int>() ?? 0,
                    Persona = new Persona
                    {
                        IdPersona = jObject["idPersona"]?.ToObject<int>() ?? 0,
                        Nombre = jObject["personaNombre"]?.ToObject<string>() ?? string.Empty,
                        Apellido = jObject["personaApellido"]?.ToObject<string>() ?? string.Empty
                    },
                    Curso = new Curso
                    {
                        IdCurso = jObject["idCurso"]?.ToObject<int>() ?? 0,
                        Nombre = jObject["cursoNombre"]?.ToObject<string>() ?? string.Empty
                    }
                };

                
                return docenteCurso;
            }
            return null;
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            FormDocenteCursosDetalle formDocenteCursosDetalle = new FormDocenteCursosDetalle(usuario);
            DocenteCurso docenteCursoNuevo = new DocenteCurso();
            formDocenteCursosDetalle.EditMode = false;
            formDocenteCursosDetalle.DocenteCurso = docenteCursoNuevo;

            formDocenteCursosDetalle.ShowDialog();
            this.GetAllAndLoad();
        } 
    }
}
