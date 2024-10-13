namespace UI_Escritorio
{
    partial class FormCursoDetalle
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            nombreTextBox = new TextBox();
            cupoTextBox = new TextBox();
            anioTextBox = new TextBox();
            cbMateria = new ComboBox();
            cbComisiones = new ComboBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(133, 38);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 0;
            label1.Text = "Materia";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(437, 38);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 1;
            label2.Text = "Comision";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(219, 250);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 2;
            label3.Text = "Año Calendario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(226, 141);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 3;
            label4.Text = "Nombre Curso";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(287, 198);
            label5.Name = "label5";
            label5.Size = new Size(44, 20);
            label5.TabIndex = 4;
            label5.Text = "Cupo";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(694, 409);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(573, 409);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 6;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click_1;
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(356, 138);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(292, 27);
            nombreTextBox.TabIndex = 7;
            // 
            // cupoTextBox
            // 
            cupoTextBox.Location = new Point(356, 195);
            cupoTextBox.Name = "cupoTextBox";
            cupoTextBox.Size = new Size(113, 27);
            cupoTextBox.TabIndex = 8;
            // 
            // anioTextBox
            // 
            anioTextBox.Location = new Point(356, 247);
            anioTextBox.Name = "anioTextBox";
            anioTextBox.Size = new Size(113, 27);
            anioTextBox.TabIndex = 9;
            // 
            // cbMateria
            // 
            cbMateria.FormattingEnabled = true;
            cbMateria.Location = new Point(208, 35);
            cbMateria.Name = "cbMateria";
            cbMateria.Size = new Size(151, 28);
            cbMateria.TabIndex = 10;
            cbMateria.SelectedIndexChanged += cbMateria_SelectedIndexChanged;
            // 
            // cbComisiones
            // 
            cbComisiones.FormattingEnabled = true;
            cbComisiones.Location = new Point(516, 35);
            cbComisiones.Name = "cbComisiones";
            cbComisiones.Size = new Size(151, 28);
            cbComisiones.TabIndex = 11;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FormCursoDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbComisiones);
            Controls.Add(cbMateria);
            Controls.Add(anioTextBox);
            Controls.Add(cupoTextBox);
            Controls.Add(nombreTextBox);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormCursoDetalle";
            Text = "FormCursoDetalle";
            Load += FormCursoDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnCancelar;
        private Button btnAceptar;
        private TextBox nombreTextBox;
        private TextBox cupoTextBox;
        private TextBox anioTextBox;
        private ComboBox cbMateria;
        private ComboBox cbComisiones;
        private ErrorProvider errorProvider1;
    }
}