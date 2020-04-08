﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using backend.Data;

namespace backend.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20200408224646_AddPatiens")]
    partial class AddPatiens
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("backend.Models.mov_history", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("date")
                        .HasColumnType("int");

                    b.Property<string>("destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("patientsId")
                        .HasColumnType("int");

                    b.Property<int>("time")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("mov_histories");
                });

            modelBuilder.Entity("backend.Models.patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("current_acount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("him")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("more_12h")
                        .HasColumnType("bit");

                    b.Property<int>("sectorId")
                        .HasColumnType("int");

                    b.Property<int>("start")
                        .HasColumnType("int");

                    b.Property<string>("type_bed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ugcc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("years")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            current_acount = "132343413",
                            destination = "",
                            diagnosis = "cod-19",
                            him = "nose que es",
                            more_12h = false,
                            sectorId = 1,
                            start = 0,
                            ugcc = "menos",
                            years = 19
                        },
                        new
                        {
                            Id = 2,
                            current_acount = "98773672",
                            destination = "",
                            diagnosis = "dolor de cabeza",
                            him = "nose que es",
                            more_12h = false,
                            sectorId = 1,
                            start = 0,
                            ugcc = "menos",
                            years = 34
                        },
                        new
                        {
                            Id = 3,
                            current_acount = "32565476",
                            destination = "",
                            diagnosis = "paro cardio respiratorio",
                            him = "nose que es",
                            more_12h = false,
                            sectorId = 3,
                            start = 0,
                            ugcc = "menos",
                            years = 29
                        },
                        new
                        {
                            Id = 4,
                            current_acount = "43536453",
                            destination = "",
                            diagnosis = "corazon roto :c",
                            him = "nose que es",
                            more_12h = false,
                            sectorId = 6,
                            start = 0,
                            ugcc = "menos",
                            years = 33
                        },
                        new
                        {
                            Id = 5,
                            current_acount = "3432355",
                            destination = "",
                            diagnosis = "se pego en el dedo chico del pie",
                            him = "nose que es",
                            more_12h = false,
                            sectorId = 6,
                            start = 0,
                            ugcc = "menos",
                            years = 23
                        },
                        new
                        {
                            Id = 6,
                            current_acount = "4343532",
                            destination = "",
                            diagnosis = "torcedura de tobillo",
                            him = "nose que es",
                            more_12h = false,
                            sectorId = 6,
                            start = 0,
                            ugcc = "menos",
                            years = 73
                        },
                        new
                        {
                            Id = 7,
                            current_acount = "234-134-1341",
                            destination = "",
                            diagnosis = "quemaduras de gravedad",
                            him = "nose que es",
                            more_12h = false,
                            sectorId = 6,
                            start = 0,
                            ugcc = "menos",
                            years = 19
                        },
                        new
                        {
                            Id = 8,
                            current_acount = "213-123-2412",
                            destination = "",
                            diagnosis = "fractura externa sector femur",
                            him = "nose que es",
                            more_12h = false,
                            sectorId = 6,
                            start = 0,
                            ugcc = "menos",
                            years = 19
                        });
                });

            modelBuilder.Entity("backend.Models.report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("date")
                        .HasColumnType("int");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("reports");
                });

            modelBuilder.Entity("backend.Models.sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("num_bed")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("sectors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            color = "rgba(128, 0, 0)",
                            description = "Emergencia Vital",
                            num_bed = 5,
                            title = "Sector C1"
                        },
                        new
                        {
                            Id = 2,
                            color = "rgba(255, 0, 0)",
                            description = "Urgencia / Alta Complejidad",
                            num_bed = 5,
                            title = "Sector C2"
                        },
                        new
                        {
                            Id = 3,
                            color = "rgb(255, 102, 0)",
                            description = "Condicion de Mediana Complejidad",
                            num_bed = 5,
                            title = "Sector C3"
                        },
                        new
                        {
                            Id = 4,
                            color = "rgb(255, 153, 0)",
                            description = "No Urgente / Baja complejidad",
                            num_bed = 5,
                            title = "Sector C4"
                        },
                        new
                        {
                            Id = 5,
                            description = "No Urgente / Atencion General",
                            num_bed = 5,
                            title = "Sector C5"
                        },
                        new
                        {
                            Id = 6,
                            color = "#0f69b4",
                            description = "Paciente en espera",
                            num_bed = 0,
                            title = "Categorización"
                        });
                });

            modelBuilder.Entity("backend.Models.temp_categorization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("categorization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_warning")
                        .HasColumnType("bit");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("temp_categorizations");
                });

            modelBuilder.Entity("backend.Models.user", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name_user")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}