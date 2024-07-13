using Lab3.Models;
namespace Lab3.Repo
{
    public class BookRepo : IBookRepo
    {
        private List<Book> _books;
        public BookRepo()
        {
           _books = new List<Book>
        {
            new Book { Id = 1, Title = "Pride and Prejudice", AuthorId = 1, Isbn = "9780141439518", PublishedYear = new DateOnly(1800,1, 2) },
            new Book { Id = 2, Title = "Crime and Punishment", AuthorId = 2, Isbn = "9780486415871", PublishedYear = new DateOnly(1800, 1, 9) },
            new Book { Id = 3, Title = "One Hundred Years of Solitude", AuthorId = 3, Isbn = "9780060883287", PublishedYear = new DateOnly(1967, 1, 2) },
            new Book { Id = 4, Title = "Norwegian Wood", AuthorId = 4, Isbn = "9780375704024", PublishedYear = new DateOnly(1987, 1, 2) },
            new Book { Id = 5, Title = "Harry Potter and the Philosopher's Stone", AuthorId = 5, Isbn = "9780590353427", PublishedYear = new DateOnly(1997, 1, 2) }
        };
        }

        public List<Book> GetAll(int year, OrderType orderType)
        {
            var books = _books.Where(x => x.PublishedYear.Year == year);

            if (orderType == OrderType.ASC)
            {
                return books.OrderBy(x => x.PublishedYear).ToList();
            }
            else
            {
                return books.OrderByDescending(x => x.PublishedYear).ToList();
            }
        }

        public List<Book> GetPage(int page, int pageSize)
        {
            return _books.Skip((page - 1)* pageSize).Take(pageSize).ToList();  
        }

        public int GetTotalNumber()
        {
            return _books.Count();
        }
    }
}
