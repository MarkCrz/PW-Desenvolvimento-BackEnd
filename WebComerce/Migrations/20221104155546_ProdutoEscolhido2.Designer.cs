﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebComerce.Data;

#nullable disable

namespace WebComerce.Migrations
{
    [DbContext(typeof(UserDBContext))]
    [Migration("20221104155546_ProdutoEscolhido2")]
    partial class ProdutoEscolhido2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("WebComerce.Models.ProdutoEscolhidoModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("produtoid")
                        .HasColumnType("int");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("produtoid");

                    b.ToTable("ProdutoEscolhido");
                });

            modelBuilder.Entity("WebComerce.Models.ProdutoModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("possuiEstoque")
                        .HasColumnType("int");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.Property<double>("valor")
                        .HasColumnType("double");

                    b.HasKey("id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("WebComerce.Models.UserModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<int>("admin")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebComerce.Models.ProdutoEscolhidoModel", b =>
                {
                    b.HasOne("WebComerce.Models.ProdutoModel", "produto")
                        .WithMany()
                        .HasForeignKey("produtoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("produto");
                });
#pragma warning restore 612, 618
        }
    }
}
