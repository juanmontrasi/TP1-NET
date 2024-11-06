namespace UI_Escritorio
{
    partial class FormUsuarioDetalle
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
            btnAceptar = new Button();
            btnCancelar = new Button();
            nombreTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            claveTextBox = new TextBox();
            comboBoxRol = new ComboBox();
            label3 = new Label();
            errorProvider1 = new ErrorProvider(components);
            label4 = new Label();
            comboBoxPersonas = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(579, 409);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(694, 409);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(339, 110);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(196, 27);
            nombreTextBox.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(206, 113);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 3;
            label1.Text = "Nombre Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(241, 170);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 4;
            label2.Text = "Contraseña";
            // 
            // claveTextBox
            // 
            claveTextBox.Location = new Point(339, 167);
            claveTextBox.Name = "claveTextBox";
            claveTextBox.Size = new Size(196, 27);
            claveTextBox.TabIndex = 5;
            // 
            // comboBoxRol
            // 
            comboBoxRol.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRol.FormattingEnabled = true;
            comboBoxRol.Location = new Point(339, 230);
            comboBoxRol.Margin = new Padding(3, 4, 3, 4);
            comboBoxRol.Name = "comboBoxRol";
            comboBoxRol.Size = new Size(228, 28);
            comboBoxRol.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(293, 233);
            label3.Name = "label3";
            label3.Size = new Size(31, 20);
            label3.TabIndex = 7;
            label3.Text = "Rol";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(241, 59);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 8;
            label4.Text = "Id Persona";
            // 
            // comboBoxPersonas
            // 
            comboBoxPersonas.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPersonas.FormattingEnabled = true;
            comboBoxPersonas.Location = new Point(339, 56);
            comboBoxPersonas.Margin = new Padding(3, 4, 3, 4);
            comboBoxPersonas.Name = "comboBoxPersonas";
            comboBoxPersonas.Size = new Size(228, 28);
            comboBoxPersonas.TabIndex = 9;
            // 
            // FormUsuarioDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBoxPersonas);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(comboBoxRol);
            Controls.Add(claveTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nombreTextBox);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Name = "FormUsuarioDetalle";
            Text = "FormUsuarioDetalle";
            Load += FormUsuarioDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Button btnCancelar;
        private TextBox nombreTextBox;
        private Label label1;
        private Label label2;
        private TextBox claveTextBox;
        private ComboBox comboBoxRol;
        private Label label3;
        private ErrorProvider errorProvider1;
        private Label label4;
        private ComboBox comboBoxPersonas;
    }
}