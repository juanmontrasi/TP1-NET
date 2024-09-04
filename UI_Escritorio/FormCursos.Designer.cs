namespace UI_Escritorio
{
    partial class FormCursos
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
            tlCursos = new TableLayoutPanel();
            dgvCursos = new DataGridView();
            btnListar = new Button();
            btnBorrar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            tlCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCursos).BeginInit();
            SuspendLayout();
            // 
            // tlCursos
            // 
            tlCursos.ColumnCount = 5;
            tlCursos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlCursos.ColumnStyles.Add(new ColumnStyle());
            tlCursos.ColumnStyles.Add(new ColumnStyle());
            tlCursos.ColumnStyles.Add(new ColumnStyle());
            tlCursos.ColumnStyles.Add(new ColumnStyle());
            tlCursos.Controls.Add(dgvCursos, 0, 0);
            tlCursos.Controls.Add(btnListar, 1, 1);
            tlCursos.Controls.Add(btnBorrar, 2, 1);
            tlCursos.Controls.Add(btnEditar, 3, 1);
            tlCursos.Controls.Add(btnNuevo, 4, 1);
            tlCursos.Dock = DockStyle.Fill;
            tlCursos.Location = new Point(0, 0);
            tlCursos.Margin = new Padding(3, 2, 3, 2);
            tlCursos.Name = "tlCursos";
            tlCursos.RowCount = 2;
            tlCursos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlCursos.RowStyles.Add(new RowStyle());
            tlCursos.Size = new Size(700, 338);
            tlCursos.TabIndex = 0;
            // 
            // dgvCursos
            // 
            dgvCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlCursos.SetColumnSpan(dgvCursos, 5);
            dgvCursos.Dock = DockStyle.Fill;
            dgvCursos.Location = new Point(3, 2);
            dgvCursos.Margin = new Padding(3, 2, 3, 2);
            dgvCursos.Name = "dgvCursos";
            dgvCursos.RowHeadersWidth = 51;
            dgvCursos.Size = new Size(694, 308);
            dgvCursos.TabIndex = 0;
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
            // FormCursos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            ControlBox = false;
            Controls.Add(tlCursos);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormCursos";
            tlCursos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCursos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlCursos;
        private Button btnListar;
        private Button btnEditar;
        private Button btnBorrar;
        private Button btnNuevo;
        private DataGridView dgvCursos;
    }
}