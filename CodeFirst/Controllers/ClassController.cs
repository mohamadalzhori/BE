using AutoMapper;
using CodeFirst.Data.ViewModels.Class;
using CodeFirst.Data.ViewModels.Student;
using CodeFirst.Repository.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{
    [Route("Class")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepo _classRepo;
        private readonly IMapper _mapper;
        public ClassController(IClassRepo classRepo, IMapper mapper)
        {
            _classRepo = classRepo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public List<GetClassVM> GetAll()
        {
            return _classRepo.GetAll();
        }


        [HttpGet("GetStudents")]
        public List<GetStudentVM> GetStudents(int classId)
        {
            return _classRepo.GetStudents(classId);
        }
    }
}
