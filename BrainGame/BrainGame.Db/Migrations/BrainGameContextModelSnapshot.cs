﻿// <auto-generated />
using System;
using BrainGame.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BrainGame.Db.Migrations
{
    [DbContext(typeof(BrainGameContext))]
    partial class BrainGameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BrainGame.Db.Entities.Auth.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Female"
                        });
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Auth.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("Value")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Auth.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("RoleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleType = 0
                        },
                        new
                        {
                            Id = 2,
                            RoleType = 1
                        },
                        new
                        {
                            Id = 3,
                            RoleType = 2
                        });
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Auth.RolePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("PermissionType")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PermissionType = 0,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            PermissionType = 1,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 3,
                            PermissionType = 2,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 4,
                            PermissionType = 3,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 5,
                            PermissionType = 4,
                            RoleId = 1
                        },
                        new
                        {
                            Id = 6,
                            PermissionType = 0,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 7,
                            PermissionType = 1,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 8,
                            PermissionType = 2,
                            RoleId = 2
                        },
                        new
                        {
                            Id = 9,
                            PermissionType = 0,
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Auth.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "god@gmail.com",
                            GenderId = 1,
                            Name = "God",
                            Password = "0000",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Email = "admin@gmail.com",
                            GenderId = 1,
                            Name = "Ted",
                            Password = "0000",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Email = "user@gmail.com",
                            GenderId = 2,
                            Name = "Anna",
                            Password = "0000",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Quiz.Correct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Corrects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CorrectAnswer = "Собака"
                        },
                        new
                        {
                            Id = 2,
                            CorrectAnswer = "Их нет"
                        },
                        new
                        {
                            Id = 3,
                            CorrectAnswer = "Пингвин"
                        },
                        new
                        {
                            Id = 4,
                            CorrectAnswer = "Арахис"
                        },
                        new
                        {
                            Id = 5,
                            CorrectAnswer = "Мухоморы"
                        },
                        new
                        {
                            Id = 6,
                            CorrectAnswer = "Боровик"
                        });
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Quiz.Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CorrectAnswerId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
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

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answers = "Собака,Кошка,Хомяк",
                            CorrectAnswerId = 1,
                            Number = 1,
                            Question = "Кто гавкает?",
                            QuizId = 1
                        },
                        new
                        {
                            Id = 2,
                            Answers = "Лисички,Опята,Мухоморы",
                            CorrectAnswerId = 5,
                            Number = 1,
                            Question = "Какие грибы ядовитые?",
                            QuizId = 3
                        },
                        new
                        {
                            Id = 3,
                            Answers = "Орел,Пингвин,Ворон",
                            CorrectAnswerId = 3,
                            Number = 2,
                            Question = "Какая птица не умеет летать?",
                            QuizId = 1
                        },
                        new
                        {
                            Id = 4,
                            Answers = "Зеленые,Желтые,Их нет",
                            CorrectAnswerId = 2,
                            Number = 1,
                            Question = "Какого цвета листья у деревьев зимой?",
                            QuizId = 2
                        },
                        new
                        {
                            Id = 5,
                            Answers = "Арахис,Фисташки,Грецкие",
                            CorrectAnswerId = 4,
                            Number = 2,
                            Question = "Как называется земляной орех?",
                            QuizId = 2
                        },
                        new
                        {
                            Id = 6,
                            Answers = "Волнушка,Боровик,Лисичка",
                            CorrectAnswerId = 6,
                            Number = 2,
                            Question = "Как еще называют Белый гриб?",
                            QuizId = 3
                        });
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Quiz.Quizzes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Point")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.ToTable("Quizzes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Animals",
                            Point = 0
                        },
                        new
                        {
                            Id = 2,
                            Name = "Plants",
                            Point = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mushrooms",
                            Point = 0
                        });
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Auth.RefreshToken", b =>
                {
                    b.HasOne("BrainGame.Db.Entities.Auth.User", "User")
                        .WithOne("RefreshToken")
                        .HasForeignKey("BrainGame.Db.Entities.Auth.RefreshToken", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Auth.RolePermission", b =>
                {
                    b.HasOne("BrainGame.Db.Entities.Auth.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Auth.User", b =>
                {
                    b.HasOne("BrainGame.Db.Entities.Auth.Gender", "Gender")
                        .WithMany("Users")
                        .HasForeignKey("GenderId");

                    b.HasOne("BrainGame.Db.Entities.Auth.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Gender");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Quiz.Questions", b =>
                {
                    b.HasOne("BrainGame.Db.Entities.Quiz.Correct", "Correct")
                        .WithMany()
                        .HasForeignKey("CorrectAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrainGame.Db.Entities.Quiz.Quizzes", "Quizzes")
                        .WithMany()
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Correct");

                    b.Navigation("Quizzes");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Auth.Gender", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Auth.Role", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("BrainGame.Db.Entities.Auth.User", b =>
                {
                    b.Navigation("RefreshToken");
                });
#pragma warning restore 612, 618
        }
    }
}
