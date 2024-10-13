# API-EFCore documentation

Projet de base qui référence l'utilisation d'EntityFrameworkCore dans une application de type API web ASP.NET Core, structure trois couche API-BLL-DAL.

L'avantage de cette architecture est que les couches sont séparées et modulaires, ainsi, si nous décidons de remplacer EFCore par ADO .NET ou Dapper, cela est bien plus facilement interchangeable, vu que nous ne devrions modifier que la DAL.

## Installation

1. Clonez le dépôt
   ```bash
   git clone https://github.com/Pierre-Bossis/API-EFCore.git

2. une fois le dépôt cloné, ouvrez le fichier .sln a la racine du dossier

## Fonctionnalités

- mettre en place l'architecture API-BLL-DAL.
- mettre en place EntityFrameworkCore.
- Controlleurs et première consomation d'endpoint.

### 1. Mettre en place l'architecture API-BLL-DAL

1. Après la création du projet type API web ASP.NET Core, créer deux bibliothèque de classe à partir de la solution.

   - nom-du-projet.BLL
      qui contient un dossier Interfaces et Services
   - nom-du-projet.DAL
      qui contient un dossier DataAccess, Entities et Repositories

2. Dans le projet de base (API), créer un dossier Models qui contiendra un dossier par entité ex: books qui lui contiendra tous les DTOs nécéssaires lié à books.

3. Toujours dans le projet de base (API) créer un dossier Tools qui contiendra un dossier Mappers, un fichier mapper par entité ex: BooksMapper.
   Endroit également pour le JwtGenerator.

### 2. Mettre en place EntityFrameworkCore

1. Avant tout, installer dans le projet API le package NuGet : Microsoft.EntityFrameworkCore.Design
   il sera nécessaire pour effectuer les futures commandes de migrations et toutes commandes liées à EntityFrameworkCore.

2. Dans la bibliothèque de classe DAL, installer les packages NuGet suivant:

   - Microsoft.EntityFrameworkCore
   - Microsoft.EntityFrameworkCore.Design
   - Microsoft.EntityFrameworkCore.SqlServer
   - Microsoft.EntityFrameworkCore.Tools

3. Créer votre première entité dans DAL -> Entities, ensuite le DbContext(MyDbContext ou autre) dans la partie DAL -> DataAccess

   voici un exemple de DbContext :

   ```C#
   using API_EFCore.DAL.Entities;
   using Microsoft.EntityFrameworkCore;

   namespace API_EFCore.DAL.DataAccess
   {
      public class MyDbContext : DbContext
      {
         public DbSet<BookEntity> Books { get; set; }

         public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
         {
               
         }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
               base.OnModelCreating(modelBuilder);

               modelBuilder.Entity<BookEntity>()
                  .HasKey(e => e.Id);

               modelBuilder.Entity<BookEntity>()
                  .Property(e => e.Id)
                  .ValueGeneratedOnAdd();

               modelBuilder.Entity<BookEntity>().HasData(
                  new BookEntity { Id = 1, Title = "test", Author = "test Author", Description = "desc", ReleaseDate = new DateOnly(1995,11,14) },
                  new BookEntity { Id = 2, Title = "test2", Author = "test Author2", Description = "desc2", ReleaseDate = new DateOnly(1994,11,14) },
                  new BookEntity { Id = 3, Title = "test3", Author = "test Author3", Description = "desc3", ReleaseDate = new DateOnly(1993,11,14) }
                  );
         }
      }
   }

4. Une fois le DbContext créé et configuré, ajoutez les paramètres nécessaires dans le projet API -> program.cs :

   ```C#
   builder.Services.AddDbContext<MyDbContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

5. dans le projet API -> appsettings.json, configurez votre ConnectionStrings : 

   ```yaml
   {
      "Logging": {
      "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
      }
      },
      "AllowedHosts": "*",
      "ConnectionStrings": {
         "DefaultConnection": "Server=nomduserveur;Database=nombasededonnée;Trusted_Connection=True;TrustServerCertificate=True;"
      }
   }

6. tout est prêt pour la configuration d'EntityFrameworkCore, il ne reste qu'a faire la première migration a partir du projet API :

   ouvrir le terminal :

   - dotnet ef migrations add InitialCreate --startup-project API-EFCore --project API-EFCore.DAL --output-dir migrations
   - dotnet ef database update --startup-project API-EFCore --project API-EFCore.DAL

#### Liste de commandes utiles

1. ...
2. ...
3. ...
4. ...
5. ...

### 3. Controlleurs

1. Pour ajouter un controlleur, aller dans le projet API, clic droit sur le dossier Controllers, Ajouter -> Contrôleur -> API -> Contrôleur d'API vide
2. Tous les endpoints lié aux livres se trouveront ici, chaque requête reçue empruntera le chemin suivant: Controlleur(API) -> BLL -> DAL et DAL -> BLL -> Controlleur(API) pour ramener les data
3. Ne pas oublier de créer les mappers pour les entités, le Controlleur s'occupe de la transformation Entité -> DTO et inversément.

## Contact

Pierre Bossis - [pbossis@hotmail.com](mailto:pbossis@hotmail.com)