namespace GridCartes
{
    partial class Accueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_Joueurs = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textFields_Pseudo = new System.Windows.Forms.TextBox();
            this.btn_Create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grid Cards";
            // 
            // listBox_Joueurs
            // 
            this.listBox_Joueurs.FormattingEnabled = true;
            this.listBox_Joueurs.Location = new System.Drawing.Point(77, 94);
            this.listBox_Joueurs.Name = "listBox_Joueurs";
            this.listBox_Joueurs.Size = new System.Drawing.Size(334, 121);
            this.listBox_Joueurs.TabIndex = 1;
            this.listBox_Joueurs.DoubleClick += new System.EventHandler(this.listBox_Joueurs_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pseudo : ";
            // 
            // textFields_Pseudo
            // 
            this.textFields_Pseudo.Location = new System.Drawing.Point(156, 255);
            this.textFields_Pseudo.Name = "textFields_Pseudo";
            this.textFields_Pseudo.Size = new System.Drawing.Size(100, 20);
            this.textFields_Pseudo.TabIndex = 3;
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(313, 253);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(75, 23);
            this.btn_Create.TabIndex = 4;
            this.btn_Create.Text = "Créer";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 411);
            this.Controls.Add(this.btn_Create);
            this.Controls.Add(this.textFields_Pseudo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox_Joueurs);
            this.Controls.Add(this.label1);
            this.Name = "Accueil";
            this.Text = "Grid Crads";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_Joueurs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textFields_Pseudo;
        private System.Windows.Forms.Button btn_Create;
    }
}

