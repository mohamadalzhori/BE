using AutoMapper;
using AutoMapper.QueryableExtensions;
using CodeFirst.Common.Exceptions;
using CodeFirst.Data;
using CodeFirst.Data.Models;
using CodeFirst.Data.ViewModels.Student;
using CodeFirst.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Repository.Implementations
{
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public StudentRepo(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(AddStudentVM addStudentVM)
        {
            var student = _mapper.Map<Student>(addStudentVM);
            _context.Students.Add(student);
            _context.SaveChanges();
        }
        public void Delete(int studentId)
        {
            var studentExists = _context.Students.Any(x => x.Id == studentId);

            if (!studentExists)
            {
                throw new StudentNotFoundException(studentId);
            }

            _context.Students.Where(x => x.Id == studentId).ExecuteDelete();
        }
        public void EnrollInClass(int studentId, int classId)
        {
            var studentExists = _context.Students.Any(x => x.Id == studentId);

            if (!studentExists)
            {
                throw new StudentNotFoundException(studentId);
            }

            var classExists = _context.Classes.Any(x => x.Id == classId);

            if (!classExists)
            {
                throw new ClassNotFoundException(classId);
            }

            _context.Students
                .Where(x => x.Id == studentId)
                .ExecuteUpdate(x => x.SetProperty(y => y.ClassId, classId));
        }
        public GetStudentVM Get(int studentId)
        {
            var studentExists = _context.Students.Any(x => x.Id == studentId);

            if (!studentExists)
            {
                throw new StudentNotFoundException(studentId);
            }


            return _context.Students
                .Where(x => x.Id == studentId)
                .ProjectTo<GetStudentVM>(_mapper.ConfigurationProvider)
                .FirstOrDefault();

        }
        public List<GetStudentVM> GetAll()
        {
            return _context.Students
                .ProjectTo<GetStudentVM>(_mapper.ConfigurationProvider)
                .ToList();
        }
    }
}
