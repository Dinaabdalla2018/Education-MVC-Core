
using Microsoft.CodeAnalysis.Scripting;
using System.ComponentModel.DataAnnotations;
namespace Day2.Models
{
    public class UniqueNamePerDeptAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            string name = (string)value;
            Course course= validationContext.ObjectInstance as Course;

            DB_Context dB_ = new DB_Context();
            Course courseD = dB_.courses.FirstOrDefault(course => course.Name == name && course.departmentId==course.departmentId);

            if (courseD == null)
                return ValidationResult.Success;
            else if (course.Id == courseD.Id) 
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Course already Found");
        }
    }
}
