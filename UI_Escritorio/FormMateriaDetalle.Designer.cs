namespace UI_Escritorio
{
    partial class FormMateriaDetalle
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
            nombreTextBox = new TextBox();
            hsemTextBox = new TextBox();
            htotTextBox = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            cbPlanes = new ComboBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(199, 142);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre Materia";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(197, 192);
            label2.Name = "label2";
            label2.Size = new Size(121, 20);
            label2.TabIndex = 1;
            label2.Text = "Horas semanales";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(221, 241);
            label3.Name = "label3";
            label3.Size = new Size(97, 20);
            label3.TabIndex = 2;
            label3.Text = "Horas totales";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(345, 139);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(263, 27);
            nombreTextBox.TabIndex = 3;
            // 
            // hsemTextBox
            // 
            hsemTextBox.Location = new Point(345, 189);
            hsemTextBox.Name = "hsemTextBox";
            hsemTextBox.Size = new Size(139, 27);
            hsemTextBox.TabIndex = 4;
            // 
            // htotTextBox
            // 
            htotTextBox.Location = new Point(345, 238);
            htotTextBox.Name = "htotTextBox";
            htotTextBox.Size = new Size(139, 27);
            htotTextBox.TabIndex = 5;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(538, 384);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 7;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(659, 384);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // cbPlanes
            // 
            cbPlanes.FormattingEnabled = true;
            cbPlanes.Location = new Point(345, 43);
            cbPlanes.Name = "cbPlanes";
            cbPlanes.Size = new Size(151, 28);
            cbPlanes.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(268, 46);
            label4.Name = "label4";
            label4.Size = new Size(51, 20);
            label4.TabIndex = 10;
            label4.Text = "Planes";
            label4.Click += label4_Click;
            // 
            // FormMateriaDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(cbPlanes);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(htotTextBox);
            Controls.Add(hsemTextBox);
            Controls.Add(nombreTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormMateriaDetalle";
            Text = "FormMateriaDetalle";
            Load += FormMateriaDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox nombreTextBox;
        private TextBox hsemTextBox;
        private TextBox htotTextBox;
        private Button btnAceptar;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
        private Label label4;
        private ComboBox cbPlanes;
    }
}