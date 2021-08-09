using BookInfo_Core.Entities.AreaBook;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookInfo_DAL.DataBase.Configuration.AreaBook
{
    class AgeCategoryConfiguration : IEntityTypeConfiguration<AgeCategory>
    {
        public void Configure(EntityTypeBuilder<AgeCategory> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
