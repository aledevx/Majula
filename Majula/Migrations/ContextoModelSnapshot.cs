﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pk.Data;

namespace Pk.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pk.Models.Computador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArmazenamentoInterno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<int>("MemoriaId")
                        .HasColumnType("int");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProcessadorId")
                        .HasColumnType("int");

                    b.Property<string>("Responsavel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tombamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.HasIndex("MemoriaId");

                    b.HasIndex("ModeloId");

                    b.HasIndex("ProcessadorId");

                    b.ToTable("Computadores");
                });

            modelBuilder.Entity("Pk.Models.Equipamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsavel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tombamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("Pk.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("Pk.Models.Memoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Memorias");
                });

            modelBuilder.Entity("Pk.Models.Modelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("Pk.Models.Monitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComputadorId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tombamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComputadorId");

                    b.HasIndex("MarcaId");

                    b.ToTable("Monitores");
                });

            modelBuilder.Entity("Pk.Models.MovimentacaoComputador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("ComputadorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtual")
                        .HasColumnType("datetime2");

                    b.Property<string>("Setor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComputadorId");

                    b.ToTable("MovimentacoesPc");
                });

            modelBuilder.Entity("Pk.Models.MovimentacaoEquipamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAtual")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Setor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EquipamentoId");

                    b.ToTable("MovimentacoesEquipamento");
                });

            modelBuilder.Entity("Pk.Models.MovimentacaoMonitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAtual")
                        .HasColumnType("datetime2");

                    b.Property<int>("MonitorId")
                        .HasColumnType("int");

                    b.Property<string>("Setor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MonitorId");

                    b.ToTable("MovimentacoesMonitor");
                });

            modelBuilder.Entity("Pk.Models.Processador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Processadores");
                });

            modelBuilder.Entity("Pk.Models.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sigla")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("Pk.Models.Computador", b =>
                {
                    b.HasOne("Pk.Models.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pk.Models.Memoria", "Memoria")
                        .WithMany()
                        .HasForeignKey("MemoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pk.Models.Modelo", "Modelo")
                        .WithMany()
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pk.Models.Processador", "Processador")
                        .WithMany()
                        .HasForeignKey("ProcessadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");

                    b.Navigation("Memoria");

                    b.Navigation("Modelo");

                    b.Navigation("Processador");
                });

            modelBuilder.Entity("Pk.Models.Equipamento", b =>
                {
                    b.HasOne("Pk.Models.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("Pk.Models.Monitor", b =>
                {
                    b.HasOne("Pk.Models.Computador", "Computador")
                        .WithMany()
                        .HasForeignKey("ComputadorId");

                    b.HasOne("Pk.Models.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Computador");

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("Pk.Models.MovimentacaoComputador", b =>
                {
                    b.HasOne("Pk.Models.Computador", "Computador")
                        .WithMany("MovimentacoesPc")
                        .HasForeignKey("ComputadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Computador");
                });

            modelBuilder.Entity("Pk.Models.MovimentacaoEquipamento", b =>
                {
                    b.HasOne("Pk.Models.Equipamento", "Equipamento")
                        .WithMany("MovimentacoesEquipamento")
                        .HasForeignKey("EquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("Pk.Models.MovimentacaoMonitor", b =>
                {
                    b.HasOne("Pk.Models.Monitor", "Monitor")
                        .WithMany("MovimentacoesMonitor")
                        .HasForeignKey("MonitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Monitor");
                });

            modelBuilder.Entity("Pk.Models.Computador", b =>
                {
                    b.Navigation("MovimentacoesPc");
                });

            modelBuilder.Entity("Pk.Models.Equipamento", b =>
                {
                    b.Navigation("MovimentacoesEquipamento");
                });

            modelBuilder.Entity("Pk.Models.Monitor", b =>
                {
                    b.Navigation("MovimentacoesMonitor");
                });
#pragma warning restore 612, 618
        }
    }
}
