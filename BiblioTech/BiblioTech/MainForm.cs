// ====================================================================
// Projet: BiblioTech - Système de gestion de bibliothèque
// Auteurs: Samuel et Bertrand
// Date: 11/16/2025
// Description: Formulaire principal de l'application permettant d'accéder
//              aux fonctionnalités principales (catalogue, emprunts, administration)
// ====================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiblioTech
{
    /// <summary>
    /// Formulaire principal de l'application BiblioTech
    /// Point d'entrée pour accéder au catalogue, aux emprunts et à l'administration
    /// </summary>
    public partial class MainForm : Form
    {
        private DatabaseService dbService;
        private Utilisateur utilisateurConnecte;

        /// <summary>
        /// Initialise une nouvelle instance du formulaire principal
        /// </summary>
        /// <param name="utilisateur">L'utilisateur actuellement connecté</param>
        public MainForm(Utilisateur utilisateur)
        {
            InitializeComponent();

            utilisateurConnecte = utilisateur;
            dbService = new DatabaseService("bibliotech.db");

            ConfigurerPermissions();
        }

        /// <summary>
        /// Configure les permissions et l'affichage selon le rôle de l'utilisateur connecté
        /// </summary>
        private void ConfigurerPermissions()
        {
            // Mettre à jour le titre avec le nom de l'utilisateur
            this.Text = $"BiblioTech - Bienvenue {utilisateurConnecte.Nom} ({(utilisateurConnecte.Role == RoleUtilisateur.Admin ? "Administrateur" : "Utilisateur")})";

            // Les utilisateurs normaux ne peuvent pas ajouter de livres
            if (utilisateurConnecte.Role != RoleUtilisateur.Admin)
            {
                btnAjouterLivre.Enabled = false;
                btnAdmin.Visible = false;
            }
            else
            {
                btnAdmin.Visible = true;
            }
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton Catalogue
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnCatalogue_Click(object sender, EventArgs e)
        {
            CatalogueForm catalog = new CatalogueForm(dbService);
            catalog.ShowDialog();
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton Ajouter Livre
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnAjouterLivre_Click(object sender, EventArgs e)
        {
            AddBookForm addBook = new AddBookForm(dbService);
            addBook.ShowDialog();
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton Emprunts
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnEmprunts_Click(object sender, EventArgs e)
        {
            EmpruntsForm empruntsForm = new EmpruntsForm(utilisateurConnecte, dbService);
            empruntsForm.ShowDialog();
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton Administration
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm(dbService);
            adminForm.ShowDialog();
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton Déconnexion
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Voulez-vous vraiment vous déconnecter ?",
                "Déconnexion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
