using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class TraineeController : Controller
    {
        CourseResultBL bl = new CourseResultBL();
        public IActionResult ShowResult(int id, int crsid)
        {

            CrsResult crsResult = bl.GetCrsResDetails(id, crsid);
            TraineeWithcrsResultSuccesssOrFail traineeWithcrsResultSuccesssOrFail = new TraineeWithcrsResultSuccesssOrFail();
            traineeWithcrsResultSuccesssOrFail.TrnName = crsResult.Trainee.Name;
            traineeWithcrsResultSuccesssOrFail.CrsName = crsResult.Course.Name;
            traineeWithcrsResultSuccesssOrFail.Degree = crsResult.Degree;
            if (crsResult.Degree > crsResult.Course.MinDegree)
            {
                traineeWithcrsResultSuccesssOrFail.Color = "green";
            }
            else
            {
                traineeWithcrsResultSuccesssOrFail.Color = "red";
            }
            return View("ShowResult", traineeWithcrsResultSuccesssOrFail);
        }
        public IActionResult ShowCourseResult(int crsid)
        {
            List<CrsResult> crsResultsForCourse = bl.GetCrsResult(crsid);
            List<TraineeWithcrsResultSuccesssOrFail> courseResults = new List<TraineeWithcrsResultSuccesssOrFail>();

            foreach (var crsResult in crsResultsForCourse)
            {
                TraineeWithcrsResultSuccesssOrFail courseResult = new TraineeWithcrsResultSuccesssOrFail();

                courseResult.TrnName = crsResult.Trainee.Name;
                courseResult.Degree = crsResult.Degree;
                if (crsResult.Degree >= crsResult.Course.MinDegree)
                {
                    courseResult.Color = "green";
                }
                else
                {
                    courseResult.Color = "red";
                }

                courseResults.Add(courseResult);
            }

            return View("ShowCourseResult", courseResults);
        }
        public IActionResult ShowTraineeResult(int id)
        {
            List<CrsResult> courseResults = bl.getTraineeResult(id);
            List<TraineeWithcrsResultSuccesssOrFail> traineeResultVMs = new List<TraineeWithcrsResultSuccesssOrFail>();

            foreach (var item in courseResults)
            {
                TraineeWithcrsResultSuccesssOrFail traineeResultVM = new TraineeWithcrsResultSuccesssOrFail();
                traineeResultVM.TrnName = item.Trainee.Name;
                traineeResultVM.CrsName = item.Course.Name;

                traineeResultVM.Degree = item.Degree;


                if (item.Degree >= item.Course.MinDegree)
                {
                    traineeResultVM.Color = "green";
                }
                else
                {
                    traineeResultVM.Color = "red";
                }

                traineeResultVMs.Add(traineeResultVM);
            }

            return View("ShowTraineeResult", traineeResultVMs);
        }
    }
}
