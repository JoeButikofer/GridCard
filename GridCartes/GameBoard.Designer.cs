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
            this.listViewHandCards = new System.Windows.Forms.ListView();
            this.lblTurn = new System.Windows.Forms.Label();
            this.btnBlock = new System.Windows.Forms.Button();
            this.btnDestroy = new System.Windows.Forms.Button();
            this.lblMyScore = new System.Windows.Forms.Label();
            this.lblHisScore = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.listBoxChat = new System.Windows.Forms.ListBox();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutGame.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutGame
            // 
            this.tableLayoutGame.ColumnCount = 3;
            this.tableLayoutGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutGame.Controls.Add(this.listViewHandCards, 1, 2);
            this.tableLayoutGame.Controls.Add(this.lblTurn, 1, 0);
            this.tableLayoutGame.Controls.Add(this.btnBlock, 0, 2);
            this.tableLayoutGame.Controls.Add(this.btnDestroy, 2, 2);
            this.tableLayoutGame.Controls.Add(this.lblMyScore, 0, 0);
            this.tableLayoutGame.Controls.Add(this.lblHisScore, 2, 0);
            this.tableLayoutGame.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutGame.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutGame.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutGame.Name = "tableLayoutGame";
            this.tableLayoutGame.RowCount = 3;
            this.tableLayoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.80645F));
            this.tableLayoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.35484F));
            this.tableLayoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutGame.Size = new System.Drawing.Size(822, 620);
            this.tableLayoutGame.TabIndex = 0;
            // 
            // listViewHandCards
            // 
            this.listViewHandCards.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewHandCards.Location = new System.Drawing.Point(167, 471);
            this.listViewHandCards.Name = "listViewHandCards";
            this.listViewHandCards.Size = new System.Drawing.Size(487, 142);
            this.listViewHandCards.TabIndex = 1;
            this.listViewHandCards.UseCompatibleStateImageBehavior = false;
            this.listViewHandCards.ItemActivate += new System.EventHandler(this.listViewHandCards_ItemActivate);
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTurn.Location = new System.Drawing.Point(167, 0);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(29, 13);
            this.lblTurn.TabIndex = 4;
            this.lblTurn.Text = "Tour";
            // 
            // btnBlock
            // 
            this.btnBlock.Location = new System.Drawing.Point(3, 471);
            this.btnBlock.Name = "btnBlock";
            this.btnBlock.Size = new System.Drawing.Size(132, 23);
            this.btnBlock.TabIndex = 5;
            this.btnBlock.Text = "Bloque une case";
            this.btnBlock.UseVisualStyleBackColor = true;
            this.btnBlock.Click += new System.EventHandler(this.btnBlock_Click);
            // 
            // btnDestroy
            // 
            this.btnDestroy.Location = new System.Drawing.Point(660, 471);
            this.btnDestroy.Name = "btnDestroy";
            this.btnDestroy.Size = new System.Drawing.Size(132, 23);
            this.btnDestroy.TabIndex = 6;
            this.btnDestroy.Text = "Détruire une carte";
            this.btnDestroy.UseVisualStyleBackColor = true;
            this.btnDestroy.Click += new System.EventHandler(this.btnDestroy_Click);
            // 
            // lblMyScore
            // 
            this.lblMyScore.AutoSize = true;
            this.lblMyScore.Location = new System.Drawing.Point(3, 0);
            this.lblMyScore.Name = "lblMyScore";
            this.lblMyScore.Size = new System.Drawing.Size(72, 13);
            this.lblMyScore.TabIndex = 2;
            this.lblMyScore.Text = "Mon score : 0";
            // 
            // lblHisScore
            // 
            this.lblHisScore.AutoSize = true;
            this.lblHisScore.Location = new System.Drawing.Point(660, 0);
            this.lblHisScore.Name = "lblHisScore";
            this.lblHisScore.Size = new System.Drawing.Size(70, 13);
            this.lblHisScore.TabIndex = 3;
            this.lblHisScore.Text = "Son score : 0";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.listBoxChat);
            this.flowLayoutPanel1.Controls.Add(this.textBoxChat);
            this.flowLayoutPanel1.Controls.Add(this.btnSend);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 64);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(132, 287);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // listBoxChat
            // 
            this.listBoxChat.FormattingEnabled = true;
            this.listBoxChat.Location = new System.Drawing.Point(3, 3);
            this.listBoxChat.Name = "listBoxChat";
            this.listBoxChat.Size = new System.Drawing.Size(132, 212);
            this.listBoxChat.TabIndex = 7;
            // 
            // textBoxChat
            // 
            this.textBoxChat.Location = new System.Drawing.Point(3, 221);
            this.textBoxChat.MaxLength = 200;
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.Size = new System.Drawing.Size(129, 20);
            this.textBoxChat.TabIndex = 8;
            this.textBoxChat.Text = "Message...";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(3, 247);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "Envoyer";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(264, 64);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(100, 3, 3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(280, 400);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 620);
            this.Controls.Add(this.tableLayoutGame);
            this.Name = "GameBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grid Cards";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameBoard_FormClosed);
            this.tableLayoutGame.ResumeLayout(false);
            this.tableLayoutGame.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutGame;
        private System.Windows.Forms.ListView listViewHandCards;
        private System.Windows.Forms.Label lblMyScore;
        private System.Windows.Forms.Label lblHisScore;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Button btnBlock;
        private System.Windows.Forms.Button btnDestroy;
        private System.Windows.Forms.ListBox listBoxChat;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}