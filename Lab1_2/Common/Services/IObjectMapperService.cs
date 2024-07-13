using Lab_1.Models;

namespace Lab_1.Common.Services
{
    public interface IObjectMapperService
    {
        public Person MapStudentToPerson(Student student);
        public TDestination Map<TSource, TDestination>(TSource source) where TDestination : new();

    }
}
