// ====================================================================
// Projet: BiblioTech - Système de gestion de bibliothèque
// Auteurs: Samuel et Bertrand
// Date: 11/16/2025
// Description: Classe abstraite de base pour tous les types de documents
// ====================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTech
{
    /// <summary>
    /// Classe abstraite représentant un document générique dans la bibliothèque
    /// </summary>
    public abstract class Document
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public int AnneePublication { get; set; }

        /// <summary>
        /// Constructeur par défaut de la classe Document
        /// </summary>
        public Document() { }

        /// <summary>
        /// Constructeur avec paramètres pour initialiser un document
        /// </summary>
        /// <param name="titre">Titre du document</param>
        /// <param name="annee">Année de publication du document</param>
        public Document(string titre, int annee)
        {
            Titre = titre;
            AnneePublication = annee;
        }

        /// <summary>
        /// Méthode abstraite pour afficher les informations du document
        /// </summary>
        /// <returns>Chaîne de caractères contenant les informations du document</returns>
        public abstract string AfficherInfos();
    }
}
