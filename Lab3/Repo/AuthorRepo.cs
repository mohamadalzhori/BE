using Lab3.Models;

namespace Lab3.Repo
{
    public class AuthorRepo : IAuthorRepo
    {
        private List<Author> _authors;
        public AuthorRepo()
        {
            _authors = new List<Author>
        {
            new Author { Id = 1, Name = "Jane Austen", BirthDate = new DateOnly(1849, 12, 16), Country = "Russia" },
            new Author { Id = 2, Name = "Fyodor Dostoevsky", BirthDate = new DateOnly(1849, 11, 11), Country = "Russia" },
            new Author { Id = 3, Name = "Gabriel García Márquez", BirthDate = new DateOnly(1927, 3, 6), Country = "Colombia" },
            new Author { Id = 4, Name = "Haruki Murakami", BirthDate = new DateOnly(1849, 1, 12), Country = "Japan" },
            new Author { Id = 5, Name = "J.K. Rowling", BirthDate = new DateOnly(1965, 7, 31), Country = "United Kingdom" },
            new Author { Id = 6, Name = "Virginia Woolf", BirthDate = new DateOnly(1882, 1, 25), Country = "United Kingdom" }, // Same birth year as someone below
            new Author { Id = 7, Name = "James Joyce", BirthDate = new DateOnly(1882, 2, 2), Country = "Ireland" }, // Same birth year as Virginia Woolf

            new Author { Id = 8, Name = "Jorge Luis Borges", BirthDate = new DateOnly(1899, 8, 24), Country = "Argentina" },
            new Author { Id = 9, Name = "Federico García Lorca", BirthDate = new DateOnly(1898, 6, 5), Country = "Spain" }, // Same birth year and country as someone below
            new Author { Id = 10,  Name = "Salvador Dalí", BirthDate = new DateOnly(1904, 5, 11), Country = "Spain" }, // Same country as Federico García Lorca

            new Author { Id = 11, Name = "Albert Camus", BirthDate = new DateOnly(1913, 11, 7), Country = "Algeria" },
            new Author { Id = 12, Name = "Simone de Beauvoir", BirthDate = new DateOnly(1908, 1, 9), Country = "France" },
        };
        }

        public List<List<Author>> GetSameYear()
        {
            return _authors
                .GroupBy(x => x.BirthDate.Year)
                .Select(x => x.ToList())
                .ToList();
        }

        public List<List<Author>> GetSameYearNCountry()
        {
            return _authors
                .GroupBy(x => new { x.BirthDate.Year, x.Country })
                .Select(x => x.ToList())
                .ToList();
        }
    }
}
