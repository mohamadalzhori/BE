using Lab_1.Common.Services;
using Lab_1.Models;
using Lab_1.Repo;
using Microsoft.AspNetCore.Mvc;

namespace Lab_1.Controllers
{
    [ApiController]
    [Route("Person")]
    public class PersonController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IObjectMapperService _objectMapperService;

        public PersonController(IStudentRepo studentRepo, IObjectMapperService objectMapperService)
        {
            _studentRepo = studentRepo;
            _objectMapperService = objectMapperService;
        }


        [HttpGet("Get")]
        public Person Get(int Id)
        {
            var student = _studentRepo.Get(Id);

            try
            {
                //var person = _objectMapperService.MapStudentToPerson(student); // Using simple Mapping

                var person = _objectMapperService.Map<Student, Person>(student); // Using Generics

                return person;
            }
            catch (Exception ex)
            {
                //return NotFound(ex.Message);
                return null;
            }

        }
    }
}
