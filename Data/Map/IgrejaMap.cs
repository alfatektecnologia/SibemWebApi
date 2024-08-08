using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SibemWebApi.Models;

namespace SibemWebApi.Data.Map
{
   
    public class IgrejaMap : IEntityTypeConfiguration<IgrejaModel>
    {
        public void Configure(EntityTypeBuilder<IgrejaModel> builder)
        {
            builder.Property(x=> x.id_igreja).IsRequired().HasMaxLength(255);
            builder.Property(x => x.igreja).IsRequired().HasMaxLength(255);
            builder.Property(x => x.situacao).IsRequired();
            builder.Property(x => x.endereco).IsRequired().HasMaxLength(255);
            builder.Property(x => x.id_setor).IsRequired().HasMaxLength(255);
            builder.Property(x => x.foto).HasMaxLength(255);
            builder.Property(x => x.last_Inventario).HasMaxLength(255);
           
        }
    }
}
