using DbFirst.Models;

namespace DbFirst.Repo
{
    public interface IBookRepo
    {
        IQueryable<Book> GetAll();
    }
}
