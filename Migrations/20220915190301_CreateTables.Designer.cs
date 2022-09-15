﻿// <auto-generated />
using System;
using Desafio_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Desafio_API.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20220915190301_CreateTables")]
    partial class CreateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Desafio_API.Model.Atendimento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DtAtendimento")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_atendimento");

                    b.Property<int>("EsperaID")
                        .HasColumnType("integer");

                    b.Property<int>("IDEspera")
                        .HasColumnType("integer");

                    b.Property<int>("Mesa")
                        .HasColumnType("integer")
                        .HasColumnName("mesa");

                    b.HasKey("ID");

                    b.HasIndex("EsperaID");

                    b.ToTable("tb_atendimento", (string)null);
                });

            modelBuilder.Entity("Desafio_API.Model.Espera", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DtEmissao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_emissao");

                    b.Property<bool>("StatusPainel")
                        .HasColumnType("boolean")
                        .HasColumnName("status_painel");

                    b.Property<int>("TipoAtendimento")
                        .HasColumnType("integer")
                        .HasColumnName("tipo_atendimento");

                    b.HasKey("ID");

                    b.ToTable("tb_espera", (string)null);
                });

            modelBuilder.Entity("Desafio_API.Model.Atendimento", b =>
                {
                    b.HasOne("Desafio_API.Model.Espera", "Espera")
                        .WithMany("Atendimentos")
                        .HasForeignKey("EsperaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Espera");
                });

            modelBuilder.Entity("Desafio_API.Model.Espera", b =>
                {
                    b.Navigation("Atendimentos");
                });
#pragma warning restore 612, 618
        }
    }
}