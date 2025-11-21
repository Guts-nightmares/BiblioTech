namespace BiblioTech
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.listBoxUtilisateurs = new System.Windows.Forms.ListBox();
            this.btnPromouvoir = new System.Windows.Forms.Button();
            this.btnRetrograder = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnActualiser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitre
            //
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(230, 20);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(240, 24);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Gestion des utilisateurs";
            //
            // listBoxUtilisateurs
            //
            this.listBoxUtilisateurs.FormattingEnabled = true;
            this.listBoxUtilisateurs.HorizontalScrollbar = true;
            this.listBoxUtilisateurs.Location = new System.Drawing.Point(30, 60);
            this.listBoxUtilisateurs.Name = "listBoxUtilisateurs";
            this.listBoxUtilisateurs.Size = new System.Drawing.Size(640, 290);
            this.listBoxUtilisateurs.TabIndex = 1;
            //
            // btnPromouvoir
            //
            this.btnPromouvoir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnPromouvoir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPromouvoir.ForeColor = System.Drawing.Color.White;
            this.btnPromouvoir.Location = new System.Drawing.Point(30, 370);
            this.btnPromouvoir.Name = "btnPromouvoir";
            this.btnPromouvoir.Size = new System.Drawing.Size(150, 35);
            this.btnPromouvoir.TabIndex = 2;
            this.btnPromouvoir.Text = "Promouvoir Admin";
            this.btnPromouvoir.UseVisualStyleBackColor = false;
            this.btnPromouvoir.Click += new System.EventHandler(this.btnPromouvoir_Click);
            //
            // btnRetrograder
            //
            this.btnRetrograder.Location = new System.Drawing.Point(195, 370);
            this.btnRetrograder.Name = "btnRetrograder";
            this.btnRetrograder.Size = new System.Drawing.Size(150, 35);
            this.btnRetrograder.TabIndex = 3;
            this.btnRetrograder.Text = "Rétrograder Utilisateur";
            this.btnRetrograder.UseVisualStyleBackColor = true;
            this.btnRetrograder.Click += new System.EventHandler(this.btnRetrograder_Click);
            //
            // btnSupprimer
            //
            this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(360, 370);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(150, 35);
            this.btnSupprimer.TabIndex = 4;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            //
            // btnActualiser
            //
            this.btnActualiser.Location = new System.Drawing.Point(520, 370);
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.Size = new System.Drawing.Size(150, 35);
            this.btnActualiser.TabIndex = 5;
            this.btnActualiser.Text = "Actualiser";
            this.btnActualiser.UseVisualStyleBackColor = true;
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);
            //
            // AdminForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 430);
            this.Controls.Add(this.btnActualiser);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnRetrograder);
            this.Controls.Add(this.btnPromouvoir);
            this.Controls.Add(this.listBoxUtilisateurs);
            this.Controls.Add(this.lblTitre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Administration - BiblioTech";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.ListBox listBoxUtilisateurs;
        private System.Windows.Forms.Button btnPromouvoir;
        private System.Windows.Forms.Button btnRetrograder;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnActualiser;
    }
}
