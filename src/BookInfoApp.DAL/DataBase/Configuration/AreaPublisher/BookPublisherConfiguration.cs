using BookInfoApp.Core.Entities.AreaPublisher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookInfoApp.DAL.DataBase.Configuration.AreaPublisher
{
    class BookPublisherConfiguration : IEntityTypeConfiguration<BookPublisher>
    {
        public void Configure(EntityTypeBuilder<BookPublisher> builder)
        {
            builder.HasKey(p => new { IdPublisher = p.PublisherId, IdBook = p.BookId });
            builder.HasOne(p => p.Book)
                .WithMany(t => t.BookPublishers)
                .HasForeignKey(p => p.BookId);

            builder.HasOne(p => p.Publisher)
                .WithMany(t => t.BookPublishers)
                .HasForeignKey(p => p.PublisherId);

            builder.HasOne(p => p.CoverType)
                .WithMany(t => t.BookPublishers)
                .HasForeignKey(p => p.CoverTypeId);
        }
    }
}
