namespace GridCartes
{
    partial class DeckCustomization
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
            this.btn_Apply = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.listViewCards = new System.Windows.Forms.ListView();
            this.listViewDeck = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.textBoxDeckName = new System.Windows.Forms.TextBox();
            this.lbl_NbCards = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Apply
            // 
            this.btn_Apply.Location = new System.Drawing.Point(415, 652);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(75, 23);
            this.btn_Apply.TabIndex = 0;
            this.btn_Apply.Text = "Appliquer";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(334, 652);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Annuler";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // listViewCards
            // 
            this.listViewCards.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewCards.Location = new System.Drawing.Point(83, 118);
            this.listViewCards.Name = "listViewCards";
            this.listViewCards.Size = new System.Drawing.Size(619, 511);
            this.listViewCards.TabIndex = 4;
            this.listViewCards.UseCompatibleStateImageBehavior = false;
            this.listViewCards.ItemActivate += new System.EventHandler(this.listViewCards_ItemActivate);
            // 
            // listViewDeck
            // 
            this.listViewDeck.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewDeck.Location = new System.Drawing.Point(718, 118);
            this.listViewDeck.Name = "listViewDeck";
            this.listViewDeck.Size = new System.Drawing.Size(329, 511);
            this.listViewDeck.TabIndex = 5;
            this.listViewDeck.UseCompatibleStateImageBehavior = false;
            this.listViewDeck.ItemActivate += new System.EventHandler(this.listViewDeck_ItemActivate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cartes disponibles :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(715, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Deck";
            // 
            // btn_Clear
            // 
            this.btn_Clear.Location = new System.Drawing.Point(816, 636);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(150, 23);
            this.btn_Clear.TabIndex = 8;
            this.btn_Clear.Text = "Tous Supprimer";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // textBoxDeckName
            // 
            this.textBoxDeckName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDeckName.Location = new System.Drawing.Point(83, 36);
            this.textBoxDeckName.Name = "textBoxDeckName";
            this.textBoxDeckName.Size = new System.Drawing.Size(100, 38);
            this.textBoxDeckName.TabIndex = 9;
            this.textBoxDeckName.TextChanged += new System.EventHandler(this.textBoxDeckName_TextChanged);
            // 
            // lbl_NbCards
            // 
            this.lbl_NbCards.AutoSize = true;
            this.lbl_NbCards.Location = new System.Drawing.Point(715, 72);
            this.lbl_NbCards.Name = "lbl_NbCards";
            this.lbl_NbCards.Size = new System.Drawing.Size(100, 13);
            this.lbl_NbCards.TabIndex = 10;
            this.lbl_NbCards.Text = "Nombre de cartes : ";
            // 
            // DeckCustomization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 693);
            this.Controls.Add(this.lbl_NbCards);
            this.Controls.Add(this.textBoxDeckName);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewDeck);
            this.Controls.Add(this.listViewCards);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Apply);
            this.Name = "DeckCustomization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DeckCustomization";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeckCustomization_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ListView listViewCards;
        private System.Windows.Forms.ListView listViewDeck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.TextBox textBoxDeckName;
        private System.Windows.Forms.Label lbl_NbCards;
    }
}