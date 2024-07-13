namespace Lab3.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string Isbn { get; set; }
        public DateOnly PublishedYear { get; set; }
    }
}
