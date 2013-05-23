namespace Hangman
{
    partial class PlayerName
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
            this.tbPlayer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btSubmit = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPlayer
            // 
            this.tbPlayer.Location = new System.Drawing.Point(12, 91);
            this.tbPlayer.MaxLength = 10;
            this.tbPlayer.Multiline = true;
            this.tbPlayer.Name = "tbPlayer";
            this.tbPlayer.Size = new System.Drawing.Size(146, 28);
            this.tbPlayer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter your name:";
            // 
            // btSubmit
            // 
            this.btSubmit.Location = new System.Drawing.Point(174, 91);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(113, 28);
            this.btSubmit.TabIndex = 2;
            this.btSubmit.Text = "Submit";
            this.btSubmit.UseVisualStyleBackColor = true;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScore.Location = new System.Drawing.Point(203, 31);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(45, 16);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(24, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Your scores is:";
            // 
            // PlayerName
            // 
            this.AcceptButton = this.btSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 133);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btSubmit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(250, 250);
            this.MaximizeBox = false;
            this.Name = "PlayerName";
            this.Text = "Player Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPlayer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSubmit;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label label3;
    }
}