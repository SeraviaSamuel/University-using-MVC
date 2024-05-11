using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class InstructorController : Controller
    {
        iTiEntity context = new iTiEntity();
        InstructorBL bl = new InstructorBL();
        public IActionResult Index()
        {
            List<Instructor> instructorsModel = bl.GetAll();
            return View("Index", instructorsModel);
        }
        public IActionResult Details(int id)
        {
            List<Instructor> instructorModel = bl.GetDetails(id);
            return View("Details", instructorModel);
        }
        public IActionResult InsDetails(int id)
        {
            Instructor instructorModel = bl.GetInsDetails(id);
            return View("InsDetails", instructorModel);
        }

        public IActionResult AddNew()
        {
            InstructorWithListOfDeptAndCourse instructorWithListOfDeptAndCourse = new InstructorWithListOfDeptAndCourse();
            instructorWithListOfDeptAndCourse.DeptList = context.Department.ToList();
            instructorWithListOfDeptAndCourse.CrsList = context.Course.ToList();
            return View("AddNew", instructorWithListOfDeptAndCourse);
        }
        public IActionResult SaveNew(InstructorWithListOfDeptAndCourse ins)
        {
            if (ins.Name != null && ins.Image != null && ins.Address != null && ins.Salary != null)
            {
                Instructor instructor = new Instructor();
                instructor.Name = ins.Name;
                instructor.Address = ins.Address;
                instructor.Image = ins.Image;
                instructor.Salary = ins.Salary;
                instructor.CourseId = ins.CourseId;
                instructor.DepartmentId = ins.DepartmentId;
                context.Instructor.Add(instructor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

                ins.DeptList = context.Department.ToList();
                ins.CrsList = context.Course.ToList();
                return View("AddNew", ins);
            }
        }
        public IActionResult Edit(int id)
        {
            //Instructor ins = context.Instructor.FirstOrDefault(i => i.Id == id);
            Instructor ins = context.Instructor.Where(ins => ins.Id == id).FirstOrDefault();
            InstructorWithListOfDeptAndCourse instructor = new InstructorWithListOfDeptAndCourse();
            instructor.Id = ins.Id;
            instructor.Name = ins.Name;
            instructor.Address = ins.Address;
            instructor.Salary = ins.Salary;
            instructor.Image = ins.Image;
            instructor.CourseId = ins.CourseId;
            instructor.DepartmentId = ins.DepartmentId;
            instructor.DeptList = context.Department.ToList();
            instructor.CrsList = context.Course.ToList();
            return View("Edit", instructor);

        }
        public IActionResult SaveEdit(Instructor instructor)
        {
            if (instructor.Name != null && instructor.Address != null && instructor.Salary != null
                && instructor.Salary != null && instructor.CourseId != null && instructor.DepartmentId != null)
            {
                context.Update(instructor);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                InstructorWithListOfDeptAndCourse instructorvm = new InstructorWithListOfDeptAndCourse();
                instructorvm.Id = instructor.Id;
                instructorvm.Name = instructor.Name;
                instructorvm.Address = instructor.Address;
                instructorvm.Salary = instructor.Salary;
                instructorvm.Image = instructor.Image;
                instructorvm.CourseId = instructor.CourseId;
                instructorvm.DepartmentId = instructor.DepartmentId;
                instructorvm.DeptList = context.Department.ToList();
                instructorvm.CrsList = context.Course.ToList();
                return RedirectToAction("Edit", instructorvm);
            }

        }
        public IActionResult GetCoursesByDepartment(int DeptId)
        {
            var courses = context.Course.Where(c => c.DepartmentId == DeptId).ToList();
            return Json(courses);
        }

    }
}
