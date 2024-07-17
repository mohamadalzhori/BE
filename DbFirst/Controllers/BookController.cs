using DbFirst.Models;
using DbFirst.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DbFirst.Controllers
{
    [Route("Book")]
    [ApiController]
    public class BookController : ODataController
    {
        private readonly IBookRepo _bookRepo;

        public BookController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<Book> Get()
        {
            return _bookRepo.GetAll();
        }


    }
}
