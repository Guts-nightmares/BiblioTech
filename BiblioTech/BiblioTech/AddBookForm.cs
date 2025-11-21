// ====================================================================
// Projet: BiblioTech - Système de gestion de bibliothèque
// Auteurs: Samuel et Bertrand
// Date: 11/16/2025
// Description: Formulaire d'ajout de livre au catalogue
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
    /// Formulaire permettant d'ajouter un nouveau livre au catalogue
    /// </summary>
    public partial class AddBookForm : Form
    {
        private DatabaseService dbService;

        /// <summary>
        /// Constructeur du formulaire d'ajout de livre
        /// </summary>
        /// <param name="db">Service de base de données</param>
        public AddBookForm(DatabaseService db)
        {
            InitializeComponent();
            dbService = db;
        }

        /// <summary>
        /// Gère l'événement de clic sur le bouton d'ajout
        /// </summary>
        /// <param name="sender">Source de l'événement</param>
        /// <param name="e">Arguments de l'événement</param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Livre livre = new Livre(
                txtTitre.Text,
                txtAuteur.Text,
                int.Parse(txtAnnee.Text),
                txtISBN.Text,
                txtGenre.Text
            );

            dbService.SauverLivre(livre);

            MessageBox.Show("Livre ajouté !");
            this.Close();
        }
    }
}
