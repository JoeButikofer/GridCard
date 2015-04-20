namespace GridCartes
{
    partial class DeckManagement
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
            this.btn_Create = new System.Windows.Forms.Button();
            this.textFields_Deck = new System.Windows.Forms.TextBox();
            this.labelDeck = new System.Windows.Forms.Label();
            this.listBoxDeck = new System.Windows.Forms.ListBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(410, 294);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(75, 23);
            this.btn_Create.TabIndex = 11;
            this.btn_Create.Text = "Créer";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // textFields_Deck
            // 
            this.textFields_Deck.Location = new System.Drawing.Point(253, 296);
            this.textFields_Deck.Name = "textFields_Deck";
            this.textFields_Deck.Size = new System.Drawing.Size(100, 20);
            this.textFields_Deck.TabIndex = 10;
            // 
            // labelDeck
            // 
            this.labelDeck.AutoSize = true;
            this.labelDeck.Location = new System.Drawing.Point(174, 296);
            this.labelDeck.Name = "labelDeck";
            this.labelDeck.Size = new System.Drawing.Size(42, 13);
            this.labelDeck.TabIndex = 9;
            this.labelDeck.Text = "Deck : ";
            // 
            // listBoxDeck
            // 
            this.listBoxDeck.FormattingEnabled = true;
            this.listBoxDeck.Location = new System.Drawing.Point(208, 81);
            this.listBoxDeck.Name = "listBoxDeck";
            this.listBoxDeck.Size = new System.Drawing.Size(262, 186);
            this.listBoxDeck.TabIndex = 8;
            this.listBoxDeck.DoubleClick += new System.EventHandler(this.listBoxDeck_DoubleClick);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(40, 26);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Retour";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // DeckManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 399);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.textFields_Deck);
            this.Controls.Add(this.labelDeck);
            this.Controls.Add(this.listBoxDeck);
            this.Name = "DeckManagement";
            this.Text = "DeckManagement";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeckManagement_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.TextBox textFields_Deck;
        private System.Windows.Forms.Label labelDeck;
        private System.Windows.Forms.ListBox listBoxDeck;
        private System.Windows.Forms.Button btnBack;
    }
}