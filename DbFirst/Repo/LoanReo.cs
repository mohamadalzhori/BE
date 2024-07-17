using DbFirst.Data;
using DbFirst.Models;

namespace DbFirst.Repo
{
    public class LoanReo : ILoanRepo
    {
        private readonly AppDbContext _context;

        public LoanReo(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Loan> GetAll()
        {
            return _context.Loans;
        }
    }
}
