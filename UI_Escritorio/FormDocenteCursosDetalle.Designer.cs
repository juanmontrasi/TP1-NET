namespace UI_Escritorio
{
    partial class FormDocenteCursosDetalle
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
            btnAceptar = new Button();
            cbCargo = new ComboBox();
            cursolb = new Label();
            label3 = new Label();
            cbDocente = new ComboBox();
            cbCurso = new ComboBox();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(211, 124);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Id Docente";
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(199, 261);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(170, 68);
            btnAceptar.TabIndex = 1;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // cbCargo
            // 
            cbCargo.FormattingEnabled = true;
            cbCargo.Location = new Point(319, 72);
            cbCargo.Name = "cbCargo";
            cbCargo.Size = new Size(189, 28);
            cbCargo.TabIndex = 2;
            // 
            // cursolb
            // 
            cursolb.AutoSize = true;
            cursolb.Location = new Point(230, 179);
            cursolb.Name = "cursolb";
            cursolb.Size = new Size(63, 20);
            cursolb.TabIndex = 3;
            cursolb.Text = "Id Curso";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(244, 75);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 4;
            label3.Text = "Cargo";
            // 
            // cbDocente
            // 
            cbDocente.FormattingEnabled = true;
            cbDocente.Location = new Point(319, 121);
            cbDocente.Name = "cbDocente";
            cbDocente.Size = new Size(189, 28);
            cbDocente.TabIndex = 5;
            // 
            // cbCurso
            // 
            cbCurso.FormattingEnabled = true;
            cbCurso.Location = new Point(319, 176);
            cbCurso.Name = "cbCurso";
            cbCurso.Size = new Size(189, 28);
            cbCurso.TabIndex = 6;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(406, 261);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(170, 68);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FormDocenteCursosDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancelar);
            Controls.Add(cbCurso);
            Controls.Add(cbDocente);
            Controls.Add(label3);
            Controls.Add(cursolb);
            Controls.Add(cbCargo);
            Controls.Add(btnAceptar);
            Controls.Add(label1);
            Name = "FormDocenteCursosDetalle";
            Text = "FormDocenteCursosDetalle";
            Load += FormDocenteCursosDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAceptar;
        private ComboBox cbCargo;
        private Label cursolb;
        private Label label3;
        private ComboBox cbDocente;
        private ComboBox cbCurso;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
    }
}