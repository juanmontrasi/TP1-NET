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

namespace UI_Escritorio
{
    public partial class FormPersonas : Form
    {
        private ReportGenerator reportGenerator;
        public FormPersonas()
        {
            InitializeComponent();
            this.reportGenerator = new ReportGenerator();
        }
        private void Personas_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            this.dgvPersonas.DataSource = null;
            this.dgvPersonas.AutoGenerateColumns = true;
            var personas = await PersonaApi.GetAllAsync();
            this.dgvPersonas.DataSource = personas;
            this.dgvPersonas.Refresh();

            if (this.dgvPersonas.Rows.Count > 0)
            {
                this.dgvPersonas.Rows[0].Selected = true;
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
            DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar la persona?", "Eliminar persona", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                int id = this.SelectedItem().IdPersona;
                await PersonaApi.DeleteAsync(id);
                this.GetAllAndLoad();

                MessageBox.Show("Persona eliminada con éxito", "Persona Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            else if (result == DialogResult.Cancel)
            {
                return;
            }
        }

        private Persona SelectedItem()
        {
            return (Persona)dgvPersonas.SelectedRows[0].DataBoundItem;
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            FormPersonaDetalle personaDetalle = new FormPersonaDetalle();
            int id = this.SelectedItem().IdPersona;
            Persona persona = await PersonaApi.GetAsync(id);
            personaDetalle.EditMode = true;
            personaDetalle.Persona = persona;
            personaDetalle.ShowDialog();
            this.GetAllAndLoad();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormPersonaDetalle personaDetalle = new FormPersonaDetalle();
            Persona personaNuevo = new Persona();
            personaDetalle.Persona = personaNuevo;
            personaDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private void FormPersonas_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void btnReporte_Click(object sender, EventArgs e)
        {
            var personas = await PersonaApi.GetAllAsync();
            string filePath = "PersonasReport.pdf";
            reportGenerator.GeneratePersonaReport(personas, filePath);
            MessageBox.Show("Reporte generado con éxito en PersonaReport.pdf", "Reporte Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);


            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = filePath,
                UseShellExecute = true
            });

        }
    }
}
