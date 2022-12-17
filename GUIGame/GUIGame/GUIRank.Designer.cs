namespace GUIGame
{
    partial class GUIRank
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
            this.easyRankingTable = new System.Windows.Forms.DataGridView();
            this.normalRankingTable = new System.Windows.Forms.DataGridView();
            this.hardRankingTable = new System.Windows.Forms.DataGridView();
            this.easyRankingLabel = new System.Windows.Forms.Label();
            this.normalRankingLabel = new System.Windows.Forms.Label();
            this.hardRankingLabel = new System.Windows.Forms.Label();
            this.PlaceEasy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameEasy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeEasy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreEasy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaceNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreNormal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaceHard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameHard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeHard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScoreHard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.easyRankingTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalRankingTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardRankingTable)).BeginInit();
            this.SuspendLayout();
            // 
            // easyRankingTable
            // 
            this.easyRankingTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.easyRankingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.easyRankingTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlaceEasy,
            this.NameEasy,
            this.TimeEasy,
            this.ScoreEasy});
            this.easyRankingTable.Location = new System.Drawing.Point(16, 65);
            this.easyRankingTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.easyRankingTable.Name = "easyRankingTable";
            this.easyRankingTable.RowHeadersWidth = 51;
            this.easyRankingTable.Size = new System.Drawing.Size(627, 185);
            this.easyRankingTable.TabIndex = 0;
            // 
            // normalRankingTable
            // 
            this.normalRankingTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.normalRankingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.normalRankingTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlaceNormal,
            this.NameNormal,
            this.TimeNormal,
            this.ScoreNormal});
            this.normalRankingTable.Location = new System.Drawing.Point(15, 309);
            this.normalRankingTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.normalRankingTable.Name = "normalRankingTable";
            this.normalRankingTable.RowHeadersWidth = 51;
            this.normalRankingTable.Size = new System.Drawing.Size(627, 185);
            this.normalRankingTable.TabIndex = 1;
            // 
            // hardRankingTable
            // 
            this.hardRankingTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.hardRankingTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.hardRankingTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlaceHard,
            this.NameHard,
            this.TimeHard,
            this.ScoreHard});
            this.hardRankingTable.Location = new System.Drawing.Point(17, 553);
            this.hardRankingTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hardRankingTable.Name = "hardRankingTable";
            this.hardRankingTable.RowHeadersWidth = 51;
            this.hardRankingTable.Size = new System.Drawing.Size(627, 185);
            this.hardRankingTable.TabIndex = 2;
            // 
            // easyRankingLabel
            // 
            this.easyRankingLabel.AutoSize = true;
            this.easyRankingLabel.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easyRankingLabel.Location = new System.Drawing.Point(201, 21);
            this.easyRankingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.easyRankingLabel.Name = "easyRankingLabel";
            this.easyRankingLabel.Size = new System.Drawing.Size(240, 40);
            this.easyRankingLabel.TabIndex = 3;
            this.easyRankingLabel.Text = "Easy Ranking";
            // 
            // normalRankingLabel
            // 
            this.normalRankingLabel.AutoSize = true;
            this.normalRankingLabel.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.normalRankingLabel.Location = new System.Drawing.Point(189, 266);
            this.normalRankingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.normalRankingLabel.Name = "normalRankingLabel";
            this.normalRankingLabel.Size = new System.Drawing.Size(278, 40);
            this.normalRankingLabel.TabIndex = 4;
            this.normalRankingLabel.Text = "Normal Ranking";
            // 
            // hardRankingLabel
            // 
            this.hardRankingLabel.AutoSize = true;
            this.hardRankingLabel.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hardRankingLabel.Location = new System.Drawing.Point(201, 510);
            this.hardRankingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hardRankingLabel.Name = "hardRankingLabel";
            this.hardRankingLabel.Size = new System.Drawing.Size(238, 40);
            this.hardRankingLabel.TabIndex = 5;
            this.hardRankingLabel.Text = "Hard Ranking";
            // 
            // PlaceEasy
            // 
            this.PlaceEasy.HeaderText = "#";
            this.PlaceEasy.MinimumWidth = 6;
            this.PlaceEasy.Name = "PlaceEasy";
            this.PlaceEasy.ReadOnly = true;
            this.PlaceEasy.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // NameEasy
            // 
            this.NameEasy.HeaderText = "Name";
            this.NameEasy.MinimumWidth = 6;
            this.NameEasy.Name = "NameEasy";
            this.NameEasy.ReadOnly = true;
            this.NameEasy.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // TimeEasy
            // 
            this.TimeEasy.HeaderText = "Best Time";
            this.TimeEasy.MinimumWidth = 6;
            this.TimeEasy.Name = "TimeEasy";
            this.TimeEasy.ReadOnly = true;
            this.TimeEasy.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ScoreEasy
            // 
            this.ScoreEasy.HeaderText = "Best Score";
            this.ScoreEasy.MinimumWidth = 6;
            this.ScoreEasy.Name = "ScoreEasy";
            this.ScoreEasy.ReadOnly = true;
            this.ScoreEasy.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PlaceNormal
            // 
            this.PlaceNormal.HeaderText = "#";
            this.PlaceNormal.MinimumWidth = 6;
            this.PlaceNormal.Name = "PlaceNormal";
            this.PlaceNormal.ReadOnly = true;
            this.PlaceNormal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // NameNormal
            // 
            this.NameNormal.HeaderText = "Name";
            this.NameNormal.MinimumWidth = 6;
            this.NameNormal.Name = "NameNormal";
            this.NameNormal.ReadOnly = true;
            this.NameNormal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // TimeNormal
            // 
            this.TimeNormal.HeaderText = "Best Time";
            this.TimeNormal.MinimumWidth = 6;
            this.TimeNormal.Name = "TimeNormal";
            this.TimeNormal.ReadOnly = true;
            this.TimeNormal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ScoreNormal
            // 
            this.ScoreNormal.HeaderText = "Best Score";
            this.ScoreNormal.MinimumWidth = 6;
            this.ScoreNormal.Name = "ScoreNormal";
            this.ScoreNormal.ReadOnly = true;
            this.ScoreNormal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // PlaceHard
            // 
            this.PlaceHard.HeaderText = "#";
            this.PlaceHard.MinimumWidth = 6;
            this.PlaceHard.Name = "PlaceHard";
            this.PlaceHard.ReadOnly = true;
            this.PlaceHard.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // NameHard
            // 
            this.NameHard.HeaderText = "Name";
            this.NameHard.MinimumWidth = 6;
            this.NameHard.Name = "NameHard";
            this.NameHard.ReadOnly = true;
            this.NameHard.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // TimeHard
            // 
            this.TimeHard.HeaderText = "Best Time";
            this.TimeHard.MinimumWidth = 6;
            this.TimeHard.Name = "TimeHard";
            this.TimeHard.ReadOnly = true;
            this.TimeHard.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ScoreHard
            // 
            this.ScoreHard.HeaderText = "Best Score";
            this.ScoreHard.MinimumWidth = 6;
            this.ScoreHard.Name = "ScoreHard";
            this.ScoreHard.ReadOnly = true;
            this.ScoreHard.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // GUIRank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 754);
            this.Controls.Add(this.easyRankingLabel);
            this.Controls.Add(this.easyRankingTable);
            this.Controls.Add(this.normalRankingLabel);
            this.Controls.Add(this.normalRankingTable);
            this.Controls.Add(this.hardRankingLabel);
            this.Controls.Add(this.hardRankingTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GUIRank";
            this.Text = "Pokémon Memory Rank";
            ((System.ComponentModel.ISupportInitialize)(this.easyRankingTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalRankingTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hardRankingTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView easyRankingTable;
        private System.Windows.Forms.DataGridView normalRankingTable;
        private System.Windows.Forms.DataGridView hardRankingTable;
        private System.Windows.Forms.Label easyRankingLabel;
        private System.Windows.Forms.Label normalRankingLabel;
        private System.Windows.Forms.Label hardRankingLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaceEasy;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameEasy;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeEasy;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreEasy;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaceNormal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameNormal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeNormal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreNormal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaceHard;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameHard;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeHard;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreHard;
    }
}