﻿// <auto-generated />
using System;
using CalculadoraLaboralBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CalculadoraLaboralBackend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211014193532_foreign key")]
    partial class foreignkey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CalculadoraLaboralBackend.Models.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AreaId");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("CalculadoraLaboralBackend.Models.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("CodigoInterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaDeIngreso")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroDeIndentificacion")
                        .HasColumnType("int");

                    b.Property<int>("Salario")
                        .HasColumnType("int");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("CalculadoraLaboralBackend.Models.Servicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Fk_ColaboradorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cantidadDeHoras")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaDeFinalizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaDeInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("horaDeFinalizacion")
                        .HasColumnType("int");

                    b.Property<int>("horaDeInicio")
                        .HasColumnType("int");

                    b.Property<int>("semanaDelAno")
                        .HasColumnType("int");

                    b.Property<string>("servicioRealizado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tipoDeHora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Servicio");
                });

            modelBuilder.Entity("CalculadoraLaboralBackend.Models.Colaborador", b =>
                {
                    b.HasOne("CalculadoraLaboralBackend.Models.Area", "Area")
                        .WithMany("Colaboradores")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("CalculadoraLaboralBackend.Models.Area", b =>
                {
                    b.Navigation("Colaboradores");
                });
#pragma warning restore 612, 618
        }
    }
}
