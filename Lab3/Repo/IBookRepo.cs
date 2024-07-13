using Lab3.Models;

namespace Lab3.Repo
{
    public interface IBookRepo
    {

        List<Book> GetAll(int year, OrderType orderType);
        int GetTotalNumber();
        List<Book> GetPage(int page, int pageSize);

    }
}
