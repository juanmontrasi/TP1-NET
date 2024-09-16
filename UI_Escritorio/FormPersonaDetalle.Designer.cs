namespace UI_Escritorio
{
    partial class FormPersonaDetalle
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
            apellidotb = new TextBox();
            mailtb = new TextBox();
            direcciontb = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            comboBoxPlanes = new ComboBox();
            label6 = new Label();
            legajotb = new TextBox();
            label7 = new Label();
            fechaNacdtp = new DateTimePicker();
            label8 = new Label();
            comboBoxTipoPersona = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(282, 43);
            nombreTextBox.Margin = new Padding(2, 1, 2, 1);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(113, 23);
            nombreTextBox.TabIndex = 0;
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(155, 43);
            nombreLabel.Margin = new Padding(2, 0, 2, 0);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(96, 15);
            nombreLabel.TabIndex = 1;
            nombreLabel.Text = "Nombre Persona";
            // 
            // aceptarButton
            // 
            aceptarButton.Location = new Point(155, 382);
            aceptarButton.Margin = new Padding(2, 1, 2, 1);
            aceptarButton.Name = "aceptarButton";
            aceptarButton.Size = new Size(81, 22);
            aceptarButton.TabIndex = 2;
            aceptarButton.Text = "Aceptar";
            aceptarButton.UseVisualStyleBackColor = true;
            aceptarButton.Click += aceptarButton_Click;
            // 
            // cancelarButton
            // 
            cancelarButton.Location = new Point(313, 382);
            cancelarButton.Margin = new Padding(2, 1, 2, 1);
            cancelarButton.Name = "cancelarButton";
            cancelarButton.Size = new Size(81, 22);
            cancelarButton.TabIndex = 3;
            cancelarButton.Text = "Cancelar";
            cancelarButton.UseVisualStyleBackColor = true;
            cancelarButton.Click += cancelarButton_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // apellidotb
            // 
            apellidotb.Location = new Point(283, 79);
            apellidotb.Name = "apellidotb";
            apellidotb.Size = new Size(111, 23);
            apellidotb.TabIndex = 4;
            // 
            // mailtb
            // 
            mailtb.Location = new Point(282, 123);
            mailtb.Name = "mailtb";
            mailtb.Size = new Size(113, 23);
            mailtb.TabIndex = 5;
            // 
            // direcciontb
            // 
            direcciontb.Location = new Point(282, 165);
            direcciontb.Name = "direcciontb";
            direcciontb.Size = new Size(113, 23);
            direcciontb.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(155, 82);
            label1.Name = "label1";
            label1.Size = new Size(96, 15);
            label1.TabIndex = 8;
            label1.Text = "Apellido persona";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(155, 123);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 9;
            label2.Text = "Mail Persona";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(155, 166);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 10;
            label3.Text = "Direccion Persona";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(155, 243);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 12;
            label5.Text = "Plan Persona";
            // 
            // comboBoxPlanes
            // 
            comboBoxPlanes.FormattingEnabled = true;
            comboBoxPlanes.Location = new Point(282, 243);
            comboBoxPlanes.Name = "comboBoxPlanes";
            comboBoxPlanes.Size = new Size(112, 23);
            comboBoxPlanes.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(155, 10);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 14;
            label6.Text = "Legajo";
            // 
            // legajotb
            // 
            legajotb.Location = new Point(283, 10);
            legajotb.Name = "legajotb";
            legajotb.Size = new Size(111, 23);
            legajotb.TabIndex = 15;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(155, 202);
            label7.Name = "label7";
            label7.Size = new Size(103, 15);
            label7.TabIndex = 16;
            label7.Text = "Fecha Nacimiento";
            // 
            // fechaNacdtp
            // 
            fechaNacdtp.Location = new Point(282, 196);
            fechaNacdtp.Name = "fechaNacdtp";
            fechaNacdtp.Size = new Size(200, 23);
            fechaNacdtp.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(155, 305);
            label8.Name = "label8";
            label8.Size = new Size(75, 15);
            label8.TabIndex = 18;
            label8.Text = "Tipo Persona";
            // 
            // comboBoxTipoPersona
            // 
            comboBoxTipoPersona.FormattingEnabled = true;
            comboBoxTipoPersona.Location = new Point(282, 305);
            comboBoxTipoPersona.Name = "comboBoxTipoPersona";
            comboBoxTipoPersona.Size = new Size(113, 23);
            comboBoxTipoPersona.TabIndex = 19;
            // 
            // FormPersonaDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(657, 499);
            Controls.Add(comboBoxTipoPersona);
            Controls.Add(label8);
            Controls.Add(fechaNacdtp);
            Controls.Add(label7);
            Controls.Add(legajotb);
            Controls.Add(label6);
            Controls.Add(comboBoxPlanes);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(direcciontb);
            Controls.Add(mailtb);
            Controls.Add(apellidotb);
            Controls.Add(cancelarButton);
            Controls.Add(aceptarButton);
            Controls.Add(nombreLabel);
            Controls.Add(nombreTextBox);
            Margin = new Padding(2, 1, 2, 1);
            Name = "FormPersonaDetalle";
            Text = "Persona";
            Load += FormPersonaDetalle_Load;
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
        private ComboBox cbPlanes;
        private ComboBox comboBoxPlanes;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox direcciontb;
        private TextBox mailtb;
        private TextBox apellidotb;
        private DateTimePicker fechaNacdtp;
        private Label label7;
        private TextBox legajotb;
        private Label label6;
        private ComboBox comboBoxTipoPersona;
        private Label label8;
    }
}