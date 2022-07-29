
namespace BoardGame
{
    partial class Server
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
            this.grpbxConn = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.btnConn = new System.Windows.Forms.Button();
            this.btnHost = new System.Windows.Forms.Button();
            this.grpbxConn.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbxConn
            // 
            this.grpbxConn.Controls.Add(this.btnConn);
            this.grpbxConn.Controls.Add(this.textBox1);
            this.grpbxConn.Controls.Add(this.lblIP);
            this.grpbxConn.Location = new System.Drawing.Point(63, 32);
            this.grpbxConn.Name = "grpbxConn";
            this.grpbxConn.Size = new System.Drawing.Size(411, 144);
            this.grpbxConn.TabIndex = 0;
            this.grpbxConn.TabStop = false;
            this.grpbxConn.Text = "Connect the game";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(52, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(186, 22);
            this.textBox1.TabIndex = 1;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(22, 56);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(24, 17);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "IP:";
            // 
            // btnConn
            // 
            this.btnConn.BackColor = System.Drawing.Color.MediumPurple;
            this.btnConn.Location = new System.Drawing.Point(256, 55);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(98, 23);
            this.btnConn.TabIndex = 2;
            this.btnConn.Text = "Connect";
            this.btnConn.UseVisualStyleBackColor = false;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // btnHost
            // 
            this.btnHost.BackColor = System.Drawing.Color.MediumPurple;
            this.btnHost.Location = new System.Drawing.Point(198, 182);
            this.btnHost.Name = "btnHost";
            this.btnHost.Size = new System.Drawing.Size(166, 53);
            this.btnHost.TabIndex = 3;
            this.btnHost.Text = "Host";
            this.btnHost.UseVisualStyleBackColor = false;
            this.btnHost.Click += new System.EventHandler(this.btnHost_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHost);
            this.Controls.Add(this.grpbxConn);
            this.Name = "Server";
            this.Text = "Server";
            this.grpbxConn.ResumeLayout(false);
            this.grpbxConn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbxConn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.Button btnHost;
    }
}