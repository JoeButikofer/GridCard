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
            this.listBoxDeck = new System.Windows.Forms.ListBox();
            this.listBoxCards = new System.Windows.Forms.ListBox();
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
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(334, 572);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Annuler";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // listBoxDeck
            // 
            this.listBoxDeck.FormattingEnabled = true;
            this.listBoxDeck.Location = new System.Drawing.Point(735, 38);
            this.listBoxDeck.Name = "listBoxDeck";
            this.listBoxDeck.Size = new System.Drawing.Size(313, 511);
            this.listBoxDeck.TabIndex = 2;
            // 
            // listBoxCards
            // 
            this.listBoxCards.FormattingEnabled = true;
            this.listBoxCards.Location = new System.Drawing.Point(64, 38);
            this.listBoxCards.Name = "listBoxCards";
            this.listBoxCards.Size = new System.Drawing.Size(624, 511);
            this.listBoxCards.TabIndex = 3;
            // 
            // DeckCustomization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 614);
            this.Controls.Add(this.listBoxCards);
            this.Controls.Add(this.listBoxDeck);
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
        private System.Windows.Forms.ListBox listBoxDeck;
        private System.Windows.Forms.ListBox listBoxCards;
    }
}