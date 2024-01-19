# CloudXForum
CloudX - Elevating Ideas Together!

## Features

### Roles

- User
- Administrator / Moderator

### The possibilities of the role:

#### User
- Login and registration on the forum
- Change the password, status and avatar of his profile
- Creating, editing his and archive his topic
- Creating and editing his reply to topics
- Global search and category search
- Automatic Activity rating
- Subscribe to a topic and receive notification when an update occurs
- Mark as read notifications

#### Administrator / Moderator:
- All **User** features
- Approve the register of users
- Lock / Unlock Users
- View and Manage the users
- Create and edit categories for topics
- Edit and close all topics
- Edit and delete answers to all topics

## Configuring the project

- Requires **.NET 6** version or higher
- Requires **MS SQL Server 2016** version or higher

In the file **```/CloudXForum.UI/appsettings.json```** specify the server and database in the *DefaultConnection* string

Go to the folder **```/CloudXForum.DataAccess```** and [creating a database](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations ) based on migrations depending on the IDE:
- Visual Studio:
```
Update-Database
```
- .NET CLI
```
dotnet ef database update
```