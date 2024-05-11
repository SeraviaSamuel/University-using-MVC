using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hours { get; set; }

        public List<Instructor>? Instructors { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public List<CrsResult>? CrsResults { get; set; }

    }
}
