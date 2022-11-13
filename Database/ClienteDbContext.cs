using leticiaViagem.Model;
using Microsoft.EntityFrameworkCore;

namespace leticiaViagem.Database
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext>
        options) : base(options){

        }

        public DbSet<Cliente> Clientes {get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        var cliente = modelBuilder.Entity<Cliente>();
        cliente.ToTable("cliente");
        cliente.Property(x => x.id);
        cliente.Property(x => x.id).HasColumnName("id").ValueGeneratedOnAdd();
        cliente.Property(x => x.nome).HasColumnName("nome").IsRequired();
        cliente.Property(x => x.celular).HasColumnName("celular");
        cliente.Property(x => x.email).HasColumnName("email");
    }

    }
    
}

