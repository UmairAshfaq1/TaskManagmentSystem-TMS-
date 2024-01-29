using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagmentSystem_TMS_.Models;

namespace TaskManagmentSystem_TMS_.Controllers
{
    public class TasksController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Tasks
        public ActionResult Index()
        {
            var noofTasks = dbContext.Tasks.ToList();
            return View(noofTasks);
        }
        public ActionResult CreateTask()
        {
            var Employees = dbContext.employees.ToList();
            var viewModel = new Tasks()
            {
                Employees = Employees
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult CreateTask(Tasks tasks)
        {
            var saveTask = new Tasks
            {
                Title = tasks.Title,
                Description = tasks.Description,
                Priority = tasks.Priority,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1),
                SelectedEmployeeId = tasks.SelectedEmployeeId,
            };
            dbContext.Tasks.Add(saveTask);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}