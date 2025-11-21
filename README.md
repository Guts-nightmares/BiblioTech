# BiblioTech - Système de Gestion de Bibliothèque

**Auteurs:** Samuel et Bertrand
**Date:** 11/16/2025
**Version:** 1.0

---

## Description

BiblioTech est une application Windows Forms développée en C# pour la gestion complète d'une bibliothèque. Le système permet de gérer un catalogue de livres, les emprunts et retours, ainsi que l'administration des utilisateurs avec différents niveaux de permissions.

### Fonctionnalités principales

- **Authentification sécurisée** : Connexion avec email et mot de passe hashé (SHA256)
- **Gestion du catalogue** : Consultation, recherche et tri des livres par titre, auteur, année ou genre
- **Système d'emprunts** : Emprunter et rendre des livres avec suivi des dates
- **Administration** : Gestion des utilisateurs, promotion/rétrogradation des rôles
- **Base de données SQLite** : Stockage persistant de toutes les données

---

## Architecture du projet

### Classes principales

- **`Document`** : Classe abstraite de base pour tous les documents
- **`Livre`** : Hérite de Document, représente un livre avec auteur, ISBN, genre
- **`Utilisateur`** : Représente un utilisateur avec authentification
- **`Emprunt`** : Représente un emprunt de livre

### Services

- **`DatabaseService`** : Service de gestion de la base de données SQLite
  - Création et initialisation des tables
  - CRUD pour les livres, emprunts et utilisateurs
  - Authentification et gestion des rôles

### Formulaires (Windows Forms)

- **`LoginForm`** : Formulaire de connexion
- **`RegisterForm`** : Formulaire d'inscription
- **`MainForm`** : Formulaire principal avec menu de navigation
- **`CatalogueForm`** : Consultation et recherche du catalogue
- **`AddBookForm`** : Ajout de nouveaux livres (admin uniquement)
- **`EmpruntsForm`** : Gestion des emprunts personnels
- **`AdminForm`** : Gestion des utilisateurs (admin uniquement)

---

## Installation et exécution

### Prérequis

- .NET Framework 4.7.1 ou supérieur
- Visual Studio 2019 ou supérieur (recommandé)
- SQLite (inclus via NuGet)

### Étapes d'installation

1. Clonez ou téléchargez le projet
2. Ouvrez la solution `BiblioTech.sln` dans Visual Studio
3. Restaurez les packages NuGet (System.Data.SQLite)
4. Compilez et exécutez le projet

### Première utilisation

Au premier lancement, la base de données est créée automatiquement avec des données de démonstration :

**Compte administrateur :**
- Email : `admin@bibliotech.fr`
- Mot de passe : `admin123`

**Compte utilisateur :**
- Email : `user@bibliotech.fr`
- Mot de passe : `user123`

---

## Guide d'utilisation

### Pour les utilisateurs

1. **Connexion** : Entrez vos identifiants ou créez un nouveau compte
2. **Consulter le catalogue** : Parcourez, recherchez et triez les livres disponibles
3. **Emprunter un livre** : Sélectionnez un livre disponible et confirmez l'emprunt
4. **Rendre un livre** : Accédez à vos emprunts et marquez un livre comme rendu

### Pour les administrateurs

En plus des fonctionnalités utilisateur :

1. **Ajouter des livres** : Ajoutez de nouveaux livres au catalogue avec toutes leurs informations
2. **Gérer les utilisateurs** : Consultez la liste des utilisateurs
3. **Promouvoir/Rétrograder** : Modifiez les rôles des utilisateurs
4. **Supprimer des utilisateurs** : Retirez des comptes du système

---

## Structure de la base de données

### Table : Livres
- `Id` (INTEGER PRIMARY KEY)
- `Titre` (TEXT)
- `Auteur` (TEXT)
- `AnneePublication` (INTEGER)
- `ISBN` (TEXT)
- `Genre` (TEXT)

### Table : Emprunts
- `Id` (INTEGER PRIMARY KEY)
- `LivreId` (INTEGER, FK → Livres)
- `UtilisateurId` (INTEGER, FK → Utilisateurs)
- `DateEmprunt` (TEXT)
- `DateRetour` (TEXT, nullable)

### Table : Utilisateurs
- `IdUtilisateur` (INTEGER PRIMARY KEY)
- `Nom` (TEXT)
- `Email` (TEXT UNIQUE)
- `MotDePasseHash` (TEXT)
- `Role` (INTEGER: 0=Utilisateur, 1=Admin)

---

## Sécurité

- **Hashage des mots de passe** : SHA256 pour la sécurité des comptes
- **Validation des entrées** : Contrôles sur les formulaires d'inscription et de connexion
- **Gestion des rôles** : Séparation des permissions Admin/Utilisateur
- **Contraintes de base de données** : Email unique, clés étrangères

---

## Technologies utilisées

- **Langage** : C# (.NET Framework)
- **Interface** : Windows Forms
- **Base de données** : SQLite
- **Packages NuGet** :
  - System.Data.SQLite (version 2.0.2)
  - Stub.System.Data.SQLite.Core.NetFramework (version 1.0.119.0)

---

## Développement futur

### Améliorations possibles

- Export du catalogue en PDF/Excel
- Système de réservations
- Gestion des retards et pénalités
- Statistiques et rapports
- Historique complet des emprunts
- Support multi-langues
- Migration vers .NET 6+ avec WPF ou Blazor

---

## Support et contribution

Pour toute question ou suggestion d'amélioration, veuillez contacter les auteurs : Samuel et Bertrand.

---

**© 2025 Samuel et Bertrand - BiblioTech**
