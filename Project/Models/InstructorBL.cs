using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public class InstructorBL
    {
        iTiEntity context = new iTiEntity();
        public List<Instructor> GetAll()
        {
            List<Instructor> instructors = context.Instructor.ToList();
            return instructors;
        }
        public List<Instructor> GetDetails(int id)
        {
            List<Instructor> instructors = context.Instructor.Where(d => d.DepartmentId == id).ToList();
            return instructors;
        }
        public Instructor GetInsDetails(int id)
        {
            Instructor instructor = context.Instructor
                .Include(d => d.Department)
                .Include(c => c.Course)
                .FirstOrDefault(ins => ins.Id == id);
            return instructor;
        }

    }
}
