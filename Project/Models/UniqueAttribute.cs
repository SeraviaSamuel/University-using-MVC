using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            iTiEntity context = new iTiEntity();
            string CrsName = value.ToString();
            CourseWithListOfDepartment CrsFromAddRequest = validationContext.ObjectInstance as CourseWithListOfDepartment;
            if (CrsFromAddRequest == null)
            {
                Course CrsFromEditRequest = validationContext.ObjectInstance as Course;
                Course CrsFromDb = context.Course.FirstOrDefault(c => c.Name == CrsName && c.DepartmentId == CrsFromEditRequest.DepartmentId && c.Id != CrsFromEditRequest.Id);
                if (CrsFromDb == null)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("There is Already Course with This Name in The Department");
            }
            else
            {
                Course CrsFromDb = context.Course.FirstOrDefault(c => c.Name == CrsName && c.DepartmentId == CrsFromAddRequest.DepartmentId);
                if (CrsFromDb == null)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("There is Already Course with This Name in The Department");
            }
        }
    }
}
