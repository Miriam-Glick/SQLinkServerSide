using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SqLinkServer.Helpers;

namespace SqLinkServer.DataDB;

public partial class ProjectsContext : DbContext
{
    public ProjectsContext()
    {
    }

    public ProjectsContext(DbContextOptions<ProjectsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Projects");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Project__3214EC07CEBF17BE");

            entity.ToTable("Project");

            entity.Property(e => e.BugsCount).HasColumnName("bugsCount");
            entity.Property(e => e.DurationInDays).HasColumnName("durationInDays");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0759471150");

            entity.ToTable("User");

            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.JoinedAt)
                .HasColumnType("date")
                .HasColumnName("joinedAt");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Team)
                .HasMaxLength(50)
                .HasColumnName("team");
        });
       
        OnModelCreatingPartial(modelBuilder);
        //modelBuilder.Seed();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
