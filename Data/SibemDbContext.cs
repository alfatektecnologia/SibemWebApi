using Microsoft.EntityFrameworkCore;
using SibemWebApi.Data.Map;
using SibemWebApi.Models;
using System.Reflection.Metadata;

namespace SibemWebApi.Data
{
    public class SibemDbContext : DbContext
    {
        public SibemDbContext(DbContextOptions<SibemDbContext> options)
            : base(options) 
        
        {
            
        }

        public DbSet<IgrejaModel> igrejas {  get; set; }
        public DbSet<InventarioModel> inventario { get; set; }
        public DbSet<BemModel> bens { get; set; }
        public DbSet<FotosModel> fotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BemModel>()
            .HasKey(b => b.id_bem);

            modelBuilder.Entity<IgrejaModel>()
            .HasKey(b => b.id_igreja);

            modelBuilder.Entity<InventarioModel>()
            .HasKey(b => b.id_inventario);

            modelBuilder.Entity<FotosModel>()
            .HasKey(b => b.id);

            modelBuilder.ApplyConfiguration(new IgrejaMap());
            modelBuilder.ApplyConfiguration(new InventarioMap());
            modelBuilder.ApplyConfiguration(new BemMap());
            modelBuilder.ApplyConfiguration(new FotosMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
