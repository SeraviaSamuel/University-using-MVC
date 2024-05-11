using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class CourseController : Controller
    {
        CourseBL bl = new CourseBL();
        iTiEntity context = new iTiEntity();
        public IActionResult Index()
        {
            List<Course> Courses = bl.GetAll();
            return View("Index", Courses);
        }
        public IActionResult AddNew()
        {
            CourseWithListOfDepartment courseWithListOfDepartmentVM = new CourseWithListOfDepartment();
            courseWithListOfDepartmentVM.DeptList = context.Department.ToList();
            return View("AddNew", courseWithListOfDepartmentVM);
        }
        public IActionResult SaveNew(CourseWithListOfDepartment courseVM)
        {
            if (ModelState.IsValid == true)
            {
                Course c = new Course();
                c.Name = courseVM.Name;
                c.Hours = courseVM.Hours;
                c.MinDegree = courseVM.MinDegree;
                c.Degree = courseVM.Degree;
                c.DepartmentId = courseVM.DepartmentId;
                context.Course.Add(c);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                courseVM.DeptList = context.Department.ToList();
                return View("AddNew", courseVM);
            }
        }
        public IActionResult CancelDelete()
        {
            return RedirectToAction("Index");
        }
        public IActionResult SaveDelete(int id)
        {
            Course courseToDelete = context.Course.FirstOrDefault(c => c.Id == id);
            context.Course.Remove(courseToDelete);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Search(string word)
        {
            if (word != null)
            {
                List<Course> courses = context.Course.Where(c => c.Name.Contains(word)).ToList();
                return View("Index", courses);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Edit(int id)
        {
            Course course = context.Course.FirstOrDefault(c => c.Id == id);
            CourseWithListOfDepartment courseVM = new CourseWithListOfDepartment();
            courseVM.Id = course.Id;
            courseVM.Name = course.Name;
            courseVM.MinDegree = course.MinDegree;
            courseVM.Degree = course.Degree;
            courseVM.Hours = course.Hours;
            courseVM.DepartmentId = course.DepartmentId;
            courseVM.DeptList = context.Department.ToList();
            return View("Edit", courseVM);
        }
        public IActionResult saveupdate(Course course)
        {
            if (ModelState.IsValid == true)
            {
                context.Update(course);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                CourseWithListOfDepartment CourseVM = new CourseWithListOfDepartment();
                CourseVM.Id = course.Id;
                CourseVM.Name = course.Name;
                CourseVM.MinDegree = course.MinDegree;
                CourseVM.Degree = course.Degree;
                CourseVM.Hours = course.Hours;
                CourseVM.DepartmentId = course.DepartmentId;
                CourseVM.DeptList = context.Department.ToList();
                return RedirectToAction("Edit", CourseVM);
            }
        }
        public IActionResult CheckDegree(int Degree, int MinDegree)
        {
            if (Degree < MinDegree)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }
        public IActionResult CheckHours(int Hours)
        {
            if (Hours % 3 == 0)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
