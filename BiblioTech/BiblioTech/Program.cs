// ====================================================================
// Projet: BiblioTech - Système de gestion de bibliothèque
// Auteurs: Samuel et Bertrand
// Date: 11/16/2025
// Description: Point d'entrée principal de l'application BiblioTech
// ====================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiblioTech
{
    /// <summary>
    /// Classe principale contenant le point d'entrée de l'application
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application BiblioTech
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Afficher le formulaire de connexion
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Si la connexion réussit, ouvrir l'application principale
                Application.Run(new MainForm(loginForm.UtilisateurConnecte));
            }
        }
    }
}
