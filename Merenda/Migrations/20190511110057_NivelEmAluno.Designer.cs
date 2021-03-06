﻿// <auto-generated />
using System;
using Merenda.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Merenda.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190511110057_NivelEmAluno")]
    partial class NivelEmAluno
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Merenda.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Curso");

                    b.Property<string>("Matricula");

                    b.Property<string>("Nivel");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Merenda.Models.AlunoLanche", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlunoId");

                    b.Property<int>("LancheId");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("LancheId");

                    b.ToTable("AlunoLanche");
                });

            modelBuilder.Entity("Merenda.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("NivelId");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("NivelId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Merenda.Models.Estoque", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("COD");

                    b.Property<string>("Descricao");

                    b.Property<string>("Item");

                    b.Property<int>("QtdEstoque");

                    b.Property<int>("QtdUtilizada");

                    b.Property<double>("Total");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Estoque");
                });

            modelBuilder.Entity("Merenda.Models.Lanche", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("COD_Estoque");

                    b.Property<DateTime>("Dia");

                    b.Property<bool>("Encerrado");

                    b.Property<string>("Turno");

                    b.HasKey("Id");

                    b.ToTable("Lanche");
                });

            modelBuilder.Entity("Merenda.Models.Nivel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Nivels");
                });

            modelBuilder.Entity("Merenda.Models.AlunoLanche", b =>
                {
                    b.HasOne("Merenda.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Merenda.Models.Lanche", "Lanche")
                        .WithMany()
                        .HasForeignKey("LancheId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Merenda.Models.Curso", b =>
                {
                    b.HasOne("Merenda.Models.Nivel", "Nivel")
                        .WithMany("Cursos")
                        .HasForeignKey("NivelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
