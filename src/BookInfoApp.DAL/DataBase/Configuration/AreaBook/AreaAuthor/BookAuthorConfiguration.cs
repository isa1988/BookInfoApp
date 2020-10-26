using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookInfoApp.DAL.DataBase.Configuration.AreaBook.AreaAuthor
{
    class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.HasKey(p => new { IdAuthor = p.AuthorId, IdBook = p.BookId});
            builder.HasOne(p => p.Author)
                .WithMany(t => t.BookAuthors)
                .HasForeignKey(p => p.AuthorId);
            builder.HasOne(p => p.Book)
                .WithMany(t => t.BookAuthors)
                .HasForeignKey(p => p.BookId);
        }
    }
}
