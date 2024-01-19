# CloudXForum
CloudX - Elevating Ideas Together!

## Features

### Roles

- User
- Administrator

### The possibilities of the role:

Fonctionnalité	Critères d'Acceptation
Page d'accueil du forum	- Affiche la liste de tous les thèmes du forum.
	- Permet d'accéder à la liste des discussions d'un thème en cliquant sur son titre.
	- Les discussions sont présentées dans l'ordre chronologique inverse.
Gestion des utilisateurs	- Différencie les utilisateurs en simples (visiteurs) et super-utilisateurs (modérateurs).
	- Les super-utilisateurs peuvent administrer d'autres utilisateurs.
	- Les super-utilisateurs peuvent supprimer n'importe quel message ou sujet.
	- Les super-utilisateurs peuvent créer, modifier, supprimer des catégories et des forums.
	- Les utilisateurs normaux peuvent gérer uniquement leurs propres messages et sujets.
Types de messages	- Identifie deux types de messages : sujets et réponses.
Inscription des utilisateurs	- Un utilisateur doit s'inscrire avec un pseudonyme, un mot de passe, et une adresse e-mail.
	- L'inscription doit être validée par un modérateur.
	- Les utilisateurs inscrits peuvent se connecter au forum.
Profil utilisateur	- Permet à l'utilisateur de mettre à jour son avatar, sa signature, et son mot de passe.
	- Le profil est accessible uniquement aux utilisateurs identifiés.
Participation aux discussions	- Les utilisateurs peuvent rédiger de nouveaux messages.
	- Les utilisateurs peuvent modifier le contenu de leurs propres messages.
	- Les messages sont datés automatiquement avec le pseudonyme de l'auteur.
Gestion des messages non-lus	- Affiche une liste des messages non-lus avec l'auteur et le sujet.
	- Permet à l'utilisateur de marquer les messages non-lus comme lus.
	- Les messages marqués comme lus sont automatiquement archivés.
Lecture des discussions	- Les utilisateurs peuvent lire les discussions en les parcourant.
	- Les utilisateurs peuvent rechercher des discussions par mots-clés.
Actions des super-utilisateurs	- Les super-utilisateurs peuvent publier de nouveaux sujets.
	- Les super-utilisateurs peuvent répondre à des sujets existants.
	- Les super-utilisateurs peuvent éditer et supprimer n'importe quel message d'une discussion.
Abonnement aux discussions	- Les utilisateurs peuvent s'abonner à une discussion.
	- Les utilisateurs peuvent se désabonner d'une discussion.
Structure du forum	- Le forum est composé d'une ou plusieurs catégories.
	- Chaque catégorie est composée d'un ou plusieurs forums.
	- Chaque forum est composé de zéro ou plusieurs messages.
Relations utilisateur-forum	- Le forum est composé d'un ou plusieurs utilisateurs qui peuvent poster.



#### User
- Login and registration on the forum
- Change the description, status and image of your profile
- Creating, editing (your) and archive (your) topic
- Creating and editing (your) reply to topics
- Global search and category search
- Activity rating

#### Administrator:
- All **User** features
- Changing the profile of other users (including changing their login)
- View all users on the site (sorted by registration date, by login, by activity rating, by email)
- Create and edit categories for topics
- Edit and close all topics
- Edit and delete answers to all topics

## Preparing for launch

- Requires **.NET 6** version or higher
- Requires **MS SQL Server**

In the file **```/CloudXForum.WebAPI/appsettings.json```** specify the server and database in the *DefaultConnection* string

Go to the folder **```/CloudXForum.DataAccess```** and [creating a database](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations ) based on migrations depending on the IDE:
- Visual Studio:
```
Update-Database
```
- .NET CLI
```
dotnet ef database update
```
