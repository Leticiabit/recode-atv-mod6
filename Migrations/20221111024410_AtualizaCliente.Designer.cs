﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using leticiaViagem.Database;

#nullable disable

namespace viagemLeticia.Migrations
{
    [DbContext(typeof(ClienteDbContext))]
    [Migration("20221111024410_AtualizaCliente")]
    partial class AtualizaCliente
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("leticiaViagem.Model.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("celular")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("celular");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("nome");

                    b.HasKey("id");

                    b.ToTable("cliente", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
