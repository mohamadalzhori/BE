using DbFirst.Models;

namespace DbFirst.Repo
{
    public interface ILoanRepo
    {
        IQueryable<Loan> GetAll();
    }
}
