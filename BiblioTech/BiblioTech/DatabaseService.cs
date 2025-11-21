// ====================================================================
// Projet: BiblioTech - Système de gestion de bibliothèque
// Auteurs: Samuel et Bertrand
// Date: 11/16/2025
// Description: Service de gestion de la base de données SQLite
// ====================================================================

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace BiblioTech
{
    /// <summary>
    /// Service de gestion de la base de données SQLite pour BiblioTech
    /// </summary>
    public class DatabaseService
    {
        private string dbPath;
        private string connectionString;

        /// <summary>
        /// Constructeur du service de base de données
        /// </summary>
        /// <param name="dbPath">Chemin vers le fichier de base de données SQLite</param>
        public DatabaseService(string dbPath)
        {
            this.dbPath = dbPath;
            connectionString = $"Data Source={dbPath};Version=3;";

            // Crée automatiquement le fichier DB si il n'existe pas
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            InitDatabase();
        }

        /// <summary>
        /// Crée les tables si elles n'existent pas.
        /// </summary>
        private void InitDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createLivresTable = @"
                CREATE TABLE IF NOT EXISTS Livres (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Titre TEXT NOT NULL,
                    Auteur TEXT NOT NULL,
                    AnneePublication INTEGER,
                    ISBN TEXT,
                    Genre TEXT
                );";

                string createEmpruntsTable = @"
                CREATE TABLE IF NOT EXISTS Emprunts (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    LivreId INTEGER NOT NULL,
                    UtilisateurId INTEGER NOT NULL,
                    DateEmprunt TEXT NOT NULL,
                    DateRetour TEXT,
                    FOREIGN KEY(LivreId) REFERENCES Livres(Id),
                    FOREIGN KEY(UtilisateurId) REFERENCES Utilisateurs(IdUtilisateur)
                );";

                string createUtilisateursTable = @"
                CREATE TABLE IF NOT EXISTS Utilisateurs (
                    IdUtilisateur INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nom TEXT NOT NULL,
                    Email TEXT NOT NULL UNIQUE,
                    MotDePasseHash TEXT NOT NULL,
                    Role INTEGER NOT NULL
                );";

                using (var cmd = new SQLiteCommand(createLivresTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SQLiteCommand(createEmpruntsTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SQLiteCommand(createUtilisateursTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                // Initialiser les données de démonstration si les tables sont vides
                InitialiserDonneesDemo(connection);
            }
        }

        /// <summary>
        /// Initialise les données de démonstration (utilisateurs et livres)
        /// </summary>
        private void InitialiserDonneesDemo(SQLiteConnection connection)
        {
            // Vérifier si des utilisateurs existent déjà
            string checkUsers = "SELECT COUNT(*) FROM Utilisateurs;";
            using (var cmd = new SQLiteCommand(checkUsers, connection))
            {
                long count = (long)cmd.ExecuteScalar();
                if (count == 0)
                {
                    // Créer un admin par défaut (email: admin@bibliotech.fr, mot de passe: admin123)
                    string insertAdmin = @"
                    INSERT INTO Utilisateurs (Nom, Email, MotDePasseHash, Role)
                    VALUES (@Nom, @Email, @Hash, @Role);";

                    using (var cmdAdmin = new SQLiteCommand(insertAdmin, connection))
                    {
                        cmdAdmin.Parameters.AddWithValue("@Nom", "Administrateur");
                        cmdAdmin.Parameters.AddWithValue("@Email", "admin@bibliotech.fr");
                        cmdAdmin.Parameters.AddWithValue("@Hash", Utilisateur.HashMotDePasse("admin123"));
                        cmdAdmin.Parameters.AddWithValue("@Role", (int)RoleUtilisateur.Admin);
                        cmdAdmin.ExecuteNonQuery();
                    }

                    // Créer un utilisateur de test (email: user@bibliotech.fr, mot de passe: user123)
                    using (var cmdUser = new SQLiteCommand(insertAdmin, connection))
                    {
                        cmdUser.Parameters.AddWithValue("@Nom", "Jean Dupont");
                        cmdUser.Parameters.AddWithValue("@Email", "user@bibliotech.fr");
                        cmdUser.Parameters.AddWithValue("@Hash", Utilisateur.HashMotDePasse("user123"));
                        cmdUser.Parameters.AddWithValue("@Role", (int)RoleUtilisateur.Utilisateur);
                        cmdUser.ExecuteNonQuery();
                    }
                }
            }

            // Vérifier si des livres existent déjà
            string checkBooks = "SELECT COUNT(*) FROM Livres;";
            using (var cmd = new SQLiteCommand(checkBooks, connection))
            {
                long count = (long)cmd.ExecuteScalar();
                if (count == 0)
                {
                    // Ajouter des livres de démonstration
                    string insertLivre = @"
                    INSERT INTO Livres (Titre, Auteur, AnneePublication, ISBN, Genre)
                    VALUES (@Titre, @Auteur, @Annee, @ISBN, @Genre);";

                    var livresDemo = new[]
                    {
                        new { Titre = "Le Petit Prince", Auteur = "Antoine de Saint-Exupéry", Annee = 1943, ISBN = "978-2070612758", Genre = "Conte" },
                        new { Titre = "1984", Auteur = "George Orwell", Annee = 1949, ISBN = "978-2070368228", Genre = "Science-Fiction" },
                        new { Titre = "L'Étranger", Auteur = "Albert Camus", Annee = 1942, ISBN = "978-2070360024", Genre = "Roman" },
                        new { Titre = "Les Misérables", Auteur = "Victor Hugo", Annee = 1862, ISBN = "978-2070409228", Genre = "Roman" },
                        new { Titre = "Harry Potter à l'école des sorciers", Auteur = "J.K. Rowling", Annee = 1997, ISBN = "978-2070584628", Genre = "Fantasy" },
                        new { Titre = "Le Seigneur des Anneaux", Auteur = "J.R.R. Tolkien", Annee = 1954, ISBN = "978-2070612888", Genre = "Fantasy" },
                        new { Titre = "Orgueil et Préjugés", Auteur = "Jane Austen", Annee = 1813, ISBN = "978-2070409457", Genre = "Romance" },
                        new { Titre = "Cent ans de solitude", Auteur = "Gabriel García Márquez", Annee = 1967, ISBN = "978-2070370528", Genre = "Roman" }
                    };

                    foreach (var livre in livresDemo)
                    {
                        using (var cmdLivre = new SQLiteCommand(insertLivre, connection))
                        {
                            cmdLivre.Parameters.AddWithValue("@Titre", livre.Titre);
                            cmdLivre.Parameters.AddWithValue("@Auteur", livre.Auteur);
                            cmdLivre.Parameters.AddWithValue("@Annee", livre.Annee);
                            cmdLivre.Parameters.AddWithValue("@ISBN", livre.ISBN);
                            cmdLivre.Parameters.AddWithValue("@Genre", livre.Genre);
                            cmdLivre.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sauvegarde un livre dans la base.
        /// </summary>
        public void SauverLivre(Livre livre)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                INSERT INTO Livres (Titre, Auteur, AnneePublication, ISBN, Genre)
                VALUES (@Titre, @Auteur, @Annee, @ISBN, @Genre);
                SELECT last_insert_rowid();"; // récupère l'id auto-généré

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Titre", livre.Titre);
                    cmd.Parameters.AddWithValue("@Auteur", livre.Auteur);
                    cmd.Parameters.AddWithValue("@Annee", livre.AnneePublication);
                    cmd.Parameters.AddWithValue("@ISBN", livre.ISBN);
                    cmd.Parameters.AddWithValue("@Genre", livre.Genre);

                    livre.Id = Convert.ToInt32(cmd.ExecuteScalar()); // assigne l'ID à l'objet
                }
            }
        }

        /// <summary>
        /// Lit tous les livres de la base.
        /// </summary>
        public List<Livre> LireTousLesLivres()
        {
            List<Livre> livres = new List<Livre>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Id, Titre, Auteur, AnneePublication, ISBN, Genre FROM Livres;";

                using (var cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Livre livre = new Livre(
                            reader["Titre"].ToString(),
                            reader["Auteur"].ToString(),
                            Convert.ToInt32(reader["AnneePublication"]),
                            reader["ISBN"].ToString(),
                            reader["Genre"].ToString()
                        )
                        {
                            Id = Convert.ToInt32(reader["Id"])
                        };

                        livres.Add(livre);
                    }
                }
            }

            return livres;
        }

        /// <summary>
        /// Sauvegarde un emprunt dans la base.
        /// </summary>
        public void SauverEmprunt(Emprunt emprunt)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                INSERT INTO Emprunts (LivreId, UtilisateurId, DateEmprunt, DateRetour)
                VALUES (@LivreId, @UtilisateurId, @DateEmprunt, @DateRetour);
                SELECT last_insert_rowid();";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@LivreId", emprunt.LivreEmprunte.Id);
                    cmd.Parameters.AddWithValue("@UtilisateurId", emprunt.Utilisateur.IdUtilisateur);
                    cmd.Parameters.AddWithValue("@DateEmprunt", emprunt.DateEmprunt.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@DateRetour", emprunt.DateRetour.HasValue ? emprunt.DateRetour.Value.ToString("yyyy-MM-dd") : (object)DBNull.Value);

                    emprunt.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Lit tous les emprunts avec leurs livres et utilisateurs.
        /// </summary>
        public List<Emprunt> LireEmprunts(List<Livre> tousLesLivres)
        {
            List<Emprunt> emprunts = new List<Emprunt>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT e.Id, e.LivreId, e.UtilisateurId, e.DateEmprunt, e.DateRetour,
                           u.Nom, u.Email, u.MotDePasseHash, u.Role
                    FROM Emprunts e
                    INNER JOIN Utilisateurs u ON e.UtilisateurId = u.IdUtilisateur;";

                using (var cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int livreId = Convert.ToInt32(reader["LivreId"]);
                        Livre livre = tousLesLivres.Find(l => l.Id == livreId);

                        if (livre != null)
                        {
                            Utilisateur utilisateur = new Utilisateur(
                                Convert.ToInt32(reader["UtilisateurId"]),
                                reader["Nom"].ToString(),
                                reader["Email"].ToString(),
                                reader["MotDePasseHash"].ToString(),
                                (RoleUtilisateur)Convert.ToInt32(reader["Role"])
                            );

                            Emprunt e = new Emprunt
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                LivreEmprunte = livre,
                                Utilisateur = utilisateur,
                                DateEmprunt = DateTime.Parse(reader["DateEmprunt"].ToString()),
                                DateRetour = string.IsNullOrEmpty(reader["DateRetour"].ToString()) ? (DateTime?)null : DateTime.Parse(reader["DateRetour"].ToString())
                            };

                            emprunts.Add(e);
                        }
                    }
                }
            }

            return emprunts;
        }

        /// <summary>
        /// Authentifie un utilisateur avec son email et mot de passe
        /// </summary>
        public Utilisateur Authentifier(string email, string motDePasse)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT IdUtilisateur, Nom, Email, MotDePasseHash, Role FROM Utilisateurs WHERE Email = @Email;";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string hash = reader["MotDePasseHash"].ToString();
                            if (hash == Utilisateur.HashMotDePasse(motDePasse))
                            {
                                return new Utilisateur(
                                    Convert.ToInt32(reader["IdUtilisateur"]),
                                    reader["Nom"].ToString(),
                                    reader["Email"].ToString(),
                                    hash,
                                    (RoleUtilisateur)Convert.ToInt32(reader["Role"])
                                );
                            }
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Inscrit un nouvel utilisateur
        /// </summary>
        public bool InscrireUtilisateur(string nom, string email, string motDePasse)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                    INSERT INTO Utilisateurs (Nom, Email, MotDePasseHash, Role)
                    VALUES (@Nom, @Email, @Hash, @Role);";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nom", nom);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Hash", Utilisateur.HashMotDePasse(motDePasse));
                        cmd.Parameters.AddWithValue("@Role", (int)RoleUtilisateur.Utilisateur);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (SQLiteException)
            {
                // Email déjà existant ou autre erreur
                return false;
            }
        }

        /// <summary>
        /// Récupère tous les utilisateurs
        /// </summary>
        public List<Utilisateur> LireTousLesUtilisateurs()
        {
            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT IdUtilisateur, Nom, Email, MotDePasseHash, Role FROM Utilisateurs;";

                using (var cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Utilisateur user = new Utilisateur(
                            Convert.ToInt32(reader["IdUtilisateur"]),
                            reader["Nom"].ToString(),
                            reader["Email"].ToString(),
                            reader["MotDePasseHash"].ToString(),
                            (RoleUtilisateur)Convert.ToInt32(reader["Role"])
                        );

                        utilisateurs.Add(user);
                    }
                }
            }

            return utilisateurs;
        }

        /// <summary>
        /// Supprime un utilisateur par son ID
        /// </summary>
        public bool SupprimerUtilisateur(int idUtilisateur)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Utilisateurs WHERE IdUtilisateur = @Id;";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", idUtilisateur);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        /// <summary>
        /// Change le rôle d'un utilisateur
        /// </summary>
        public bool ChangerRole(int idUtilisateur, RoleUtilisateur nouveauRole)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Utilisateurs SET Role = @Role WHERE IdUtilisateur = @Id;";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Role", (int)nouveauRole);
                        cmd.Parameters.AddWithValue("@Id", idUtilisateur);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        /// <summary>
        /// Marque un emprunt comme rendu
        /// </summary>
        public bool RendreEmprunt(int idEmprunt)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Emprunts SET DateRetour = @DateRetour WHERE Id = @Id;";

                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@DateRetour", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Id", idEmprunt);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }
    }
}
