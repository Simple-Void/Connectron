namespace Connectron
{
    partial class BoardView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataBoard = new System.Windows.Forms.DataGridView();
            this.sliderDrop = new System.Windows.Forms.TrackBar();
            this.btnDrop = new System.Windows.Forms.Button();
            this.btnBomb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderDrop)).BeginInit();
            this.SuspendLayout();
            // 
            // DataBoard
            // 
            this.DataBoard.AllowUserToAddRows = false;
            this.DataBoard.AllowUserToDeleteRows = false;
            this.DataBoard.AllowUserToOrderColumns = true;
            this.DataBoard.AllowUserToResizeColumns = false;
            this.DataBoard.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataBoard.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DataBoard.ColumnHeadersHeight = 29;
            this.DataBoard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DataBoard.ColumnHeadersVisible = false;
            this.DataBoard.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DataBoard.Location = new System.Drawing.Point(12, 112);
            this.DataBoard.Name = "DataBoard";
            this.DataBoard.ReadOnly = true;
            this.DataBoard.RowHeadersVisible = false;
            this.DataBoard.RowHeadersWidth = 51;
            this.DataBoard.RowTemplate.Height = 10;
            this.DataBoard.Size = new System.Drawing.Size(500, 500);
            this.DataBoard.TabIndex = 0;
            this.DataBoard.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataBoard_CellContentClick);
            // 
            // sliderDrop
            // 
            this.sliderDrop.Location = new System.Drawing.Point(12, 50);
            this.sliderDrop.Name = "sliderDrop";
            this.sliderDrop.Size = new System.Drawing.Size(500, 56);
            this.sliderDrop.TabIndex = 1;
            // 
            // btnDrop
            // 
            this.btnDrop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDrop.Location = new System.Drawing.Point(112, 12);
            this.btnDrop.Name = "btnDrop";
            this.btnDrop.Size = new System.Drawing.Size(400, 32);
            this.btnDrop.TabIndex = 2;
            this.btnDrop.Text = "Drop";
            this.btnDrop.UseVisualStyleBackColor = true;
            this.btnDrop.Click += new System.EventHandler(this.btnDrop_Click);
            // 
            // btnBomb
            // 
            this.btnBomb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBomb.Location = new System.Drawing.Point(12, 12);
            this.btnBomb.Name = "btnBomb";
            this.btnBomb.Size = new System.Drawing.Size(94, 32);
            this.btnBomb.TabIndex = 3;
            this.btnBomb.Text = "Bomb";
            this.btnBomb.UseVisualStyleBackColor = true;
            this.btnBomb.Click += new System.EventHandler(this.btnBomb_Click);
            // 
            // BoardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 625);
            this.Controls.Add(this.btnBomb);
            this.Controls.Add(this.btnDrop);
            this.Controls.Add(this.sliderDrop);
            this.Controls.Add(this.DataBoard);
            this.Name = "BoardView";
            this.Text = "x";
            ((System.ComponentModel.ISupportInitialize)(this.DataBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderDrop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView DataBoard;
        private TrackBar sliderDrop;
        private Button btnDrop;
        private Button btnBomb;
    }
}