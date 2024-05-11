using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    public class CourseResultBL
    {
        iTiEntity context = new iTiEntity();
        public CrsResult GetCrsResDetails(int id, int crsid)
        {
            CrsResult crsResult = context.CrsResult
                .Include(t => t.Trainee)
                .Include(c => c.Course)
                .FirstOrDefault(r => r.TraineeId == id && r.CourseId == crsid);
            return crsResult;

        }

        public List<CrsResult> GetCrsResult(int courseId)
        {
            List<CrsResult> crsResults = context.CrsResult
                                                     .Include(c => c.Trainee)
                                                     .Include(c => c.Course)
                                                     .Where(c => c.CourseId == courseId)
                                                     .ToList();

            return crsResults;
        }
        public List<CrsResult> getTraineeResult(int Trainid)
        {
            List<CrsResult> crsResults = context.CrsResult
                                                    .Include(t => t.Course)
                                                    .Include(t => t.Trainee)
                                                    .Where(t => t.TraineeId == Trainid)
                                                    .ToList();

            return crsResults;

        }
    }
}
