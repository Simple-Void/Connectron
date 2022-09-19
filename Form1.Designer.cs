namespace Connectron
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sliderBoardSize = new System.Windows.Forms.TrackBar();
            this.lblBoardSize = new System.Windows.Forms.Label();
            this.lblPlayerCount = new System.Windows.Forms.Label();
            this.sliderPlayerCount = new System.Windows.Forms.TrackBar();
            this.lblWinLength = new System.Windows.Forms.Label();
            this.sliderWinLength = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkOverflow = new System.Windows.Forms.CheckBox();
            this.chkSolitaire = new System.Windows.Forms.CheckBox();
            this.chkBomb = new System.Windows.Forms.CheckBox();
            this.chkCorners = new System.Windows.Forms.CheckBox();
            this.rd3rounds = new System.Windows.Forms.RadioButton();
            this.rd5rounds = new System.Windows.Forms.RadioButton();
            this.btnPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sliderBoardSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPlayerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderWinLength)).BeginInit();
            this.SuspendLayout();
            // 
            // sliderBoardSize
            // 
            this.sliderBoardSize.Location = new System.Drawing.Point(12, 114);
            this.sliderBoardSize.Maximum = 100;
            this.sliderBoardSize.Minimum = 6;
            this.sliderBoardSize.Name = "sliderBoardSize";
            this.sliderBoardSize.Size = new System.Drawing.Size(558, 56);
            this.sliderBoardSize.TabIndex = 0;
            this.sliderBoardSize.Value = 6;
            // 
            // lblBoardSize
            // 
            this.lblBoardSize.AutoSize = true;
            this.lblBoardSize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBoardSize.Location = new System.Drawing.Point(12, 91);
            this.lblBoardSize.Name = "lblBoardSize";
            this.lblBoardSize.Size = new System.Drawing.Size(148, 20);
            this.lblBoardSize.TabIndex = 1;
            this.lblBoardSize.Text = "Board Size [6 - 100]";
            this.lblBoardSize.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblPlayerCount
            // 
            this.lblPlayerCount.AutoSize = true;
            this.lblPlayerCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPlayerCount.Location = new System.Drawing.Point(12, 9);
            this.lblPlayerCount.Name = "lblPlayerCount";
            this.lblPlayerCount.Size = new System.Drawing.Size(155, 20);
            this.lblPlayerCount.TabIndex = 3;
            this.lblPlayerCount.Text = "Player Count [1 - 10]";
            this.lblPlayerCount.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // sliderPlayerCount
            // 
            this.sliderPlayerCount.Location = new System.Drawing.Point(12, 32);
            this.sliderPlayerCount.Minimum = 1;
            this.sliderPlayerCount.Name = "sliderPlayerCount";
            this.sliderPlayerCount.Size = new System.Drawing.Size(558, 56);
            this.sliderPlayerCount.TabIndex = 2;
            this.sliderPlayerCount.Value = 6;
            this.sliderPlayerCount.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // lblWinLength
            // 
            this.lblWinLength.AutoSize = true;
            this.lblWinLength.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWinLength.Location = new System.Drawing.Point(12, 173);
            this.lblWinLength.Name = "lblWinLength";
            this.lblWinLength.Size = new System.Drawing.Size(139, 20);
            this.lblWinLength.TabIndex = 5;
            this.lblWinLength.Text = "Win Length [4-10]";
            // 
            // sliderWinLength
            // 
            this.sliderWinLength.Location = new System.Drawing.Point(12, 196);
            this.sliderWinLength.Minimum = 4;
            this.sliderWinLength.Name = "sliderWinLength";
            this.sliderWinLength.Size = new System.Drawing.Size(558, 56);
            this.sliderWinLength.TabIndex = 4;
            this.sliderWinLength.Value = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(293, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Best of";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Special Rules";
            // 
            // chkOverflow
            // 
            this.chkOverflow.AutoSize = true;
            this.chkOverflow.Location = new System.Drawing.Point(12, 258);
            this.chkOverflow.Name = "chkOverflow";
            this.chkOverflow.Size = new System.Drawing.Size(124, 24);
            this.chkOverflow.TabIndex = 10;
            this.chkOverflow.Text = "Overflow Rule";
            this.chkOverflow.UseVisualStyleBackColor = true;
            // 
            // chkSolitaire
            // 
            this.chkSolitaire.AutoSize = true;
            this.chkSolitaire.Location = new System.Drawing.Point(10, 288);
            this.chkSolitaire.Name = "chkSolitaire";
            this.chkSolitaire.Size = new System.Drawing.Size(119, 24);
            this.chkSolitaire.TabIndex = 11;
            this.chkSolitaire.Text = "Solitaire Rule";
            this.chkSolitaire.UseVisualStyleBackColor = true;
            // 
            // chkBomb
            // 
            this.chkBomb.AutoSize = true;
            this.chkBomb.Location = new System.Drawing.Point(10, 318);
            this.chkBomb.Name = "chkBomb";
            this.chkBomb.Size = new System.Drawing.Size(104, 24);
            this.chkBomb.TabIndex = 12;
            this.chkBomb.Text = "Bomb Rule";
            this.chkBomb.UseVisualStyleBackColor = true;
            // 
            // chkCorners
            // 
            this.chkCorners.AutoSize = true;
            this.chkCorners.Location = new System.Drawing.Point(10, 348);
            this.chkCorners.Name = "chkCorners";
            this.chkCorners.Size = new System.Drawing.Size(114, 24);
            this.chkCorners.TabIndex = 13;
            this.chkCorners.Text = "Corners Rule";
            this.chkCorners.UseVisualStyleBackColor = true;
            // 
            // rd3rounds
            // 
            this.rd3rounds.AutoSize = true;
            this.rd3rounds.Location = new System.Drawing.Point(293, 255);
            this.rd3rounds.Name = "rd3rounds";
            this.rd3rounds.Size = new System.Drawing.Size(91, 24);
            this.rd3rounds.TabIndex = 14;
            this.rd3rounds.TabStop = true;
            this.rd3rounds.Text = "3 Rounds";
            this.rd3rounds.UseVisualStyleBackColor = true;
            // 
            // rd5rounds
            // 
            this.rd5rounds.AutoSize = true;
            this.rd5rounds.Location = new System.Drawing.Point(293, 288);
            this.rd5rounds.Name = "rd5rounds";
            this.rd5rounds.Size = new System.Drawing.Size(91, 24);
            this.rd5rounds.TabIndex = 15;
            this.rd5rounds.TabStop = true;
            this.rd5rounds.Text = "5 Rounds";
            this.rd5rounds.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPlay.Location = new System.Drawing.Point(10, 378);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(561, 45);
            this.btnPlay.TabIndex = 16;
            this.btnPlay.Text = "play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 435);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.rd5rounds);
            this.Controls.Add(this.rd3rounds);
            this.Controls.Add(this.chkCorners);
            this.Controls.Add(this.chkBomb);
            this.Controls.Add(this.chkSolitaire);
            this.Controls.Add(this.chkOverflow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblWinLength);
            this.Controls.Add(this.sliderWinLength);
            this.Controls.Add(this.lblPlayerCount);
            this.Controls.Add(this.sliderPlayerCount);
            this.Controls.Add(this.lblBoardSize);
            this.Controls.Add(this.sliderBoardSize);
            this.Name = "Form1";
            this.Text = "Inputs";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sliderBoardSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderPlayerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderWinLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TrackBar sliderBoardSize;
        private Label lblBoardSize;
        private Label lblPlayerCount;
        private TrackBar sliderPlayerCount;
        private Label lblWinLength;
        private TrackBar sliderWinLength;
        private Label label1;
        private Label label2;
        private CheckBox chkOverflow;
        private CheckBox chkSolitaire;
        private CheckBox chkBomb;
        private CheckBox chkCorners;
        private RadioButton rd3rounds;
        private RadioButton rd5rounds;
        private Button btnPlay;
    }
}