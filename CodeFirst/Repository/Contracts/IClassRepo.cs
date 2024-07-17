using CodeFirst.Data.ViewModels.Class;
using CodeFirst.Data.ViewModels.Student;

namespace CodeFirst.Repository.Contracts
{
    public interface IClassRepo
    {
        List<GetStudentVM> GetStudents(int classId);
        List<GetClassVM> GetAll();
    }
}
