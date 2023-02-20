﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(EstacionamentoDB))]
    [Migration("20230220031006_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Carro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("HorarioEntrada")
                        .HasColumnType("datetime2")
                        .HasColumnName("HORARIO_ENTRADA");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("PLACA");

                    b.Property<bool>("TemSaida")
                        .HasColumnType("bit")
                        .HasColumnName("TEM_SAIDA");

                    b.HasKey("ID");

                    b.ToTable("CARROS", (string)null);
                });

            modelBuilder.Entity("Entities.SaidasCarro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CarroID")
                        .HasColumnType("int");

                    b.Property<DateTime>("HorarioSaida")
                        .HasColumnType("datetime2")
                        .HasColumnName("HORARIO_SAIDA");

                    b.Property<double>("Preco")
                        .HasColumnType("float")
                        .HasColumnName("PRECO");

                    b.Property<int>("TempoCobrado")
                        .HasColumnType("int")
                        .HasColumnName("TEMPO_COBRADO");

                    b.Property<string>("TempoFicado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TEMPO_FICADO");

                    b.Property<double>("ValorPagar")
                        .HasColumnType("float")
                        .HasColumnName("TOTAL_PAGO");

                    b.HasKey("ID");

                    b.HasIndex("CarroID");

                    b.ToTable("SAIDA_CARROS", (string)null);
                });

            modelBuilder.Entity("Entities.SaidasCarro", b =>
                {
                    b.HasOne("Entities.Carro", "Carro")
                        .WithMany()
                        .HasForeignKey("CarroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carro");
                });
#pragma warning restore 612, 618
        }
    }
}