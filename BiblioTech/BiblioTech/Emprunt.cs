// ====================================================================
// Projet: BiblioTech - Système de gestion de bibliothèque
// Auteurs: Samuel et Bertrand
// Date: 11/16/2025
// Description: Classe représentant un emprunt de livre par un utilisateur
// ====================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTech
{
    /// <summary>
    /// Représente un emprunt de livre avec ses dates et utilisateur associé
    /// </summary>
    public class Emprunt
    {
        public int Id { get; set; }
        public Livre LivreEmprunte { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public DateTime DateEmprunt { get; set; }
        public DateTime? DateRetour { get; set; }

        /// <summary>
        /// Constructeur par défaut de la classe Emprunt
        /// </summary>
        public Emprunt() { }

        /// <summary>
        /// Constructeur pour créer un nouvel emprunt
        /// </summary>
        /// <param name="livre">Le livre à emprunter</param>
        /// <param name="utilisateur">L'utilisateur qui emprunte le livre</param>
        public Emprunt(Livre livre, Utilisateur utilisateur)
        {
            LivreEmprunte = livre;
            Utilisateur = utilisateur;
            DateEmprunt = DateTime.Now;
            DateRetour = null;
        }

        /// <summary>
        /// Vérifie si le livre a été rendu
        /// </summary>
        /// <returns>True si le livre a été rendu, False sinon</returns>
        public bool EstRendu()
        {
            return DateRetour.HasValue;
        }
    }
}
