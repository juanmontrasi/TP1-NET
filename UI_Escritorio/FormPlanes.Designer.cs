namespace UI_Escritorio
{
    partial class FormPlanes
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
            tlPlanes = new TableLayoutPanel();
            dgvPlanes = new DataGridView();
            btnListar = new Button();
            btnBorrar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            tlPlanes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlanes).BeginInit();
            SuspendLayout();
            // 
            // tlPlanes
            // 
            tlPlanes.ColumnCount = 5;
            tlPlanes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlPlanes.ColumnStyles.Add(new ColumnStyle());
            tlPlanes.ColumnStyles.Add(new ColumnStyle());
            tlPlanes.ColumnStyles.Add(new ColumnStyle());
            tlPlanes.ColumnStyles.Add(new ColumnStyle());
            tlPlanes.Controls.Add(dgvPlanes, 0, 0);
            tlPlanes.Controls.Add(btnListar, 1, 1);
            tlPlanes.Controls.Add(btnBorrar, 2, 1);
            tlPlanes.Controls.Add(btnEditar, 3, 1);
            tlPlanes.Controls.Add(btnNuevo, 4, 1);
            tlPlanes.Dock = DockStyle.Fill;
            tlPlanes.Location = new Point(0, 0);
            tlPlanes.Margin = new Padding(3, 2, 3, 2);
            tlPlanes.Name = "tlPlanes";
            tlPlanes.RowCount = 2;
            tlPlanes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlPlanes.RowStyles.Add(new RowStyle());
            tlPlanes.Size = new Size(700, 338);
            tlPlanes.TabIndex = 0;
            // 
            // dgvPlanes
            // 
            dgvPlanes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlPlanes.SetColumnSpan(dgvPlanes, 5);
            dgvPlanes.Dock = DockStyle.Fill;
            dgvPlanes.Location = new Point(3, 2);
            dgvPlanes.Margin = new Padding(3, 2, 3, 2);
            dgvPlanes.Name = "dgvPlanes";
            dgvPlanes.RowHeadersWidth = 51;
            dgvPlanes.Size = new Size(694, 308);
            dgvPlanes.TabIndex = 0;
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
            // FormPlanes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            ControlBox = false;
            Controls.Add(tlPlanes);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormPlanes";
            tlPlanes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPlanes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlPlanes;
        private Button btnListar;
        private Button btnEditar;
        private Button btnBorrar;
        private Button btnNuevo;
        private DataGridView dgvPlanes;
    }
}