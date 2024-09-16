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
    public partial class FormPersonas : Form
    {
        public FormPersonas()
        {
            InitializeComponent();
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
            int id = this.SelectedItem().IdPersona;
            await PersonaApi.DeleteAsync(id);
            this.GetAllAndLoad();
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

    }
    }
