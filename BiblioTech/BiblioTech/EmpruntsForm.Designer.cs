namespace BiblioTech
{
    partial class EmpruntsForm
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
            this.listBoxEmprunts = new System.Windows.Forms.ListBox();
            this.lblMesEmprunts = new System.Windows.Forms.Label();
            this.lblEmprunter = new System.Windows.Forms.Label();
            this.cmbLivres = new System.Windows.Forms.ComboBox();
            this.btnEmprunter = new System.Windows.Forms.Button();
            this.btnRendre = new System.Windows.Forms.Button();
            this.btnActualiser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxEmprunts
            // 
            this.listBoxEmprunts.FormattingEnabled = true;
            this.listBoxEmprunts.HorizontalScrollbar = true;
            this.listBoxEmprunts.Location = new System.Drawing.Point(30, 115);
            this.listBoxEmprunts.Name = "listBoxEmprunts";
            this.listBoxEmprunts.Size = new System.Drawing.Size(740, 264);
            this.listBoxEmprunts.TabIndex = 0;
            // 
            // lblMesEmprunts
            // 
            this.lblMesEmprunts.AutoSize = true;
            this.lblMesEmprunts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesEmprunts.Location = new System.Drawing.Point(30, 90);
            this.lblMesEmprunts.Name = "lblMesEmprunts";
            this.lblMesEmprunts.Size = new System.Drawing.Size(109, 17);
            this.lblMesEmprunts.TabIndex = 4;
            this.lblMesEmprunts.Text = "Mes emprunts";
            // 
            // lblEmprunter
            // 
            this.lblEmprunter.AutoSize = true;
            this.lblEmprunter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmprunter.Location = new System.Drawing.Point(30, 20);
            this.lblEmprunter.Name = "lblEmprunter";
            this.lblEmprunter.Size = new System.Drawing.Size(142, 17);
            this.lblEmprunter.TabIndex = 1;
            this.lblEmprunter.Text = "Emprunter un livre";
            // 
            // cmbLivres
            // 
            this.cmbLivres.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLivres.FormattingEnabled = true;
            this.cmbLivres.Location = new System.Drawing.Point(30, 45);
            this.cmbLivres.Name = "cmbLivres";
            this.cmbLivres.Size = new System.Drawing.Size(500, 21);
            this.cmbLivres.TabIndex = 2;
            // 
            // btnEmprunter
            // 
            this.btnEmprunter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnEmprunter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmprunter.ForeColor = System.Drawing.Color.White;
            this.btnEmprunter.Location = new System.Drawing.Point(545, 40);
            this.btnEmprunter.Name = "btnEmprunter";
            this.btnEmprunter.Size = new System.Drawing.Size(100, 30);
            this.btnEmprunter.TabIndex = 3;
            this.btnEmprunter.Text = "Emprunter";
            this.btnEmprunter.UseVisualStyleBackColor = false;
            this.btnEmprunter.Click += new System.EventHandler(this.btnEmprunter_Click);
            // 
            // btnRendre
            // 
            this.btnRendre.Location = new System.Drawing.Point(30, 395);
            this.btnRendre.Name = "btnRendre";
            this.btnRendre.Size = new System.Drawing.Size(120, 30);
            this.btnRendre.TabIndex = 5;
            this.btnRendre.Text = "Rendre le livre";
            this.btnRendre.UseVisualStyleBackColor = true;
            this.btnRendre.Click += new System.EventHandler(this.btnRendre_Click);
            // 
            // btnActualiser
            // 
            this.btnActualiser.Location = new System.Drawing.Point(650, 395);
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.Size = new System.Drawing.Size(120, 30);
            this.btnActualiser.TabIndex = 6;
            this.btnActualiser.Text = "Actualiser";
            this.btnActualiser.UseVisualStyleBackColor = true;
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);
            // 
            // EmpruntsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnActualiser);
            this.Controls.Add(this.btnRendre);
            this.Controls.Add(this.lblMesEmprunts);
            this.Controls.Add(this.btnEmprunter);
            this.Controls.Add(this.cmbLivres);
            this.Controls.Add(this.lblEmprunter);
            this.Controls.Add(this.listBoxEmprunts);
            this.Name = "EmpruntsForm";
            this.Text = "Gestion des Emprunts";
            this.Load += new System.EventHandler(this.EmpruntsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxEmprunts;
        private System.Windows.Forms.Label lblMesEmprunts;
        private System.Windows.Forms.Label lblEmprunter;
        private System.Windows.Forms.ComboBox cmbLivres;
        private System.Windows.Forms.Button btnEmprunter;
        private System.Windows.Forms.Button btnRendre;
        private System.Windows.Forms.Button btnActualiser;
    }
}