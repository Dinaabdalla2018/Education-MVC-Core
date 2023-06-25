using Castle.Core.Resource;
using Day2.Models;
using Day2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Day2.Controllers
{
    public class TraineeController : Controller
    {
        DB_Context db =new DB_Context();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowResult(int TId,int CId)
        {
            
            var Result = (from result in db.results
                        join trainee in db.trainees
                        on result.traineeId equals trainee.Id
                        join course in db.courses
                        on result.courseId equals course.Id
                        where trainee.Id == TId && course.Id== CId
                        select new { trainetName = trainee.Name, CourseName = course.Name,Degree=result.degree }).SingleOrDefault();

            RCourse_Trainee rCourse_Trainee = new RCourse_Trainee()
            {
                TName = Result.trainetName,
                CName = Result.CourseName,
                degree = Result.Degree,
                color = Result.Degree >= 60 ? "green" : "red"
            };
            return View(rCourse_Trainee);
        }
        public IActionResult showCourseResult(int id)
        {
            var Result = (from result in db.results
                          join trainee in db.trainees
                          on result.traineeId equals trainee.Id
                          where result.courseId == id
                          select new { trainetName = trainee.Name, Degree = result.degree,color= result.degree>60?"green":"red" }).ToList();

            return View(Result);
        }

        public IActionResult showTrainResult(int id)
        {
            var Result = (from result in db.results
                          join course in db.courses
                          on result.courseId equals course.Id
                          where result.traineeId == id
                          select new { courseName = course.Name, Degree = result.degree, color = result.degree > 60 ? "green" : "red" }).ToList();

            return View(Result);
        }
    }
}
