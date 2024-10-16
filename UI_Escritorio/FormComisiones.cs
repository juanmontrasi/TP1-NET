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
    public partial class FormComisiones : Form
    {
        private Usuario usuario;
        public FormComisiones(Usuario usuario)
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
            this.dgvComisiones.DataSource = null;
            this.dgvComisiones.AutoGenerateColumns = true;
            var comisiones = await ComisionesApi.GetAllAsync();
            this.dgvComisiones.DataSource = comisiones;
            this.dgvComisiones.Refresh();

            if (this.dgvComisiones.Rows.Count > 0)
            {
                this.dgvComisiones.Rows[0].Selected = true;
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
            int id = this.SelectedItem().IdComision;
            await ComisionesApi.DeleteAsync(id);
            this.GetAllAndLoad();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            FormComisionDetalle comisionDetalle = new FormComisionDetalle();
            int id = this.SelectedItem().IdComision;
            Comision comision = await ComisionesApi.GetAsync(id);
            comisionDetalle.EditMode = true;
            comisionDetalle.Comision = comision;
            comisionDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormComisionDetalle comisionDetalle = new FormComisionDetalle();
            Comision comisionNuevo = new Comision();
            comisionDetalle.Comision = comisionNuevo;
            comisionDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private Comision SelectedItem()
        {
            return (Comision)dgvComisiones.SelectedRows[0].DataBoundItem;
        }

        private void FormComisiones_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();

        }
    }
}
