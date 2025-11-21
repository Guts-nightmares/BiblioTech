// ====================================================================
// Projet: BiblioTech - Système de gestion de bibliothèque
// Auteurs: Samuel et Bertrand
// Date: 11/16/2025
// Description: Classe représentant un livre dans le système de bibliothèque
// ====================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTech
{
    /// <summary>
    /// Représente un livre héritant de la classe Document
    /// </summary>
    public class Livre : Document
    {
        public string Auteur { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }

        /// <summary>
        /// Constructeur par défaut de la classe Livre
        /// </summary>
        public Livre() { }

        /// <summary>
        /// Constructeur avec paramètres pour initialiser un livre
        /// </summary>
        /// <param name="titre">Titre du livre</param>
        /// <param name="auteur">Nom de l'auteur du livre</param>
        /// <param name="annee">Année de publication du livre</param>
        /// <param name="isbn">Numéro ISBN du livre (optionnel)</param>
        /// <param name="genre">Genre littéraire du livre (optionnel)</param>
        public Livre(string titre, string auteur, int annee, string isbn = "", string genre = "")
            : base(titre, annee)
        {
            Auteur = auteur;
            ISBN = isbn;
            Genre = genre;
        }

        /// <summary>
        /// Affiche les informations détaillées du livre
        /// </summary>
        /// <returns>Chaîne formatée contenant toutes les informations du livre</returns>
        public override string AfficherInfos()
        {
            return $"Titre: {Titre}, Auteur: {Auteur}, Année: {AnneePublication}, ISBN: {ISBN}, Genre: {Genre}";
        }
    }
}
