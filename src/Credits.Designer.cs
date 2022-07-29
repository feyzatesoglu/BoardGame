
namespace BoardGame {
    partial class Credits {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblCreditsGameName = new System.Windows.Forms.Label();
            this.lblCreditsInfoDev = new System.Windows.Forms.Label();
            this.lblDevelopmentDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCreditsGameName
            // 
            this.lblCreditsGameName.AutoSize = true;
            this.lblCreditsGameName.Location = new System.Drawing.Point(38, 51);
            this.lblCreditsGameName.Name = "lblCreditsGameName";
            this.lblCreditsGameName.Size = new System.Drawing.Size(128, 13);
            this.lblCreditsGameName.TabIndex = 0;
            this.lblCreditsGameName.Text = "Game Name: BoardGame";
            // 
            // lblCreditsInfoDev
            // 
            this.lblCreditsInfoDev.AutoSize = true;
            this.lblCreditsInfoDev.Location = new System.Drawing.Point(38, 79);
            this.lblCreditsInfoDev.Name = "lblCreditsInfoDev";
            this.lblCreditsInfoDev.Size = new System.Drawing.Size(196, 13);
            this.lblCreditsInfoDev.TabIndex = 0;
            this.lblCreditsInfoDev.Text = "Developers: Feyzatesoglu, ThePoetDev";
            // 
            // lblDevelopmentDate
            // 
            this.lblDevelopmentDate.AutoSize = true;
            this.lblDevelopmentDate.Location = new System.Drawing.Point(38, 107);
            this.lblDevelopmentDate.Name = "lblDevelopmentDate";
            this.lblDevelopmentDate.Size = new System.Drawing.Size(156, 13);
            this.lblDevelopmentDate.TabIndex = 0;
            this.lblDevelopmentDate.Text = "Development Date: 11.04.2022";
            // 
            // Credits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(380, 199);
            this.Controls.Add(this.lblDevelopmentDate);
            this.Controls.Add(this.lblCreditsInfoDev);
            this.Controls.Add(this.lblCreditsGameName);
            this.Name = "Credits";
            this.Text = "Credits";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCreditsGameName;
        private System.Windows.Forms.Label lblCreditsInfoDev;
        private System.Windows.Forms.Label lblDevelopmentDate;
    }
}