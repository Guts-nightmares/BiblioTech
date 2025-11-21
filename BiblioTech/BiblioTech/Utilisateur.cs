// ====================================================================
// Projet: BiblioTech - Système de gestion de bibliothèque
// Auteurs: Samuel et Bertrand
// Date: 11/16/2025
// Description: Classe représentant un utilisateur du système avec authentification
// ====================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BiblioTech
{
    /// <summary>
    /// Énumération des rôles possibles pour un utilisateur
    /// </summary>
    public enum RoleUtilisateur
    {
        Utilisateur,
        Admin
    }

    /// <summary>
    /// Représente un utilisateur du système avec authentification et gestion des rôles
    /// </summary>
    public class Utilisateur
    {
        public int IdUtilisateur { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string MotDePasseHash { get; set; }
        public RoleUtilisateur Role { get; set; }

        /// <summary>
        /// Constructeur par défaut de la classe Utilisateur
        /// </summary>
        public Utilisateur() { }

        /// <summary>
        /// Constructeur simplifié pour créer un utilisateur basique
        /// </summary>
        /// <param name="id">Identifiant unique de l'utilisateur</param>
        /// <param name="nom">Nom complet de l'utilisateur</param>
        public Utilisateur(int id, string nom)
        {
            IdUtilisateur = id;
            Nom = nom;
            Role = RoleUtilisateur.Utilisateur;
        }

        /// <summary>
        /// Constructeur complet pour initialiser un utilisateur avec tous ses attributs
        /// </summary>
        /// <param name="id">Identifiant unique de l'utilisateur</param>
        /// <param name="nom">Nom complet de l'utilisateur</param>
        /// <param name="email">Adresse email de l'utilisateur</param>
        /// <param name="motDePasseHash">Hash du mot de passe de l'utilisateur</param>
        /// <param name="role">Rôle de l'utilisateur (Admin ou Utilisateur)</param>
        public Utilisateur(int id, string nom, string email, string motDePasseHash, RoleUtilisateur role)
        {
            IdUtilisateur = id;
            Nom = nom;
            Email = email;
            MotDePasseHash = motDePasseHash;
            Role = role;
        }

        /// <summary>
        /// Hash un mot de passe avec l'algorithme SHA256
        /// </summary>
        /// <param name="motDePasse">Le mot de passe en clair à hasher</param>
        /// <returns>Le hash du mot de passe en format hexadécimal</returns>
        public static string HashMotDePasse(string motDePasse)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(motDePasse));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    // convertit en hexa 
                    builder.Append(b.ToString("x2")); // ex : 5 devient "05", 255 devient "ff".
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Vérifie si un mot de passe correspond au hash stocké
        /// </summary>
        /// <param name="motDePasse">Le mot de passe en clair à vérifier</param>
        /// <returns>True si le mot de passe correspond, False sinon</returns>
        public bool VerifierMotDePasse(string motDePasse)
        {
            string hash = HashMotDePasse(motDePasse);
            return hash == MotDePasseHash;
        }
    }
}
