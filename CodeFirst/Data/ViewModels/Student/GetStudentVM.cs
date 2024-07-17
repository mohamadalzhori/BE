namespace CodeFirst.Data.ViewModels.Student
{
    public class GetStudentVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
