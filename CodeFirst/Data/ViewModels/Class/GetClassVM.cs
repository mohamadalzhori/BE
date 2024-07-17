using CodeFirst.Data.Models;

namespace CodeFirst.Data.ViewModels.Class
{
    public class GetClassVM
    {
        public int Id { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string Room { get; set; }
    }
}
