using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AtosLibrary.Infrastructure
{
    public class AtosLibraryContext : DbContext
    {
        public AtosLibraryContext(DbContextOptions<AtosLibraryContext> dbContextOptions) : base(dbContextOptions) { }

        public virtual DbSet<ReaderEntity> ReaderList { get; set; }

        public virtual DbSet<BookEntity> BookList { get; set; }

        public virtual DbSet<RecordEntity> RecordLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReaderEntity>()
                .HasMany(e => e.Records)
                .WithOne(e => e.Reader)
                .HasForeignKey(e => e.ReaderId);

            modelBuilder.Entity<BookEntity>()
                .HasMany(e => e.Records)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.BookId);

            modelBuilder.Entity<RecordEntity>()
                .HasOne(e => e.Reader)
                .WithMany(e => e.Records)
                .HasForeignKey(e => e.ReaderId);
            
            modelBuilder.Entity<RecordEntity>()
                .HasOne(e => e.Book)
                .WithMany(e => e.Records)
                .HasForeignKey(e => e.BookId);
        }
    }
}
