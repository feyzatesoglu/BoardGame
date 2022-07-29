
namespace BoardGame
{
    partial class MainGame
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
            this.mainSettingsBtn = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCredits = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnMulti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainSettingsBtn
            // 
            this.mainSettingsBtn.BackColor = System.Drawing.Color.MediumPurple;
            this.mainSettingsBtn.Location = new System.Drawing.Point(427, 227);
            this.mainSettingsBtn.Margin = new System.Windows.Forms.Padding(4);
            this.mainSettingsBtn.Name = "mainSettingsBtn";
            this.mainSettingsBtn.Size = new System.Drawing.Size(207, 73);
            this.mainSettingsBtn.TabIndex = 2;
            this.mainSettingsBtn.Text = "Settings";
            this.mainSettingsBtn.UseVisualStyleBackColor = false;
            this.mainSettingsBtn.Click += new System.EventHandler(this.mainSettingsBtn_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.MediumPurple;
            this.btnProfile.Location = new System.Drawing.Point(427, 146);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(4);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(207, 73);
            this.btnProfile.TabIndex = 1;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.MediumPurple;
            this.btnBack.Location = new System.Drawing.Point(427, 468);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(207, 73);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Log Out";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCredits
            // 
            this.btnCredits.BackColor = System.Drawing.Color.MediumPurple;
            this.btnCredits.Location = new System.Drawing.Point(427, 308);
            this.btnCredits.Margin = new System.Windows.Forms.Padding(4);
            this.btnCredits.Name = "btnCredits";
            this.btnCredits.Size = new System.Drawing.Size(207, 73);
            this.btnCredits.TabIndex = 3;
            this.btnCredits.Text = "Credits";
            this.btnCredits.UseVisualStyleBackColor = false;
            this.btnCredits.Click += new System.EventHandler(this.btnCredits_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.MediumPurple;
            this.btnPlay.Location = new System.Drawing.Point(300, 65);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(207, 73);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.MediumPurple;
            this.btnHelp.Location = new System.Drawing.Point(427, 388);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(207, 73);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnMulti
            // 
            this.btnMulti.BackColor = System.Drawing.Color.MediumPurple;
            this.btnMulti.Location = new System.Drawing.Point(547, 65);
            this.btnMulti.Margin = new System.Windows.Forms.Padding(4);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(207, 73);
            this.btnMulti.TabIndex = 6;
            this.btnMulti.Text = "Multiplay";
            this.btnMulti.UseVisualStyleBackColor = false;
            this.btnMulti.Click += new System.EventHandler(this.btnMulti_Click);
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnMulti);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnCredits);
            this.Controls.Add(this.mainSettingsBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainGame";
            this.Text = "MainGame";
            this.Load += new System.EventHandler(this.MainGame_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button mainSettingsBtn;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCredits;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnMulti;
    }
}