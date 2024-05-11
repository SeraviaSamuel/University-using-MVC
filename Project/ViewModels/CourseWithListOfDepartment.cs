using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Project.ViewModels
{
    public class CourseWithListOfDepartment
    {
        public int Id { get; set; }
        [MaxLength(20)]
        [MinLength(2)]
        [Unique]
        public string Name { get; set; }
        [Range(50, 100)]

        public int Degree { get; set; }
        [Remote("CheckDegree", "Course"
            , ErrorMessage = "Min Degree Must Be Less Than Degree", AdditionalFields = "Degree")]
        public int MinDegree { get; set; }
        [Remote("CheckHours", "Course"
            , ErrorMessage = "Course Hours Must be Devided By 3")]
        public int Hours { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public List<Department>? DeptList { get; set; }

    }
}
