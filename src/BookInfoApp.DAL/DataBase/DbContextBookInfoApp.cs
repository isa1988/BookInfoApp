using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using BookInfoApp.Core.Entities.AreaBook.AreaGenre;
using BookInfoApp.Core.Entities.AreaPublisher;
using BookInfoApp.DAL.DataBase.Configuration.AreaBook;
using BookInfoApp.DAL.DataBase.Configuration.AreaBook.AreaAuthor;
using BookInfoApp.DAL.DataBase.Configuration.AreaBook.AreaGenre;
using BookInfoApp.DAL.DataBase.Configuration.AreaPublisher;
using Microsoft.EntityFrameworkCore;

namespace BookInfoApp.DAL.DataBase
{
    public class DbContextBookInfoApp : DbContext
    {
        public DbContextBookInfoApp(DbContextOptions<DbContextBookInfoApp> options)
            : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<AgeCategory> AgeCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<InputWork> InputWorks { get; set; }
        public DbSet<BookPublisher> BookPublishers { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Publisher> Publishers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookAuthorConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new BookGenreConfiguration());
            modelBuilder.ApplyConfiguration(new AgeCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new InputWorkConfiguration());
            modelBuilder.ApplyConfiguration(new BookPublisherConfiguration());
            modelBuilder.ApplyConfiguration(new CoverTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PublisherConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
