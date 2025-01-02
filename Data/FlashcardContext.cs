using Microsoft.EntityFrameworkCore;
using SquirrelCannon.Models;
using System.Collections.Generic;

namespace SquirrelCannon.Data
{
    public class FlashcardContext : DbContext
    {
        public FlashcardContext(DbContextOptions<FlashcardContext> options)
            : base(options)
        {
        }

        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flashcard>()
                .HasOne(f => f.Subject)
                .WithMany()
                .HasForeignKey(f => f.SubjectId);
        }
    }

}
