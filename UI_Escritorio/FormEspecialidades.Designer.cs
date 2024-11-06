namespace UI_Escritorio
{
    partial class FormEspecialidades
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
            tlEspecialidades = new TableLayoutPanel();
            dgvEspecialidades = new DataGridView();
            btnListar = new Button();
            btnBorrar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            btnGenerarReporte = new Button();
            tlEspecialidades.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEspecialidades).BeginInit();
            SuspendLayout();
            // 
            // tlEspecialidades
            // 
            tlEspecialidades.ColumnCount = 5;
            tlEspecialidades.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlEspecialidades.ColumnStyles.Add(new ColumnStyle());
            tlEspecialidades.ColumnStyles.Add(new ColumnStyle());
            tlEspecialidades.ColumnStyles.Add(new ColumnStyle());
            tlEspecialidades.ColumnStyles.Add(new ColumnStyle());
            tlEspecialidades.Controls.Add(dgvEspecialidades, 0, 0);
            tlEspecialidades.Controls.Add(btnListar, 1, 1);
            tlEspecialidades.Controls.Add(btnBorrar, 2, 1);
            tlEspecialidades.Controls.Add(btnEditar, 3, 1);
            tlEspecialidades.Controls.Add(btnNuevo, 4, 1);
            tlEspecialidades.Controls.Add(btnGenerarReporte, 0, 1);
            tlEspecialidades.Dock = DockStyle.Fill;
            tlEspecialidades.Location = new Point(0, 0);
            tlEspecialidades.Margin = new Padding(3, 2, 3, 2);
            tlEspecialidades.Name = "tlEspecialidades";
            tlEspecialidades.RowCount = 2;
            tlEspecialidades.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlEspecialidades.RowStyles.Add(new RowStyle());
            tlEspecialidades.Size = new Size(700, 338);
            tlEspecialidades.TabIndex = 0;
            // 
            // dgvEspecialidades
            // 
            dgvEspecialidades.AllowUserToOrderColumns = true;
            dgvEspecialidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlEspecialidades.SetColumnSpan(dgvEspecialidades, 5);
            dgvEspecialidades.Dock = DockStyle.Fill;
            dgvEspecialidades.Location = new Point(3, 2);
            dgvEspecialidades.Margin = new Padding(3, 2, 3, 2);
            dgvEspecialidades.Name = "dgvEspecialidades";
            dgvEspecialidades.ReadOnly = true;
            dgvEspecialidades.RowHeadersWidth = 51;
            dgvEspecialidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEspecialidades.Size = new Size(694, 305);
            dgvEspecialidades.TabIndex = 0;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(351, 311);
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
            btnBorrar.Location = new Point(439, 311);
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
            btnEditar.Location = new Point(527, 311);
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
            btnNuevo.Location = new Point(615, 311);
            btnNuevo.Margin = new Padding(3, 2, 3, 2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(82, 22);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "Agregar";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.Location = new Point(3, 312);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(150, 23);
            btnGenerarReporte.TabIndex = 5;
            btnGenerarReporte.Text = "Generar Reporte";
            btnGenerarReporte.UseVisualStyleBackColor = true;
            btnGenerarReporte.Click += btnGenerarReporte_Click;
            // 
            // FormEspecialidades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            ControlBox = false;
            Controls.Add(tlEspecialidades);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormEspecialidades";
            Load += Especialidades_Load;
            tlEspecialidades.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEspecialidades).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlEspecialidades;
        private Button btnListar;
        private Button btnEditar;
        private Button btnBorrar;
        private Button btnNuevo;
        private DataGridView dgvEspecialidades;
        private Button btnGenerarReporte;
    }
}