namespace UI_Escritorio
{
    partial class FormPersonas
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
            tlPersonas = new TableLayoutPanel();
            dgvPersonas = new DataGridView();
            btnListar = new Button();
            btnBorrar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            btnReporte = new Button();
            tlPersonas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).BeginInit();
            SuspendLayout();
            // 
            // tlPersonas
            // 
            tlPersonas.ColumnCount = 5;
            tlPersonas.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlPersonas.ColumnStyles.Add(new ColumnStyle());
            tlPersonas.ColumnStyles.Add(new ColumnStyle());
            tlPersonas.ColumnStyles.Add(new ColumnStyle());
            tlPersonas.ColumnStyles.Add(new ColumnStyle());
            tlPersonas.Controls.Add(dgvPersonas, 0, 0);
            tlPersonas.Controls.Add(btnListar, 1, 1);
            tlPersonas.Controls.Add(btnBorrar, 2, 1);
            tlPersonas.Controls.Add(btnEditar, 3, 1);
            tlPersonas.Controls.Add(btnNuevo, 4, 1);
            tlPersonas.Controls.Add(btnReporte, 0, 1);
            tlPersonas.Dock = DockStyle.Fill;
            tlPersonas.Location = new Point(0, 0);
            tlPersonas.Margin = new Padding(3, 2, 3, 2);
            tlPersonas.Name = "tlPersonas";
            tlPersonas.RowCount = 2;
            tlPersonas.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlPersonas.RowStyles.Add(new RowStyle());
            tlPersonas.Size = new Size(700, 338);
            tlPersonas.TabIndex = 0;
            // 
            // dgvPersonas
            // 
            dgvPersonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlPersonas.SetColumnSpan(dgvPersonas, 5);
            dgvPersonas.Dock = DockStyle.Fill;
            dgvPersonas.Location = new Point(3, 2);
            dgvPersonas.Margin = new Padding(3, 2, 3, 2);
            dgvPersonas.Name = "dgvPersonas";
            dgvPersonas.RowHeadersWidth = 51;
            dgvPersonas.Size = new Size(694, 305);
            dgvPersonas.TabIndex = 0;
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
            btnReporte.Size = new Size(133, 23);
            btnReporte.TabIndex = 5;
            btnReporte.Text = "Generar Reporte";
            btnReporte.UseVisualStyleBackColor = true;
            btnReporte.Click += btnReporte_Click;
            // 
            // FormPersonas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            ControlBox = false;
            Controls.Add(tlPersonas);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormPersonas";
            Load += FormPersonas_Load;
            tlPersonas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlPersonas;
        private Button btnListar;
        private Button btnEditar;
        private Button btnBorrar;
        private Button btnNuevo;
        private DataGridView dgvPersonas;
        private Button btnReporte;
    }
}