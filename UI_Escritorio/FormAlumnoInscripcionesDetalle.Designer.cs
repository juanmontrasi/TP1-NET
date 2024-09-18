namespace UI_Escritorio
{
    partial class FormAlumnoInscripcionesDetalle
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbCondicion = new TextBox();
            tbNota = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            label4 = new Label();
            cbCursos = new ComboBox();
            cbAlumnos = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(275, 68);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Condicion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(304, 109);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 1;
            label2.Text = "Nota";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(299, 150);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 2;
            label3.Text = "Curso";
            // 
            // tbCondicion
            // 
            tbCondicion.Location = new Point(361, 65);
            tbCondicion.Name = "tbCondicion";
            tbCondicion.Size = new Size(143, 23);
            tbCondicion.TabIndex = 3;
            
            // 
            // tbNota
            // 
            tbNota.Location = new Point(361, 106);
            tbNota.Name = "tbNota";
            tbNota.Size = new Size(143, 23);
            tbNota.TabIndex = 4;
            
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(234, 227);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(158, 53);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(433, 227);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(166, 53);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(287, 184);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 8;
            label4.Text = "Alumno";
            // 
            // cbCursos
            // 
            cbCursos.FormattingEnabled = true;
            cbCursos.Location = new Point(361, 142);
            cbCursos.Name = "cbCursos";
            cbCursos.Size = new Size(143, 23);
            cbCursos.TabIndex = 9;

            // 
            // cbAlumnos
            // 
            cbAlumnos.FormattingEnabled = true;
            cbAlumnos.Location = new Point(361, 181);
            cbAlumnos.Name = "cbAlumnos";
            cbAlumnos.Size = new Size(143, 23);
            cbAlumnos.TabIndex = 10;

            // 
            // FormAlumnoInscripcionesDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 473);
            Controls.Add(cbAlumnos);
            Controls.Add(cbCursos);
            Controls.Add(label4);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(tbNota);
            Controls.Add(tbCondicion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormAlumnoInscripcionesDetalle";
            Text = "FormAlumnoInscripcionesDetalle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbCondicion;
        private TextBox tbNota;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label4;
        private ComboBox cbCursos;
        private ComboBox cbAlumnos;
    }
}