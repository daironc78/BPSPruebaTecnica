﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia.Entidad;

namespace Persistencia.Migrations
{
    [DbContext(typeof(BPSContext))]
    [Migration("20210825184318_IdentityCoreInitial")]
    partial class IdentityCoreInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Models.EstudianteModel", b =>
                {
                    b.Property<Guid>("IdEstudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstudiante");

                    b.ToTable("Estudiante");
                });

            modelBuilder.Entity("Dominio.Models.NotaModel", b =>
                {
                    b.Property<Guid>("IdEstudiante")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProfesor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdNota")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("IdNota");

                    b.ToTable("Nota");
                });

            modelBuilder.Entity("Dominio.Models.ProfesorModel", b =>
                {
                    b.Property<Guid>("IdProfesor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProfesor");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("Dominio.Models.NotaModel", b =>
                {
                    b.HasOne("Dominio.Models.EstudianteModel", "Estudiante")
                        .WithMany("EstudianteLink")
                        .HasForeignKey("IdEstudiante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Models.ProfesorModel", "Profesor")
                        .WithMany("ProfesorLink")
                        .HasForeignKey("IdProfesor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estudiante");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("Dominio.Models.EstudianteModel", b =>
                {
                    b.Navigation("EstudianteLink");
                });

            modelBuilder.Entity("Dominio.Models.ProfesorModel", b =>
                {
                    b.Navigation("ProfesorLink");
                });
#pragma warning restore 612, 618
        }
    }
}