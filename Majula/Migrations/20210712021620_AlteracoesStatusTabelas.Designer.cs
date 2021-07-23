﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pk.Data;

namespace Pk.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210712021620_AlteracoesStatusTabelas")]
    partial class AlteracoesStatusTabelas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("ArmazenamentoInterno1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArmazenamentoInterno2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cautela")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Memoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessoAquisicao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsavel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Tombamento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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

                    b.Property<string>("Cautela")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destino")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessoAquisicao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Responsavel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("Pk.Models.Monitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComputadorId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tombamento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComputadorId");

                    b.ToTable("Monitores");
                });

            modelBuilder.Entity("Pk.Models.Movimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ComputadorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAtual")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EquipamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Setor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComputadorId");

                    b.HasIndex("EquipamentoId");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("Pk.Models.Monitor", b =>
                {
                    b.HasOne("Pk.Models.Computador", "Computador")
                        .WithMany("Monitores")
                        .HasForeignKey("ComputadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Computador");
                });

            modelBuilder.Entity("Pk.Models.Movimentacao", b =>
                {
                    b.HasOne("Pk.Models.Computador", null)
                        .WithMany("Movimentacoes")
                        .HasForeignKey("ComputadorId");

                    b.HasOne("Pk.Models.Equipamento", null)
                        .WithMany("Movimentacoes")
                        .HasForeignKey("EquipamentoId");
                });

            modelBuilder.Entity("Pk.Models.Computador", b =>
                {
                    b.Navigation("Monitores");

                    b.Navigation("Movimentacoes");
                });

            modelBuilder.Entity("Pk.Models.Equipamento", b =>
                {
                    b.Navigation("Movimentacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
