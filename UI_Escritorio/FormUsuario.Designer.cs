using Entidades;

namespace UI_Escritorio
{
    partial class FormUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tlUsuarios = new TableLayoutPanel();
            dgvUsuarios = new DataGridView();
            btnListar = new Button();
            btnBorrar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            tlUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // tlUsuarios
            // 
            tlUsuarios.ColumnCount = 5;
            tlUsuarios.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlUsuarios.ColumnStyles.Add(new ColumnStyle());
            tlUsuarios.ColumnStyles.Add(new ColumnStyle());
            tlUsuarios.ColumnStyles.Add(new ColumnStyle());
            tlUsuarios.ColumnStyles.Add(new ColumnStyle());
            tlUsuarios.Controls.Add(dgvUsuarios, 0, 0);
            tlUsuarios.Controls.Add(btnListar, 1, 1);
            tlUsuarios.Controls.Add(btnBorrar, 2, 1);
            tlUsuarios.Controls.Add(btnEditar, 3, 1);
            tlUsuarios.Controls.Add(btnNuevo, 4, 1);
            tlUsuarios.Dock = DockStyle.Fill;
            tlUsuarios.Location = new Point(0, 0);
            tlUsuarios.Name = "tlUsuarios";
            tlUsuarios.RowCount = 2;
            tlUsuarios.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlUsuarios.RowStyles.Add(new RowStyle());
            tlUsuarios.Size = new Size(800, 451);
            tlUsuarios.TabIndex = 0;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlUsuarios.SetColumnSpan(dgvUsuarios, 5);
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.Location = new Point(3, 3);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(794, 410);
            dgvUsuarios.TabIndex = 0;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(403, 419);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(94, 29);
            btnListar.TabIndex = 4;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(503, 419);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(94, 29);
            btnBorrar.TabIndex = 2;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(603, 419);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(703, 419);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "Agregar";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // FormUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            ControlBox = false;
            Controls.Add(tlUsuarios);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormUsuario";
            tlUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlUsuarios;
        private Button btnListar;
        private Button btnEditar;
        private Button btnBorrar;
        private Button btnNuevo;
        private DataGridView dgvUsuarios;
    }
}