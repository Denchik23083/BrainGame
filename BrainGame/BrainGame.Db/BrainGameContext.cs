﻿using System;
using BrainGame.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrainGame.Db
{
    public class BrainGameContext : DbContext
    {
        public BrainGameContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<Correct> Corrects { get; set; }

        public DbSet<Points> Points { get; set; }
    }
}
