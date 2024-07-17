using AutoMapper;
using CodeFirst.Data.Models;
using CodeFirst.Data.ViewModels.Class;
using CodeFirst.Data.ViewModels.Student;

namespace CodeFirst.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, GetStudentVM>();
            CreateMap<AddStudentVM, Student>();

            CreateMap<Class, GetClassVM>();
        }
    }
}
