namespace JCDecaux_Client_WebAPP
{
    partial class Form1
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
            this.ville = new System.Windows.Forms.TextBox();
            this.titre = new System.Windows.Forms.Label();
            this.contract = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dispo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ville
            // 
            this.ville.Location = new System.Drawing.Point(299, 129);
            this.ville.Name = "ville";
            this.ville.Size = new System.Drawing.Size(427, 26);
            this.ville.TabIndex = 0;
            // 
            // titre
            // 
            this.titre.AutoSize = true;
            this.titre.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titre.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.titre.Location = new System.Drawing.Point(173, 29);
            this.titre.Name = "titre";
            this.titre.Size = new System.Drawing.Size(454, 60);
            this.titre.TabIndex = 1;
            this.titre.Text = "Client App JCDecaux";
            this.titre.Click += new System.EventHandler(this.label1_Click);
            // 
            // contract
            // 
            this.contract.AutoSize = true;
            this.contract.Location = new System.Drawing.Point(113, 132);
            this.contract.Name = "contract";
            this.contract.Size = new System.Drawing.Size(105, 20);
            this.contract.TabIndex = 2;
            this.contract.Text = "Contrat (Ville)";
            this.contract.Click += new System.EventHandler(this.label2_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.searchButton.Location = new System.Drawing.Point(299, 203);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(146, 41);
            this.searchButton.TabIndex = 5;
            this.searchButton.Text = "Chercher";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(39, 317);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(376, 26);
            this.result.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Point d\'accès";
            // 
            // dispo
            // 
            this.dispo.Location = new System.Drawing.Point(449, 317);
            this.dispo.Name = "dispo";
            this.dispo.Size = new System.Drawing.Size(208, 26);
            this.dispo.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Vélos disponibles";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(698, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 33);
            this.button1.TabIndex = 10;
            this.button1.Text = "Autres";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 662);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dispo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.result);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.contract);
            this.Controls.Add(this.titre);
            this.Controls.Add(this.ville);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.getNextPA);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ville;
        private System.Windows.Forms.Label titre;
        private System.Windows.Forms.Label contract;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dispo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

