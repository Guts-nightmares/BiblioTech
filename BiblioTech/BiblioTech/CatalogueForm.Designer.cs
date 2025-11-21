namespace BiblioTech
{
    partial class CatalogueForm
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
            this.listBoxCatalogue = new System.Windows.Forms.ListBox();
            this.lblTri = new System.Windows.Forms.Label();
            this.cmbTri = new System.Windows.Forms.ComboBox();
            this.lblRecherche = new System.Windows.Forms.Label();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // listBoxCatalogue
            //
            this.listBoxCatalogue.FormattingEnabled = true;
            this.listBoxCatalogue.HorizontalScrollbar = true;
            this.listBoxCatalogue.Location = new System.Drawing.Point(30, 70);
            this.listBoxCatalogue.Name = "listBoxCatalogue";
            this.listBoxCatalogue.Size = new System.Drawing.Size(740, 355);
            this.listBoxCatalogue.TabIndex = 0;
            //
            // lblTri
            //
            this.lblTri.AutoSize = true;
            this.lblTri.Location = new System.Drawing.Point(30, 30);
            this.lblTri.Name = "lblTri";
            this.lblTri.Size = new System.Drawing.Size(50, 13);
            this.lblTri.TabIndex = 1;
            this.lblTri.Text = "Trier par :";
            //
            // cmbTri
            //
            this.cmbTri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTri.FormattingEnabled = true;
            this.cmbTri.Location = new System.Drawing.Point(90, 27);
            this.cmbTri.Name = "cmbTri";
            this.cmbTri.Size = new System.Drawing.Size(150, 21);
            this.cmbTri.TabIndex = 2;
            this.cmbTri.SelectedIndexChanged += new System.EventHandler(this.cmbTri_SelectedIndexChanged);
            //
            // lblRecherche
            //
            this.lblRecherche.AutoSize = true;
            this.lblRecherche.Location = new System.Drawing.Point(320, 30);
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(66, 13);
            this.lblRecherche.TabIndex = 3;
            this.lblRecherche.Text = "Rechercher :";
            //
            // txtRecherche
            //
            this.txtRecherche.Location = new System.Drawing.Point(390, 27);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(300, 20);
            this.txtRecherche.TabIndex = 4;
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);
            //
            // CatalogueForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.lblRecherche);
            this.Controls.Add(this.cmbTri);
            this.Controls.Add(this.lblTri);
            this.Controls.Add(this.listBoxCatalogue);
            this.Name = "CatalogueForm";
            this.Text = "Catalogue des Livres";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCatalogue;
        private System.Windows.Forms.Label lblTri;
        private System.Windows.Forms.ComboBox cmbTri;
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.TextBox txtRecherche;
    }
}