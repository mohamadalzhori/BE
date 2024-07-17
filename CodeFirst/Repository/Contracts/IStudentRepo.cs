using CodeFirst.Data.Models;
using CodeFirst.Data.ViewModels;
using CodeFirst.Data.ViewModels.Student;

namespace CodeFirst.Repository.Contracts
{
    public interface IStudentRepo
    {
        void Add(AddStudentVM addStudentVM);
        void Delete(int studentId);
        void EnrollInClass(int studentId, int classId);
        GetStudentVM Get(int studentId);
        List<GetStudentVM> GetAll();

    }
}
