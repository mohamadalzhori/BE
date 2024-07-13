using Lab_1.Models;

namespace Lab_1.Repo
{
    public interface IStudentRepo 
    {
        List<Student> GetAll();
        Student Get(int id);
        List<Student> GetByName(string substring);

        void SetName(int id, string name);

        void Delete(int id);
    }
}
