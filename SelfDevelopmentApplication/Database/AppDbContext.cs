using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SelfDevelopmentApplication.Models;
using System.IO;

namespace SelfDevelopmentApplication.Database
{
    class AppDbContext : DbContext
    {
        public DbSet<TaskCategoryModel> TasksCategories { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<NoteCategoryModel> NotesCategories { get; set; }
        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<MoodStatusModel> MoodStatuses { get; set; }

        public AppDbContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new SqliteConnectionStringBuilder("Data Source=data.db");
            builder.DataSource = Path.Combine(Directory.GetCurrentDirectory(), builder.DataSource);
            optionsBuilder.UseSqlite(builder.ToString());

            optionsBuilder.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskCategoryModel>()
                        .ToTable("TasksCategories");
            modelBuilder.Entity<TaskCategoryModel>()
                        .HasKey(tc => tc.Id);
            modelBuilder.Entity<TaskCategoryModel>()
                        .Property(tc => tc.Id)
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<TaskCategoryModel>()
                        .Property(tc => tc.Name)
                        .IsRequired()
                        .HasMaxLength(30);

            modelBuilder.Entity<TaskModel>()
                        .ToTable("Tasks");
            modelBuilder.Entity<TaskModel>()
                        .HasKey(t => t.Id);
            modelBuilder.Entity<TaskModel>()
                        .Property(t => t.Id)
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<TaskModel>()
                        .Property(t => t.Name)
                        .IsRequired()
                        .HasMaxLength(30);
            modelBuilder.Entity<TaskModel>()
                        .Property(t => t.Description)
                        .IsRequired(false)
                        .HasMaxLength(1000);
            modelBuilder.Entity<TaskModel>()
                        .Property(t => t.Status)
                        .IsRequired()
                        .HasConversion<int>();
            modelBuilder.Entity<TaskModel>()
                        .Property(t => t.Priority)
                        .IsRequired()
                        .HasConversion<int>();
            modelBuilder.Entity<TaskModel>()
                        .Property(t => t.AssignedDateTime)
                        .IsRequired()
                        .HasConversion<string>();
            modelBuilder.Entity<TaskModel>()
                        .HasOne(t => t.Category)
                        .WithMany(c => c.Tasks)
                        .HasForeignKey(t => t.CategoryId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NoteCategoryModel>()
                        .ToTable("NotesCategories");
            modelBuilder.Entity<NoteCategoryModel>()
                        .HasKey(nc => nc.Id);
            modelBuilder.Entity<NoteCategoryModel>()
                        .Property(nc => nc.Id)
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<NoteCategoryModel>()
                        .Property(nc => nc.Name)
                        .IsRequired()
                        .HasMaxLength(30);

            modelBuilder.Entity<NoteModel>()
                        .ToTable("Notes");
            modelBuilder.Entity<NoteModel>()
                        .HasKey(n => n.Id);
            modelBuilder.Entity<NoteModel>()
                        .Property(n => n.Id)
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<NoteModel>()
                        .Property(n => n.Title)
                        .IsRequired()
                        .HasMaxLength(30);
            modelBuilder.Entity<NoteModel>()
                        .Property(n => n.Content)
                        .IsRequired(false)
                        .HasMaxLength(2000);
            modelBuilder.Entity<NoteModel>()
                        .HasOne(n => n.Category)
                        .WithMany(c => c.Notes)
                        .HasForeignKey(n => n.CategoryId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MoodStatusModel>()
                        .ToTable("MoodStatuses");
            modelBuilder.Entity<MoodStatusModel>()
                        .HasKey(m => m.Id);
            modelBuilder.Entity<MoodStatusModel>()
                        .Property(m => m.Id)
                        .ValueGeneratedOnAdd();
            modelBuilder.Entity<MoodStatusModel>()
                        .Property(m => m.Day)
                        .IsRequired()
                        .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
