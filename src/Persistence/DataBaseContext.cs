using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Persistence;

// Criando a classe e importando a classe do DbContext
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Construindo uma entidade
        // Chamando a entidade de tabela
        builder.Entity<Pessoa>(tabela => { 
            // Definindo chave primaria da tabela
            tabela.HasKey(e => e.Id);
            tabela
                .HasMany(e => e.contratos) // Tabela Pessoa recebe vários contratos
                .WithOne() // Pra cada um dos contratos, a pessoa recebe uma chave estrangeira
                .HasForeignKey(c => c.PessoaId); // Indica a chave estrangeira 
        });
        builder.Entity<Contrato>(tabela => {
            tabela.HasKey(e => e.Id);
        });
    } 
}