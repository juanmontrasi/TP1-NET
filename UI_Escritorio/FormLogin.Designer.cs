namespace UI_Escritorio
{
    partial class FormLogin
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
            txtUsuario = new TextBox();
            txtPass = new TextBox();
            btnIngresar = new Button();
            lnkOlvidaPass = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(114, 72);
            label1.Name = "label1";
            label1.Size = new Size(287, 40);
            label1.TabIndex = 0;
            label1.Text = "¡Bienvenido al Sistema!\r\nPor favor digite su informacion de ingreso";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(114, 146);
            label2.Name = "label2";
            label2.Size = new Size(142, 20);
            label2.TabIndex = 1;
            label2.Text = "Nombre de Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(170, 206);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 2;
            label3.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(274, 143);
            txtUsuario.Margin = new Padding(3, 4, 3, 4);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(151, 27);
            txtUsuario.TabIndex = 3;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(274, 203);
            txtPass.Margin = new Padding(3, 4, 3, 4);
            txtPass.Name = "txtPass";
            txtPass.PasswordChar = '*';
            txtPass.Size = new Size(151, 27);
            txtPass.TabIndex = 4;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(339, 263);
            btnIngresar.Margin = new Padding(3, 4, 3, 4);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(86, 31);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += BtnIngresar_Click;
            // 
            // lnkOlvidaPass
            // 
            lnkOlvidaPass.AutoSize = true;
            lnkOlvidaPass.Location = new Point(146, 274);
            lnkOlvidaPass.Name = "lnkOlvidaPass";
            lnkOlvidaPass.Size = new Size(149, 20);
            lnkOlvidaPass.TabIndex = 6;
            lnkOlvidaPass.TabStop = true;
            lnkOlvidaPass.Text = "Olvidé mi contraseña";
            lnkOlvidaPass.LinkClicked += LnkOlvidaPass_LinkClicked;
            // 
            // FormLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 461);
            Controls.Add(lnkOlvidaPass);
            Controls.Add(btnIngresar);
            Controls.Add(txtPass);
            Controls.Add(txtUsuario);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ingresar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsuario;
        private TextBox txtPass;
        private Button btnIngresar;
        private LinkLabel lnkOlvidaPass;
    }
}