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
    public partial class FormUsuario : Form
    {

        public FormUsuario()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void btnBorrar_Click(object sender, EventArgs e)
        {
            int id = this.SelectedItem().IdUsuario;
            await UsuariosApi.DeleteAsync(id);
            this.GetAllAndLoad();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            FormUsuarioDetalle usuarioDetalle = new FormUsuarioDetalle();
            int id = this.SelectedItem().IdUsuario;
            Usuario usuario = await UsuariosApi.GetAsync(id);
            usuarioDetalle.EditMode = true;
            usuarioDetalle.Usuario = usuario;
            usuarioDetalle.ShowDialog();
            this.GetAllAndLoad();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormUsuarioDetalle usuarioDetalle = new FormUsuarioDetalle();
            Usuario usuarioNuevo = new Usuario();
            usuarioDetalle.Usuario = usuarioNuevo;
            usuarioDetalle.ShowDialog();
            this.GetAllAndLoad();
        }
        private void Usuarios_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }

        private async void GetAllAndLoad()
        {
            this.dgvUsuarios.DataSource = null;
            this.dgvUsuarios.AutoGenerateColumns = true;
            var usuarios = await UsuariosApi.GetAllAsync();
            this.dgvUsuarios.DataSource = usuarios;
            this.dgvUsuarios.Refresh();

            if (this.dgvUsuarios.Rows.Count > 0)
            {
                this.dgvUsuarios.Rows[0].Selected = true;
                this.btnBorrar.Enabled = true;
                this.btnEditar.Enabled = true;
            }
            else
            {
                this.btnBorrar.Enabled = false;
                this.btnEditar.Enabled = false;
            }
        }

        private Usuario SelectedItem()
        {
            return (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            this.GetAllAndLoad();
        }
    }
}
