// ====================================================================
// Projet: BiblioTech - Système de gestion de bibliothèque
// Auteurs: Samuel et Bertrand
// Date: 11/16/2025
// Description: Formulaire de gestion des emprunts permettant d'emprunter
//              et de rendre des livres
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
    /// Formulaire de gestion des emprunts de livres
    /// Permet aux utilisateurs d'emprunter et de rendre des livres
    /// </summary>
    public partial class EmpruntsForm : Form
    {
        private Utilisateur utilisateurConnecte;
        private DatabaseService dbService;
        private List<Livre> livres;
        private List<Emprunt> emprunts;

        /// <summary>
        /// Initialise une nouvelle instance du formulaire des emprunts
        /// </summary>
        /// <param name="utilisateur">Utilisateur actuellement connecté</param>
        /// <param name="db">Service de base de données</param>
        public EmpruntsForm(Utilisateur utilisateur, DatabaseService db)
        {
            InitializeComponent();
            utilisateurConnecte = utilisateur;
            dbService = db;

            ChargerLivres();
            ChargerEmprunts();
        }

        /// <summary>
        /// Charge la liste des livres disponibles dans la combobox
        /// </summary>
        private void ChargerLivres()
        {
            cmbLivres.Items.Clear();
            livres = dbService.LireTousLesLivres();
            emprunts = dbService.LireEmprunts(livres);

            foreach (var livre in livres)
            {
                // Vérifier si le livre est disponible
                bool estEmprunte = emprunts.Any(emp => emp.LivreEmprunte.Id == livre.Id && !emp.EstRendu());
                string statut = estEmprunte ? " [EMPRUNTÉ]" : " [DISPONIBLE]";
                cmbLivres.Items.Add(livre.Titre + statut);
            }

            if (cmbLivres.Items.Count > 0)
                cmbLivres.SelectedIndex = 0;
        }

        /// <summary>
        /// Charge la liste des emprunts de l'utilisateur connecté
        /// </summary>
        private void ChargerEmprunts()
        {
            listBoxEmprunts.Items.Clear();

            if (emprunts == null)
            {
                livres = dbService.LireTousLesLivres();
                emprunts = dbService.LireEmprunts(livres);
            }

            // Afficher seulement les emprunts de l'utilisateur connecté
            var mesEmprunts = emprunts
                .Where(emp => emp.Utilisateur.IdUtilisateur == utilisateurConnecte.IdUtilisateur)
                .ToList();

            foreach (var emprunt in mesEmprunts)
            {
                string statut = emprunt.EstRendu() ? "Rendu le " + emprunt.DateRetour?.ToString("dd/MM/yyyy") : "En cours";
                listBoxEmprunts.Items.Add($"{emprunt.LivreEmprunte.Titre} - Emprunté le {emprunt.DateEmprunt:dd/MM/yyyy} - {statut}");
            }

            if (mesEmprunts.Count == 0)
            {
                listBoxEmprunts.Items.Add("Aucun emprunt pour le moment");
            }
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton Emprunter
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnEmprunter_Click(object sender, EventArgs e)
        {
            if (cmbLivres.SelectedIndex < 0)
            {
                MessageBox.Show("Veuillez sélectionner un livre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var livreSelectionne = livres[cmbLivres.SelectedIndex];

            // Vérifier si le livre est déjà emprunté
            bool estEmprunte = emprunts
                .Any(emp => emp.LivreEmprunte != null
                          && emp.LivreEmprunte.Id == livreSelectionne.Id
                          && !emp.EstRendu());

            if (estEmprunte)
            {
                MessageBox.Show("Ce livre est déjà emprunté.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Créer l'emprunt
            var emprunt = new Emprunt(livreSelectionne, utilisateurConnecte);

            // Sauvegarder dans la base de données
            dbService.SauverEmprunt(emprunt);

            MessageBox.Show($"Le livre '{livreSelectionne.Titre}' a été emprunté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ChargerLivres();
            ChargerEmprunts();
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton Rendre
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnRendre_Click(object sender, EventArgs e)
        {
            if (listBoxEmprunts.SelectedIndex < 0)
            {
                MessageBox.Show("Veuillez sélectionner un emprunt à rendre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var mesEmprunts = emprunts
                .Where(emp => emp.Utilisateur.IdUtilisateur == utilisateurConnecte.IdUtilisateur)
                .ToList();

            if (listBoxEmprunts.SelectedIndex >= mesEmprunts.Count)
                return;

            var emprunt = mesEmprunts[listBoxEmprunts.SelectedIndex];

            if (emprunt.EstRendu())
            {
                MessageBox.Show("Ce livre a déjà été rendu.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Voulez-vous rendre le livre '{emprunt.LivreEmprunte.Titre}' ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Mettre à jour dans la base de données
                dbService.RendreEmprunt(emprunt.Id);

                MessageBox.Show("Le livre a été rendu avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ChargerLivres();
                ChargerEmprunts();
            }
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton Actualiser
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnActualiser_Click(object sender, EventArgs e)
        {
            ChargerLivres();
            ChargerEmprunts();
            MessageBox.Show("Liste actualisée.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Gère l'événement de chargement du formulaire
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void EmpruntsForm_Load(object sender, EventArgs e)
        {

        }
    }
}