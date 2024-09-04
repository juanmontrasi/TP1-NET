namespace UI_Escritorio
{
    partial class FormInscripcionesAlumno
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
            tlInscripcionesAlumno = new TableLayoutPanel();
            dgvInscripcionesAlumno = new DataGridView();
            btnListar = new Button();
            btnBorrar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            tlInscripcionesAlumno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInscripcionesAlumno).BeginInit();
            SuspendLayout();
            // 
            // tlInscripcionesAlumno
            // 
            tlInscripcionesAlumno.ColumnCount = 5;
            tlInscripcionesAlumno.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlInscripcionesAlumno.ColumnStyles.Add(new ColumnStyle());
            tlInscripcionesAlumno.ColumnStyles.Add(new ColumnStyle());
            tlInscripcionesAlumno.ColumnStyles.Add(new ColumnStyle());
            tlInscripcionesAlumno.ColumnStyles.Add(new ColumnStyle());
            tlInscripcionesAlumno.Controls.Add(dgvInscripcionesAlumno, 0, 0);
            tlInscripcionesAlumno.Controls.Add(btnListar, 1, 1);
            tlInscripcionesAlumno.Controls.Add(btnBorrar, 2, 1);
            tlInscripcionesAlumno.Controls.Add(btnEditar, 3, 1);
            tlInscripcionesAlumno.Controls.Add(btnNuevo, 4, 1);
            tlInscripcionesAlumno.Dock = DockStyle.Fill;
            tlInscripcionesAlumno.Location = new Point(0, 0);
            tlInscripcionesAlumno.Margin = new Padding(3, 2, 3, 2);
            tlInscripcionesAlumno.Name = "tlInscripcionesAlumno";
            tlInscripcionesAlumno.RowCount = 2;
            tlInscripcionesAlumno.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlInscripcionesAlumno.RowStyles.Add(new RowStyle());
            tlInscripcionesAlumno.Size = new Size(700, 338);
            tlInscripcionesAlumno.TabIndex = 0;
            // 
            // dgvInscripcionesAlumno
            // 
            dgvInscripcionesAlumno.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlInscripcionesAlumno.SetColumnSpan(dgvInscripcionesAlumno, 5);
            dgvInscripcionesAlumno.Dock = DockStyle.Fill;
            dgvInscripcionesAlumno.Location = new Point(3, 2);
            dgvInscripcionesAlumno.Margin = new Padding(3, 2, 3, 2);
            dgvInscripcionesAlumno.Name = "dgvInscripcionesAlumno";
            dgvInscripcionesAlumno.RowHeadersWidth = 51;
            dgvInscripcionesAlumno.Size = new Size(694, 308);
            dgvInscripcionesAlumno.TabIndex = 0;
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
            // FormInscripcionesAlumno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            ControlBox = false;
            Controls.Add(tlInscripcionesAlumno);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormInscripcionesAlumno";
            tlInscripcionesAlumno.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInscripcionesAlumno).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlInscripcionesAlumno;
        private Button btnListar;
        private Button btnEditar;
        private Button btnBorrar;
        private Button btnNuevo;
        private DataGridView dgvInscripcionesAlumno;
    }
}