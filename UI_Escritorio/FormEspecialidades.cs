﻿using MySqlX.XDevAPI;
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
        private Usuario usuario;
        private ReportGenerator reportGenerator;
        public FormEspecialidades(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.reportGenerator = new ReportGenerator();
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
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar la especialidad?", "Eliminar especialidad", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                int id = this.SelectedItem().IdEspecialidad;
                await EspecialidadesApi.DeleteAsync(id);
                this.GetAllAndLoad();
                MessageBox.Show("Especialidad eliminada con éxito", "Especialidad eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            else if (result == DialogResult.Cancel)
            {
                return;
            }

        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            FormEspecialidadDetalle especialidadDetalle = new FormEspecialidadDetalle();
            int id = this.SelectedItem().IdEspecialidad;
            Entidades.Especialidad especialidad = await EspecialidadesApi.GetAsync(id);
            especialidadDetalle.EditMode = true;
            especialidadDetalle.Especialidad = especialidad;
            especialidadDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormEspecialidadDetalle especialidadDetalle = new FormEspecialidadDetalle();
            Entidades.Especialidad especialidadNuevo = new Entidades.Especialidad();
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
                this.btnGenerarReporte.Visible = false;
            }
        }

        private Entidades.Especialidad SelectedItem()
        {
            return (Entidades.Especialidad)dgvEspecialidades.SelectedRows[0].DataBoundItem;
        }

        private async void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            var especialidades = await EspecialidadesApi.GetAllAsync();
            string filePath = "EspecialidadesReport.pdf";
            reportGenerator.GenerateEspecialidadesReport(especialidades, filePath);
            MessageBox.Show("Reporte generado con éxito en EspecialidadesReport.pdf", "Reporte Generado", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = filePath,
                UseShellExecute = true
            });
        }

    }
}
