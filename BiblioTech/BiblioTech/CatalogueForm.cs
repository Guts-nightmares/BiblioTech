// ====================================================================
// Projet: BiblioTech - Système de gestion de bibliothèque
// Auteurs: Samuel et Bertrand
// Date: 11/16/2025
// Description: Formulaire d'affichage et de recherche du catalogue de livres
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
    /// Formulaire permettant de consulter et rechercher dans le catalogue de livres
    /// </summary>
    public partial class CatalogueForm : Form
    {
        private DatabaseService dbService;
        private List<Livre> livres;

        /// <summary>
        /// Constructeur du formulaire catalogue
        /// </summary>
        /// <param name="db">Service de base de données</param>
        public CatalogueForm(DatabaseService db)
        {
            InitializeComponent();
            dbService = db;

            // Initialiser le ComboBox avec les options de tri
            cmbTri.Items.AddRange(new string[] { "Titre", "Auteur", "Année", "Genre" });
            cmbTri.SelectedIndex = 0; // Sélectionner "Titre" par défaut

            ChargerCatalogue();
        }

        /// <summary>
        /// Filtre la liste de livres selon le texte de recherche
        /// </summary>
        /// <param name="livres">Liste des livres à filtrer</param>
        /// <returns>Liste filtrée de livres</returns>
        private List<Livre> FiltrerLivres(List<Livre> livres)
        {
            string recherche = txtRecherche.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(recherche))
                return livres;

            return livres.Where(l =>
                l.Titre.ToLower().Contains(recherche) ||
                l.Auteur.ToLower().Contains(recherche) ||
                l.Genre.ToLower().Contains(recherche) ||
                l.AnneePublication.ToString().Contains(recherche) ||
                l.ISBN.ToLower().Contains(recherche)
            ).ToList();
        }

        /// <summary>
        /// Charge et affiche le catalogue de livres avec tri et filtrage
        /// </summary>
        private void ChargerCatalogue()
        {
            listBoxCatalogue.Items.Clear();

            // Récupérer tous les livres
            livres = dbService.LireTousLesLivres();

            // Filtrer selon la recherche
            livres = FiltrerLivres(livres);

            // Trier selon le critère sélectionné
            string critere = cmbTri.SelectedItem?.ToString() ?? "Titre";
            switch (critere)
            {
                case "Titre":
                    livres = livres.OrderBy(l => l.Titre).ToList();
                    break;
                case "Auteur":
                    livres = livres.OrderBy(l => l.Auteur).ToList();
                    break;
                case "Année":
                    livres = livres.OrderBy(l => l.AnneePublication).ToList();
                    break;
                case "Genre":
                    livres = livres.OrderBy(l => l.Genre).ToList();
                    break;
            }

            // Afficher les livres triés
            if (livres.Count == 0)
            {
                listBoxCatalogue.Items.Add("Aucun livre trouvé.");
            }
            else
            {
                foreach (var livre in livres)
                {
                    listBoxCatalogue.Items.Add(livre.AfficherInfos());
                }
            }
        }

        /// <summary>
        /// Gère le changement de sélection du critère de tri
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void cmbTri_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerCatalogue();
        }

        /// <summary>
        /// Gère le changement du texte de recherche
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            ChargerCatalogue();
        }
    }
}
