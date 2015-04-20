namespace GridCartes
{
    partial class GameBoard
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
            this.tableLayoutGame = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listViewHandCards = new System.Windows.Forms.ListView();
            this.lblMyScore = new System.Windows.Forms.Label();
            this.lblHisScore = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.tableLayoutGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutGame
            // 
            this.tableLayoutGame.ColumnCount = 3;
            this.tableLayoutGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutGame.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutGame.Controls.Add(this.listViewHandCards, 1, 2);
            this.tableLayoutGame.Controls.Add(this.lblMyScore, 0, 1);
            this.tableLayoutGame.Controls.Add(this.lblHisScore, 2, 1);
            this.tableLayoutGame.Controls.Add(this.lblTurn, 1, 0);
            this.tableLayoutGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutGame.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutGame.Name = "tableLayoutGame";
            this.tableLayoutGame.RowCount = 3;
            this.tableLayoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutGame.Size = new System.Drawing.Size(690, 489);
            this.tableLayoutGame.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(141, 51);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(408, 287);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanel1_MouseClick);
            // 
            // listViewHandCards
            // 
            this.listViewHandCards.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewHandCards.Location = new System.Drawing.Point(141, 344);
            this.listViewHandCards.Name = "listViewHandCards";
            this.listViewHandCards.Size = new System.Drawing.Size(408, 142);
            this.listViewHandCards.TabIndex = 1;
            this.listViewHandCards.UseCompatibleStateImageBehavior = false;
            this.listViewHandCards.ItemActivate += new System.EventHandler(this.listViewHandCards_ItemActivate);
            // 
            // lblMyScore
            // 
            this.lblMyScore.AutoSize = true;
            this.lblMyScore.Location = new System.Drawing.Point(3, 48);
            this.lblMyScore.Name = "lblMyScore";
            this.lblMyScore.Size = new System.Drawing.Size(65, 13);
            this.lblMyScore.TabIndex = 2;
            this.lblMyScore.Text = "My score : 0";
            // 
            // lblHisScore
            // 
            this.lblHisScore.AutoSize = true;
            this.lblHisScore.Location = new System.Drawing.Point(555, 48);
            this.lblHisScore.Name = "lblHisScore";
            this.lblHisScore.Size = new System.Drawing.Size(66, 13);
            this.lblHisScore.TabIndex = 3;
            this.lblHisScore.Text = "His score : 0";
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTurn.Location = new System.Drawing.Point(141, 0);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(29, 13);
            this.lblTurn.TabIndex = 4;
            this.lblTurn.Text = "Turn";
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 489);
            this.Controls.Add(this.tableLayoutGame);
            this.Name = "GameBoard";
            this.Text = "GameBoard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameBoard_FormClosed);
            this.tableLayoutGame.ResumeLayout(false);
            this.tableLayoutGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutGame;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listViewHandCards;
        private System.Windows.Forms.Label lblMyScore;
        private System.Windows.Forms.Label lblHisScore;
        private System.Windows.Forms.Label lblTurn;
    }
}