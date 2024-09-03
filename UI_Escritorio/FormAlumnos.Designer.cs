namespace UI_Escritorio
{
    partial class FormAlumnos
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
            tlAlumnos = new TableLayoutPanel();
            dgvAlumnos = new DataGridView();
            btnEditar = new Button();
            btnBorrar = new Button();
            btnNuevo = new Button();
            tlAlumnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).BeginInit();
            SuspendLayout();
            // 
            // tlAlumnos
            // 
            tlAlumnos.ColumnCount = 3;
            tlAlumnos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlAlumnos.ColumnStyles.Add(new ColumnStyle());
            tlAlumnos.ColumnStyles.Add(new ColumnStyle());
            tlAlumnos.Controls.Add(dgvAlumnos, 0, 0);
            tlAlumnos.Controls.Add(btnEditar, 1, 1);
            tlAlumnos.Controls.Add(btnBorrar, 0, 1);
            tlAlumnos.Controls.Add(btnNuevo, 2, 1);
            tlAlumnos.Dock = DockStyle.Fill;
            tlAlumnos.Location = new Point(0, 0);
            tlAlumnos.Name = "tlAlumnos";
            tlAlumnos.RowCount = 2;
            tlAlumnos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlAlumnos.RowStyles.Add(new RowStyle());
            tlAlumnos.Size = new Size(800, 450);
            tlAlumnos.TabIndex = 0;
            // 
            // dgvAlumnos
            // 
            dgvAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tlAlumnos.SetColumnSpan(dgvAlumnos, 3);
            dgvAlumnos.Dock = DockStyle.Fill;
            dgvAlumnos.Location = new Point(3, 3);
            dgvAlumnos.Name = "dgvAlumnos";
            dgvAlumnos.RowHeadersWidth = 51;
            dgvAlumnos.Size = new Size(794, 409);
            dgvAlumnos.TabIndex = 0;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(603, 418);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnBorrar
            // 
            btnBorrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBorrar.Location = new Point(503, 418);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(94, 29);
            btnBorrar.TabIndex = 2;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(703, 418);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // FormAlumnos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(tlAlumnos);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormAlumnos";
            tlAlumnos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlAlumnos;
        private Button btnEditar;
        private Button btnBorrar;
        private Button btnNuevo;
        private DataGridView dgvAlumnos;
    }
}