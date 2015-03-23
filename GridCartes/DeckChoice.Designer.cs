namespace GridCartes
{
    partial class DeckChoice
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
            this.listBoxDeckChoice = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxDeckChoice
            // 
            this.listBoxDeckChoice.FormattingEnabled = true;
            this.listBoxDeckChoice.Location = new System.Drawing.Point(149, 29);
            this.listBoxDeckChoice.Name = "listBoxDeckChoice";
            this.listBoxDeckChoice.Size = new System.Drawing.Size(262, 186);
            this.listBoxDeckChoice.TabIndex = 0;
            // 
            // DeckChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 350);
            this.Controls.Add(this.listBoxDeckChoice);
            this.Name = "DeckChoice";
            this.Text = "DeckChoice";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDeckChoice;
    }
}