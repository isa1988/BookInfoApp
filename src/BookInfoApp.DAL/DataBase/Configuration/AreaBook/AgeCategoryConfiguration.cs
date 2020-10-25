using BookInfoApp.Core.Entities.AreaBook;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookInfoApp.DAL.DataBase.Configuration.AreaBook
{
    class AgeCategoryConfiguration : IEntityTypeConfiguration<AgeCategory>
    {
        public void Configure(EntityTypeBuilder<AgeCategory> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
