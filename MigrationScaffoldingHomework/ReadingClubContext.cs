using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MigrationScaffoldingHomework
{
    public partial class ReadingClubContext : DbContext
    {
        public ReadingClubContext()
        {
            Database.Migrate();
        }

        public ReadingClubContext(DbContextOptions<ReadingClubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server = DESKTOP-6543DI3; Database = ReadingClub; Trusted_Connection = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AuthorsId).HasDefaultValueSql("('{B716BDDF-C821-4D89-85ED-F9A159B374A9}')");

                entity.Property(e => e.CategoryId).HasDefaultValueSql("('{F5C65CB9-10CC-44CF-B89B-36756D6B32EA}')");

                entity.Property(e => e.Name).HasDefaultValueSql("('Без названия')");

                entity.HasOne(d => d.Authors)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.AuthorsId)
                    .HasConstraintName("FK_Articles_Authors");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Articles_Category");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasDefaultValueSql("('Аноним')");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasDefaultValueSql("('Общая')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
