using DbFirst.Data;
using DbFirst.Models;

namespace DbFirst.Repo
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDbContext _context;

        public BookRepo(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Get(int bookId)
        {
            return _context.Books.Where(x => x.BookId == bookId);
        }

        public IQueryable<Book> GetAll()
        {
            return _context.Books;
        }

        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
    }
}
