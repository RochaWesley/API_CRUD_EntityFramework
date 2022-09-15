using Microsoft.EntityFrameworkCore;
using src.Models;
namespace src.Persistence;

public class DataBaseContext : DbContext
{
    public DataBaseContext
    (
        DbContextOptions<DataBaseContext> options
    ) : base(options)
    {
        
    }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Contrato> Contratos { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
     //   optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;");
    //}

    protected override void OnModelCreating(ModelBuilder builder){
        builder.Entity<Pessoa>(tabela =>{
            tabela.HasKey(e => e.id);
            tabela.HasMany(e => e.contratos)
            .WithOne()
            .HasForeignKey(c => c.PessoaId);
        });

        builder.Entity<Contrato>(e => {
            e.HasKey(e => e.Id);
        });
    }


}