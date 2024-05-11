using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public String Address { get; set; }
        public int Grade { get; set; }
        public List<CrsResult> CrsResults { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
