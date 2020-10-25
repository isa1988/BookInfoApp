

using BookInfoApp.Core.Entities.AreaPublisher;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookInfoApp.DAL.DataBase.Configuration.AreaPublisher
{
    class CoverTypeConfiguration : IEntityTypeConfiguration<CoverType>
    {
        public void Configure(EntityTypeBuilder<CoverType> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        }
    }
}
