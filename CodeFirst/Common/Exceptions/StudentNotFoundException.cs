namespace CodeFirst.Common.Exceptions
{
    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(int studentId) : base($"Student with id {studentId} not found")
        {
        }
    }
}
