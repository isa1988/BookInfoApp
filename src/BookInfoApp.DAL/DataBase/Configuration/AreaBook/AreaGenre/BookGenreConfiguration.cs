using System;
using System.Collections.Generic;
using System.Text;
using BookInfoApp.Core.Entities.AreaBook.AreaGenre;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookInfoApp.DAL.DataBase.Configuration.AreaBook.AreaGenre
{
    class BookGenreConfiguration : IEntityTypeConfiguration<BookGenre>
    {
        public void Configure(EntityTypeBuilder<BookGenre> builder)
        {
            builder.HasKey(p => new { IdGenre = p.GenreId, IdBook = p.BookId });
            builder.HasOne(p => p.Genre)
                .WithMany(t => t.BookGenras)
                .HasForeignKey(p => p.GenreId);
            builder.HasOne(p => p.Book)
                .WithMany(t => t.BookGenres)
                .HasForeignKey(p => p.BookId);
        }
    }
}
