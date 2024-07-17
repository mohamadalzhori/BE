using CodeFirst.Common.Validators;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Data.ViewModels.Student
{
    public class AddStudentVM
    {
        [Length(3, 50)]
        public string FirstName { get; set; }


        [Length(3, 50)]
        public string LastName { get; set; }
        

        [DateRange("1900-01-01", "2021-12-31")]
        public DateOnly DateOfBirth { get; set; }


        [MaxLength(100)]
        public string Address { get; set; }


        [Range(1, int.MaxValue)]
        public int ClassId { get; set; }
    }
}
