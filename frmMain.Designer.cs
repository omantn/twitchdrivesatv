namespace twitchDrivesATV_Server
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblPrev = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblLeftL = new System.Windows.Forms.Label();
            this.lblRightL = new System.Windows.Forms.Label();
            this.lblForwardL = new System.Windows.Forms.Label();
            this.lblBackL = new System.Windows.Forms.Label();
            this.lblTimeL = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblLeft = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.lblForward = new System.Windows.Forms.Label();
            this.lblBack = new System.Windows.Forms.Label();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.lblLastSingleL = new System.Windows.Forms.Label();
            this.lblLastWinner = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPrev
            // 
            this.lblPrev.AutoSize = true;
            this.lblPrev.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrev.ForeColor = System.Drawing.Color.White;
            this.lblPrev.Location = new System.Drawing.Point(26, 9);
            this.lblPrev.Name = "lblPrev";
            this.lblPrev.Size = new System.Drawing.Size(652, 50);
            this.lblPrev.TabIndex = 0;
            this.lblPrev.Text = "Previous Vote Results";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrent.ForeColor = System.Drawing.Color.White;
            this.lblCurrent.Location = new System.Drawing.Point(34, 545);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(592, 50);
            this.lblCurrent.TabIndex = 1;
            this.lblCurrent.Text = "Current Vote Status";
            // 
            // lblLeftL
            // 
            this.lblLeftL.AutoSize = true;
            this.lblLeftL.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftL.ForeColor = System.Drawing.Color.White;
            this.lblLeftL.Location = new System.Drawing.Point(44, 636);
            this.lblLeftL.Name = "lblLeftL";
            this.lblLeftL.Size = new System.Drawing.Size(352, 50);
            this.lblLeftL.TabIndex = 2;
            this.lblLeftL.Text = "Left Votes:";
            // 
            // lblRightL
            // 
            this.lblRightL.AutoSize = true;
            this.lblRightL.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightL.ForeColor = System.Drawing.Color.White;
            this.lblRightL.Location = new System.Drawing.Point(44, 700);
            this.lblRightL.Name = "lblRightL";
            this.lblRightL.Size = new System.Drawing.Size(382, 50);
            this.lblRightL.TabIndex = 3;
            this.lblRightL.Text = "Right Votes:";
            // 
            // lblForwardL
            // 
            this.lblForwardL.AutoSize = true;
            this.lblForwardL.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForwardL.ForeColor = System.Drawing.Color.White;
            this.lblForwardL.Location = new System.Drawing.Point(44, 767);
            this.lblForwardL.Name = "lblForwardL";
            this.lblForwardL.Size = new System.Drawing.Size(442, 50);
            this.lblForwardL.TabIndex = 4;
            this.lblForwardL.Text = "Forward Votes:";
            // 
            // lblBackL
            // 
            this.lblBackL.AutoSize = true;
            this.lblBackL.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackL.ForeColor = System.Drawing.Color.White;
            this.lblBackL.Location = new System.Drawing.Point(44, 835);
            this.lblBackL.Name = "lblBackL";
            this.lblBackL.Size = new System.Drawing.Size(352, 50);
            this.lblBackL.TabIndex = 5;
            this.lblBackL.Text = "Back Votes:";
            // 
            // lblTimeL
            // 
            this.lblTimeL.AutoSize = true;
            this.lblTimeL.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeL.ForeColor = System.Drawing.Color.White;
            this.lblTimeL.Location = new System.Drawing.Point(44, 900);
            this.lblTimeL.Name = "lblTimeL";
            this.lblTimeL.Size = new System.Drawing.Size(472, 50);
            this.lblTimeL.TabIndex = 6;
            this.lblTimeL.Text = "Time Remaining:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(554, 900);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(82, 50);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "15";
            // 
            // lblLeft
            // 
            this.lblLeft.AutoSize = true;
            this.lblLeft.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeft.ForeColor = System.Drawing.Color.White;
            this.lblLeft.Location = new System.Drawing.Point(554, 636);
            this.lblLeft.Name = "lblLeft";
            this.lblLeft.Size = new System.Drawing.Size(52, 50);
            this.lblLeft.TabIndex = 8;
            this.lblLeft.Text = "0";
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRight.ForeColor = System.Drawing.Color.White;
            this.lblRight.Location = new System.Drawing.Point(554, 700);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(52, 50);
            this.lblRight.TabIndex = 9;
            this.lblRight.Text = "0";
            // 
            // lblForward
            // 
            this.lblForward.AutoSize = true;
            this.lblForward.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForward.ForeColor = System.Drawing.Color.White;
            this.lblForward.Location = new System.Drawing.Point(554, 767);
            this.lblForward.Name = "lblForward";
            this.lblForward.Size = new System.Drawing.Size(52, 50);
            this.lblForward.TabIndex = 10;
            this.lblForward.Text = "0";
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBack.ForeColor = System.Drawing.Color.White;
            this.lblBack.Location = new System.Drawing.Point(554, 835);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(52, 50);
            this.lblBack.TabIndex = 11;
            this.lblBack.Text = "0";
            // 
            // lstHistory
            // 
            this.lstHistory.BackColor = System.Drawing.Color.Black;
            this.lstHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstHistory.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstHistory.ForeColor = System.Drawing.Color.White;
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.ItemHeight = 50;
            this.lstHistory.Location = new System.Drawing.Point(43, 75);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(615, 400);
            this.lstHistory.TabIndex = 12;
            // 
            // lblLastSingleL
            // 
            this.lblLastSingleL.AutoSize = true;
            this.lblLastSingleL.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastSingleL.ForeColor = System.Drawing.Color.White;
            this.lblLastSingleL.Location = new System.Drawing.Point(44, 979);
            this.lblLastSingleL.Name = "lblLastSingleL";
            this.lblLastSingleL.Size = new System.Drawing.Size(382, 50);
            this.lblLastSingleL.TabIndex = 13;
            this.lblLastSingleL.Text = "Last Winner:";
            // 
            // lblLastWinner
            // 
            this.lblLastWinner.AutoSize = true;
            this.lblLastWinner.Font = new System.Drawing.Font("OCR A Extended", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastWinner.ForeColor = System.Drawing.Color.White;
            this.lblLastWinner.Location = new System.Drawing.Point(434, 979);
            this.lblLastWinner.Name = "lblLastWinner";
            this.lblLastWinner.Size = new System.Drawing.Size(0, 50);
            this.lblLastWinner.TabIndex = 14;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(721, 1141);
            this.Controls.Add(this.lblLastWinner);
            this.Controls.Add(this.lblLastSingleL);
            this.Controls.Add(this.lstHistory);
            this.Controls.Add(this.lblBack);
            this.Controls.Add(this.lblForward);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblLeft);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblTimeL);
            this.Controls.Add(this.lblBackL);
            this.Controls.Add(this.lblForwardL);
            this.Controls.Add(this.lblRightL);
            this.Controls.Add(this.lblLeftL);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.lblPrev);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Twitch Drives an ATV Vote Scorer";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPrev;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblLeftL;
        private System.Windows.Forms.Label lblRightL;
        private System.Windows.Forms.Label lblForwardL;
        private System.Windows.Forms.Label lblBackL;
        private System.Windows.Forms.Label lblTimeL;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblLeft;
        private System.Windows.Forms.Label lblRight;
        private System.Windows.Forms.Label lblForward;
        private System.Windows.Forms.Label lblBack;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Label lblLastSingleL;
        private System.Windows.Forms.Label lblLastWinner;
    }
}

