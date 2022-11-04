using Microsoft.EntityFrameworkCore;
using WebComerce.Data.Map;
using WebComerce.Models;

namespace WebComerce.Data;

public class UserDBContext : DbContext
{
    public UserDBContext(DbContextOptions<UserDBContext> options) : base(options)
    {
    }

    public DbSet<UserModel> Usuarios { get; set; }
    public DbSet<ProdutoModel> Produtos { get; set; }
    
    public  DbSet<ProdutoEscolhidoModel> ProdutoEscolhido { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.Property(e => e.id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            
        });
        modelBuilder.Entity<ProdutoModel>(entity =>
        {
            entity.Property(e => e.id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            
        });
        modelBuilder.Entity<ProdutoEscolhidoModel>(entity =>
        {
            entity.Property(e => e.id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            
        });
        
        modelBuilder.ApplyConfiguration(new UserMap());
        base.OnModelCreating(modelBuilder);
    }
}