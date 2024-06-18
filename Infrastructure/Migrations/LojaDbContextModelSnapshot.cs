﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(LojaDbContext))]
    partial class LojaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("ClientePreferencia", b =>
                {
                    b.Property<Guid>("ClientesId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PreferenciasId")
                        .HasColumnType("TEXT");

                    b.HasKey("ClientesId", "PreferenciasId");

                    b.HasIndex("PreferenciasId");

                    b.ToTable("ClientePreferencia");
                });

            modelBuilder.Entity("Domain.Model.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.ComplexProperty<Dictionary<string, object>>("Telefone", "Domain.Model.Cliente.Telefone#Telefone", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int?>("DDD")
                                .HasColumnType("INTEGER");

                            b1.Property<int?>("Numero")
                                .HasColumnType("INTEGER");
                        });

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Clientes", t =>
                        {
                            t.HasTrigger("Clientes_AfterUpdate");
                        });

                    b.HasAnnotation("UPDATE-TRIGGER-Clientes", "\r\nDROP TRIGGER IF EXISTS Clientes_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Clientes_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Clientes\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Clientes\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");
                });

            modelBuilder.Entity("Domain.Model.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("PedidoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UFId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.ComplexProperty<Dictionary<string, object>>("Cep", "Domain.Model.Endereco.Cep#CEP", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Valor")
                                .HasColumnType("INTEGER");
                        });

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.HasIndex("PedidoId")
                        .IsUnique();

                    b.HasIndex("UFId");

                    b.ToTable("Enderecos", t =>
                        {
                            t.HasTrigger("Enderecos_AfterUpdate");
                        });

                    b.HasAnnotation("UPDATE-TRIGGER-Enderecos", "\r\nDROP TRIGGER IF EXISTS Enderecos_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Enderecos_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Enderecos\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Enderecos\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");
                });

            modelBuilder.Entity("Domain.Model.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.ComplexProperty<Dictionary<string, object>>("Preco", "Domain.Model.Item.Preco#Dinheiro", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Moeda")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<float>("Valor")
                                .HasColumnType("REAL");
                        });

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Itens", null, t =>
                        {
                            t.HasTrigger("Itens_AfterUpdate");
                        });

                    b.HasAnnotation("UPDATE-TRIGGER-Itens", "\r\nDROP TRIGGER IF EXISTS Itens_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Itens_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Itens\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Itens\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");
                });

            modelBuilder.Entity("Domain.Model.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Pedidos", t =>
                        {
                            t.HasTrigger("Pedidos_AfterUpdate");
                        });

                    b.HasAnnotation("UPDATE-TRIGGER-Pedidos", "\r\nDROP TRIGGER IF EXISTS Pedidos_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Pedidos_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Pedidos\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Pedidos\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");
                });

            modelBuilder.Entity("Domain.Model.Preferencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.HasKey("Id");

                    b.HasIndex("Descricao")
                        .IsUnique();

                    b.ToTable("Preferencias", t =>
                        {
                            t.HasTrigger("Preferencias_AfterUpdate");
                        });

                    b.HasAnnotation("UPDATE-TRIGGER-Preferencias", "\r\nDROP TRIGGER IF EXISTS Preferencias_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Preferencias_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Preferencias\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Preferencias\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");
                });

            modelBuilder.Entity("Domain.Model.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.ComplexProperty<Dictionary<string, object>>("CodigoBarras", "Domain.Model.Produto.CodigoBarras#CodigoBarras", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("TEXT");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("Preco", "Domain.Model.Produto.Preco#Dinheiro", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Moeda")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<float>("Valor")
                                .HasColumnType("REAL");
                        });

                    b.HasKey("Id");

                    b.ToTable("Produtos", t =>
                        {
                            t.HasTrigger("Produtos_AfterUpdate");
                        });

                    b.HasAnnotation("UPDATE-TRIGGER-Produtos", "\r\nDROP TRIGGER IF EXISTS Produtos_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Produtos_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Produtos\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Produtos\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");
                });

            modelBuilder.Entity("Domain.Model.UF", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime()");

                    b.HasKey("Id");

                    b.HasIndex("Sigla")
                        .IsUnique();

                    b.ToTable("UFs", t =>
                        {
                            t.HasTrigger("UFs_AfterUpdate");
                        });

                    b.HasAnnotation("UPDATE-TRIGGER-UFs", "\r\nDROP TRIGGER IF EXISTS UFs_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS UFs_AfterUpdate \r\n         AFTER UPDATE\r\n            ON UFs\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE UFs\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");
                });

            modelBuilder.Entity("ClientePreferencia", b =>
                {
                    b.HasOne("Domain.Model.Cliente", null)
                        .WithMany()
                        .HasForeignKey("ClientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.Preferencia", null)
                        .WithMany()
                        .HasForeignKey("PreferenciasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Model.Cliente", b =>
                {
                    b.OwnsOne("Domain.Model.CPF", "CPF", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("TEXT");

                            b1.Property<long>("Valor")
                                .HasColumnType("INTEGER");

                            b1.HasKey("ClienteId");

                            b1.HasIndex("Valor")
                                .IsUnique();

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.Navigation("CPF")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Model.Endereco", b =>
                {
                    b.HasOne("Domain.Model.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("Domain.Model.Endereco", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Model.Pedido", "Pedido")
                        .WithOne("EnderecoEntrega")
                        .HasForeignKey("Domain.Model.Endereco", "PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Model.UF", "UF")
                        .WithMany()
                        .HasForeignKey("UFId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Pedido");

                    b.Navigation("UF");
                });

            modelBuilder.Entity("Domain.Model.Item", b =>
                {
                    b.HasOne("Domain.Model.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Domain.Model.Pedido", b =>
                {
                    b.HasOne("Domain.Model.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Domain.Model.Cliente", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Domain.Model.Pedido", b =>
                {
                    b.Navigation("EnderecoEntrega")
                        .IsRequired();

                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
