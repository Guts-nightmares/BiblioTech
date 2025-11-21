// ====================================================================
// Projet: BiblioTech - Système de gestion de bibliothèque
// Auteurs: Samuel et Bertrand
// Date: 11/16/2025
// Description: Formulaire de connexion pour l'authentification des utilisateurs
// ====================================================================

using System;
using System.Windows.Forms;

namespace BiblioTech
{
    /// <summary>
    /// Formulaire de connexion permettant l'authentification des utilisateurs
    /// </summary>
    public partial class LoginForm : Form
    {
        private DatabaseService dbService;
        public Utilisateur UtilisateurConnecte { get; private set; }

        /// <summary>
        /// Constructeur du formulaire de connexion
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();
            dbService = new DatabaseService("bibliotech.db");
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton de connexion
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string motDePasse = txtMotDePasse.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(motDePasse))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UtilisateurConnecte = dbService.Authentifier(email, motDePasse);

            if (UtilisateurConnecte != null)
            {
                MessageBox.Show($"Bienvenue {UtilisateurConnecte.Nom} !", "Connexion réussie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Email ou mot de passe incorrect.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton d'inscription
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnInscription_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Inscription réussie ! Vous pouvez maintenant vous connecter.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton quitter
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
