using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagmentSystem_TMS_.Models;

namespace TaskManagmentSystem_TMS_.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult CreateEmployee(Employee employee)
        {

            HttpPostedFileBase pb = Request.Files["ProfilePicture01"];
            return Json("dshfldshf");
        }
    }
}