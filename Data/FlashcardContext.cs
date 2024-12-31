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
    }

}
