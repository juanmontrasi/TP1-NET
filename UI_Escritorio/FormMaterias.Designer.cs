namespace UI_Escritorio
{
    partial class FormMaterias
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
            tlMaterias = new TableLayoutPanel();
            dgvMaterias = new DataGridView();
            btnListar = new Button();
            btnBorrar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            btnReporte = new Button();
            tlMaterias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).BeginInit();
            SuspendLayout();
            // 
            // tlMaterias
            // 
            tlMaterias.ColumnCount = 5;
            tlMaterias.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlMaterias.ColumnStyles.Add(new ColumnStyle());
            tlMaterias.ColumnStyles.Add(new ColumnStyle());
            tlMaterias.ColumnStyles.Add(new ColumnStyle());
            tlMaterias.ColumnStyles.Add(new ColumnStyle());
            tlMaterias.Controls.Add(dgvMaterias, 0, 0);
            tlMaterias.Controls.Add(btnListar, 1, 1);
            tlMaterias.Controls.Add(btnBorrar, 2, 1);
            tlMaterias.Controls.Add(btnEditar, 3, 1);
            tlMaterias.Controls.Add(btnNuevo, 4, 1);
            tlMaterias.Controls.Add(btnReporte, 0, 1);
            tlMaterias.Dock = DockStyle.Fill;
            tlMaterias.Location = new Point(0, 0);
            tlMaterias.Margin = new Padding(3, 2, 3, 2);
            tlMaterias.Name = "tlMaterias";
            tlMaterias.RowCount = 2;
            tlMaterias.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlMaterias.RowStyles.Add(new RowStyle());
            tlMaterias.Size = new Size(700, 338);
            tlMaterias.TabIndex = 0;
            // 
            // dgvMaterias
            // 
            dgvMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlMaterias.SetColumnSpan(dgvMaterias, 5);
            dgvMaterias.Dock = DockStyle.Fill;
            dgvMaterias.Location = new Point(3, 2);
            dgvMaterias.Margin = new Padding(3, 2, 3, 2);
            dgvMaterias.Name = "dgvMaterias";
            dgvMaterias.RowHeadersWidth = 51;
            dgvMaterias.Size = new Size(694, 305);
            dgvMaterias.TabIndex = 0;
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
            // btnReporte
            // 
            btnReporte.Location = new Point(3, 312);
            btnReporte.Name = "btnReporte";
            btnReporte.Size = new Size(139, 23);
            btnReporte.TabIndex = 5;
            btnReporte.Text = "Generar Reporte";
            btnReporte.UseVisualStyleBackColor = true;
            btnReporte.Click += btnReporte_Click;
            // 
            // FormMaterias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            ControlBox = false;
            Controls.Add(tlMaterias);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormMaterias";
            Load += FormMaterias_Load;
            tlMaterias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlMaterias;
        private Button btnListar;
        private Button btnEditar;
        private Button btnBorrar;
        private Button btnNuevo;
        private DataGridView dgvMaterias;
        private Button btnReporte;
    }
}