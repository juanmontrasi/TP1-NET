namespace UI_Escritorio
{
    partial class FormComisionDetalle
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
            nombreTextBox = new TextBox();
            anioTextBox = new TextBox();
            cbPlanes = new ComboBox();
            label3 = new Label();
            btnCancelar = new Button();
            btnAceptar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(188, 112);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre comision";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(192, 168);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 2;
            label2.Text = "Año especialidad";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(347, 109);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(255, 27);
            nombreTextBox.TabIndex = 3;
            // 
            // anioTextBox
            // 
            anioTextBox.Location = new Point(347, 165);
            anioTextBox.Name = "anioTextBox";
            anioTextBox.Size = new Size(121, 27);
            anioTextBox.TabIndex = 4;
            // 
            // cbPlanes
            // 
            cbPlanes.FormattingEnabled = true;
            cbPlanes.Location = new Point(347, 39);
            cbPlanes.Name = "cbPlanes";
            cbPlanes.Size = new Size(151, 28);
            cbPlanes.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(266, 42);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 6;
            label3.Text = "Plan";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(694, 409);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(576, 409);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FormComisionDetalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAceptar);
            Controls.Add(btnCancelar);
            Controls.Add(label3);
            Controls.Add(cbPlanes);
            Controls.Add(anioTextBox);
            Controls.Add(nombreTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormComisionDetalle";
            Text = "FormComisionDetalle";
            Load += FormComisionDetalle_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox nombreTextBox;
        private TextBox anioTextBox;
        private ComboBox cbPlanes;
        private Label label3;
        private Button btnCancelar;
        private Button btnAceptar;
        private ErrorProvider errorProvider1;
    }
}