using Lab3.Models;

namespace Lab3.Repo
{
    public interface IAuthorRepo
    {

        List<List<Author>> GetSameYear();
        List<List<Author>> GetSameYearNCountry();
    }
}
