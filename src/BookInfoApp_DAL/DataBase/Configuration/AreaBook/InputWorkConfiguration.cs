using BookInfo_Core.Entities.AreaBook;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookInfo_DAL.DataBase.Configuration.AreaBook
{
    class InputWorkConfiguration : IEntityTypeConfiguration<InputWork>
    {
        public void Configure(EntityTypeBuilder<InputWork> builder)
        {
            builder.HasKey(p => new { IdWork = p.WorkId, IdBook = p.BookId });
            builder.HasOne(p => p.Book)
                .WithMany(t => t.BookForConnectInputWorks)
                .HasForeignKey(p => p.BookId);
            builder.HasOne(p => p.Work)
                .WithMany(t => t.InputWorks)
                .HasForeignKey(p => p.WorkId);
        }
    }
}
