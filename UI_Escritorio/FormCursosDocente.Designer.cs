﻿namespace UI_Escritorio
{
    partial class FormCursosDocente
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
            tlCursosDocente = new TableLayoutPanel();
            dgvCursosDocente = new DataGridView();
            btnListar = new Button();
            btnBorrar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            tlCursosDocente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCursosDocente).BeginInit();
            SuspendLayout();
            // 
            // tlCursosDocente
            // 
            tlCursosDocente.ColumnCount = 5;
            tlCursosDocente.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlCursosDocente.ColumnStyles.Add(new ColumnStyle());
            tlCursosDocente.ColumnStyles.Add(new ColumnStyle());
            tlCursosDocente.ColumnStyles.Add(new ColumnStyle());
            tlCursosDocente.ColumnStyles.Add(new ColumnStyle());
            tlCursosDocente.Controls.Add(dgvCursosDocente, 0, 0);
            tlCursosDocente.Controls.Add(btnListar, 1, 1);
            tlCursosDocente.Controls.Add(btnBorrar, 2, 1);
            tlCursosDocente.Controls.Add(btnEditar, 3, 1);
            tlCursosDocente.Controls.Add(btnNuevo, 4, 1);
            tlCursosDocente.Dock = DockStyle.Fill;
            tlCursosDocente.Location = new Point(0, 0);
            tlCursosDocente.Margin = new Padding(3, 2, 3, 2);
            tlCursosDocente.Name = "tlCursosDocente";
            tlCursosDocente.RowCount = 2;
            tlCursosDocente.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlCursosDocente.RowStyles.Add(new RowStyle());
            tlCursosDocente.Size = new Size(700, 338);
            tlCursosDocente.TabIndex = 0;
            // 
            // dgvCursosDocente
            // 
            dgvCursosDocente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlCursosDocente.SetColumnSpan(dgvCursosDocente, 5);
            dgvCursosDocente.Dock = DockStyle.Fill;
            dgvCursosDocente.Location = new Point(3, 2);
            dgvCursosDocente.Margin = new Padding(3, 2, 3, 2);
            dgvCursosDocente.Name = "dgvCursosDocente";
            dgvCursosDocente.RowHeadersWidth = 51;
            dgvCursosDocente.Size = new Size(694, 308);
            dgvCursosDocente.TabIndex = 0;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(351, 314);
            btnListar.Margin = new Padding(3, 2, 3, 2);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(82, 22);
            btnListar.TabIndex = 4;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(439, 314);
            btnBorrar.Margin = new Padding(3, 2, 3, 2);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(82, 22);
            btnBorrar.TabIndex = 2;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(527, 314);
            btnEditar.Margin = new Padding(3, 2, 3, 2);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(82, 22);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(615, 314);
            btnNuevo.Margin = new Padding(3, 2, 3, 2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(82, 22);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "Agregar";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // FormCursosDocente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            ControlBox = false;
            Controls.Add(tlCursosDocente);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormCursosDocente";
            tlCursosDocente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCursosDocente).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlCursosDocente;
        private Button btnListar;
        private Button btnEditar;
        private Button btnBorrar;
        private Button btnNuevo;
        private DataGridView dgvCursosDocente;
    }
}