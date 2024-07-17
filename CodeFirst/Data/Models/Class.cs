namespace CodeFirst.Data.Models
{
    public class Class
    {
        public int Id { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Room { get; set; }


        public int? CourseId { get; set; }
        public Course Course { get; set; }



        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }


        public List<Student> Students { get; set; }
    }
}
