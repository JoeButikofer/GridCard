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
            this.SuspendLayout();
            // 
            // btn_Apply
            // 
            this.btn_Apply.Location = new System.Drawing.Point(415, 572);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(75, 23);
            this.btn_Apply.TabIndex = 0;
            this.btn_Apply.Text = "Appliquer";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(334, 572);
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
            this.listViewCards.Location = new System.Drawing.Point(83, 38);
            this.listViewCards.Name = "listViewCards";
            this.listViewCards.Size = new System.Drawing.Size(619, 511);
            this.listViewCards.TabIndex = 4;
            this.listViewCards.UseCompatibleStateImageBehavior = false;
            this.listViewCards.ItemActivate += new System.EventHandler(this.listViewCards_ItemActivate);
            // 
            // listViewDeck
            // 
            this.listViewDeck.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewDeck.Location = new System.Drawing.Point(718, 38);
            this.listViewDeck.Name = "listViewDeck";
            this.listViewDeck.Size = new System.Drawing.Size(329, 511);
            this.listViewDeck.TabIndex = 5;
            this.listViewDeck.UseCompatibleStateImageBehavior = false;
            this.listViewDeck.ItemActivate += new System.EventHandler(this.listViewDeck_ItemActivate);
            // 
            // DeckCustomization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 614);
            this.Controls.Add(this.listViewDeck);
            this.Controls.Add(this.listViewCards);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Apply);
            this.Name = "DeckCustomization";
            this.Text = "DeckCustomization";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeckCustomization_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Apply;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ListView listViewCards;
        private System.Windows.Forms.ListView listViewDeck;
    }
}