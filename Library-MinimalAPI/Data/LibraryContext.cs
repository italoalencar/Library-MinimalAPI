﻿using Library_MinimalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_MinimalAPI.Data;

public class LibraryContext : DbContext
{
    public LibraryContext() { }

    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    public virtual DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(a => a.Id);
        });
    }
}
