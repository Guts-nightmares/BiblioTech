// ====================================================================
// Projet: BiblioTech - Système de gestion de bibliothèque
// Auteurs: Samuel et Bertrand
// Date: 11/16/2025
// Description: Formulaire d'administration permettant de gérer les utilisateurs
//              (promotion, rétrogradation, suppression)
// ====================================================================

using System;
using System.Windows.Forms;

namespace BiblioTech
{
    /// <summary>
    /// Formulaire d'administration pour la gestion des utilisateurs
    /// Permet de promouvoir, rétrograder et supprimer des utilisateurs
    /// </summary>
    public partial class AdminForm : Form
    {
        private DatabaseService dbService;

        /// <summary>
        /// Initialise une nouvelle instance du formulaire d'administration
        /// </summary>
        /// <param name="db">Service de base de données</param>
        public AdminForm(DatabaseService db)
        {
            InitializeComponent();
            dbService = db;
            ChargerUtilisateurs();
        }

        /// <summary>
        /// Charge la liste de tous les utilisateurs dans la listbox
        /// </summary>
        private void ChargerUtilisateurs()
        {
            listBoxUtilisateurs.Items.Clear();
            var utilisateurs = dbService.LireTousLesUtilisateurs();

            foreach (var user in utilisateurs)
            {
                string role = user.Role == RoleUtilisateur.Admin ? "Admin" : "Utilisateur";
                listBoxUtilisateurs.Items.Add($"{user.Nom} ({user.Email}) - {role} [ID: {user.IdUtilisateur}]");
            }
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton Promouvoir
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnPromouvoir_Click(object sender, EventArgs e)
        {
            if (listBoxUtilisateurs.SelectedIndex < 0)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var utilisateurs = dbService.LireTousLesUtilisateurs();
            var selectedUser = utilisateurs[listBoxUtilisateurs.SelectedIndex];

            if (selectedUser.Role == RoleUtilisateur.Admin)
            {
                MessageBox.Show("Cet utilisateur est déjà administrateur.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Voulez-vous promouvoir {selectedUser.Nom} au rôle d'administrateur ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                bool success = dbService.ChangerRole(selectedUser.IdUtilisateur, RoleUtilisateur.Admin);
                if (success)
                {
                    MessageBox.Show("L'utilisateur a été promu administrateur.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerUtilisateurs();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la promotion.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton Rétrograder
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnRetrograder_Click(object sender, EventArgs e)
        {
            if (listBoxUtilisateurs.SelectedIndex < 0)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var utilisateurs = dbService.LireTousLesUtilisateurs();
            var selectedUser = utilisateurs[listBoxUtilisateurs.SelectedIndex];

            if (selectedUser.Role == RoleUtilisateur.Utilisateur)
            {
                MessageBox.Show("Cet utilisateur est déjà un utilisateur standard.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Voulez-vous rétrograder {selectedUser.Nom} au rôle d'utilisateur standard ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                bool success = dbService.ChangerRole(selectedUser.IdUtilisateur, RoleUtilisateur.Utilisateur);
                if (success)
                {
                    MessageBox.Show("L'utilisateur a été rétrogradé.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerUtilisateurs();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la rétrogradation.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton Supprimer
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (listBoxUtilisateurs.SelectedIndex < 0)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var utilisateurs = dbService.LireTousLesUtilisateurs();
            var selectedUser = utilisateurs[listBoxUtilisateurs.SelectedIndex];

            DialogResult result = MessageBox.Show(
                $"Voulez-vous vraiment supprimer l'utilisateur {selectedUser.Nom} ?\nCette action est irréversible.",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                bool success = dbService.SupprimerUtilisateur(selectedUser.IdUtilisateur);
                if (success)
                {
                    MessageBox.Show("L'utilisateur a été supprimé.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerUtilisateurs();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton Actualiser
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnActualiser_Click(object sender, EventArgs e)
        {
            ChargerUtilisateurs();
            MessageBox.Show("Liste des utilisateurs actualisée.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
