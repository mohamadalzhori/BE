using AutoMapper;
using CodeFirst.Common.Exceptions;
using CodeFirst.Data;
using CodeFirst.Data.Models;
using CodeFirst.Data.ViewModels.Class;
using CodeFirst.Data.ViewModels.Student;
using CodeFirst.Repository.Contracts;

namespace CodeFirst.Repository.Implementations
{
    public class ClassRepo : IClassRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClassRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetClassVM> GetAll()
        {
            return _context.Classes
                .Select(c => _mapper.Map<GetClassVM>(c))
                .ToList();
        }

        public List<GetStudentVM> GetStudents(int classId)
        {
            var classExists = _context.Classes.Any(x => x.Id == classId);

            if (!classExists)
            {
                throw new ClassNotFoundException(classId);
            }

            return _context.Students
                .Where(x => x.ClassId == classId)
                .Select(x => _mapper.Map<GetStudentVM>(x))
                .ToList();
        }

    }
}
