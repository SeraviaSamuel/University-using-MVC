namespace Project.Models
{
    public class CourseBL
    {
        iTiEntity context = new iTiEntity();
        public List<Course> GetAll()
        {
            List<Course> courses = context.Course.ToList();
            return courses;
        }
    }
}
