﻿// <auto-generated />
using System;
using ClinicaOdontologicaPersistencia.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClinicaOdontologicaPersistencia.Migrations
{
    [DbContext(typeof(ConsultorioContext))]
    partial class ConsultorioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClinicaOdontologicaPersistencia.Entidades.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CPFPaciente")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("dataConsulta")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("horaFim")
                        .HasColumnType("time without time zone");

                    b.Property<TimeOnly>("horaInicio")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("ClinicaOdontologicaPersistencia.Entidades.Paciente", b =>
                {
                    b.Property<string>("CPF")
                        .HasColumnType("text");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CPF");

                    b.ToTable("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
