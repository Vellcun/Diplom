namespace StudyAppZK
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordUser = new System.Windows.Forms.TextBox();
            this.LoginUser = new System.Windows.Forms.TextBox();
            this.PasswordUserText = new System.Windows.Forms.Label();
            this.LodinUserText = new System.Windows.Forms.Label();
            this.passwordUser1 = new System.Windows.Forms.TextBox();
            this.passwordUser1Text = new System.Windows.Forms.Label();
            this.Reg = new System.Windows.Forms.Button();
            this.Warning = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Blue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 109);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(952, 109);
            this.label1.TabIndex = 0;
            this.label1.Text = "Регистрация";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordUser
            // 
            this.PasswordUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PasswordUser.Location = new System.Drawing.Point(403, 296);
            this.PasswordUser.MaxLength = 16;
            this.PasswordUser.Multiline = true;
            this.PasswordUser.Name = "PasswordUser";
            this.PasswordUser.Size = new System.Drawing.Size(299, 31);
            this.PasswordUser.TabIndex = 8;
            this.PasswordUser.Enter += new System.EventHandler(this.PasswordUser_Enter);
            this.PasswordUser.Leave += new System.EventHandler(this.PasswordUser_Leave);
            // 
            // LoginUser
            // 
            this.LoginUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginUser.Location = new System.Drawing.Point(403, 232);
            this.LoginUser.MaxLength = 16;
            this.LoginUser.Multiline = true;
            this.LoginUser.Name = "LoginUser";
            this.LoginUser.Size = new System.Drawing.Size(299, 31);
            this.LoginUser.TabIndex = 7;
            this.LoginUser.Enter += new System.EventHandler(this.LoginUser_Enter);
            this.LoginUser.Leave += new System.EventHandler(this.LoginUser_Leave);
            // 
            // PasswordUserText
            // 
            this.PasswordUserText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordUserText.AutoSize = true;
            this.PasswordUserText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordUserText.Location = new System.Drawing.Point(289, 296);
            this.PasswordUserText.Name = "PasswordUserText";
            this.PasswordUserText.Size = new System.Drawing.Size(108, 31);
            this.PasswordUserText.TabIndex = 6;
            this.PasswordUserText.Text = "Пароль";
            // 
            // LodinUserText
            // 
            this.LodinUserText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LodinUserText.Location = new System.Drawing.Point(309, 232);
            this.LodinUserText.Name = "LodinUserText";
            this.LodinUserText.Size = new System.Drawing.Size(88, 31);
            this.LodinUserText.TabIndex = 5;
            this.LodinUserText.Text = "Логин";
            // 
            // passwordUser1
            // 
            this.passwordUser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordUser1.Location = new System.Drawing.Point(403, 361);
            this.passwordUser1.MaxLength = 16;
            this.passwordUser1.Multiline = true;
            this.passwordUser1.Name = "passwordUser1";
            this.passwordUser1.Size = new System.Drawing.Size(299, 31);
            this.passwordUser1.TabIndex = 10;
            this.passwordUser1.WordWrap = false;
            this.passwordUser1.Enter += new System.EventHandler(this.passwordUser1_Enter);
            this.passwordUser1.Leave += new System.EventHandler(this.passwordUser1_Leave);
            // 
            // passwordUser1Text
            // 
            this.passwordUser1Text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordUser1Text.AutoSize = true;
            this.passwordUser1Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordUser1Text.Location = new System.Drawing.Point(123, 361);
            this.passwordUser1Text.Name = "passwordUser1Text";
            this.passwordUser1Text.Size = new System.Drawing.Size(274, 31);
            this.passwordUser1Text.TabIndex = 11;
            this.passwordUser1Text.Text = "Подтвердить пароль";
            // 
            // Reg
            // 
            this.Reg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Reg.Location = new System.Drawing.Point(361, 420);
            this.Reg.Name = "Reg";
            this.Reg.Size = new System.Drawing.Size(234, 49);
            this.Reg.TabIndex = 12;
            this.Reg.Text = "Зарегестрироваться";
            this.Reg.UseVisualStyleBackColor = true;
            this.Reg.Click += new System.EventHandler(this.Reg_Click);
            // 
            // Warning
            // 
            this.Warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Warning.ForeColor = System.Drawing.Color.Red;
            this.Warning.Location = new System.Drawing.Point(202, 529);
            this.Warning.Name = "Warning";
            this.Warning.Size = new System.Drawing.Size(552, 50);
            this.Warning.TabIndex = 13;
            this.Warning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // login
            // 
            this.login.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login.Location = new System.Drawing.Point(361, 475);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(234, 49);
            this.login.TabIndex = 14;
            this.login.Text = "Авторизоваться";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 584);
            this.Controls.Add(this.login);
            this.Controls.Add(this.Warning);
            this.Controls.Add(this.Reg);
            this.Controls.Add(this.passwordUser1Text);
            this.Controls.Add(this.passwordUser1);
            this.Controls.Add(this.PasswordUser);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LoginUser);
            this.Controls.Add(this.LodinUserText);
            this.Controls.Add(this.PasswordUserText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(972, 627);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(972, 627);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordUser;
        private System.Windows.Forms.TextBox LoginUser;
        private System.Windows.Forms.Label PasswordUserText;
        private System.Windows.Forms.Label LodinUserText;
        private System.Windows.Forms.TextBox passwordUser1;
        private System.Windows.Forms.Label passwordUser1Text;
        private System.Windows.Forms.Button Reg;
        private System.Windows.Forms.Label Warning;
        private System.Windows.Forms.Button login;
    }
}