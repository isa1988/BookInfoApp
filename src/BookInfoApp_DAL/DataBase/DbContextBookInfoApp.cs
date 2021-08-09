using BookInfo_Core.Entities.AreaBook;
using BookInfo_Core.Entities.AreaBook.AreaAuthor;
using BookInfo_Core.Entities.AreaBook.AreaGenre;
using BookInfo_Core.Entities.AreaPublisher;
using BookInfo_DAL.DataBase.Configuration.AreaBook;
using BookInfo_DAL.DataBase.Configuration.AreaBook.AreaAuthor;
using BookInfo_DAL.DataBase.Configuration.AreaBook.AreaGenre;
using BookInfo_DAL.DataBase.Configuration.AreaPublisher;
using Microsoft.EntityFrameworkCore;

namespace BookInfo_DAL.DataBase
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
