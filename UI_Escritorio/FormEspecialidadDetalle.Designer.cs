namespace UI_Escritorio
{
    partial class FormEspecialidadDetalle
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
            nombreTextBox = new TextBox();
            nombreLabel = new Label();
            aceptarButton = new Button();
            cancelarButton = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(201, 24);
            nombreTextBox.Margin = new Padding(2, 1, 2, 1);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(125, 27);
            nombreTextBox.TabIndex = 0;
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(27, 28);
            nombreLabel.Margin = new Padding(2, 0, 2, 0);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(152, 20);
            nombreLabel.TabIndex = 1;
            nombreLabel.Text = "Nombre Especialidad";
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(273, 229);
            aceptarButton.Margin = new Padding(2, 1, 2, 1);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(93, 29);
            aceptarButton.TabIndex = 2;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(378, 229);
            cancelarButton.Margin = new Padding(2, 1, 2, 1);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(93, 29);
            cancelarButton.TabIndex = 3;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // FormEspecialidadDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 281);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(nombreLabel);
            Controls.Add(nombreTextBox);
            Margin = new Padding(2, 1, 2, 1);
            Name = "FormEspecialidadDetalle";
            Text = "Especialidad";
            Load += FormEspecialidadDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nombreTextBox;
        private Label nombreLabel;
        private Button aceptarButton;
        private Button cancelarButton;
        private ErrorProvider errorProvider;
    }
}