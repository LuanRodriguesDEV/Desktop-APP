﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonowProject.Context;

#nullable disable

namespace MonowProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221129124144_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("MonowProject.Models.Caixa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataFechamento")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("SaldoFinalEmCartoes")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal?>("SaldoFinalEmDinheiro")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("Caixas");
                });

            modelBuilder.Entity("MonowProject.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("MonowProject.Models.Comanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Abertura")
                        .HasColumnType("TEXT");

                    b.Property<int>("CaixaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Codigo")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("decimal(5,2)");

                    b.Property<bool>("Estado")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Fechamento")
                        .HasColumnType("TEXT");

                    b.Property<int>("Mesa")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("Comandas");
                });

            modelBuilder.Entity("MonowProject.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ComandaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("HoraRemovida")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Horas")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsExcluido")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("MonowProject.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsImprimir")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("MonowProject.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "admin",
                            Senha = "admin"
                        });
                });

            modelBuilder.Entity("MonowProject.Models.Pedido", b =>
                {
                    b.HasOne("MonowProject.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("MonowProject.Models.Produto", b =>
                {
                    b.HasOne("MonowProject.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });
#pragma warning restore 612, 618
        }
    }
}
