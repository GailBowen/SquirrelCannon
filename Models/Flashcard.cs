namespace SquirrelCannon.Models
{
    public class Flashcard
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Box { get; set; }
        public DateTime LastReview { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }

}
