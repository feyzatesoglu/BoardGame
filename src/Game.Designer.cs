namespace BoardGame
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            this.GameBoard = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtScore = new System.Windows.Forms.TextBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblBestScore = new System.Windows.Forms.Label();
            this.txtBoxBestScore = new System.Windows.Forms.TextBox();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // GameBoard
            // 
            this.GameBoard.BackColor = System.Drawing.Color.SkyBlue;
            this.GameBoard.ErrorImage = global::BoardGame.Properties.Resources.RedTriangle;
            this.GameBoard.Location = new System.Drawing.Point(12, 12);
            this.GameBoard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GameBoard.Name = "GameBoard";
            this.GameBoard.Size = new System.Drawing.Size(775, 775);
            this.GameBoard.TabIndex = 0;
            this.GameBoard.TabStop = false;
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(907, 114);
            this.txtScore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(100, 22);
            this.txtScore.TabIndex = 2;
            this.txtScore.Text = "0";
            this.txtScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(815, 118);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(49, 17);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "Score:";
            // 
            // lblBestScore
            // 
            this.lblBestScore.AutoSize = true;
            this.lblBestScore.Location = new System.Drawing.Point(815, 175);
            this.lblBestScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBestScore.Name = "lblBestScore";
            this.lblBestScore.Size = new System.Drawing.Size(85, 17);
            this.lblBestScore.TabIndex = 4;
            this.lblBestScore.Text = "Best Score: ";
            // 
            // txtBoxBestScore
            // 
            this.txtBoxBestScore.Location = new System.Drawing.Point(907, 171);
            this.txtBoxBestScore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBoxBestScore.Name = "txtBoxBestScore";
            this.txtBoxBestScore.Size = new System.Drawing.Size(100, 22);
            this.txtBoxBestScore.TabIndex = 5;
            this.txtBoxBestScore.Text = "0";
            this.txtBoxBestScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Location = new System.Drawing.Point(852, 287);
            this.lblTurn.MaximumSize = new System.Drawing.Size(15, 15);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(12, 15);
            this.lblTurn.TabIndex = 6;
            this.lblTurn.Text = " ";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(818, 287);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(12, 17);
            this.lbl.TabIndex = 7;
            this.lbl.Text = " ";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(1047, 828);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.txtBoxBestScore);
            this.Controls.Add(this.lblBestScore);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.GameBoard);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Game";
            this.Text = "Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.Load += new System.EventHandler(this.Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GameBoard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GameBoard;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblBestScore;
        private System.Windows.Forms.TextBox txtBoxBestScore;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lbl;
    }
}