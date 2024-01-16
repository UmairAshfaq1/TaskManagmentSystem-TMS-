using System;
using System.Collections.Generic;
using System.IO;
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
            //HttpPostedFileBase pb = Request.Files["ProfilePicture"];

            Employee employee1 = new Employee();
            
            var ProfileImage = employee.ProfilePicture;

            if((ProfileImage.FileName != null) && (ProfileImage.ContentLength > 0))
            {
                string ProfileImgExtention = Path.GetExtension(ProfileImage.FileName);
                string[] allowedExtention = { ".jpg", ".png", ".jpeg", ".svg" };

                if (allowedExtention.Contains(ProfileImgExtention))
                {
                    var maxfilesize = 5 * 1024 * 1024; // 5 MB
                    if(ProfileImage.ContentLength > maxfilesize)
                    {
                        return Json("This file is greater than 5MB");
                    }

                    string fileName = Path.GetFileName(ProfileImage.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/Images"),fileName);

                    employee.ProfilePicture.SaveAs(path);


                    employee1.ProfilePicture = path;

                }


            }





            return Json("dshfldshf");
        }
    }
}