using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SquirrelCannon.Data;

namespace SquirrelCannon.Controllers
{
    public class FlashcardController : Controller
    {
        private readonly FlashcardContext _context;

        public FlashcardController(FlashcardContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var today = DateTime.Today;
            var cards = await _context.Flashcards.ToListAsync();
            var cardsToReview = cards.Where(c =>
                (today - c.LastReview).Days >= GetNextReviewInterval(c.Box));
            return View(cardsToReview);
        }


        [HttpPost]
        public async Task<IActionResult> Review(int id, bool correct)
        {
            var card = await _context.Flashcards.FindAsync(id);
            if (card == null) return NotFound();

            if (correct && card.Box < 5)
                card.Box++;
            else if (!correct)
                card.Box = 1;

            card.LastReview = DateTime.Today;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private int GetNextReviewInterval(int box) => box switch
        {
            1 => 1,
            2 => 2,
            3 => 4,
            4 => 7,
            5 => 14,
            _ => 1
        };
    }

}
