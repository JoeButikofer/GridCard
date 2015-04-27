namespace GridCartes
{
    partial class VictoryScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.pictureBoxNewCard = new System.Windows.Forms.PictureBox();
            this.lblCardMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewCard)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Freestyle Script", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "VICTOIRE !!!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bien joué !!!";
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(53, 227);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(166, 23);
            this.btnMenu.TabIndex = 5;
            this.btnMenu.Text = "Retourner au menu principal";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // pictureBoxNewCard
            // 
            this.pictureBoxNewCard.Location = new System.Drawing.Point(78, 127);
            this.pictureBoxNewCard.Name = "pictureBoxNewCard";
            this.pictureBoxNewCard.Size = new System.Drawing.Size(113, 97);
            this.pictureBoxNewCard.TabIndex = 6;
            this.pictureBoxNewCard.TabStop = false;
            // 
            // lblCardMessage
            // 
            this.lblCardMessage.AutoSize = true;
            this.lblCardMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardMessage.Location = new System.Drawing.Point(29, 104);
            this.lblCardMessage.Name = "lblCardMessage";
            this.lblCardMessage.Size = new System.Drawing.Size(240, 17);
            this.lblCardMessage.TabIndex = 7;
            this.lblCardMessage.Text = "Vou avez gagné une nouvelle carte :";
            // 
            // VictoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblCardMessage);
            this.Controls.Add(this.pictureBoxNewCard);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "VictoryScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grid Cards";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VictoryScreen_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.PictureBox pictureBoxNewCard;
        private System.Windows.Forms.Label lblCardMessage;
    }
}