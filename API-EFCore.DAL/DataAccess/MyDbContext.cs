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
