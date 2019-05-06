using Microsoft.EntityFrameworkCore;

namespace apiAgenda.models
{
    public class EstacaoDbContext : DbContext
    {
        public EstacaoDbContext(DbContextOptions<EstacaoDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // definição dos nomes das tabelas e varchar
            modelBuilder.Entity<Estacao>().ToTable("Estacoes")
            .Property(x => x.Nome).HasMaxLength(50);
            modelBuilder.Entity<Operador>().ToTable("Operadores")
            .Property(x => x.Nome).HasMaxLength(50);
            modelBuilder.Entity<Supervisor>().ToTable("Supervisores")
            .Property(x => x.nome).HasMaxLength(50);
            modelBuilder.Entity<DadosEnel>().ToTable("DadosEnels");
            modelBuilder.Entity<Telefone>().ToTable("Telefones");

            //relacionamento de um para um
            modelBuilder.Entity<Supervisor>()
            .HasOne(x => x.Estacao)
            .WithOne(p => p.supervisor);

            modelBuilder.Entity<DadosEnel>()
            .HasOne(x => x.estacao)
            .WithOne(p => p.dadosEnel);

            //relacionamento de um para muitos
            modelBuilder.Entity<Operador>()
            .HasOne(x => x.Estacao)
            .WithMany(b => b.operadores)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Operador>()
            .HasMany(tel => tel.telefones)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Supervisor>()
            .HasMany(tel => tel.telefones)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Estacao> Estacao { get; set; }

        public DbSet<Operador> Operador { get; set; }

        public DbSet<Supervisor> Supervisor { get; set; }

        public DbSet<DadosEnel> DadosEnel { get; set; }

        public DbSet<Telefone> telefones { get; set; }
    }
}