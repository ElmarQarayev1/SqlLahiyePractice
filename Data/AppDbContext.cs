﻿using System;
using Core.Entites;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core
{
	public class AppDbContext:DbContext
	{
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=company;User ID=sa; Password=reallyStrongPwd123;TrustServerCertificate=true;");
        }
    }
}

