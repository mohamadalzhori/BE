using Lab3.Models;
using Lab3.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    [ApiController]
    [Route("Author")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepo _authorRepo;

        public AuthorController(IAuthorRepo authorRepo)
        {
            _authorRepo = authorRepo;
        }

        [HttpGet("GetSameYear")]
        public List<List<Author>> GetSameYear()
        {
            return _authorRepo.GetSameYear();
        }  
        
         [HttpGet("GetSameYearNCountry")]
        public List<List<Author>> GetSameYearNCountry()
        {
            return _authorRepo.GetSameYearNCountry();
        }  
        

    }
}
