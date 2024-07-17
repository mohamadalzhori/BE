using AutoMapper;
using CodeFirst.Data.Models;
using CodeFirst.Data.ViewModels.Student;
using CodeFirst.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CodeFirst.Controllers
{
    [Route("Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepo studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public List<GetStudentVM> GetAll()
        {
            return _studentRepo.GetAll();
        } 

        [HttpPost("Add")]
        public IActionResult Add(AddStudentVM addStudentVM)
        {
            _studentRepo.Add(addStudentVM);
            return Ok();
        }

        [HttpGet("Get")]
        public GetStudentVM Get(int studentId)
        {

            return _studentRepo.Get(studentId);
        }

        [HttpPost("Enroll")]
        public IActionResult Enroll(int studentId, int classId)
        {

            _studentRepo.EnrollInClass(studentId, classId);

            return Ok();
        }
    }
}
