using Lab3.Models;
using Lab3.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    [Route("Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _bookRepo;

        public BookController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }

        [HttpGet("GetAll")]
        public List<Book> GetAll(int year, OrderType orderType)
        {
            return _bookRepo.GetAll(year, orderType);
        }

        [HttpGet("GetTotalNumber")]
        public int GetTotalNumber()
        {
            return _bookRepo.GetTotalNumber();
        }

        [HttpGet("GetPage")]
        public List<Book> GetPage(int page, int pageSize)
        {
            return _bookRepo.GetPage(page, pageSize);
        }        


    }

}
