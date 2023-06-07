﻿using Back_End.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Back_End.Dados
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<ClientEntityModel> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientEntityModel>(c =>
            {
                c.HasKey(x => x.ClientId);

                c.Property(x => x.Nome);
                c.Property(x => x.Login);
                c.Property(x => x.Senha);

            });

            //modelBuilder.Entity<ClientEntityModel>()
        }

    }
}
