﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiAgenda.models;

namespace apiAgenda.Migrations
{
    [DbContext(typeof(EstacaoDbContext))]
    partial class EstacaoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("apiAgenda.models.DadosEnel", b =>
                {
                    b.Property<int>("DadosEnelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("classe");

                    b.Property<string>("endereco");

                    b.Property<int>("estacaoId");

                    b.Property<string>("nome_cliente");

                    b.Property<int>("uc");

                    b.HasKey("DadosEnelId");

                    b.HasIndex("estacaoId")
                        .IsUnique();

                    b.ToTable("DadosEnels");
                });

            modelBuilder.Entity("apiAgenda.models.Estacao", b =>
                {
                    b.Property<int>("estacaoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasMaxLength(50);

                    b.Property<string>("Tipo");

                    b.HasKey("estacaoId");

                    b.ToTable("Estacoes");
                });

            modelBuilder.Entity("apiAgenda.models.Operador", b =>
                {
                    b.Property<int>("OperadorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasMaxLength(50);

                    b.Property<int?>("estacaoId");

                    b.HasKey("OperadorId");

                    b.HasIndex("estacaoId");

                    b.ToTable("Operadores");
                });

            modelBuilder.Entity("apiAgenda.models.Supervisor", b =>
                {
                    b.Property<int>("SupervisorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("area");

                    b.Property<int>("estacaoId");

                    b.Property<string>("nome")
                        .HasMaxLength(50);

                    b.HasKey("SupervisorId");

                    b.HasIndex("estacaoId")
                        .IsUnique();

                    b.ToTable("Supervisores");
                });

            modelBuilder.Entity("apiAgenda.models.Telefone", b =>
                {
                    b.Property<int>("TelefoneId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Fone");

                    b.Property<int?>("OperadorId");

                    b.Property<int?>("SupervisorId");

                    b.Property<int>("tipo");

                    b.HasKey("TelefoneId");

                    b.HasIndex("OperadorId");

                    b.HasIndex("SupervisorId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("apiAgenda.models.DadosEnel", b =>
                {
                    b.HasOne("apiAgenda.models.Estacao", "estacao")
                        .WithOne("dadosEnel")
                        .HasForeignKey("apiAgenda.models.DadosEnel", "estacaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("apiAgenda.models.Operador", b =>
                {
                    b.HasOne("apiAgenda.models.Estacao", "Estacao")
                        .WithMany("operadores")
                        .HasForeignKey("estacaoId");
                });

            modelBuilder.Entity("apiAgenda.models.Supervisor", b =>
                {
                    b.HasOne("apiAgenda.models.Estacao", "Estacao")
                        .WithOne("supervisor")
                        .HasForeignKey("apiAgenda.models.Supervisor", "estacaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("apiAgenda.models.Telefone", b =>
                {
                    b.HasOne("apiAgenda.models.Operador")
                        .WithMany("telefones")
                        .HasForeignKey("OperadorId");

                    b.HasOne("apiAgenda.models.Supervisor")
                        .WithMany("telefones")
                        .HasForeignKey("SupervisorId");
                });
#pragma warning restore 612, 618
        }
    }
}
