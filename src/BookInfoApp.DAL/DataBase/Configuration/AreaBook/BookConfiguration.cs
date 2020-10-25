using BookInfoApp.Core.Entities.AreaBook;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookInfoApp.DAL.DataBase.Configuration.AreaBook
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Description).HasMaxLength(5000);


            builder.HasOne(p => p.AgeCategory)
                .WithMany(t => t.Books)
                .HasForeignKey(p => p.AgeCategoryId);
        }
    }
}
