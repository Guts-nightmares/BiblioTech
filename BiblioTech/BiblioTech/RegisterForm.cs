// ====================================================================
// Projet: BiblioTech - Système de gestion de bibliothèque
// Auteurs: Samuel et Bertrand
// Date: 11/16/2025
// Description: Formulaire d'inscription pour créer un nouveau compte utilisateur
// ====================================================================

using System;
using System.Windows.Forms;

namespace BiblioTech
{
    /// <summary>
    /// Formulaire d'inscription permettant de créer un nouveau compte utilisateur
    /// </summary>
    public partial class RegisterForm : Form
    {
        private DatabaseService dbService;

        /// <summary>
        /// Constructeur du formulaire d'inscription
        /// </summary>
        public RegisterForm()
        {
            InitializeComponent();
            dbService = new DatabaseService("bibliotech.db");
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton d'inscription
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnInscrire_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string email = txtEmail.Text.Trim();
            string motDePasse = txtMotDePasse.Text;
            string confirmation = txtConfirmation.Text;

            // Validation
            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(motDePasse) || string.IsNullOrEmpty(confirmation))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Veuillez entrer un email valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (motDePasse.Length < 6)
            {
                MessageBox.Show("Le mot de passe doit contenir au moins 6 caractères.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (motDePasse != confirmation)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Inscription
            bool success = dbService.InscrireUtilisateur(nom, email, motDePasse);

            if (success)
            {
                MessageBox.Show("Inscription réussie !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cet email est déjà utilisé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton annuler
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
