using Lab_1.Models;

namespace Lab_1.Repo
{
    public class StudentRepo : IStudentRepo
    {
        public List<Student> Students { get; set; }
        public StudentRepo()
        {
            Students = new List<Student>()
            {
                new Student{Id = 1, Name = "Yorgo", Email = "Yorgo@gmail.com", Age = 12},
                new Student{Id = 2, Name = "Charbel", Email = "Charbel@gmail.com", Age = 14},
                new Student{Id = 3, Name = "Kevin", Email = "Kevin@gmail.com", Age = 15},
                new Student{Id = 4, Name = "Roni", Email = "Roni@gmail.com", Age = 11},
            };
        }

        public List<Student> GetAll()
        {
            return Students;
        }

        public Student Get(int id)
        {
            return Students.FirstOrDefault(x=>x.Id == id);
        }

        public List<Student> GetByName(string substring)
        {
            return Students.Where(x => x.Name.Contains(substring)).ToList();
        }

        public void SetName(int id, string name)
        {
            var student = Students.FirstOrDefault(x => x.Id == id);
            if (student is null)
            {
                throw new Exception("Student Not Found");
            }
            else
            {
                student.Name = name;
            }
        }

        public void Delete(int id)
        {
            var student = Students.FirstOrDefault(x=>x.Id == id);

            if(student is null)
            {
                throw new Exception("Student Not Found");
            }
            else
            {
                Students.Remove(student);
            }
        }
    }
}
