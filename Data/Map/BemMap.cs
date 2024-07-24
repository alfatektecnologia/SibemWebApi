using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SibemWebApi.Models;

namespace SibemWebApi.Data.Map
{
    public class BemMap : IEntityTypeConfiguration<BemModel>
    {
        public void Configure(EntityTypeBuilder<BemModel> builder)
        {
            builder.Property(x => x.id_bem).IsRequired().HasMaxLength(255);
            builder.Property(x => x.descricao).IsRequired().HasMaxLength(255);
            builder.Property(x => x.status).IsRequired().HasMaxLength(255);
            builder.Property(x => x.dependencia).IsRequired().HasMaxLength(255);
            builder.Property(x => x.id_igreja).IsRequired().HasMaxLength(255);
            
        }
    }
}
