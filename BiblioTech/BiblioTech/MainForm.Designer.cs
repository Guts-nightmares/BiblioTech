namespace BiblioTech
{
    partial class MainForm
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
            this.btnCatalogue = new System.Windows.Forms.Button();
            this.btnAjouterLivre = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnDeconnexion = new System.Windows.Forms.Button();
            this.btnEmprunts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCatalogue
            // 
            this.btnCatalogue.Location = new System.Drawing.Point(171, 128);
            this.btnCatalogue.Name = "btnCatalogue";
            this.btnCatalogue.Size = new System.Drawing.Size(75, 23);
            this.btnCatalogue.TabIndex = 0;
            this.btnCatalogue.Text = "Catalogue";
            this.btnCatalogue.UseVisualStyleBackColor = true;
            this.btnCatalogue.Click += new System.EventHandler(this.btnCatalogue_Click);
            // 
            // btnAjouterLivre
            // 
            this.btnAjouterLivre.Location = new System.Drawing.Point(280, 128);
            this.btnAjouterLivre.Name = "btnAjouterLivre";
            this.btnAjouterLivre.Size = new System.Drawing.Size(75, 23);
            this.btnAjouterLivre.TabIndex = 0;
            this.btnAjouterLivre.Text = "AjouterLivre";
            this.btnAjouterLivre.UseVisualStyleBackColor = true;
            this.btnAjouterLivre.Click += new System.EventHandler(this.btnAjouterLivre_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(490, 128);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(100, 23);
            this.btnAdmin.TabIndex = 0;
            this.btnAdmin.Text = "Administration";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnDeconnexion
            // 
            this.btnDeconnexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeconnexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeconnexion.ForeColor = System.Drawing.Color.White;
            this.btnDeconnexion.Location = new System.Drawing.Point(650, 20);
            this.btnDeconnexion.Name = "btnDeconnexion";
            this.btnDeconnexion.Size = new System.Drawing.Size(100, 30);
            this.btnDeconnexion.TabIndex = 0;
            this.btnDeconnexion.Text = "Déconnexion";
            this.btnDeconnexion.UseVisualStyleBackColor = false;
            this.btnDeconnexion.Click += new System.EventHandler(this.btnDeconnexion_Click);
            // 
            // btnEmprunts
            // 
            this.btnEmprunts.Location = new System.Drawing.Point(374, 128);
            this.btnEmprunts.Name = "btnEmprunts";
            this.btnEmprunts.Size = new System.Drawing.Size(100, 23);
            this.btnEmprunts.TabIndex = 0;
            this.btnEmprunts.Text = "Emprunts";
            this.btnEmprunts.UseVisualStyleBackColor = true;
            this.btnEmprunts.Click += new System.EventHandler(this.btnEmprunts_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDeconnexion);
            this.Controls.Add(this.btnEmprunts);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnAjouterLivre);
            this.Controls.Add(this.btnCatalogue);
            this.Name = "MainForm";
            this.Text = "BiblioTech";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCatalogue;
        private System.Windows.Forms.Button btnAjouterLivre;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnDeconnexion;
        private System.Windows.Forms.Button btnEmprunts;
    }
}

