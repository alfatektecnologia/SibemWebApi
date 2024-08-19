using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SibemWebApi.Models;

namespace SibemWebApi.Data.Map
{
    public class FotosMap : IEntityTypeConfiguration<FotosModel>
    {
        public void Configure(EntityTypeBuilder<FotosModel> builder)
        {
           builder.Property<int>("Id");
           builder.Property(x=> x.id_igreja).IsRequired();
           builder.Property(x=> x.foto).IsRequired().HasMaxLength(255);
        }
    }
}
