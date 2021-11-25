﻿// <auto-generated />
using BrainGame.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BrainGame.Db.Migrations
{
    [DbContext(typeof(BrainGameContext))]
    [Migration("20211125160219_AnimalsPlantsMushrooms")]
    partial class AnimalsPlantsMushrooms
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BrainGame.Db.Entities.AnimalQuestions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CorrectAnswerId")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CorrectAnswerId");

                    b.HasIndex("QuizId");

                    b.ToTable("AnimalQuestions");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Correct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Corrects");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.MushroomsQuestions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CorrectAnswerId")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CorrectAnswerId");

                    b.HasIndex("QuizId");

                    b.ToTable("MushroomsQuestions");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.PlantsQuestions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CorrectAnswerId")
                        .HasColumnType("int");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CorrectAnswerId");

                    b.HasIndex("QuizId");

                    b.ToTable("PlantsQuestions");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Point")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.AnimalQuestions", b =>
                {
                    b.HasOne("BrainGame.Db.Entities.Correct", "Correct")
                        .WithMany()
                        .HasForeignKey("CorrectAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrainGame.Db.Entities.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Correct");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.MushroomsQuestions", b =>
                {
                    b.HasOne("BrainGame.Db.Entities.Correct", "Correct")
                        .WithMany()
                        .HasForeignKey("CorrectAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrainGame.Db.Entities.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Correct");

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.PlantsQuestions", b =>
                {
                    b.HasOne("BrainGame.Db.Entities.Correct", "Correct")
                        .WithMany()
                        .HasForeignKey("CorrectAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrainGame.Db.Entities.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Correct");

                    b.Navigation("Quiz");
                });
#pragma warning restore 612, 618
        }
    }
}
