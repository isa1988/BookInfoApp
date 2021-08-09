using BookInfo_Core.Entities.AreaBook.AreaAuthor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookInfo_DAL.DataBase.Configuration.AreaBook.AreaAuthor
{
    class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(200);
            builder.Property(p => p.MiddleName).HasMaxLength(200);
            builder.Property(p => p.SurName).HasMaxLength(200);
        }
    }
}
