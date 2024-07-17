using DbFirst.Models;
using DbFirst.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace DbFirst.Controllers
{
    [Route("Loan")]
    [ApiController]
    public class LoanController : ODataController
    {
        private readonly ILoanRepo _loanRepo;

        public LoanController(ILoanRepo loanRepo)
        {
            _loanRepo = loanRepo;
        }


        [HttpGet]
        [EnableQuery]
        public IQueryable<Loan> Get()
        {
            return _loanRepo.GetAll();
        }

    }
}
