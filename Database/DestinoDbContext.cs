using leticiaViagem.Model;
using Microsoft.EntityFrameworkCore;

namespace leticiaViagem.Database
{
    public class DestinoDbContext : DbContext
    {
        public DestinoDbContext(DbContextOptions<ClienteDbContext>
        options) : base(options){

        }

        public DbSet<Destino> Destinos {get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        var destino = modelBuilder.Entity<Destino>();
        destino.ToTable("destino");
        destino.Property(x => x.id);
        destino.Property(x => x.id).HasColumnName("id").ValueGeneratedOnAdd();
        destino.Property(x => x.pais).HasColumnName("pais").IsRequired();
        destino.Property(x => x.cidade).HasColumnName("cidade");
        destino.Property(x => x.valor).HasColumnName("valor");
    }

    }
    
}

