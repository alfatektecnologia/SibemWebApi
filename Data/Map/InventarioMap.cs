using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SibemWebApi.Models;

namespace SibemWebApi.Data.Map
{
    public class InventarioMap : IEntityTypeConfiguration<InventarioModel>
    {
        public void Configure(EntityTypeBuilder<InventarioModel> builder)
        {

            builder.Property(x => x.id_igreja).IsRequired().HasMaxLength(255);
            builder.Property(x => x.id_inventario).IsRequired().HasMaxLength(255);
            builder.Property(x => x.status).IsRequired().HasMaxLength(255);
            builder.Property(x => x.termino).IsRequired();
            builder.Property(x => x.bens).IsRequired();
            builder.Property(x => x.inventariantes).IsRequired().HasMaxLength(255);
            builder.Property(x => x.data).IsRequired();
            builder.Property(x => x.inicio).IsRequired();
            builder.Property(x => x.responsaveis).IsRequired().HasMaxLength(255);
            builder.Property(x => x.pdf).HasMaxLength(255);

        }
    }
}
