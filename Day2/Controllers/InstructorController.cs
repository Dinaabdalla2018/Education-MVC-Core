using Day2.Models;
using Day2.ViewModel;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace Day2.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        DB_Context db =new DB_Context();
        public InstructorController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<Instructor> instructors = db.instructors.ToList();
            return View(instructors);
        }
        public IActionResult Details(int id)
        {
            
            Instructor insModel = db.instructors.FirstOrDefault(x => x.Id == id);
            Instructor_Course_DepartmentViewModel insVM =  new Instructor_Course_DepartmentViewModel();
            insVM.instructor_id = insModel.Id;
            insVM.instructor_name = insModel.Name;
            insVM.instructor_image = insModel.Image;
            insVM.instructor_Address = insModel.address;
            insVM.course = insModel.course;
            insVM.dep = insModel.department;

            return View(insVM);
        }

        public IActionResult GetCourseByDept(int deptId)
        {
            List<Instructor_Course_DepartmentViewModel> course = db.courses.Where(c => c.departmentId == deptId)
                                                                                                                                                     .Select(c => new Instructor_Course_DepartmentViewModel {
                course_id = c.Id,
                course_name = c.Name
            })
        .ToList();
          return Json(course);
        }
        public IActionResult New()
        {

            ViewData["Clist"] = db.courses.ToList();
            ViewData["Dlist"] = db.departments.ToList();
            View();
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Save(Instructor instructor, IFormFile Image)
        {
            if (instructor.Name != null && instructor.salary>6000 && Image != null)
            {
                string filename = Image.FileName;
                filename = Path.GetFileName(filename);

                string uploadFilePath = Path.Combine(_environment.WebRootPath, "images", filename);

                await using var stream = new FileStream(uploadFilePath, FileMode.Create);
                await Image.CopyToAsync(stream);
                db.instructors.Add(new Instructor()
                {
                    Name=instructor.Name,
                    salary=instructor.salary,
                    address=instructor.address,
                    courseId=instructor.courseId,
                    departmentId=instructor.departmentId,
                    Image= filename
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Clist"] = db.courses.ToList();
            ViewData["Dlist"] = db.departments.ToList();
            return View("New", instructor);
            
        }

        public IActionResult Edit(int id)
        {
            Instructor InsModel = db.instructors.FirstOrDefault(i => i.Id == id);
            ViewData["DList"] = db.departments.ToList();
            ViewData["CList"] = db.courses.ToList();

            return View(InsModel);
            
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Instructor ins, int id, IFormFile Image)
        {

            if (ins.Name != null && ins.salary > 6000 )
            {
                Instructor InsModel = db.instructors.FirstOrDefault(i => i.Id == id);
                InsModel.Name    = ins.Name;
                InsModel.address = ins.address;
                InsModel.departmentId = ins.departmentId;
                InsModel.courseId = ins.courseId;
                InsModel.salary      = ins.salary;
                if (Image != null)
                {
                    string filename = Image.FileName;
                    filename = Path.GetFileName(filename);
                    string uploadFilePath = Path.Combine(_environment.WebRootPath, "images", filename);
                    await using var stream = new FileStream(uploadFilePath, FileMode.Create);
                    await Image.CopyToAsync(stream);
                    InsModel.Image = filename;
                }

                db.SaveChanges();
              return  RedirectToAction("Index");
            }

            ViewData["DList"] = db.departments.ToList();
            ViewData["CList"] = db.courses.ToList();
            return View(ins);

        }
        public IActionResult Search(string search)
        {
            var ins = db.instructors.Where(i=>i.Name== search).ToList();
            ViewData["search"] = search;
            return View("index",ins);
        }
    }
}
