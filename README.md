# StarForum

## Features

### Roles

- User
- Administrator

### The possibilities of the role:

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

In the file **```/Star Forum.WebAPI/appsettings.json```** specify the server and database in the *DefaultConnection* string

Go to the folder **```/ Star Forum.Infrastructure```** and [creating a database](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations ) based on migrations depending on the IDE:
- Visual Studio:
```
Update-Database
```
- .NET CLI
```
dotnet ef database update
```