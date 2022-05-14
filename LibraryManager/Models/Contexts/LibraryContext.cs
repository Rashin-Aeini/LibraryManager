﻿using LibraryManager.Models.Configurations;
using LibraryManager.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Models.Contexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<LibraryItem> LibraryItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new LibraryItemConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
