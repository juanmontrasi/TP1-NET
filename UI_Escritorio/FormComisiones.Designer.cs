namespace UI_Escritorio
{
    partial class FormComisiones
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
            tlComisiones = new TableLayoutPanel();
            dgvComisiones = new DataGridView();
            btnListar = new Button();
            btnBorrar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            tlComisiones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComisiones).BeginInit();
            SuspendLayout();
            // 
            // tlComisiones
            // 
            tlComisiones.ColumnCount = 5;
            tlComisiones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlComisiones.ColumnStyles.Add(new ColumnStyle());
            tlComisiones.ColumnStyles.Add(new ColumnStyle());
            tlComisiones.ColumnStyles.Add(new ColumnStyle());
            tlComisiones.ColumnStyles.Add(new ColumnStyle());
            tlComisiones.Controls.Add(dgvComisiones, 0, 0);
            tlComisiones.Controls.Add(btnListar, 1, 1);
            tlComisiones.Controls.Add(btnBorrar, 2, 1);
            tlComisiones.Controls.Add(btnEditar, 3, 1);
            tlComisiones.Controls.Add(btnNuevo, 4, 1);
            tlComisiones.Dock = DockStyle.Fill;
            tlComisiones.Location = new Point(0, 0);
            tlComisiones.Margin = new Padding(3, 2, 3, 2);
            tlComisiones.Name = "tlComisiones";
            tlComisiones.RowCount = 2;
            tlComisiones.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlComisiones.RowStyles.Add(new RowStyle());
            tlComisiones.Size = new Size(700, 338);
            tlComisiones.TabIndex = 0;
            // 
            // dgvComisiones
            // 
            dgvComisiones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlComisiones.SetColumnSpan(dgvComisiones, 5);
            dgvComisiones.Dock = DockStyle.Fill;
            dgvComisiones.Location = new Point(3, 2);
            dgvComisiones.Margin = new Padding(3, 2, 3, 2);
            dgvComisiones.Name = "dgvComisiones";
            dgvComisiones.RowHeadersWidth = 51;
            dgvComisiones.Size = new Size(694, 308);
            dgvComisiones.TabIndex = 0;
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
            // FormComisiones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            ControlBox = false;
            Controls.Add(tlComisiones);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormComisiones";
            Load += FormComisiones_Load;
            tlComisiones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvComisiones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlComisiones;
        private Button btnListar;
        private Button btnEditar;
        private Button btnBorrar;
        private Button btnNuevo;
        private DataGridView dgvComisiones;
    }
}