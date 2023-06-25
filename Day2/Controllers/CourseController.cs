using Day2.Models;
using Day2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Day2.Controllers
{
    public class CourseController : Controller
    {
        IDepartmentRepository deptRepository;
        ICourseRepository courseRepository;
        public CourseController(IDepartmentRepository _deptRepository,ICourseRepository _courseRepository)
        {
            deptRepository = _deptRepository;
            courseRepository = _courseRepository;
        }
        public IActionResult testDegree(double minDegree, double degree)
        {
            if (minDegree < degree)
            {
                return Json(true);
            }
            return Json(false);
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(courseRepository.GetAll());
        }
        public IActionResult New()
        {
            ViewData["Dlist"] = deptRepository.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Course course)
        {
            if( ModelState.IsValid) {
                try
                {
                    courseRepository.Insert(course);
                    courseRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.InnerException.Message);
                }
            }
            ViewData["Dlist"] = deptRepository.GetAll();
            return View("new");
        }


        public IActionResult Edit(int id)
        {
            Course  CModel = courseRepository.GetById(id);
            ViewData["DList"] = deptRepository.GetAll();

            return View(CModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course ins, int id)
        {

            if (ModelState.IsValid)
            {
                courseRepository.Update(id, ins);
                courseRepository.Save();

                return RedirectToAction("Index");
            }

            ViewData["DList"] = deptRepository.GetAll();
            return View(ins);
        }
    
    }
}
