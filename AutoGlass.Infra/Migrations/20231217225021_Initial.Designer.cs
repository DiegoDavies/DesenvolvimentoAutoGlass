﻿// <auto-generated />
using System;
using AutoGlass.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoGlass.Infra.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20231217225021_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoGlass.Domain.Models.Fornecedor", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Situacao")
                        .HasColumnType("bit");

                    b.HasKey("Codigo");

                    b.ToTable("Fornecedor");

                    b.HasData(
                        new
                        {
                            Codigo = 1,
                            CNPJ = "12775524000133",
                            DataInclusao = new DateTime(2023, 12, 17, 19, 50, 21, 18, DateTimeKind.Local).AddTicks(2088),
                            Descricao = "Fornecedor 1",
                            Situacao = true
                        },
                        new
                        {
                            Codigo = 2,
                            CNPJ = "09809005000134",
                            DataInclusao = new DateTime(2023, 12, 17, 14, 50, 21, 20, DateTimeKind.Local).AddTicks(282),
                            Descricao = "Fornecedor 2",
                            Situacao = true
                        },
                        new
                        {
                            Codigo = 3,
                            CNPJ = "40575582000159",
                            DataInclusao = new DateTime(2023, 12, 16, 19, 50, 21, 20, DateTimeKind.Local).AddTicks(466),
                            Descricao = "Fornecedor 3",
                            Situacao = true
                        },
                        new
                        {
                            Codigo = 4,
                            CNPJ = "27283103000162",
                            DataInclusao = new DateTime(2023, 12, 10, 19, 50, 21, 20, DateTimeKind.Local).AddTicks(488),
                            Descricao = "Fornecedor 4",
                            Situacao = true
                        });
                });

            modelBuilder.Entity("AutoGlass.Domain.Models.Produto", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodigoFornecedor")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFabricacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Situacao")
                        .HasColumnType("bit");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoFornecedor");

                    b.ToTable("Produto");

                    b.HasData(
                        new
                        {
                            Codigo = 1,
                            CodigoFornecedor = 1,
                            DataFabricacao = new DateTime(2023, 10, 20, 20, 40, 10, 0, DateTimeKind.Unspecified),
                            DataInclusao = new DateTime(2023, 12, 17, 19, 50, 21, 30, DateTimeKind.Local).AddTicks(1894),
                            DataValidade = new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Arroz",
                            Situacao = true
                        },
                        new
                        {
                            Codigo = 2,
                            CodigoFornecedor = 2,
                            DataFabricacao = new DateTime(2023, 11, 15, 7, 40, 10, 0, DateTimeKind.Unspecified),
                            DataInclusao = new DateTime(2023, 12, 17, 19, 50, 21, 30, DateTimeKind.Local).AddTicks(2568),
                            DataValidade = new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Descricao = "Coca Cola",
                            Situacao = true
                        });
                });

            modelBuilder.Entity("AutoGlass.Domain.Models.Produto", b =>
                {
                    b.HasOne("AutoGlass.Domain.Models.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("CodigoFornecedor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("AutoGlass.Domain.Models.Fornecedor", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}