namespace Project.ViewModels
{
    public class InstructorWithListOfDeptAndCourse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> DeptList { get; set; }
        public List<Course> CrsList { get; set; }
    }
}
