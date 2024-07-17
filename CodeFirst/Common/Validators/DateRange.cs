using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Common.Validators
{
    public class DateRange : ValidationAttribute
    {
        private DateOnly minDate;
        private DateOnly maxDate;
        public DateRange(string minDate, string maxDate)
        {
            this.minDate = DateOnly.Parse(minDate);
            this.maxDate = DateOnly.Parse(maxDate);
        }
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateOnly date)
            {
                if (date < minDate || date > maxDate)
                {
                    return new ValidationResult($"Date must be between {minDate.ToString("yyyy-MM-dd")} and {maxDate.ToString("yyyy-MM-dd")}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
